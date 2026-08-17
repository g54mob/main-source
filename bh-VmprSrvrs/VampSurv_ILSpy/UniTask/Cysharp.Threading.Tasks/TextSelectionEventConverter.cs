using System;
using System.Reflection;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace Cysharp.Threading.Tasks;

internal class TextSelectionEventConverter : UnityEvent<(string, int, int)>, IDisposable
{
	private readonly UnityEvent<string, int, int> innerEvent;

	private readonly UnityAction<string, int, int> invokeDelegate;

	public TextSelectionEventConverter(UnityEvent<string, int, int> unityEvent)
	{
		//IL_006d: Expected O, but got I
		_ = 0;
		base._002Ector();
		innerEvent = unityEvent;
		UnityAction<string, int, int> unityAction = InvokeCore;
		invokeDelegate = unityAction;
		UnityEvent<string, int, int> unityEvent2 = innerEvent;
		UnityEngine.Events.BaseInvokableCall baseInvokableCall = UnityEvent<string, int, int>.GetDelegate(invokeDelegate);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rbx_v3 (UnityEngine.Events.UnityEvent`3<System.String, System.Int32, System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A5D0D0");
		_ = 1;
	}

	private unsafe void InvokeCore(string item1, int item2, int item3)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		Invoke(((string, int, int))(&obj));
	}

	public void Dispose()
	{
		//IL_0049: Expected O, but got I
		//IL_0049: Expected O, but got I
		UnityEvent<string, int, int> unityEvent = innerEvent;
		UnityAction<string, int, int> unityAction = invokeDelegate;
		MethodInfo methodImpl = ((MulticastDelegate)invokeDelegate).GetMethodImpl();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdi_v1 (UnityEngine.Events.UnityEvent`3<System.String, System.Int32, System.Int32>)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v3 (UnityEngine.Events.UnityAction`3<System.String, System.Int32, System.Int32>)+20]");
		((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
	}
}
