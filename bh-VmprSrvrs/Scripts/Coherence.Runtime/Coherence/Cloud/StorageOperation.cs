using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Coherence.Cloud
{
	public sealed class StorageOperation<TResult> : CloudOperation<TResult, StorageError>
	{
		internal StorageOperation(Task<TResult> task)
			: base((Task<TResult>)null)
		{
		}

		internal StorageOperation(StorageException exception)
			: base((Task<TResult>)null)
		{
		}

		internal StorageOperation(Task<TResult> task, CancellationToken cancellationToken)
			: base((Task<TResult>)null)
		{
		}

		public new StorageOperation<TResult> ContinueWith([DisallowNull] Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public StorageOperation<TResult> ContinueWith([DisallowNull] Action<StorageOperation<TResult>> action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public new StorageOperation<TResult> OnSuccess([DisallowNull] Action<TResult> action)
		{
			return null;
		}

		public new StorageOperation<TResult> OnFail([DisallowNull] Action<StorageError> action)
		{
			return null;
		}

		public new TaskAwaiter<StorageOperation<TResult>> GetAwaiter()
		{
			return default(TaskAwaiter<StorageOperation<TResult>>);
		}

		internal override StorageError CreateError(Exception exception, object storageObjectIds = null)
		{
			return null;
		}

		public static implicit operator StorageOperation<TResult>(Task<TResult> task)
		{
			return null;
		}

		public static implicit operator StorageOperation<TResult>(Exception exception)
		{
			return null;
		}

		protected override string ResultToString([DisallowNull] TResult result)
		{
			return null;
		}
	}
	public sealed class StorageOperation : CloudOperation<StorageError>
	{
		internal StorageOperation(Task task)
			: base((Task)null)
		{
		}

		internal StorageOperation(Task task, CancellationToken cancellationToken)
			: base((Task)null)
		{
		}

		internal StorageOperation(StorageException exception)
			: base((Task)null)
		{
		}

		public new StorageOperation ContinueWith([DisallowNull] Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public StorageOperation ContinueWith([DisallowNull] Action<StorageOperation> action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public new StorageOperation OnSuccess([DisallowNull] Action action)
		{
			return null;
		}

		public new StorageOperation OnFail([DisallowNull] Action<StorageError> action)
		{
			return null;
		}

		public new TaskAwaiter<StorageOperation> GetAwaiter()
		{
			return default(TaskAwaiter<StorageOperation>);
		}

		internal override StorageError CreateError(Exception exception, object storageObjectIds = null)
		{
			return null;
		}

		public static implicit operator StorageOperation(Task task)
		{
			return null;
		}

		internal static StorageOperation<TResult> ToSingleResultOperation<TResult>(StorageOperation<TResult[]> multiResultOperation, StorageObjectId storageObjectId)
		{
			return null;
		}
	}
}
