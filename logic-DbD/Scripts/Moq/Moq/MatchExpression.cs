using System;
using System.Linq.Expressions;

namespace Moq
{
	internal sealed class MatchExpression : Expression
	{
		public readonly Match Match;

		public override ExpressionType NodeType => ExpressionType.Extension;

		public override Type Type => Match.RenderExpression.Type;

		public override bool CanReduce => false;

		public MatchExpression(Match match)
		{
			Match = match;
		}

		protected override Expression VisitChildren(ExpressionVisitor visitor)
		{
			return this;
		}

		public override string ToString()
		{
			return Match.RenderExpression.ToString();
		}
	}
}
