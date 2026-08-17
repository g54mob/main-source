using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncCollisionExit2DTrigger : AsyncTriggerBase<Collision2D>
{
	private unsafe void OnCollisionExit2D(Collision2D coll)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(coll);
	}

	public IAsyncOnCollisionExit2DHandler GetOnCollisionExit2DAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnCollisionExit2DHandler GetOnCollisionExit2DAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<Collision2D> OnCollisionExit2DAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<Collision2D> asyncTriggerHandler = (AsyncTriggerHandler<Collision2D>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<Collision2D> uniTask = ((IAsyncOnCollisionExit2DHandler)(&obj)).OnCollisionExit2DAsync();
			AsyncCollisionExit2DTrigger asyncCollisionExit2DTrigger = (AsyncCollisionExit2DTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<Collision2D>)this;
		}
		return (UniTask<Collision2D>)new NullReferenceException();
	}

	public unsafe UniTask<Collision2D> OnCollisionExit2DAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<Collision2D> asyncTriggerHandler = (AsyncTriggerHandler<Collision2D>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<Collision2D> uniTask = ((IAsyncOnCollisionExit2DHandler)(&obj)).OnCollisionExit2DAsync();
			AsyncCollisionExit2DTrigger asyncCollisionExit2DTrigger = (AsyncCollisionExit2DTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<Collision2D>)this;
		}
		return (UniTask<Collision2D>)new NullReferenceException();
	}

	public AsyncCollisionExit2DTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
