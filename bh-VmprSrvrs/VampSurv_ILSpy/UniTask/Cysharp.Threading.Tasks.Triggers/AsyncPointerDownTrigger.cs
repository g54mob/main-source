using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncPointerDownTrigger : AsyncTriggerBase<PointerEventData>, IPointerDownHandler, IEventSystemHandler
{
	unsafe void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(eventData);
	}

	public IAsyncOnPointerDownHandler GetOnPointerDownAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnPointerDownHandler GetOnPointerDownAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<PointerEventData> OnPointerDownAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<PointerEventData> asyncTriggerHandler = (AsyncTriggerHandler<PointerEventData>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<PointerEventData> uniTask = ((IAsyncOnPointerDownHandler)(&obj)).OnPointerDownAsync();
			AsyncPointerDownTrigger asyncPointerDownTrigger = (AsyncPointerDownTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new NullReferenceException();
	}

	public unsafe UniTask<PointerEventData> OnPointerDownAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<PointerEventData> asyncTriggerHandler = (AsyncTriggerHandler<PointerEventData>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<PointerEventData> uniTask = ((IAsyncOnPointerDownHandler)(&obj)).OnPointerDownAsync();
			AsyncPointerDownTrigger asyncPointerDownTrigger = (AsyncPointerDownTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<PointerEventData>)this;
		}
		return (UniTask<PointerEventData>)new NullReferenceException();
	}

	public AsyncPointerDownTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
