using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class GameUIHider : MonoBehaviour
{
	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private void Construct(SignalBus signal, PlayerOptions playerOptions)
	{
		_signalBus = signal;
		_playerOptions = playerOptions;
	}

	private void Start()
	{
		//IL_0085: Expected O, but got I4
		//IL_0085: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0156: Expected O, but got I
		Action<UISignals.ToggleHideGameUISignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E9F0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ToggleHideGameUISignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ToggleHideGameUISignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v12 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		PlayerOptions playerOptions = _playerOptions;
		if (playerOptions._003CIsInitialized_003Ek__BackingField)
		{
			GameObject gameObject = base.gameObject;
			PlayerOptionsData config = _playerOptions.Config;
			bool active = !config._003CHideGameUI_003Ek__BackingField;
			gameObject.SetActive(active);
		}
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Action<UISignals.ToggleHideGameUISignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E9F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
	}

	private void HandleHideGameUISignal(UISignals.ToggleHideGameUISignal signal)
	{
		GameObject gameObject = base.gameObject;
		bool active = (object)signal == null;
		gameObject.SetActive(active);
	}

	public GameUIHider()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
