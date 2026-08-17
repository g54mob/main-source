using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

[StructLayout((LayoutKind)0, Size = 1)]
public struct SwitchToTaskPoolAwaitable
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct Awaiter : ICriticalNotifyCompletion, INotifyCompletion
	{
		private static readonly Action<object> switchToCallback;

		public bool IsCompleted => false;

		public void GetResult()
		{
		}

		public void OnCompleted(Action continuation)
		{
			//IL_0039: Expected O, but got I4
			TaskCreationOptions creationOptions = default(TaskCreationOptions);
			TaskScheduler scheduler = default(TaskScheduler);
			Task task = Task._003CFactory_003Ek__BackingField.StartNew(switchToCallback, continuation, (CancellationToken)0, creationOptions, scheduler);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			//IL_0039: Expected O, but got I4
			TaskCreationOptions creationOptions = default(TaskCreationOptions);
			TaskScheduler scheduler = default(TaskScheduler);
			Task task = Task._003CFactory_003Ek__BackingField.StartNew(switchToCallback, continuation, (CancellationToken)0, creationOptions, scheduler);
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
			Action<object> action = Callback;
			switchToCallback = action;
		}
	}

	public Awaiter GetAwaiter()
	{
		//IL_0006: Expected O, but got I4
		return (Awaiter)0;
	}
}
