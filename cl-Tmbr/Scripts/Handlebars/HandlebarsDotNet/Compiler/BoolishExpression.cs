using System;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class BoolishExpression : HandlebarsExpression
	{
		public new Expression Condition { get; }

		public override ExpressionType NodeType => (ExpressionType)6008;

		public override Type Type => typeof(bool);

		public BoolishExpression(Expression condition)
		{
			Condition = condition;
		}
	}
}
