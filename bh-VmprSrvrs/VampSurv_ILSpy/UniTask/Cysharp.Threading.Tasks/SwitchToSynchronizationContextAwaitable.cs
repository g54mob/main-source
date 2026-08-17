using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public struct SwitchToSynchronizationContextAwaitable(SynchronizationContext synchronizationContext, CancellationToken cancellationToken)
{
	public struct Awaiter(SynchronizationContext synchronizationContext, CancellationToken cancellationToken) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private static readonly SendOrPostCallback switchToCallback;

		private readonly SynchronizationContext synchronizationContext = synchronizationContext;

		private readonly CancellationToken cancellationToken = cancellationToken;

		public bool IsCompleted => false;

		public unsafe void GetResult()
		{
			//IL_0010: Expected O, but got Ref
			CancellationToken cancellationToken = (CancellationToken)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((CancellationToken*)cancellationToken)->ThrowIfCancellationRequested();
		}

		public void OnCompleted(Action continuation)
		{
			synchronizationContext.Post(switchToCallback, continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			synchronizationContext.Post(switchToCallback, continuation);
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
			SendOrPostCallback sendOrPostCallback = Callback;
			switchToCallback = sendOrPostCallback;
		}
	}

	private readonly SynchronizationContext synchronizationContext = synchronizationContext;

	private readonly CancellationToken cancellationToken = cancellationToken;

	public unsafe Awaiter GetAwaiter()
	{
		//IL_0005: Expected native int or pointer, but got O
		//IL_001a: Expected native int or pointer, but got O
		Awaiter awaiter = default(Awaiter);
		System.Runtime.CompilerServices.Unsafe.Write(&((Awaiter*)(nint)awaiter)->synchronizationContext, null);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)awaiter, new Awaiter(synchronizationContext, cancellationToken));
		return awaiter;
	}
}
