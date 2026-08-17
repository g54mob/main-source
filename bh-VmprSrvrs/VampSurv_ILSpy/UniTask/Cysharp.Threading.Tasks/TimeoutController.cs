using System;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public sealed class TimeoutController : IDisposable
{
	private static readonly Action<object> CancelCancellationTokenSourceStateDelegate;

	private CancellationTokenSource timeoutSource;

	private CancellationTokenSource linkedSource;

	private PlayerLoopTimer timer;

	private bool isDisposed;

	private readonly DelayType delayType;

	private readonly PlayerLoopTiming delayTiming;

	private readonly CancellationTokenSource originalLinkCancellationTokenSource;

	private static void CancelCancellationTokenSourceState(object state)
	{
		//IL_00a9: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_0059: Expected O, but got I
		nint num = (nint)typeof(CancellationTokenSource);
		nint num2 = (nint)state;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (Il2CppClass<System.Threading.CancellationTokenSource>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r9_v3 (Il2CppClass<System.Object>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (Il2CppClass<System.Threading.CancellationTokenSource>)+130]");
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r9_v3 (Il2CppClass<System.Object>)+C8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v9+FFFFFFF8+v42 @ rax_v8 (Il2CppMethodInfo)*8]");
			if (0 == (nint)typeof(CancellationTokenSource))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [state @ rcx (System.Object)+28]");
				if ((nint)0 == 0)
				{
					((CancellationTokenSource)state).NotifyCancellation(false);
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
				CancellationTokenSource.ThrowObjectDisposedException();
			}
		}
		throw new InvalidCastException();
	}

	public TimeoutController(DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
	{
		//IL_0035: Expected I4, but got I8
		timeoutSource = new CancellationTokenSource
		{
			_threadIDExecutingCallbacks = -1,
			_state = 1
		};
		originalLinkCancellationTokenSource = null;
		linkedSource = null;
		this.delayType = delayType;
		this.delayTiming = delayTiming;
	}

	public TimeoutController(CancellationTokenSource linkCancellationTokenSource, DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
	{
		//IL_007b: Expected I4, but got I8
		timeoutSource = new CancellationTokenSource
		{
			_threadIDExecutingCallbacks = -1,
			_state = 1
		};
		originalLinkCancellationTokenSource = linkCancellationTokenSource;
		CancellationToken token = timeoutSource.Token;
		CancellationToken token2 = linkCancellationTokenSource.Token;
		CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, token2);
		linkedSource = cancellationTokenSource;
		this.delayTiming = delayTiming;
		this.delayType = delayType;
	}

	public CancellationToken Timeout(int millisecondsTimeout)
	{
		//IL_0018: Expected F8, but got I4
		CancellationToken result = (CancellationToken)TimeSpan.Interval((double)millisecondsTimeout, 1);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 81 Invalid \"Jump target not found in method: 0x185D50AC0\"");
		return result;
	}

	public CancellationToken Timeout(TimeSpan timeout)
	{
		//IL_00a6: Expected I4, but got I8
		//IL_0206: Expected I, but got O
		CancellationToken token;
		if (originalLinkCancellationTokenSource != null)
		{
			CancellationTokenSource cancellationTokenSource = originalLinkCancellationTokenSource;
			if (cancellationTokenSource._state >= 2)
			{
				token = originalLinkCancellationTokenSource.Token;
				goto IL_0045;
			}
		}
		CancellationTokenSource cancellationTokenSource2 = timeoutSource;
		if (cancellationTokenSource2._state >= 2)
		{
			timeoutSource.Dispose();
			CancellationTokenSource cancellationTokenSource3 = new CancellationTokenSource();
			cancellationTokenSource3._threadIDExecutingCallbacks = -1;
			cancellationTokenSource3._state = 1;
			timeoutSource = cancellationTokenSource3;
			if (linkedSource != null)
			{
				linkedSource.Cancel();
				linkedSource.Dispose();
				CancellationToken token2 = timeoutSource.Token;
				CancellationToken token3 = originalLinkCancellationTokenSource.Token;
				CancellationTokenSource cancellationTokenSource4 = CancellationTokenSource.CreateLinkedTokenSource(token2, token3);
				linkedSource = cancellationTokenSource4;
			}
			PlayerLoopTimer playerLoopTimer = timer;
			if (timer != null)
			{
				playerLoopTimer.isDisposed = true;
			}
			timer = null;
		}
		CancellationTokenSource cancellationTokenSource5 = ((linkedSource == null) ? timeoutSource : linkedSource);
		token = cancellationTokenSource5.Token;
		if (timer != null)
		{
			IPlayerLoopItem playerLoopItem = timer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v5 (Cysharp.Threading.Tasks.IPlayerLoopItem)+2F]");
			if ((nint)0 != 0)
			{
				ObjectDisposedException ex = new ObjectDisposedException(null);
				throw ex;
			}
			nint num = (nint)playerLoopItem;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v629 @ rax_v31 (Il2CppClass<Cysharp.Threading.Tasks.IPlayerLoopItem>)+198] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v5 (Cysharp.Threading.Tasks.IPlayerLoopItem)+2D]");
			if ((nint)0 == 0)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v5 (Cysharp.Threading.Tasks.IPlayerLoopItem)+28]");
				PlayerLoopHelper.AddAction(PlayerLoopTiming.Initialization, playerLoopItem);
			}
			_ = 0;
		}
		else
		{
			CancellationToken cancellationToken = default(CancellationToken);
			Action<object> timerCallback = default(Action<object>);
			object state = default(object);
			PlayerLoopTimer playerLoopTimer2 = PlayerLoopTimer.StartNew(timeout, periodic: false, delayType, delayTiming, cancellationToken, timerCallback, state);
			timer = playerLoopTimer2;
		}
		goto IL_0045;
		IL_0045:
		return token;
	}

	public bool IsTimeout()
	{
		//IL_00ad: Expected I4, but got O
		//IL_003c: Expected O, but got I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected I4, but got Unknown
		CancellationTokenSource cancellationTokenSource = timeoutSource;
		if (timeoutSource != null)
		{
			object obj = cancellationTokenSource._state - 2;
			int num = cancellationTokenSource._state ^ 2;
			int num2 = cancellationTokenSource._state ^ obj;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = (nint)obj < 0;
			return flag2 == flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void Reset()
	{
		PlayerLoopTimer playerLoopTimer = timer;
		if (timer != null)
		{
			playerLoopTimer.tryStop = true;
		}
	}

	public void Dispose()
	{
		//IL_0032: Expected O, but got I
		//IL_0153: Expected O, but got I
		//IL_012d: Expected O, but got I4
		//IL_008d: Expected O, but got I
		//IL_00a3: Expected O, but got I
		//IL_00d9: Expected O, but got I
		//IL_010f: Expected O, but got I
		if (isDisposed)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_8_v3+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_8_v3+20]");
		bool flag = (nint)0 == 0;
		object obj3 = default(object);
		object obj2 = obj3;
		if (!flag)
		{
			_ = 1;
			obj2 = obj3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v4+10]");
		CancellationTokenSource cancellationTokenSource = (CancellationTokenSource)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v4+10]");
		if ((nint)0 != 0)
		{
			if (!cancellationTokenSource._disposed)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v4+10]");
				((CancellationTokenSource)0).NotifyCancellation(false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_8_v3+10]");
				((CancellationTokenSource)0).Dispose();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_8_v3+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_8_v3+18]");
					((CancellationTokenSource)0).Cancel();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_8_v3+18]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_8_v3+18]");
					((CancellationTokenSource)0).Dispose();
				}
				_ = 1;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
			CancellationTokenSource.ThrowObjectDisposedException();
			obj = 0;
		}
		throw new NullReferenceException();
	}

	static TimeoutController()
	{
		Action<object> cancelCancellationTokenSourceStateDelegate = CancelCancellationTokenSourceState;
		CancelCancellationTokenSourceStateDelegate = cancelCancellationTokenSourceStateDelegate;
	}
}
