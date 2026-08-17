using System;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

namespace Cysharp.Threading.Tasks;

public static class CancellationTokenSourceExtensions
{
	private static readonly Action<object> CancelCancellationTokenSourceStateDelegate;

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

	public static IDisposable CancelAfterSlim(CancellationTokenSource cts, int millisecondsDelay, DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
	{
		//IL_0018: Expected F8, but got I4
		TimeSpan interval = TimeSpan.Interval((double)millisecondsDelay, 1);
		if (cts != null)
		{
			CancellationToken token = cts.Token;
			CancellationToken cancellationToken = default(CancellationToken);
			Action<object> timerCallback = default(Action<object>);
			object state = default(object);
			return PlayerLoopTimer.StartNew(interval, periodic: false, delayType, delayTiming, cancellationToken, timerCallback, state);
		}
		return (IDisposable)new NullReferenceException();
	}

	public static IDisposable CancelAfterSlim(CancellationTokenSource cts, TimeSpan delayTimeSpan, DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming delayTiming = PlayerLoopTiming.Update)
	{
		if (cts != null)
		{
			CancellationToken token = cts.Token;
			CancellationToken cancellationToken = default(CancellationToken);
			Action<object> timerCallback = default(Action<object>);
			object state = default(object);
			return PlayerLoopTimer.StartNew(delayTimeSpan, periodic: false, delayType, delayTiming, cancellationToken, timerCallback, state);
		}
		return (IDisposable)new NullReferenceException();
	}

	public static void RegisterRaiseCancelOnDestroy(CancellationTokenSource cts, Component component)
	{
		GameObject gameObject = component.gameObject;
		AsyncDestroyTrigger asyncDestroyTrigger = (gameObject.TryGetComponent<AsyncDestroyTrigger>(out var component2) ? component2 : gameObject.AddComponent<AsyncDestroyTrigger>());
		CancellationToken cancellationToken = asyncDestroyTrigger.CancellationToken;
		CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, CancelCancellationTokenSourceStateDelegate, cts);
	}

	public static void RegisterRaiseCancelOnDestroy(CancellationTokenSource cts, GameObject gameObject)
	{
		AsyncDestroyTrigger asyncDestroyTrigger = (gameObject.TryGetComponent<AsyncDestroyTrigger>(out var component) ? component : gameObject.AddComponent<AsyncDestroyTrigger>());
		CancellationToken cancellationToken = asyncDestroyTrigger.CancellationToken;
		CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, CancelCancellationTokenSourceStateDelegate, cts);
	}

	static CancellationTokenSourceExtensions()
	{
		Action<object> cancelCancellationTokenSourceStateDelegate = CancelCancellationTokenSourceState;
		CancelCancellationTokenSourceStateDelegate = cancelCancellationTokenSourceStateDelegate;
	}
}
