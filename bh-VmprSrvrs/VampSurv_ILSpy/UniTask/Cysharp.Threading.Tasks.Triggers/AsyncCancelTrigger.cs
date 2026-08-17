using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncCancelTrigger : AsyncTriggerBase<BaseEventData>, ICancelHandler, IEventSystemHandler
{
	unsafe void ICancelHandler.OnCancel(BaseEventData eventData)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(eventData);
	}

	public IAsyncOnCancelHandler GetOnCancelAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnCancelHandler GetOnCancelAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<BaseEventData> OnCancelAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<BaseEventData> asyncTriggerHandler = (AsyncTriggerHandler<BaseEventData>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<BaseEventData> uniTask = ((IAsyncOnCancelHandler)(&obj)).OnCancelAsync();
			AsyncCancelTrigger asyncCancelTrigger = (AsyncCancelTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new NullReferenceException();
	}

	public unsafe UniTask<BaseEventData> OnCancelAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<BaseEventData> asyncTriggerHandler = (AsyncTriggerHandler<BaseEventData>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<BaseEventData> uniTask = ((IAsyncOnCancelHandler)(&obj)).OnCancelAsync();
			AsyncCancelTrigger asyncCancelTrigger = (AsyncCancelTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new NullReferenceException();
	}

	public AsyncCancelTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
