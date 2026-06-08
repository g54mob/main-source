using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class PartialExpression : HandlebarsExpression
	{
		public override ExpressionType NodeType => (ExpressionType)6007;

		public Expression PartialName { get; }

		public Expression Argument { get; }

		public Expression Fallback { get; }

		public PartialExpression(Expression partialName, Expression argument, Expression fallback)
		{
			PartialName = partialName;
			Argument = argument;
			Fallback = fallback;
		}
	}
}
