using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncUpdateSelectedTrigger : AsyncTriggerBase<BaseEventData>, IUpdateSelectedHandler, IEventSystemHandler
{
	unsafe void IUpdateSelectedHandler.OnUpdateSelected(BaseEventData eventData)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(eventData);
	}

	public IAsyncOnUpdateSelectedHandler GetOnUpdateSelectedAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnUpdateSelectedHandler GetOnUpdateSelectedAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<BaseEventData> OnUpdateSelectedAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<BaseEventData> asyncTriggerHandler = (AsyncTriggerHandler<BaseEventData>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<BaseEventData> uniTask = ((IAsyncOnUpdateSelectedHandler)(&obj)).OnUpdateSelectedAsync();
			AsyncUpdateSelectedTrigger asyncUpdateSelectedTrigger = (AsyncUpdateSelectedTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new NullReferenceException();
	}

	public unsafe UniTask<BaseEventData> OnUpdateSelectedAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<BaseEventData> asyncTriggerHandler = (AsyncTriggerHandler<BaseEventData>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<BaseEventData> uniTask = ((IAsyncOnUpdateSelectedHandler)(&obj)).OnUpdateSelectedAsync();
			AsyncUpdateSelectedTrigger asyncUpdateSelectedTrigger = (AsyncUpdateSelectedTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<BaseEventData>)this;
		}
		return (UniTask<BaseEventData>)new NullReferenceException();
	}

	public AsyncUpdateSelectedTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
