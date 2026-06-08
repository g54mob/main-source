using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class CommentExpression : HandlebarsExpression
	{
		public string Value { get; }

		public override ExpressionType NodeType => (ExpressionType)6012;

		public CommentExpression(string value)
		{
			Value = value;
		}
	}
}
