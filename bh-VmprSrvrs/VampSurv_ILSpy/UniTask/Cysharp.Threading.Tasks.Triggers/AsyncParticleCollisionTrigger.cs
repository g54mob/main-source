using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncParticleCollisionTrigger : AsyncTriggerBase<GameObject>
{
	private unsafe void OnParticleCollision(GameObject other)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(other);
	}

	public IAsyncOnParticleCollisionHandler GetOnParticleCollisionAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnParticleCollisionHandler GetOnParticleCollisionAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<GameObject> OnParticleCollisionAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<GameObject> asyncTriggerHandler = (AsyncTriggerHandler<GameObject>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<GameObject> uniTask = ((IAsyncOnParticleCollisionHandler)(&obj)).OnParticleCollisionAsync();
			AsyncParticleCollisionTrigger asyncParticleCollisionTrigger = (AsyncParticleCollisionTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<GameObject>)this;
		}
		return (UniTask<GameObject>)new NullReferenceException();
	}

	public unsafe UniTask<GameObject> OnParticleCollisionAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<GameObject> asyncTriggerHandler = (AsyncTriggerHandler<GameObject>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<GameObject> uniTask = ((IAsyncOnParticleCollisionHandler)(&obj)).OnParticleCollisionAsync();
			AsyncParticleCollisionTrigger asyncParticleCollisionTrigger = (AsyncParticleCollisionTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<GameObject>)this;
		}
		return (UniTask<GameObject>)new NullReferenceException();
	}

	public AsyncParticleCollisionTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
