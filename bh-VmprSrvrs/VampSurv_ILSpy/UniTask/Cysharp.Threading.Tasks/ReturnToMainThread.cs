using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public struct ReturnToMainThread(PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken)
{
	public struct Awaiter(PlayerLoopTiming timing, CancellationToken cancellationToken) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private readonly PlayerLoopTiming timing = timing;

		private readonly CancellationToken cancellationToken = cancellationToken;

		public bool IsCompleted
		{
			get
			{
				//IL_00cd: Expected I4, but got O
				//IL_00ab: Expected O, but got I4
				Thread currentThread = Thread.CurrentThread;
				if (currentThread != null)
				{
					if (currentThread.internal_thread == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B455E8");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B1F7E0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC8810");
						System.Threading.InternalThread internal_thread = currentThread.internal_thread;
						internal_thread.state = ThreadState.Unstarted;
					}
					System.Threading.InternalThread internal_thread2 = currentThread.internal_thread;
					if (currentThread.internal_thread != null)
					{
						object obj = PlayerLoopHelper.mainThreadId - internal_thread2.managed_id;
						return obj == null;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
		}

		public unsafe Awaiter GetAwaiter()
		{
			//IL_000a: Expected native int or pointer, but got O
			Awaiter awaiter = default(Awaiter);
			((Awaiter*)(nint)awaiter)->timing = timing;
			return awaiter;
		}

		public unsafe void GetResult()
		{
			//IL_0010: Expected O, but got Ref
			CancellationToken cancellationToken = (CancellationToken)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((CancellationToken*)cancellationToken)->ThrowIfCancellationRequested();
		}

		public void OnCompleted(Action continuation)
		{
			PlayerLoopHelper.AddContinuation(timing, continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			PlayerLoopHelper.AddContinuation(timing, continuation);
		}
	}

	private readonly PlayerLoopTiming playerLoopTiming = playerLoopTiming;

	private readonly CancellationToken cancellationToken = cancellationToken;

	public unsafe Awaiter DisposeAsync()
	{
		//IL_0010: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		_ = 0;
		Awaiter awaiter = default(Awaiter);
		((Awaiter*)(nint)awaiter)->timing = playerLoopTiming;
		System.Runtime.CompilerServices.Unsafe.Write(&((Awaiter*)(nint)awaiter)->cancellationToken, cancellationToken);
		return awaiter;
	}
}
