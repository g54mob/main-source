using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq.Language;

namespace Moq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class SequenceExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use instance method Mock<T>.SetupSequence instead.")]
		public static ISetupSequentialResult<TResult> SetupSequence<TMock, TResult>(this Mock<TMock> mock, Expression<Func<TMock, TResult>> expression) where TMock : class
		{
			return mock.SetupSequence(expression);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use instance method Mock<T>.SetupSequence instead.")]
		public static ISetupSequentialAction SetupSequence<TMock>(this Mock<TMock> mock, Expression<Action<TMock>> expression) where TMock : class
		{
			return mock.SetupSequence(expression);
		}

		public static ISetupSequentialResult<Task<TResult>> ReturnsAsync<TResult>(this ISetupSequentialResult<Task<TResult>> setup, TResult value)
		{
			return setup.Returns(() => Task.FromResult(value));
		}

		public static ISetupSequentialResult<Task<TResult>> ReturnsAsync<TResult>(this ISetupSequentialResult<Task<TResult>> setup, Func<TResult> valueFunction)
		{
			return setup.Returns(() => Task.FromResult(valueFunction()));
		}

		public static ISetupSequentialResult<ValueTask<TResult>> ReturnsAsync<TResult>(this ISetupSequentialResult<ValueTask<TResult>> setup, TResult value)
		{
			return setup.Returns(() => new ValueTask<TResult>(value));
		}

		public static ISetupSequentialResult<ValueTask<TResult>> ReturnsAsync<TResult>(this ISetupSequentialResult<ValueTask<TResult>> setup, Func<TResult> valueFunction)
		{
			return setup.Returns(() => new ValueTask<TResult>(valueFunction()));
		}

		public static ISetupSequentialResult<Task> PassAsync(this ISetupSequentialResult<Task> setup)
		{
			return setup.Returns(() => Task.FromResult(0));
		}

		public static ISetupSequentialResult<ValueTask> PassAsync(this ISetupSequentialResult<ValueTask> setup)
		{
			return setup.Returns(() => default(ValueTask));
		}

		public static ISetupSequentialResult<Task<TResult>> ThrowsAsync<TResult>(this ISetupSequentialResult<Task<TResult>> setup, Exception exception)
		{
			return setup.Returns(delegate
			{
				TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
				taskCompletionSource.SetException(exception);
				return taskCompletionSource.Task;
			});
		}

		public static ISetupSequentialResult<ValueTask<TResult>> ThrowsAsync<TResult>(this ISetupSequentialResult<ValueTask<TResult>> setup, Exception exception)
		{
			return setup.Returns(delegate
			{
				TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
				taskCompletionSource.SetException(exception);
				return new ValueTask<TResult>(taskCompletionSource.Task);
			});
		}

		public static ISetupSequentialResult<Task> ThrowsAsync(this ISetupSequentialResult<Task> setup, Exception exception)
		{
			return setup.Returns(delegate
			{
				TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
				taskCompletionSource.SetException(exception);
				return taskCompletionSource.Task;
			});
		}

		public static ISetupSequentialResult<ValueTask> ThrowsAsync(this ISetupSequentialResult<ValueTask> setup, Exception exception)
		{
			return setup.Returns(delegate
			{
				TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
				taskCompletionSource.SetException(exception);
				return new ValueTask(taskCompletionSource.Task);
			});
		}
	}
}
