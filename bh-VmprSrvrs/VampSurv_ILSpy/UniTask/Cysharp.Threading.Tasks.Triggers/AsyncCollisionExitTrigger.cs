using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncCollisionExitTrigger : AsyncTriggerBase<Collision>
{
	private unsafe void OnCollisionExit(Collision coll)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(coll);
	}

	public IAsyncOnCollisionExitHandler GetOnCollisionExitAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnCollisionExitHandler GetOnCollisionExitAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<Collision> OnCollisionExitAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<Collision> asyncTriggerHandler = (AsyncTriggerHandler<Collision>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<Collision> uniTask = ((IAsyncOnCollisionExitHandler)(&obj)).OnCollisionExitAsync();
			AsyncCollisionExitTrigger asyncCollisionExitTrigger = (AsyncCollisionExitTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<Collision>)this;
		}
		return (UniTask<Collision>)new NullReferenceException();
	}

	public unsafe UniTask<Collision> OnCollisionExitAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<Collision> asyncTriggerHandler = (AsyncTriggerHandler<Collision>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<Collision> uniTask = ((IAsyncOnCollisionExitHandler)(&obj)).OnCollisionExitAsync();
			AsyncCollisionExitTrigger asyncCollisionExitTrigger = (AsyncCollisionExitTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<Collision>)this;
		}
		return (UniTask<Collision>)new NullReferenceException();
	}

	public AsyncCollisionExitTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
