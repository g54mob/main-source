using System;
using System.Linq.Expressions;
using Moq.Async;

namespace Moq
{
	internal abstract class Expectation : IEquatable<Expectation>
	{
		public abstract LambdaExpression Expression { get; }

		public virtual bool HasResultExpression(out IAwaitableFactory awaitableFactory)
		{
			awaitableFactory = null;
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Expectation other)
			{
				return Equals(other);
			}
			return false;
		}

		public abstract bool Equals(Expectation other);

		public abstract override int GetHashCode();

		public abstract bool IsMatch(Invocation invocation);

		public virtual void SetupEvaluatedSuccessfully(Invocation invocation)
		{
		}

		public override string ToString()
		{
			return Expression.ToStringFixed();
		}
	}
}
