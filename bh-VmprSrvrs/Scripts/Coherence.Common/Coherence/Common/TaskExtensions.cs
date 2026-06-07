using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Coherence.Common
{
	internal static class TaskExtensions
	{
		public static void Then([DisallowNull] this Task task, [DisallowNull] Action action, CancellationToken cancellationToken = default(CancellationToken))
		{
		}

		public static void Then([DisallowNull] this Task task, [DisallowNull] Action action, TaskContinuationOptions taskContinuationOptions, CancellationToken cancellationToken = default(CancellationToken))
		{
		}

		public static void Then([DisallowNull] this Task task, [DisallowNull] Action<Task> action, CancellationToken cancellationToken = default(CancellationToken))
		{
		}

		public static Task<TResult> Then<TResult>([DisallowNull] this Task task, [DisallowNull] Func<Task, TResult> continuationAsync, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static void Then([DisallowNull] this Task task, [DisallowNull] Action<Task> action, TaskContinuationOptions taskContinuationOptions, CancellationToken cancellationToken = default(CancellationToken))
		{
		}

		public static void Then<TResult>([DisallowNull] this Task<TResult> task, [DisallowNull] Action<Task<TResult>> action, CancellationToken cancellationToken = default(CancellationToken))
		{
		}

		public static void Then<TResult>([DisallowNull] this Task<TResult> task, [DisallowNull] Action<Task<TResult>> action, TaskContinuationOptions taskContinuationOptions, CancellationToken cancellationToken = default(CancellationToken))
		{
		}
	}
}
