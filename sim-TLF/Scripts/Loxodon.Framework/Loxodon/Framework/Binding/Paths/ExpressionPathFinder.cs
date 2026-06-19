using System.Collections.Generic;
using System.Linq.Expressions;

namespace Loxodon.Framework.Binding.Paths
{
	public class ExpressionPathFinder : IExpressionPathFinder
	{
		public List<Path> FindPaths(LambdaExpression expression)
		{
			PathExpressionVisitor pathExpressionVisitor = new PathExpressionVisitor();
			pathExpressionVisitor.Visit(expression);
			return pathExpressionVisitor.Paths;
		}
	}
}
