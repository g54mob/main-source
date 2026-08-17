using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncStartTrigger : AsyncTriggerBase<AsyncUnit>
{
	private bool called;

	private unsafe void Start()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		called = true;
		TriggerEvent<AsyncUnit> triggerEvent = (TriggerEvent<AsyncUnit>)(this + 32);
		((TriggerEvent<AsyncUnit>*)triggerEvent)->SetResult(AsyncUnit.Default);
	}

	public unsafe UniTask StartAsync()
	{
		//IL_0090: Expected native int or pointer, but got O
		//IL_0048: Expected native int or pointer, but got O
		UniTask uniTask = default(UniTask);
		if (!called)
		{
			AsyncTriggerHandler<AsyncUnit> asyncTriggerHandler = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4610");
			if (asyncTriggerHandler != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
				object source = default(object);
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
				return uniTask;
			}
			return (UniTask)new NullReferenceException();
		}
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, (IUniTaskSource)UniTask.CompletedTask);
		return uniTask;
	}

	public AsyncStartTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
