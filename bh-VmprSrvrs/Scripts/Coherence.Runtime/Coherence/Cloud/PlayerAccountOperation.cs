using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Coherence.Log;

namespace Coherence.Cloud
{
	public sealed class PlayerAccountOperation<TResult> : CloudOperation<TResult, PlayerAccountOperationError>
	{
		internal PlayerAccountOperation(Task<TResult> task)
			: base((Task<TResult>)null)
		{
		}

		internal PlayerAccountOperation(PlayerAccountErrorType errorType, Error error, string message = null)
			: base((Task<TResult>)null)
		{
		}

		public new PlayerAccountOperation<TResult> ContinueWith([DisallowNull] Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public PlayerAccountOperation<TResult> ContinueWith([DisallowNull] Action<PlayerAccountOperation<TResult>> action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public new PlayerAccountOperation<TResult> OnSuccess([DisallowNull] Action<TResult> action)
		{
			return null;
		}

		public new PlayerAccountOperation<TResult> OnFail([DisallowNull] Action<PlayerAccountOperationError> action)
		{
			return null;
		}

		public new TaskAwaiter<PlayerAccountOperation<TResult>> GetAwaiter()
		{
			return default(TaskAwaiter<PlayerAccountOperation<TResult>>);
		}

		internal override PlayerAccountOperationError CreateError([DisallowNull] Exception exception, object args = null)
		{
			return null;
		}
	}
	public sealed class PlayerAccountOperation : CloudOperation<PlayerAccountOperationError>
	{
		internal PlayerAccountOperation(Task task)
			: base((Task)null)
		{
		}

		internal PlayerAccountOperation(PlayerAccountErrorType errorType, Error error, string message = null)
			: base((Task)null)
		{
		}

		public new PlayerAccountOperation ContinueWith([DisallowNull] Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public PlayerAccountOperation ContinueWith([DisallowNull] Action<PlayerAccountOperation> action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public new TaskAwaiter<PlayerAccountOperation> GetAwaiter()
		{
			return default(TaskAwaiter<PlayerAccountOperation>);
		}

		internal override PlayerAccountOperationError CreateError([DisallowNull] Exception exception, object args = null)
		{
			return null;
		}
	}
}
