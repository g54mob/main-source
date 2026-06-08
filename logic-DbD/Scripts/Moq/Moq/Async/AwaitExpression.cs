using System;
using System.Linq.Expressions;

namespace Moq.Async
{
	internal sealed class AwaitExpression : Expression
	{
		private readonly IAwaitableFactory awaitableFactory;

		private readonly Expression operand;

		public override bool CanReduce => false;

		public override ExpressionType NodeType => ExpressionType.Extension;

		public Expression Operand => operand;

		public override Type Type => awaitableFactory.ResultType;

		public AwaitExpression(Expression operand, IAwaitableFactory awaitableFactory)
		{
			this.awaitableFactory = awaitableFactory;
			this.operand = operand;
		}

		public override string ToString()
		{
			if (!(awaitableFactory.ResultType == typeof(void)))
			{
				return $"(await {operand})";
			}
			return $"await {operand}";
		}

		protected override Expression VisitChildren(ExpressionVisitor visitor)
		{
			return this;
		}
	}
}
