using DotCriteria.Utils;
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

        public Criteria(Expression<Func<T, bool>> lambda)
        {
            this.Lambda = lambda;
        }

        public virtual ICriteria<T> Or(ICriteria<T> other)
        {
            return Or(other.Lambda);
        }

        public virtual ICriteria<T> And(ICriteria<T> other)
        {
            return And(other.Lambda);
        }

        public virtual ICriteria<T> Or(Expression<Func<T, bool>> other)
        {
            var paramOne = Lambda.Parameters[0];
            var paramTwo = other.Parameters[0];

            var newLambda = Expression.Lambda<Func<T, bool>>(Expression.OrElse(
                Lambda.Body,
                SwapParams.ReplaceParam(other.Body, paramTwo, paramOne)
                ), Lambda.Parameters);
            return new Criteria<T>(newLambda);
        }

        public virtual ICriteria<T> And(Expression<Func<T, bool>> other)
        {
            var paramOne = Lambda.Parameters[0];
            var paramTwo = other.Parameters[0];

            var newLambda = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(
                Lambda.Body,
                SwapParams.ReplaceParam(other.Body, paramTwo, paramOne)
                ), Lambda.Parameters);
            return new Criteria<T>(newLambda);
        }

        public virtual Func<T, bool> Compile()
        {
            return Lambda.Compile();
        }
    }
}
