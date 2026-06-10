using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Cysharp.Threading.Tasks
{
	public class UniTaskCompletionSource : IUniTaskSource
	{
		private CancellationToken cancellationToken;

		private ExceptionHolder exception;

		private object gate;

		private Action<object> singleContinuation;

		private object singleState;

		private List<(Action<object>, object)> secondaryContinuationList;

		private int intStatus;

		private bool handled;

		public UniTask Task
		{
			[DebuggerHidden]
			get
			{
				return default(UniTask);
			}
		}

		[DebuggerHidden]
		internal void MarkHandled()
		{
		}

		[DebuggerHidden]
		public bool TrySetResult()
		{
			return false;
		}

		[DebuggerHidden]
		public void GetResult(short token)
		{
		}

		[DebuggerHidden]
		public UniTaskStatus GetStatus(short token)
		{
			return default(UniTaskStatus);
		}

		[DebuggerHidden]
		public UniTaskStatus UnsafeGetStatus()
		{
			return default(UniTaskStatus);
		}

		[DebuggerHidden]
		public void OnCompleted(Action<object> continuation, object state, short token)
		{
		}

		[DebuggerHidden]
		private bool TrySignalCompletion(UniTaskStatus status)
		{
			return false;
		}
	}
}
