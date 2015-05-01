using DotCriteria.Criterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCriteria.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> CriteraWhere<T>(this IEnumerable<T> source, ICriteria<T> criteria)
        {
            var predicate = criteria.Compile();
            return source.Where(i => predicate(i));
        }

        public static T CriteraFirst<T>(this IEnumerable<T> source, ICriteria<T> criteria)
        {
            var predicate = criteria.Compile();
            return source.First(i => predicate(i));
        }

        public static bool CriteraAny<T>(this IEnumerable<T> source, ICriteria<T> criteria)
        {
            var predicate = criteria.Compile();
            return source.Any(i => predicate(i));
        }
    }
}
