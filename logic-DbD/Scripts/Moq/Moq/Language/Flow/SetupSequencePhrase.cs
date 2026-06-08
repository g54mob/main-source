using System;
using System.ComponentModel;
using Moq.Behaviors;

namespace Moq.Language.Flow
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class SetupSequencePhrase : ISetupSequentialAction
	{
		private SequenceSetup setup;

		public SetupSequencePhrase(SequenceSetup setup)
		{
			this.setup = setup;
		}

		public ISetupSequentialAction Pass()
		{
			setup.AddBehavior(NoOp.Instance);
			return this;
		}

		public ISetupSequentialAction Throws<TException>() where TException : Exception, new()
		{
			return Throws(new TException());
		}

		public ISetupSequentialAction Throws(Exception exception)
		{
			setup.AddBehavior(new ThrowException(exception));
			return this;
		}

		public ISetupSequentialAction Throws<TException>(Func<TException> exceptionFunction) where TException : Exception
		{
			Guard.NotNull(exceptionFunction, "exceptionFunction");
			setup.AddBehavior(new ThrowComputedException((IInvocation _) => exceptionFunction()));
			return this;
		}

		public override string ToString()
		{
			return setup.Expression.ToStringFixed();
		}
	}
	internal sealed class SetupSequencePhrase<TResult> : ISetupSequentialResult<TResult>
	{
		private SequenceSetup setup;

		public SetupSequencePhrase(SequenceSetup setup)
		{
			this.setup = setup;
		}

		public ISetupSequentialResult<TResult> CallBase()
		{
			setup.AddBehavior(ReturnBase.Instance);
			return this;
		}

		public ISetupSequentialResult<TResult> Returns(TResult value)
		{
			setup.AddBehavior(new ReturnValue(value));
			return this;
		}

		public ISetupSequentialResult<TResult> Returns(Func<TResult> valueFunction)
		{
			Guard.NotNull(valueFunction, "valueFunction");
			if (valueFunction is TResult)
			{
				return Returns((TResult)(object)valueFunction);
			}
			setup.AddBehavior(new ReturnComputedValue((IInvocation _) => valueFunction()));
			return this;
		}

		public ISetupSequentialResult<TResult> Throws(Exception exception)
		{
			setup.AddBehavior(new ThrowException(exception));
			return this;
		}

		public ISetupSequentialResult<TResult> Throws<TException>() where TException : Exception, new()
		{
			return Throws(new TException());
		}

		public ISetupSequentialResult<TResult> Throws<TException>(Func<TException> exceptionFunction) where TException : Exception
		{
			Guard.NotNull(exceptionFunction, "exceptionFunction");
			setup.AddBehavior(new ThrowComputedException((IInvocation _) => exceptionFunction()));
			return this;
		}

		public override string ToString()
		{
			return setup.Expression.ToStringFixed();
		}
	}
}
