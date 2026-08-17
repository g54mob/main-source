using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncJointBreak2DTrigger : AsyncTriggerBase<Joint2D>
{
	private unsafe void OnJointBreak2D(Joint2D brokenJoint)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<object> triggerEvent = (TriggerEvent<object>)(this + 32);
		((TriggerEvent<object>*)triggerEvent)->SetResult(brokenJoint);
	}

	public IAsyncOnJointBreak2DHandler GetOnJointBreak2DAsyncHandler()
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, callOnce: false);
	}

	public IAsyncOnJointBreak2DHandler GetOnJointBreak2DAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<Joint2D> OnJointBreak2DAsync()
	{
		//IL_0047: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<Joint2D> asyncTriggerHandler = (AsyncTriggerHandler<Joint2D>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<Joint2D> uniTask = ((IAsyncOnJointBreak2DHandler)(&obj)).OnJointBreak2DAsync();
			AsyncJointBreak2DTrigger asyncJointBreak2DTrigger = (AsyncJointBreak2DTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<Joint2D>)this;
		}
		return (UniTask<Joint2D>)new NullReferenceException();
	}

	public unsafe UniTask<Joint2D> OnJointBreak2DAsync(CancellationToken cancellationToken)
	{
		//IL_004b: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<Joint2D> asyncTriggerHandler = (AsyncTriggerHandler<Joint2D>)(object)new AsyncTriggerHandler<object>((AsyncTriggerBase<object>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<Joint2D> uniTask = ((IAsyncOnJointBreak2DHandler)(&obj)).OnJointBreak2DAsync();
			AsyncJointBreak2DTrigger asyncJointBreak2DTrigger = (AsyncJointBreak2DTrigger)uniTask;
			_ = uniTask.source;
			return (UniTask<Joint2D>)this;
		}
		return (UniTask<Joint2D>)new NullReferenceException();
	}

	public AsyncJointBreak2DTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
