using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncAnimatorIKTrigger : AsyncTriggerBase<int>
{
	private unsafe void OnAnimatorIK(int layerIndex)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		TriggerEvent<int> triggerEvent = (TriggerEvent<int>)(this + 32);
		((TriggerEvent<int>*)triggerEvent)->SetResult(layerIndex);
	}

	public IAsyncOnAnimatorIKHandler GetOnAnimatorIKAsyncHandler()
	{
		AsyncTriggerHandler<int> result = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4730");
		return result;
	}

	public IAsyncOnAnimatorIKHandler GetOnAnimatorIKAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<int>(this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<int> OnAnimatorIKAsync()
	{
		//IL_0013: Expected O, but got Ref
		AsyncTriggerHandler<int> asyncTriggerHandler = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4730");
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<int> uniTask = ((IAsyncOnAnimatorIKHandler)(&obj)).OnAnimatorIKAsync();
			AsyncAnimatorIKTrigger asyncAnimatorIKTrigger = (AsyncAnimatorIKTrigger)uniTask;
			return (UniTask<int>)this;
		}
		return (UniTask<int>)new NullReferenceException();
	}

	public unsafe UniTask<int> OnAnimatorIKAsync(CancellationToken cancellationToken)
	{
		//IL_0041: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<int> asyncTriggerHandler = new AsyncTriggerHandler<int>((AsyncTriggerBase<int>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<int> uniTask = ((IAsyncOnAnimatorIKHandler)(&obj)).OnAnimatorIKAsync();
			AsyncAnimatorIKTrigger asyncAnimatorIKTrigger = (AsyncAnimatorIKTrigger)uniTask;
			return (UniTask<int>)this;
		}
		return (UniTask<int>)new NullReferenceException();
	}

	public AsyncAnimatorIKTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
