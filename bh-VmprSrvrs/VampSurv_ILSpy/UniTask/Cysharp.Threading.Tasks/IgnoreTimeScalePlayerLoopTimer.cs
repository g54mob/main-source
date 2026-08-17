using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks;

internal sealed class IgnoreTimeScalePlayerLoopTimer : PlayerLoopTimer
{
	private int initialFrame;

	private float elapsed;

	private float interval;

	public unsafe IgnoreTimeScalePlayerLoopTimer(TimeSpan interval, bool periodic, PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken, Action<object> timerCallback, object state)
	{
		//IL_0029: Expected O, but got Ref
		CancellationToken cancellationToken2 = default(CancellationToken);
		Action<object> action = default(Action<object>);
		object obj = default(object);
		base._002Ector(periodic, playerLoopTiming, cancellationToken2, action, obj);
		object obj2 = default(object);
		ResetCore((TimeSpan?)(object)(&obj2));
	}

	protected override bool MoveNextCore()
	{
		//IL_0015: Invalid comparison between F4 and I4
		//IL_0071: Expected O, but got F4
		//IL_0046: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185D4F486h\"");
		if (elapsed == 0f)
		{
			object obj = Time.frameCount;
			if (initialFrame == (nint)obj)
			{
				return true;
			}
		}
		object obj2 = Time.unscaledDeltaTime;
		bool result = elapsed < interval;
		elapsed = elapsed;
		return result;
	}

	protected override void ResetCore(TimeSpan? interval)
	{
		//IL_0039: Expected I4, but got I8
		elapsed = 0f;
		int num = (int)(PlayerLoopHelper.IsMainThread ? Time.frameCount : 4294967295L);
		bool flag = (object)interval == null;
		initialFrame = num;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,qword ptr [rdi+8]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A10160h]\"");
			this.interval = 0f;
		}
	}
}
