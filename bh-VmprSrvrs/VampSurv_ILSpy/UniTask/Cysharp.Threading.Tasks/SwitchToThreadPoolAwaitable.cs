using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

[StructLayout((LayoutKind)0, Size = 1)]
public struct SwitchToThreadPoolAwaitable
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct Awaiter : ICriticalNotifyCompletion, INotifyCompletion
	{
		private static readonly WaitCallback switchToCallback;

		public bool IsCompleted => false;

		public void GetResult()
		{
		}

		public void OnCompleted(Action continuation)
		{
			bool flag = ThreadPool.QueueUserWorkItem(switchToCallback, continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			bool flag = ThreadPool.UnsafeQueueUserWorkItem(switchToCallback, continuation);
		}

		private static void Callback(object state)
		{
			bool flag = (object)state.GetType() != typeof(Action);
			object obj = null;
			if (!flag)
			{
				obj = state;
			}
			if (obj != null)
			{
				bool flag2 = (object)state.GetType() != typeof(Action);
				object obj2 = null;
				if (!flag2)
				{
					obj2 = state;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v94 @ r8_v3 (System.Object)+18] (should have been resolved before IL gen)");
				return;
			}
			throw new InvalidCastException();
		}

		static Awaiter()
		{
			WaitCallback waitCallback = Callback;
			switchToCallback = waitCallback;
		}
	}

	public Awaiter GetAwaiter()
	{
		//IL_0006: Expected O, but got I4
		return (Awaiter)0;
	}
}
