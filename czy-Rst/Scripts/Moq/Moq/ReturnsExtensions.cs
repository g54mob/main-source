using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Moq.Language;
using Moq.Language.Flow;
using Moq.Properties;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ReturnsExtensions
	{
		private static readonly Random Random = new Random();

		public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, TResult value) where TMock : class
		{
			return mock.ReturnsAsync(() => value);
		}

		public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, ValueTask<TResult>> mock, TResult value) where TMock : class
		{
			return mock.ReturnsAsync(() => value);
		}

		public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, Func<TResult> valueFunction) where TMock : class
		{
			if (IsNullResult(valueFunction, typeof(TResult)))
			{
				return mock.ReturnsAsync(() => default(TResult));
			}
			return mock.Returns(() => Task.FromResult(valueFunction()));
		}

		public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, ValueTask<TResult>> mock, Func<TResult> valueFunction) where TMock : class
		{
			if (IsNullResult(valueFunction, typeof(TResult)))
			{
				return mock.ReturnsAsync(() => default(TResult));
			}
			return mock.Returns(() => new ValueTask<TResult>(valueFunction()));
		}

		public static IReturnsResult<TMock> ThrowsAsync<TMock>(this IReturns<TMock, Task> mock, Exception exception) where TMock : class
		{
			return mock.Returns(delegate
			{
				TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
				taskCompletionSource.SetException(exception);
				return taskCompletionSource.Task;
			});
		}

		public static IReturnsResult<TMock> ThrowsAsync<TMock>(this IReturns<TMock, ValueTask> mock, Exception exception) where TMock : class
		{
			return mock.Returns(delegate
			{
				TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
				taskCompletionSource.SetException(exception);
				return new ValueTask(taskCompletionSource.Task);
			});
		}

		public static IReturnsResult<TMock> ThrowsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, Exception exception) where TMock : class
		{
			return mock.Returns(delegate
			{
				TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
				taskCompletionSource.SetException(exception);
				return taskCompletionSource.Task;
			});
		}

		public static IReturnsResult<TMock> ThrowsAsync<TMock, TResult>(this IReturns<TMock, ValueTask<TResult>> mock, Exception exception) where TMock : class
		{
			return mock.Returns(delegate
			{
				TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
				taskCompletionSource.SetException(exception);
				return new ValueTask<TResult>(taskCompletionSource.Task);
			});
		}

		public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, TResult value, TimeSpan delay) where TMock : class
		{
			return DelayedResult(mock, value, delay);
		}

		public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, ValueTask<TResult>> mock, TResult value, TimeSpan delay) where TMock : class
		{
			return DelayedResult(mock, value, delay);
		}

		public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, TResult value, TimeSpan minDelay, TimeSpan maxDelay) where TMock : class
		{
			TimeSpan delay = GetDelay(minDelay, maxDelay, Random);
			return DelayedResult(mock, value, delay);
		}

		public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, ValueTask<TResult>> mock, TResult value, TimeSpan minDelay, TimeSpan maxDelay) where TMock : class
		{
			TimeSpan delay = GetDelay(minDelay, maxDelay, Random);
			return DelayedResult(mock, value, delay);
		}

		public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, TResult value, TimeSpan minDelay, TimeSpan maxDelay, Random random) where TMock : class
		{
			if (random == null)
			{
				throw new ArgumentNullException("random");
			}
			TimeSpan delay = GetDelay(minDelay, maxDelay, random);
			return DelayedResult(mock, value, delay);
		}

		public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(this IReturns<TMock, ValueTask<TResult>> mock, TResult value, TimeSpan minDelay, TimeSpan maxDelay, Random random) where TMock : class
		{
			if (random == null)
			{
				throw new ArgumentNullException("random");
			}
			TimeSpan delay = GetDelay(minDelay, maxDelay, random);
			return DelayedResult(mock, value, delay);
		}

		public static IReturnsResult<TMock> ThrowsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, Exception exception, TimeSpan delay) where TMock : class
		{
			return DelayedException(mock, exception, delay);
		}

		public static IReturnsResult<TMock> ThrowsAsync<TMock, TResult>(this IReturns<TMock, ValueTask<TResult>> mock, Exception exception, TimeSpan delay) where TMock : class
		{
			return DelayedException(mock, exception, delay);
		}

		public static IReturnsResult<TMock> ThrowsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, Exception exception, TimeSpan minDelay, TimeSpan maxDelay) where TMock : class
		{
			TimeSpan delay = GetDelay(minDelay, maxDelay, Random);
			return DelayedException(mock, exception, delay);
		}

		public static IReturnsResult<TMock> ThrowsAsync<TMock, TResult>(this IReturns<TMock, ValueTask<TResult>> mock, Exception exception, TimeSpan minDelay, TimeSpan maxDelay) where TMock : class
		{
			TimeSpan delay = GetDelay(minDelay, maxDelay, Random);
			return DelayedException(mock, exception, delay);
		}

		public static IReturnsResult<TMock> ThrowsAsync<TMock, TResult>(this IReturns<TMock, Task<TResult>> mock, Exception exception, TimeSpan minDelay, TimeSpan maxDelay, Random random) where TMock : class
		{
			if (random == null)
			{
				throw new ArgumentNullException("random");
			}
			TimeSpan delay = GetDelay(minDelay, maxDelay, random);
			return DelayedException(mock, exception, delay);
		}

		public static IReturnsResult<TMock> ThrowsAsync<TMock, TResult>(this IReturns<TMock, ValueTask<TResult>> mock, Exception exception, TimeSpan minDelay, TimeSpan maxDelay, Random random) where TMock : class
		{
			if (random == null)
			{
				throw new ArgumentNullException("random");
			}
			TimeSpan delay = GetDelay(minDelay, maxDelay, random);
			return DelayedException(mock, exception, delay);
		}

		internal static bool IsNullResult(Delegate valueFunction, Type resultType)
		{
			if ((object)valueFunction == null)
			{
				if (resultType.IsValueType)
				{
					return Nullable.GetUnderlyingType(resultType) != null;
				}
				return true;
			}
			return false;
		}

		private static TimeSpan GetDelay(TimeSpan minDelay, TimeSpan maxDelay, Random random)
		{
			if (minDelay >= maxDelay)
			{
				throw new ArgumentException(Resources.MinDelayMustBeLessThanMaxDelay);
			}
			int minValue = (int)minDelay.Ticks;
			int maxValue = (int)maxDelay.Ticks;
			return new TimeSpan(random.Next(minValue, maxValue));
		}

		private static IReturnsResult<TMock> DelayedResult<TMock, TResult>(IReturns<TMock, Task<TResult>> mock, TResult value, TimeSpan delay) where TMock : class
		{
			Guard.Positive(delay);
			return mock.Returns(() => Task.Delay(delay).ContinueWith((Task t) => value));
		}

		private static IReturnsResult<TMock> DelayedResult<TMock, TResult>(IReturns<TMock, ValueTask<TResult>> mock, TResult value, TimeSpan delay) where TMock : class
		{
			Guard.Positive(delay);
			return mock.Returns(() => new ValueTask<TResult>(Task.Delay(delay).ContinueWith((Task t) => value)));
		}

		private static IReturnsResult<TMock> DelayedException<TMock, TResult>(IReturns<TMock, Task<TResult>> mock, Exception exception, TimeSpan delay) where TMock : class
		{
			Guard.Positive(delay);
			return mock.Returns(delegate
			{
				TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();
				Task.Delay(delay).ContinueWith(delegate
				{
					tcs.SetException(exception);
				});
				return tcs.Task;
			});
		}

		private static IReturnsResult<TMock> DelayedException<TMock, TResult>(IReturns<TMock, ValueTask<TResult>> mock, Exception exception, TimeSpan delay) where TMock : class
		{
			Guard.Positive(delay);
			return mock.Returns(delegate
			{
				TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();
				Task.Delay(delay).ContinueWith(delegate
				{
					tcs.SetException(exception);
				});
				return new ValueTask<TResult>(tcs.Task);
			});
		}
	}
}
