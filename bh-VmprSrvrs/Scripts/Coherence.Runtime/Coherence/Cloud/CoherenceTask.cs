using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Coherence.Cloud
{
	public sealed class CoherenceTask<TResult> : CoherenceTask
	{
		public TResult Result => default(TResult);

		internal new Task<TResult> task => null;

		internal CoherenceTask(Task<TResult> task)
			: base(null)
		{
		}

		internal CoherenceTask(Task<TResult> task, CancellationToken cancellationToken)
			: base(null)
		{
		}

		public new CoherenceTask<TResult> ContinueWith([DisallowNull] Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public CoherenceTask<TResult> OnSuccess([DisallowNull] Action<TResult> action)
		{
			return null;
		}

		public new TaskAwaiter<CoherenceTask<TResult>> GetAwaiter()
		{
			return default(TaskAwaiter<CoherenceTask<TResult>>);
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator TResult(CoherenceTask<TResult> operation)
		{
			return default(TResult);
		}
	}
	public class CoherenceTask : CustomYieldInstruction
	{
		protected internal readonly Task task;

		internal readonly CancellationToken cancellationToken;

		public bool IsCompleted => false;

		public bool IsCompletedSuccessfully => false;

		public bool IsCanceled => false;

		public sealed override bool keepWaiting => false;

		protected CoherenceTask(Task task)
		{
		}

		protected CoherenceTask(Task task, CancellationToken cancellationToken)
		{
		}

		private protected TaskAwaiter<TOperation> GetAwaiter<TOperation>(TOperation operation) where TOperation : CoherenceTask
		{
			return default(TaskAwaiter<TOperation>);
		}

		public TaskAwaiter<CoherenceTask> GetAwaiter()
		{
			return default(TaskAwaiter<CoherenceTask>);
		}

		public CoherenceTask ContinueWith([DisallowNull] Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.NotOnCanceled)
		{
			return null;
		}

		public CoherenceTask OnSuccess([DisallowNull] Action action)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator Task(CoherenceTask operation)
		{
			return null;
		}
	}
}
