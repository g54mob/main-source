using System;
using System.Linq.Expressions;

namespace Moq
{
	internal sealed class DefaultExpressionCompiler : ExpressionCompiler
	{
		public new static readonly DefaultExpressionCompiler Instance = new DefaultExpressionCompiler();

		private DefaultExpressionCompiler()
		{
		}

		public override Delegate Compile(LambdaExpression expression)
		{
			return expression.Compile();
		}

		public override TDelegate Compile<TDelegate>(Expression<TDelegate> expression)
		{
			return expression.Compile();
		}
	}
}
