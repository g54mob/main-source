using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncAwakeTrigger : AsyncTriggerBase<AsyncUnit>
{
	public unsafe UniTask AwakeAsync()
	{
		//IL_0096: Expected native int or pointer, but got O
		//IL_0048: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.Triggers.AsyncAwakeTrigger)+38]");
		UniTask uniTask = default(UniTask);
		if ((nint)0 == 0)
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

	public AsyncAwakeTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
