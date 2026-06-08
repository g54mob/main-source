using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Moq.Expressions.Visitors
{
	internal sealed class EvaluateCaptures : ExpressionVisitor
	{
		public static readonly ExpressionVisitor Rewriter = new EvaluateCaptures();

		private EvaluateCaptures()
		{
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			if (node.Member is FieldInfo fieldInfo && node.Expression is ConstantExpression constantExpression && node.Member.DeclaringType.IsDefined(typeof(CompilerGeneratedAttribute)))
			{
				return Expression.Constant(fieldInfo.GetValue(constantExpression.Value), node.Type);
			}
			return base.VisitMember(node);
		}

		protected override Expression VisitUnary(UnaryExpression node)
		{
			if (node.NodeType != ExpressionType.Quote)
			{
				return base.VisitUnary(node);
			}
			return node;
		}
	}
}
