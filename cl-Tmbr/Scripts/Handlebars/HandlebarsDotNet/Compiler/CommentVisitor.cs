using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class CommentVisitor : HandlebarsExpressionVisitor
	{
		protected override Expression VisitStatementExpression(StatementExpression sex)
		{
			if (sex.Body is CommentExpression)
			{
				return Expression.Empty();
			}
			return sex;
		}
	}
}
