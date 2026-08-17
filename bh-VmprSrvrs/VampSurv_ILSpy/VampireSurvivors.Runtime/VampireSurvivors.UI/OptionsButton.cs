using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class OptionsButton : MonoBehaviour
{
	private SignalBus signalBus;

	private void Construct(SignalBus _signal)
	{
		signalBus = _signal;
	}

	private void Start()
	{
		//IL_0085: Expected O, but got I4
		//IL_0085: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00f7: Expected O, but got I
		Action action = Hide;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowBackButtonSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ShowBackButtonSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus obj4 = signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v12 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		obj4.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = Show;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99FE0");
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		Action token = Hide;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = Show;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
	}

	private void Hide()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	private void Show()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
	}

	public OptionsButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
