using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotCriteria.Criterias
{
    public class CacheCriteria<T> : Criteria<T>
    {
        private Func<T, bool> predicate;
        public bool IsCompiled { get; private set; }

        public CacheCriteria(Expression<Func<T, bool>> lambda)
            : base(lambda)
        {
            predicate = null;
            IsCompiled = false;
        }

        public override Func<T, bool> Compile()
        {
            if(!IsCompiled)
            {
                predicate = base.Compile();
                IsCompiled = true;
            }
            return predicate;
        }

        protected override ICriteria<T> Construct(Expression<Func<T, bool>> lambda)
        {
            return new CacheCriteria<T>(lambda);
        }
    }
}
