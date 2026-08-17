using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncApplicationPauseTrigger : AsyncTriggerBase<bool>
{
	private unsafe void OnApplicationPause(bool pauseStatus)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<bool> triggerEvent = (TriggerEvent<bool>)(this + 32);
		((TriggerEvent<bool>*)triggerEvent)->SetResult(pauseStatus);
	}

	public IAsyncOnApplicationPauseHandler GetOnApplicationPauseAsyncHandler()
	{
		AsyncTriggerHandler<bool> result = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4850");
		return result;
	}

	public IAsyncOnApplicationPauseHandler GetOnApplicationPauseAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<bool>(this, cancellationToken, callOnce: false);
	}

	public UniTask<bool> OnApplicationPauseAsync()
	{
		AsyncTriggerHandler<bool> asyncTriggerHandler = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4850");
		if (asyncTriggerHandler != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
			object obj = default(object);
			AsyncApplicationPauseTrigger asyncApplicationPauseTrigger = (AsyncApplicationPauseTrigger)obj;
			return (UniTask<bool>)this;
		}
		return (UniTask<bool>)new NullReferenceException();
	}

	public UniTask<bool> OnApplicationPauseAsync(CancellationToken cancellationToken)
	{
		//IL_0039: Expected O, but got I
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<bool> asyncTriggerHandler = new AsyncTriggerHandler<bool>((AsyncTriggerBase<bool>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
			object obj = default(object);
			AsyncApplicationPauseTrigger asyncApplicationPauseTrigger = (AsyncApplicationPauseTrigger)obj;
			return (UniTask<bool>)this;
		}
		return (UniTask<bool>)new NullReferenceException();
	}

	public AsyncApplicationPauseTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
