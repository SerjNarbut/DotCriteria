using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotCriteria.Criterias
{
    public class Criteria<T> : ICriteria<T>
    {
        public System.Linq.Expressions.Expression<Func<T, bool>> Lambda { get; private set; }

        public ICriteria<T> Or(ICriteria<T> other)
        {
            throw new NotImplementedException();
        }

        public ICriteria<T> And(ICriteria<T> other)
        {
            throw new NotImplementedException();
        }

        public ICriteria<T> Or(Expression<Func<T, bool>> other)
        {
            throw new NotImplementedException();
        }

        public ICriteria<T> And(Expression<Func<T, bool>> other)
        {
            throw new NotImplementedException();
        }

        public Func<T, bool> Compile()
        {
            return Lambda.Compile();
        }
    }
}
