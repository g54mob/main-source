using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Moq.Async
{
	internal sealed class ValueTaskFactory : AwaitableFactory<ValueTask>
	{
		public static readonly ValueTaskFactory Instance = new ValueTaskFactory();

		private ValueTaskFactory()
		{
		}

		public override ValueTask CreateCompleted()
		{
			return default(ValueTask);
		}

		public override ValueTask CreateFaulted(Exception exception)
		{
			TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
			taskCompletionSource.SetException(exception);
			return new ValueTask(taskCompletionSource.Task);
		}

		public override ValueTask CreateFaulted(IEnumerable<Exception> exceptions)
		{
			TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
			taskCompletionSource.SetException(exceptions);
			return new ValueTask(taskCompletionSource.Task);
		}
	}
	internal sealed class ValueTaskFactory<TResult> : AwaitableFactory<ValueTask<TResult>, TResult>
	{
		public override ValueTask<TResult> CreateCompleted(TResult result)
		{
			return new ValueTask<TResult>(result);
		}

		public override ValueTask<TResult> CreateFaulted(Exception exception)
		{
			TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
			taskCompletionSource.SetException(exception);
			return new ValueTask<TResult>(taskCompletionSource.Task);
		}

		public override ValueTask<TResult> CreateFaulted(IEnumerable<Exception> exceptions)
		{
			TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
			taskCompletionSource.SetException(exceptions);
			return new ValueTask<TResult>(taskCompletionSource.Task);
		}

		public override Expression CreateResultExpression(Expression awaitableExpression)
		{
			return Expression.MakeMemberAccess(awaitableExpression, typeof(ValueTask<TResult>).GetProperty("Result"));
		}

		public override bool TryGetResult(ValueTask<TResult> valueTask, out TResult result)
		{
			if (valueTask.IsCompletedSuccessfully)
			{
				result = valueTask.Result;
				return true;
			}
			result = default(TResult);
			return false;
		}
	}
}
