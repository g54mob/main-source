using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public struct ReturnToSynchronizationContext(SynchronizationContext syncContext, bool dontPostWhenSameContext, CancellationToken cancellationToken)
{
	public struct Awaiter(SynchronizationContext synchronizationContext, bool dontPostWhenSameContext, CancellationToken cancellationToken) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private static readonly SendOrPostCallback switchToCallback;

		private readonly SynchronizationContext synchronizationContext = synchronizationContext;

		private readonly bool dontPostWhenSameContext = dontPostWhenSameContext;

		private readonly CancellationToken cancellationToken = cancellationToken;

		public bool IsCompleted
		{
			get
			{
				if (dontPostWhenSameContext)
				{
					SynchronizationContext current = SynchronizationContext.Current;
					object obj = (object)current - (object)synchronizationContext;
					return obj == null;
				}
				return false;
			}
		}

		public unsafe Awaiter GetAwaiter()
		{
			//IL_000a: Expected native int or pointer, but got O
			//IL_0019: Expected native int or pointer, but got O
			Awaiter awaiter = default(Awaiter);
			System.Runtime.CompilerServices.Unsafe.Write(&((Awaiter*)(nint)awaiter)->synchronizationContext, synchronizationContext);
			System.Runtime.CompilerServices.Unsafe.Write(&((Awaiter*)(nint)awaiter)->cancellationToken, cancellationToken);
			return awaiter;
		}

		public unsafe void GetResult()
		{
			//IL_0010: Expected O, but got Ref
			CancellationToken cancellationToken = (CancellationToken)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
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

	private readonly SynchronizationContext syncContext = syncContext;

	private readonly bool dontPostWhenSameContext = dontPostWhenSameContext;

	private readonly CancellationToken cancellationToken = cancellationToken;

	public unsafe Awaiter DisposeAsync()
	{
		//IL_0005: Expected native int or pointer, but got O
		//IL_0018: Expected O, but got I4
		//IL_0013: Expected native int or pointer, but got O
		//IL_002e: Expected native int or pointer, but got O
		Awaiter awaiter = default(Awaiter);
		System.Runtime.CompilerServices.Unsafe.Write(&((Awaiter*)(nint)awaiter)->synchronizationContext, null);
		System.Runtime.CompilerServices.Unsafe.Write(&((Awaiter*)(nint)awaiter)->cancellationToken, (CancellationToken)0);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)awaiter, new Awaiter(syncContext, dontPostWhenSameContext, cancellationToken));
		return awaiter;
	}
}
