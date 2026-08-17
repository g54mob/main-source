using System;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public abstract class PlayerLoopTimer : IDisposable, IPlayerLoopItem
{
	private readonly CancellationToken cancellationToken;

	private readonly Action<object> timerCallback;

	private readonly object state;

	private readonly PlayerLoopTiming playerLoopTiming;

	private readonly bool periodic;

	private bool isRunning;

	private bool tryStop;

	private bool isDisposed;

	protected PlayerLoopTimer(bool periodic, PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken, Action<object> timerCallback, object state)
	{
		this.periodic = periodic;
		this.cancellationToken = cancellationToken;
		this.playerLoopTiming = playerLoopTiming;
		Action<object> action = default(Action<object>);
		this.timerCallback = action;
		object obj = default(object);
		this.state = obj;
	}

	public unsafe static PlayerLoopTimer Create(TimeSpan interval, bool periodic, DelayType delayType, PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken, Action<object> timerCallback, object state)
	{
		//IL_00be: Expected O, but got Ref
		//IL_0013: Expected O, but got I4
		bool flag = delayType == DelayType.DeltaTime;
		if (flag)
		{
			goto IL_0065;
		}
		object obj = delayType - 1;
		IgnoreTimeScalePlayerLoopTimer ignoreTimeScalePlayerLoopTimer;
		if (!flag)
		{
			if ((nint)obj != 1)
			{
				goto IL_0065;
			}
			RealtimePlayerLoopTimer realtimePlayerLoopTimer = null;
			ignoreTimeScalePlayerLoopTimer = (IgnoreTimeScalePlayerLoopTimer)(object)realtimePlayerLoopTimer;
		}
		else
		{
			IgnoreTimeScalePlayerLoopTimer ignoreTimeScalePlayerLoopTimer2 = null;
			ignoreTimeScalePlayerLoopTimer = ignoreTimeScalePlayerLoopTimer2;
		}
		goto IL_0094;
		IL_0065:
		DeltaTimePlayerLoopTimer deltaTimePlayerLoopTimer = null;
		ignoreTimeScalePlayerLoopTimer = (IgnoreTimeScalePlayerLoopTimer)(object)deltaTimePlayerLoopTimer;
		goto IL_0094;
		IL_0094:
		CancellationToken cancellationToken2 = default(CancellationToken);
		Action<object> action = default(Action<object>);
		object obj2 = default(object);
		ignoreTimeScalePlayerLoopTimer._002Ector(periodic, playerLoopTiming, cancellationToken2, action, obj2);
		object obj3 = default(object);
		ignoreTimeScalePlayerLoopTimer.ResetCore((TimeSpan?)(object)(&obj3));
		return ignoreTimeScalePlayerLoopTimer;
	}

	public unsafe static PlayerLoopTimer StartNew(TimeSpan interval, bool periodic, DelayType delayType, PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken, Action<object> timerCallback, object state)
	{
		//IL_003c: Expected O, but got Ref
		CancellationToken cancellationToken2 = default(CancellationToken);
		Action<object> action = default(Action<object>);
		object obj = default(object);
		PlayerLoopTimer playerLoopTimer = Create(interval, periodic, delayType, playerLoopTiming, cancellationToken2, action, obj);
		if (!playerLoopTimer.isDisposed)
		{
			object obj2 = default(object);
			playerLoopTimer.ResetCore((TimeSpan?)(object)(&obj2));
			if (!playerLoopTimer.isRunning)
			{
				playerLoopTimer.isRunning = true;
				PlayerLoopHelper.AddAction(playerLoopTimer.playerLoopTiming, playerLoopTimer);
			}
			playerLoopTimer.tryStop = false;
			return playerLoopTimer;
		}
		ObjectDisposedException ex = new ObjectDisposedException(null);
		throw ex;
	}

	public unsafe void Restart()
	{
		//IL_000f: Expected O, but got Ref
		if (!isDisposed)
		{
			object obj = default(object);
			ResetCore((TimeSpan?)(object)(&obj));
			if (!isRunning)
			{
				isRunning = true;
				PlayerLoopHelper.AddAction(playerLoopTiming, this);
			}
			tryStop = false;
			return;
		}
		ObjectDisposedException ex = new ObjectDisposedException(null);
		throw ex;
	}

	public unsafe void Restart(TimeSpan interval)
	{
		//IL_000f: Expected O, but got Ref
		if (!isDisposed)
		{
			object obj = default(object);
			ResetCore((TimeSpan?)(object)(&obj));
			if (!isRunning)
			{
				isRunning = true;
				PlayerLoopHelper.AddAction(playerLoopTiming, this);
			}
			tryStop = false;
			return;
		}
		ObjectDisposedException ex = new ObjectDisposedException(null);
		throw ex;
	}

	public void Stop()
	{
		tryStop = true;
	}

	protected abstract void ResetCore(TimeSpan? newInterval);

	public void Dispose()
	{
		isDisposed = true;
	}

	unsafe bool IPlayerLoopItem.MoveNext()
	{
		//IL_0115: Expected I4, but got O
		//IL_00f1: Expected O, but got Ref
		if (!isDisposed && !tryStop)
		{
			if ((object)this.cancellationToken != null)
			{
				CancellationToken cancellationToken = this.cancellationToken;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v15 (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					goto IL_00f6;
				}
			}
			if (!MoveNextCore())
			{
				Action<object> action = timerCallback;
				if (timerCallback == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v200 @ rax_v10 (System.Action`1<System.Object>)+18] (should have been resolved before IL gen)");
				if (!periodic)
				{
					goto IL_00f6;
				}
				object obj = default(object);
				ResetCore((TimeSpan?)(object)(&obj));
			}
			return true;
		}
		goto IL_00f6;
		IL_00f6:
		isRunning = false;
		return false;
	}

	protected abstract bool MoveNextCore();
}
