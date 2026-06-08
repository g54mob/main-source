using System;
using System.Linq.Expressions;
using HandlebarsDotNet.Compiler;

namespace HandlebarsDotNet
{
	internal class SubExpressionExpression : HandlebarsExpression
	{
		private readonly Expression _expression;

		public override Type Type => typeof(object);

		public Expression Expression => _expression;

		public override ExpressionType NodeType => (ExpressionType)6009;

		public SubExpressionExpression(Expression expression)
		{
			_expression = expression;
		}
	}
}
