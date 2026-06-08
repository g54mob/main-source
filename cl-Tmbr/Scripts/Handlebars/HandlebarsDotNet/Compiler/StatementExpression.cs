using System;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class StatementExpression : HandlebarsExpression
	{
		public Expression Body { get; }

		public bool IsEscaped { get; }

		public bool TrimBefore { get; }

		public bool TrimAfter { get; }

		public override ExpressionType NodeType => (ExpressionType)6001;

		public override Type Type => Body.Type;

		public StatementExpression(Expression body, bool isEscaped, bool trimBefore, bool trimAfter)
		{
			Body = body;
			IsEscaped = isEscaped;
			TrimBefore = trimBefore;
			TrimAfter = trimAfter;
		}
	}
}
