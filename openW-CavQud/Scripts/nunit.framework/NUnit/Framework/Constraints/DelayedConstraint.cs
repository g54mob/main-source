using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework.Internal;

namespace NUnit.Framework.Constraints
{
	public class DelayedConstraint : PrefixConstraint
	{
		private readonly int delayInMilliseconds;

		private readonly int pollingInterval;

		public override string Description => $"{base.BaseConstraint.Description} after {delayInMilliseconds} millisecond delay";

		public DelayedConstraint(IConstraint baseConstraint, int delayInMilliseconds)
			: this(baseConstraint, delayInMilliseconds, 0)
		{
		}

		public DelayedConstraint(IConstraint baseConstraint, int delayInMilliseconds, int pollingInterval)
			: base(baseConstraint)
		{
			if (delayInMilliseconds < 0)
			{
				throw new ArgumentException("Cannot check a condition in the past", "delayInMilliseconds");
			}
			this.delayInMilliseconds = delayInMilliseconds;
			this.pollingInterval = pollingInterval;
		}

		public override ConstraintResult ApplyTo(object actual)
		{
			long timestamp = Stopwatch.GetTimestamp();
			long num = TimestampOffset(timestamp, TimeSpan.FromMilliseconds(delayInMilliseconds));
			if (pollingInterval > 0)
			{
				long num2 = TimestampOffset(timestamp, TimeSpan.FromMilliseconds(pollingInterval));
				while ((timestamp = Stopwatch.GetTimestamp()) < num)
				{
					if (num2 > timestamp)
					{
						Thread.Sleep((int)TimestampDiff((num < num2) ? num : num2, timestamp).TotalMilliseconds);
					}
					num2 = TimestampOffset(timestamp, TimeSpan.FromMilliseconds(pollingInterval));
					if (base.BaseConstraint.ApplyTo(actual).IsSuccess)
					{
						return new ConstraintResult(this, actual, isSuccess: true);
					}
				}
			}
			if ((timestamp = Stopwatch.GetTimestamp()) < num)
			{
				Thread.Sleep((int)TimestampDiff(num, timestamp).TotalMilliseconds);
			}
			return new ConstraintResult(this, actual, base.BaseConstraint.ApplyTo(actual).IsSuccess);
		}

		public override ConstraintResult ApplyTo<TActual>(ActualValueDelegate<TActual> del)
		{
			long timestamp = Stopwatch.GetTimestamp();
			long num = TimestampOffset(timestamp, TimeSpan.FromMilliseconds(delayInMilliseconds));
			object obj;
			if (pollingInterval > 0)
			{
				long num2 = TimestampOffset(timestamp, TimeSpan.FromMilliseconds(pollingInterval));
				while ((timestamp = Stopwatch.GetTimestamp()) < num)
				{
					if (num2 > timestamp)
					{
						Thread.Sleep((int)TimestampDiff((num < num2) ? num : num2, timestamp).TotalMilliseconds);
					}
					num2 = TimestampOffset(timestamp, TimeSpan.FromMilliseconds(pollingInterval));
					obj = InvokeDelegate(del);
					try
					{
						if (base.BaseConstraint.ApplyTo(obj).IsSuccess)
						{
							return new ConstraintResult(this, obj, isSuccess: true);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			if ((timestamp = Stopwatch.GetTimestamp()) < num)
			{
				Thread.Sleep((int)TimestampDiff(num, timestamp).TotalMilliseconds);
			}
			obj = InvokeDelegate(del);
			return new ConstraintResult(this, obj, base.BaseConstraint.ApplyTo(obj).IsSuccess);
		}

		private static object InvokeDelegate<T>(ActualValueDelegate<T> del)
		{
			if (AsyncInvocationRegion.IsAsyncOperation(del))
			{
				using (AsyncInvocationRegion asyncInvocationRegion = AsyncInvocationRegion.Create(del))
				{
					return asyncInvocationRegion.WaitForPendingOperationsToComplete(del());
				}
			}
			return del();
		}

		public override ConstraintResult ApplyTo<TActual>(ref TActual actual)
		{
			long timestamp = Stopwatch.GetTimestamp();
			long num = TimestampOffset(timestamp, TimeSpan.FromMilliseconds(delayInMilliseconds));
			if (pollingInterval > 0)
			{
				long num2 = TimestampOffset(timestamp, TimeSpan.FromMilliseconds(pollingInterval));
				while ((timestamp = Stopwatch.GetTimestamp()) < num)
				{
					if (num2 > timestamp)
					{
						Thread.Sleep((int)TimestampDiff((num < num2) ? num : num2, timestamp).TotalMilliseconds);
					}
					num2 = TimestampOffset(timestamp, TimeSpan.FromMilliseconds(pollingInterval));
					try
					{
						if (base.BaseConstraint.ApplyTo(actual).IsSuccess)
						{
							return new ConstraintResult(this, actual, isSuccess: true);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			if ((timestamp = Stopwatch.GetTimestamp()) < num)
			{
				Thread.Sleep((int)TimestampDiff(num, timestamp).TotalMilliseconds);
			}
			return new ConstraintResult(this, actual, base.BaseConstraint.ApplyTo(actual).IsSuccess);
		}

		protected override string GetStringRepresentation()
		{
			return $"<after {delayInMilliseconds} {base.BaseConstraint}>";
		}

		private static long TimestampOffset(long timestamp, TimeSpan offset)
		{
			return timestamp + (long)(offset.TotalSeconds * (double)Stopwatch.Frequency);
		}

		private static TimeSpan TimestampDiff(long timestamp1, long timestamp2)
		{
			return TimeSpan.FromSeconds((double)(timestamp1 - timestamp2) / (double)Stopwatch.Frequency);
		}
	}
}
