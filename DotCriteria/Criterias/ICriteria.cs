using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotCriteria.Criterias
{
    public interface ICriteria<T>
    {
        Expression<Func<T, bool>> Lambda { get; }

        ICriteria<T> Or(ICriteria<T> other);
        ICriteria<T> And(ICriteria<T> other);

        ICriteria<T> Or(Expression<Func<T, bool>> other);
        ICriteria<T> And(Expression<Func<T, bool>> other);

        Func<T, bool> Compile();
    }
}
