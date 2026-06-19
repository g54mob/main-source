using System;
using System.Runtime.CompilerServices;
using Loxodon.Framework.Asynchronous;

namespace Loxodon.Framework.Views
{
	public struct TransitionAwaiter : IAwaiter, ICriticalNotifyCompletion, INotifyCompletion
	{
		private Transition transition;

		public bool IsCompleted => transition.IsDone;

		public TransitionAwaiter(Transition transition)
		{
			this.transition = transition ?? throw new ArgumentNullException("transition");
		}

		public void GetResult()
		{
			if (!IsCompleted)
			{
				throw new Exception("The task is not finished yet");
			}
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			if (continuation == null)
			{
				throw new ArgumentNullException("continuation");
			}
			transition.OnFinish(continuation);
		}
	}
}
