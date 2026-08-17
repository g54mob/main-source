using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncTransformChildrenChangedTrigger : AsyncTriggerBase<AsyncUnit>
{
	private unsafe void OnTransformChildrenChanged()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		TriggerEvent<AsyncUnit> triggerEvent = (TriggerEvent<AsyncUnit>)(this + 32);
		((TriggerEvent<AsyncUnit>*)triggerEvent)->SetResult(AsyncUnit.Default);
	}

	public IAsyncOnTransformChildrenChangedHandler GetOnTransformChildrenChangedAsyncHandler()
	{
		AsyncTriggerHandler<AsyncUnit> result = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4610");
		return result;
	}

	public IAsyncOnTransformChildrenChangedHandler GetOnTransformChildrenChangedAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<AsyncUnit>(this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask OnTransformChildrenChangedAsync()
	{
		//IL_0017: Expected native int or pointer, but got O
		AsyncTriggerHandler<AsyncUnit> asyncTriggerHandler = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4610");
		if (asyncTriggerHandler != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
			UniTask uniTask = default(UniTask);
			object source = default(object);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
			return uniTask;
		}
		return (UniTask)new NullReferenceException();
	}

	public unsafe UniTask OnTransformChildrenChangedAsync(CancellationToken cancellationToken)
	{
		//IL_0017: Expected native int or pointer, but got O
		AsyncTriggerHandler<AsyncUnit> asyncTriggerHandler = new AsyncTriggerHandler<AsyncUnit>(this, cancellationToken, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
			UniTask uniTask = default(UniTask);
			object source = default(object);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
			return uniTask;
		}
		return (UniTask)new NullReferenceException();
	}

	public AsyncTransformChildrenChangedTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
