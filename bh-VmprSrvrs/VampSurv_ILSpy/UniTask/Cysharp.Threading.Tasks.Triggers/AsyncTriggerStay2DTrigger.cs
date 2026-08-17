using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncTriggerStay2DTrigger : AsyncTriggerBase<Collider2D>
{
	private unsafe void OnTriggerStay2D(Collider2D other)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(other);
	}

	public IAsyncOnTriggerStay2DHandler GetOnTriggerStay2DAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnTriggerStay2DHandler GetOnTriggerStay2DAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<Collider2D> OnTriggerStay2DAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<Collider2D> asyncTriggerHandler = (AsyncTriggerHandler<Collider2D>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<Collider2D> uniTask = ((IAsyncOnTriggerStay2DHandler)(&obj)).OnTriggerStay2DAsync();
			AsyncTriggerStay2DTrigger asyncTriggerStay2DTrigger = (AsyncTriggerStay2DTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<Collider2D>)this;
		}
		return (UniTask<Collider2D>)new NullReferenceException();
	}

	public unsafe UniTask<Collider2D> OnTriggerStay2DAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<Collider2D> asyncTriggerHandler = (AsyncTriggerHandler<Collider2D>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<Collider2D> uniTask = ((IAsyncOnTriggerStay2DHandler)(&obj)).OnTriggerStay2DAsync();
			AsyncTriggerStay2DTrigger asyncTriggerStay2DTrigger = (AsyncTriggerStay2DTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<Collider2D>)this;
		}
		return (UniTask<Collider2D>)new NullReferenceException();
	}

	public AsyncTriggerStay2DTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
