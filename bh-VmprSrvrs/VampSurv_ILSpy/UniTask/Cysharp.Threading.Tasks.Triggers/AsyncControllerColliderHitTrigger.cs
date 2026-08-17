using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncControllerColliderHitTrigger : AsyncTriggerBase<ControllerColliderHit>
{
	private unsafe void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(hit);
	}

	public IAsyncOnControllerColliderHitHandler GetOnControllerColliderHitAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnControllerColliderHitHandler GetOnControllerColliderHitAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<ControllerColliderHit> OnControllerColliderHitAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<ControllerColliderHit> asyncTriggerHandler = (AsyncTriggerHandler<ControllerColliderHit>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<ControllerColliderHit> uniTask = ((IAsyncOnControllerColliderHitHandler)(&obj)).OnControllerColliderHitAsync();
			AsyncControllerColliderHitTrigger asyncControllerColliderHitTrigger = (AsyncControllerColliderHitTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<ControllerColliderHit>)this;
		}
		return (UniTask<ControllerColliderHit>)new NullReferenceException();
	}

	public unsafe UniTask<ControllerColliderHit> OnControllerColliderHitAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<ControllerColliderHit> asyncTriggerHandler = (AsyncTriggerHandler<ControllerColliderHit>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<ControllerColliderHit> uniTask = ((IAsyncOnControllerColliderHitHandler)(&obj)).OnControllerColliderHitAsync();
			AsyncControllerColliderHitTrigger asyncControllerColliderHitTrigger = (AsyncControllerColliderHitTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<ControllerColliderHit>)this;
		}
		return (UniTask<ControllerColliderHit>)new NullReferenceException();
	}

	public AsyncControllerColliderHitTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
