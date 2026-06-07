using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Common;
using UnityEngine;

namespace Coherence.Cloud
{
	public abstract class CloudOperation<TResult, TError> : CloudOperation<TError> where TError : CoherenceError
	{
		public TResult Result => default(TResult);

		protected internal new Task<TResult> task => null;

		protected CloudOperation(Task<TResult> task)
			: base((Task)null)
		{
		}

		protected CloudOperation(Task<TResult> task, CancellationToken cancellationToken)
			: base((Task)null)
		{
		}

		public new CloudOperation<TResult, TError> ContinueWith([DisallowNull] Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public CloudOperation<TResult, TError> OnSuccess([DisallowNull] Action<TResult> action)
		{
			return null;
		}

		public new CloudOperation<TResult, TError> OnFail([DisallowNull] Action<TError> action)
		{
			return null;
		}

		public void Deconstruct(out TResult result, out TError error)
		{
			result = default(TResult);
			error = null;
		}

		public new TaskAwaiter<CloudOperation<TResult, TError>> GetAwaiter()
		{
			return default(TaskAwaiter<CloudOperation<TResult, TError>>);
		}

		public sealed override string ToString()
		{
			return null;
		}

		protected virtual string ResultToString([DisallowNull] TResult result)
		{
			return null;
		}

		public static implicit operator TResult(CloudOperation<TResult, TError> operation)
		{
			return default(TResult);
		}
	}
	public abstract class CloudOperation<TError> : CustomYieldInstruction where TError : CoherenceError
	{
		internal TError error;

		protected internal readonly Task task;

		internal readonly CancellationToken cancellationToken;

		internal bool errorHasBeenObserved;

		public TError Error => null;

		public bool IsCompleted => false;

		public bool IsCompletedSuccessfully => false;

		public bool HasFailed => false;

		public bool IsCanceled => false;

		public override bool keepWaiting => false;

		protected CloudOperation(Task task)
		{
		}

		protected CloudOperation(Task task, CancellationToken cancellationToken)
		{
		}

		private protected TaskAwaiter<TOperation> GetAwaiter<TOperation>(TOperation operation) where TOperation : CloudOperation<TError>
		{
			return default(TaskAwaiter<TOperation>);
		}

		public TaskAwaiter<CloudOperation<TError>> GetAwaiter()
		{
			return default(TaskAwaiter<CloudOperation<TError>>);
		}

		public CloudOperation<TError> ContinueWith([DisallowNull] Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public CloudOperation<TError> OnSuccess([DisallowNull] Action action)
		{
			return null;
		}

		public CloudOperation<TError> OnFail([DisallowNull] Action<TError> action)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal TError GetOrCreateError()
		{
			return null;
		}

		internal abstract TError CreateError([AllowNull] Exception exception, object args = null);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void MarkErrorAsObserved()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator Exception(CloudOperation<TError> operation)
		{
			return null;
		}

		public static implicit operator Task(CloudOperation<TError> operation)
		{
			return null;
		}
	}
}
