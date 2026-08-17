using System;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.Internal;

namespace Cysharp.Threading.Tasks;

internal sealed class RealtimePlayerLoopTimer : PlayerLoopTimer
{
	private ValueStopwatch stopwatch;

	private long intervalTicks;

	public unsafe RealtimePlayerLoopTimer(TimeSpan interval, bool periodic, PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken, Action<object> timerCallback, object state)
	{
		//IL_0029: Expected O, but got Ref
		CancellationToken cancellationToken2 = default(CancellationToken);
		Action<object> action = default(Action<object>);
		object obj = default(object);
		base._002Ector(periodic, playerLoopTiming, cancellationToken2, action, obj);
		object obj2 = default(object);
		ResetCore((TimeSpan?)(object)(&obj2));
	}

	protected unsafe override bool MoveNextCore()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_002c: Expected O, but got I8
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected I8, but got Unknown
		ValueStopwatch valueStopwatch = (ValueStopwatch)(this + 48);
		long elapsedTicks = ((ValueStopwatch*)valueStopwatch)->ElapsedTicks;
		object obj = elapsedTicks - intervalTicks;
		long num = elapsedTicks ^ intervalTicks;
		long num2 = elapsedTicks ^ obj;
		long num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 != flag;
	}

	protected override void ResetCore(TimeSpan? interval)
	{
		//IL_0052: Expected I8, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B21B10");
		bool flag = (object)interval == null;
		ValueStopwatch valueStopwatch = default(ValueStopwatch);
		stopwatch = valueStopwatch;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [interval @ rdx (System.Nullable`1<System.TimeSpan>)+8]");
			intervalTicks = 0L;
		}
	}
}
