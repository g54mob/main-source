using System.Linq.Expressions;
using Expressions.Shortcuts;

namespace HandlebarsDotNet.Compiler
{
	internal class BoolishConverter : HandlebarsExpressionVisitor
	{
		private readonly CompilationContext _compilationContext;

		public BoolishConverter(CompilationContext compilationContext)
		{
			_compilationContext = compilationContext;
		}

		protected override Expression VisitBoolishExpression(BoolishExpression bex)
		{
			Expression expression = Visit(bex.Condition);
			expression = FunctionBuilder.Reduce(expression, _compilationContext, out var _);
			ExpressionContainer<object> @object = ExpressionShortcuts.Arg<object>(expression);
			return ExpressionShortcuts.Call(() => HandlebarsUtils.IsTruthyOrNonEmpty(@object));
		}
	}
}
