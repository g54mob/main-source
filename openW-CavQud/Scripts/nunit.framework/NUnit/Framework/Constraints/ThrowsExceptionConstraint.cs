using System;
using System.Threading.Tasks;
using NUnit.Framework.Internal;

namespace NUnit.Framework.Constraints
{
	public class ThrowsExceptionConstraint : Constraint
	{
		private class ThrowsExceptionConstraintResult : ConstraintResult
		{
			public ThrowsExceptionConstraintResult(ThrowsExceptionConstraint constraint, Exception caughtException)
				: base(constraint, caughtException, caughtException != null)
			{
			}

			public override void WriteActualValueTo(MessageWriter writer)
			{
				if (base.Status == ConstraintStatus.Failure)
				{
					writer.Write("no exception thrown");
				}
				else
				{
					base.WriteActualValueTo(writer);
				}
			}
		}

		public override string Description => "an exception to be thrown";

		public override ConstraintResult ApplyTo(object actual)
		{
			TestDelegate testDelegate = actual as TestDelegate;
			Exception caughtException = null;
			if (testDelegate != null)
			{
				try
				{
					testDelegate();
				}
				catch (Exception ex)
				{
					caughtException = ex;
				}
			}
			AsyncTestDelegate asyncTestDelegate = actual as AsyncTestDelegate;
			if (asyncTestDelegate != null)
			{
				using AsyncInvocationRegion asyncInvocationRegion = AsyncInvocationRegion.Create(asyncTestDelegate);
				try
				{
					Task invocationResult = asyncTestDelegate();
					asyncInvocationRegion.WaitForPendingOperationsToComplete(invocationResult);
				}
				catch (Exception ex2)
				{
					caughtException = ex2;
				}
			}
			if (testDelegate == null && asyncTestDelegate == null)
			{
				throw new ArgumentException($"The actual value must be a TestDelegate or AsyncTestDelegate but was {actual.GetType().Name}", "actual");
			}
			return new ThrowsExceptionConstraintResult(this, caughtException);
		}

		protected override object GetTestObject<TActual>(ActualValueDelegate<TActual> del)
		{
			return (TestDelegate)delegate
			{
				del();
			};
		}
	}
}
