using System;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

namespace Cysharp.Threading.Tasks;

public static class UniTaskCancellationExtensions
{
	public static CancellationToken GetCancellationTokenOnDestroy(MonoBehaviour monoBehaviour)
	{
		return (CancellationToken)(((object?)monoBehaviour?.destroyCancellationToken) ?? ((object)new NullReferenceException()));
	}

	public static CancellationToken GetCancellationTokenOnDestroy(GameObject gameObject)
	{
		AsyncDestroyTrigger component;
		return (CancellationToken)(((object?)(gameObject.TryGetComponent<AsyncDestroyTrigger>(out component) ? component : gameObject.AddComponent<AsyncDestroyTrigger>())?.CancellationToken) ?? ((object)new NullReferenceException()));
	}

	public static CancellationToken GetCancellationTokenOnDestroy(Component component)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		if ((object)component == null)
		{
			goto IL_00cf;
		}
		nint num = (nint)typeof(MonoBehaviour);
		nint num2 = (nint)component;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v4 (Il2CppClass<UnityEngine.MonoBehaviour>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<UnityEngine.Component>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v4 (Il2CppClass<UnityEngine.MonoBehaviour>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<UnityEngine.Component>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v11+FFFFFFF8+v42 @ rax_v6*8]");
			if (0 == (nint)typeof(MonoBehaviour))
			{
				obj3 = 1;
				goto IL_0136;
			}
		}
		obj3 = 0;
		goto IL_0136;
		IL_00cf:
		return (CancellationToken)(((object?)AsyncTriggerExtensions.GetAsyncDestroyTrigger(component)?.CancellationToken) ?? ((object)new NullReferenceException()));
		IL_0136:
		bool flag = obj3 == null;
		MonoBehaviour monoBehaviour = null;
		if (!flag)
		{
			monoBehaviour = (MonoBehaviour)component;
		}
		if ((object)monoBehaviour != null)
		{
			return monoBehaviour.destroyCancellationToken;
		}
		goto IL_00cf;
	}
}
