using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Moq.Async;

namespace Moq
{
	internal abstract class Setup : ISetup
	{
		[Flags]
		private enum Flags : byte
		{
			Matched = 1,
			Overridden = 2,
			Verifiable = 4
		}

		private readonly Expectation expectation;

		private readonly Expression originalExpression;

		private readonly Mock mock;

		private Flags flags;

		public virtual Condition Condition => null;

		public Expectation Expectation => expectation;

		public LambdaExpression Expression => expectation.Expression;

		Mock ISetup.InnerMock => InnerMocks.SingleOrDefault();

		public virtual IEnumerable<Mock> InnerMocks => Enumerable.Empty<Mock>();

		public bool IsConditional => Condition != null;

		public bool IsOverridden => (flags & Flags.Overridden) != 0;

		public bool IsVerifiable => (flags & Flags.Verifiable) != 0;

		public Mock Mock => mock;

		public Expression OriginalExpression => originalExpression;

		public bool IsMatched => (flags & Flags.Matched) != 0;

		protected Setup(Expression originalExpression, Mock mock, Expectation expectation)
		{
			this.originalExpression = originalExpression;
			this.expectation = expectation;
			this.mock = mock;
		}

		public void Execute(Invocation invocation)
		{
			flags |= Flags.Matched;
			invocation.MarkAsMatchedBy(this);
			SetOutParameters(invocation);
			Condition?.SetupEvaluatedSuccessfully();
			expectation.SetupEvaluatedSuccessfully(invocation);
			if (expectation.HasResultExpression(out IAwaitableFactory awaitableFactory))
			{
				try
				{
					ExecuteCore(invocation);
					return;
				}
				catch (Exception exception)
				{
					invocation.Exception = exception;
					return;
				}
				finally
				{
					invocation.ConvertResultToAwaitable(awaitableFactory);
				}
			}
			ExecuteCore(invocation);
		}

		protected abstract void ExecuteCore(Invocation invocation);

		public void MarkAsOverridden()
		{
			flags |= Flags.Overridden;
		}

		public void MarkAsVerifiable()
		{
			flags |= Flags.Verifiable;
		}

		public bool Matches(Invocation invocation)
		{
			if (expectation.IsMatch(invocation))
			{
				if (Condition != null)
				{
					return Condition.IsTrue;
				}
				return true;
			}
			return false;
		}

		public bool Matches(MethodExpectation expectation)
		{
			return this.expectation.Equals(expectation);
		}

		public virtual void SetOutParameters(Invocation invocation)
		{
		}

		public override string ToString()
		{
			LambdaExpression expression = expectation.Expression;
			Type type = expression.Parameters[0].Type;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendNameOf(type).Append(' ').Append(expression.PartialMatcherAwareEval().ToStringFixed());
			return stringBuilder.ToString();
		}

		internal void Verify(bool recursive, Func<ISetup, bool> predicate, HashSet<Mock> verifiedMocks)
		{
			VerifySelf();
			if (!recursive)
			{
				return;
			}
			try
			{
				foreach (Mock innerMock in InnerMocks)
				{
					innerMock.Verify(predicate, verifiedMocks);
				}
			}
			catch (MockException ex) when (ex.IsVerificationError)
			{
				throw MockException.FromInnerMockOf(this, ex);
			}
		}

		protected virtual void VerifySelf()
		{
			if (!IsMatched)
			{
				throw MockException.UnmatchedSetup(this);
			}
		}

		public void Reset()
		{
			flags &= ~Flags.Matched;
			ResetCore();
		}

		protected virtual void ResetCore()
		{
		}

		public void Verify(bool recursive = true)
		{
			Verify(recursive, (ISetup setup) => setup.IsVerifiable);
		}

		public void VerifyAll()
		{
			Verify(recursive: true, (ISetup setup) => true);
		}

		private void Verify(bool recursive, Func<ISetup, bool> predicate)
		{
			HashSet<Mock> verifiedMocks = new HashSet<Mock>();
			foreach (Invocation mutableInvocation in mock.MutableInvocations)
			{
				mutableInvocation.MarkAsVerifiedIfMatchedBy((Setup setup) => setup == this);
			}
			Verify(recursive, predicate, verifiedMocks);
		}

		protected static Mock TryGetInnerMockFrom(object returnValue)
		{
			return (Awaitable.TryGetResultRecursive(returnValue) as IMocked)?.Mock;
		}
	}
}
