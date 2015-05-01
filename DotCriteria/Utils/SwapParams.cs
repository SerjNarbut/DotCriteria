using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotCriteria.Utils
{
    internal class SwapParams : ExpressionVisitor
    {
        private readonly Expression from;
        private readonly Expression to;

        public SwapParams(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }

        public override Expression Visit(Expression node)
        {
            if (node == from)
                return to;
            return base.Visit(node);
        }

        public static Expression ReplaceParam(Expression body, ParameterExpression from, ParameterExpression to)
        {
            return new SwapParams(from, to).Visit(body);
        }
    }
}
