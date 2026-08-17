using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncJointBreakTrigger : AsyncTriggerBase<float>
{
	private unsafe void OnJointBreak(float breakForce)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<float> triggerEvent = (TriggerEvent<float>)(this + 32);
		((TriggerEvent<float>*)triggerEvent)->SetResult(breakForce);
	}

	public IAsyncOnJointBreakHandler GetOnJointBreakAsyncHandler()
	{
		AsyncTriggerHandler<float> result = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4A90");
		return result;
	}

	public IAsyncOnJointBreakHandler GetOnJointBreakAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<float>(this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<float> OnJointBreakAsync()
	{
		//IL_0013: Expected O, but got Ref
		AsyncTriggerHandler<float> asyncTriggerHandler = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4A90");
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<float> uniTask = ((IAsyncOnJointBreakHandler)(&obj)).OnJointBreakAsync();
			AsyncJointBreakTrigger asyncJointBreakTrigger = (AsyncJointBreakTrigger)uniTask;
			return (UniTask<float>)this;
		}
		return (UniTask<float>)new NullReferenceException();
	}

	public unsafe UniTask<float> OnJointBreakAsync(CancellationToken cancellationToken)
	{
		//IL_0041: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<float> asyncTriggerHandler = new AsyncTriggerHandler<float>((AsyncTriggerBase<float>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<float> uniTask = ((IAsyncOnJointBreakHandler)(&obj)).OnJointBreakAsync();
			AsyncJointBreakTrigger asyncJointBreakTrigger = (AsyncJointBreakTrigger)uniTask;
			return (UniTask<float>)this;
		}
		return (UniTask<float>)new NullReferenceException();
	}

	public AsyncJointBreakTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
