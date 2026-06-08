using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Moq.Async
{
	internal sealed class TaskFactory : AwaitableFactory<Task>
	{
		public static readonly TaskFactory Instance = new TaskFactory();

		private TaskFactory()
		{
		}

		public override Task CreateCompleted()
		{
			return Task.FromResult<object>(null);
		}

		public override Task CreateFaulted(Exception exception)
		{
			TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
			taskCompletionSource.SetException(exception);
			return taskCompletionSource.Task;
		}

		public override Task CreateFaulted(IEnumerable<Exception> exceptions)
		{
			TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
			taskCompletionSource.SetException(exceptions);
			return taskCompletionSource.Task;
		}
	}
	internal sealed class TaskFactory<TResult> : AwaitableFactory<Task<TResult>, TResult>
	{
		public override Task<TResult> CreateCompleted(TResult result)
		{
			return Task.FromResult(result);
		}

		public override Task<TResult> CreateFaulted(Exception exception)
		{
			TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
			taskCompletionSource.SetException(exception);
			return taskCompletionSource.Task;
		}

		public override Task<TResult> CreateFaulted(IEnumerable<Exception> exceptions)
		{
			TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
			taskCompletionSource.SetException(exceptions);
			return taskCompletionSource.Task;
		}

		public override Expression CreateResultExpression(Expression awaitableExpression)
		{
			return Expression.MakeMemberAccess(awaitableExpression, typeof(Task<TResult>).GetProperty("Result"));
		}

		public override bool TryGetResult(Task<TResult> task, out TResult result)
		{
			if (task.Status == TaskStatus.RanToCompletion)
			{
				result = task.Result;
				return true;
			}
			result = default(TResult);
			return false;
		}
	}
}
