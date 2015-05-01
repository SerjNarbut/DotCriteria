using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotCriteria.Criterias;

namespace DotCriteriaTests
{
    [TestClass]
    public class CriteriaTest
    {
        [TestMethod]
        public void SimpeCriteriaTest()
        {
            int a = 10;
            ICriteria<int> criteria = new Criteria<int>(i => i > 10);
            Assert.IsFalse(criteria.Compile()(a));

            ICriteria<int> criteriaOk = new Criteria<int>(i => i == 10);
            Assert.IsTrue(criteriaOk.Compile()(a));
        }

        [TestMethod]
        public void CriteriaOrTest()
        {
            int a = 8;
            ICriteria<int> criteria = new Criteria<int>(i => i > 10).Or(i => i % 2 == 0);
            Assert.IsTrue(criteria.Compile()(a));

            //test different params name
            ICriteria<int> criteria2 = new Criteria<int>(j => j > 10).Or(z => z % 2 == 0);
            Assert.IsTrue(criteria2.Compile()(a));
        }

        [TestMethod]
        public void CriteriaAndTest()
        {
            int a = 8;
            ICriteria<int> criteria = new Criteria<int>(i => i < 10).And(i => i % 2 == 0);
            Assert.IsTrue(criteria.Compile()(a));

            //test different params name
            ICriteria<int> criteria2 = new Criteria<int>(j => j < 10).And(z => z % 2 == 0);
            Assert.IsTrue(criteria2.Compile()(a));
        }

        [TestMethod]
        public void HardCriteriaTest()
        {
            int a = 8;
            ICriteria<int> criteria = new Criteria<int>(i => i > 10).And( i => i % 2 == 0).Or( i => i == 8);
            Assert.IsTrue(criteria.Compile()(a));

            //test different params name
            ICriteria<int> criteria2 = new Criteria<int>(i => i > 10).And(j => j % 2 == 0).Or(k => k == 8);
            Assert.IsTrue(criteria2.Compile()(a));
        }

        [TestMethod]
        public void CaheCriteriaTest()
        {
            int a = 8;
            ICriteria<int> criteria = new CacheCriteria<int>(i => i > 10).And(i => i % 2 == 0).Or(i => i == 8);
            Assert.IsTrue(criteria.Compile()(a));
            Assert.IsTrue((criteria as CacheCriteria<int>).IsCompiled);

        }
    }
}
