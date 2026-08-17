using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncSubmitTrigger : AsyncTriggerBase<BaseEventData>, ISubmitHandler, IEventSystemHandler
{
	unsafe void ISubmitHandler.OnSubmit(BaseEventData eventData)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(eventData);
	}

	public IAsyncOnSubmitHandler GetOnSubmitAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnSubmitHandler GetOnSubmitAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<BaseEventData> OnSubmitAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<BaseEventData> asyncTriggerHandler = (AsyncTriggerHandler<BaseEventData>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<BaseEventData> uniTask = ((IAsyncOnSubmitHandler)(&obj)).OnSubmitAsync();
			AsyncSubmitTrigger asyncSubmitTrigger = (AsyncSubmitTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new NullReferenceException();
	}

	public unsafe UniTask<BaseEventData> OnSubmitAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<BaseEventData> asyncTriggerHandler = (AsyncTriggerHandler<BaseEventData>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<BaseEventData> uniTask = ((IAsyncOnSubmitHandler)(&obj)).OnSubmitAsync();
			AsyncSubmitTrigger asyncSubmitTrigger = (AsyncSubmitTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new NullReferenceException();
	}

	public AsyncSubmitTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
