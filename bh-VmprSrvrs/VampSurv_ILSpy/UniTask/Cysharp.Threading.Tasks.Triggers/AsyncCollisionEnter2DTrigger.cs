using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncCollisionEnter2DTrigger : AsyncTriggerBase<Collision2D>
{
	private unsafe void OnCollisionEnter2D(Collision2D coll)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(coll);
	}

	public IAsyncOnCollisionEnter2DHandler GetOnCollisionEnter2DAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnCollisionEnter2DHandler GetOnCollisionEnter2DAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<Collision2D> OnCollisionEnter2DAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<Collision2D> asyncTriggerHandler = (AsyncTriggerHandler<Collision2D>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<Collision2D> uniTask = ((IAsyncOnCollisionEnter2DHandler)(&obj)).OnCollisionEnter2DAsync();
			AsyncCollisionEnter2DTrigger asyncCollisionEnter2DTrigger = (AsyncCollisionEnter2DTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<Collision2D>)this;
		}
		return (UniTask<Collision2D>)new NullReferenceException();
	}

	public unsafe UniTask<Collision2D> OnCollisionEnter2DAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<Collision2D> asyncTriggerHandler = (AsyncTriggerHandler<Collision2D>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<Collision2D> uniTask = ((IAsyncOnCollisionEnter2DHandler)(&obj)).OnCollisionEnter2DAsync();
			AsyncCollisionEnter2DTrigger asyncCollisionEnter2DTrigger = (AsyncCollisionEnter2DTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<Collision2D>)this;
		}
		return (UniTask<Collision2D>)new NullReferenceException();
	}

	public AsyncCollisionEnter2DTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
