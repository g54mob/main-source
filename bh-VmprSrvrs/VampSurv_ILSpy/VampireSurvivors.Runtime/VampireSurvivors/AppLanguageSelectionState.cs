using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class AppLanguageSelectionState : AppStateMachineState
{
	public override void OnEnter()
	{
		//IL_000a: Expected I, but got O
		//IL_00d3: Expected O, but got I4
		//IL_00d3: Expected O, but got I
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_0153: Expected O, but got I
		base.OnEnter();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v2 (Il2CppClass<VampireSurvivors.AppLanguageSelectionState>)+1B0]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v2 (Il2CppClass<VampireSurvivors.AppLanguageSelectionState>)+1B0]");
		action._002Ector(this, (IntPtr)0);
		BackButtonController.AddListener(action);
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action2 = LanguageSelected;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action3 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.LanguageSelectedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.LanguageSelectedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = appStateMachine.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v18 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0B80");
	}

	public override void OnExit()
	{
		//IL_000a: Expected I, but got O
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		base.OnExit();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v2 (Il2CppClass<VampireSurvivors.AppLanguageSelectionState>)+1B0]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r8_v2 (Il2CppClass<VampireSurvivors.AppLanguageSelectionState>)+1B0]");
		action._002Ector(this, (IntPtr)0);
		BackButtonController.TryRemoveListener(action);
		AppStateMachine appStateMachine = base.appStateMachine;
		Action token = LanguageSelected;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		appStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
	}

	protected override void GoBack()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4294]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("RETURN_TO_OPTIONS");
		GameEventMessage.SendEvent("RETURN_TO_OPTIONS");
	}

	private void LanguageSelected()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4295]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("RETURN_TO_OPTIONS");
		GameEventMessage.SendEvent("RETURN_TO_OPTIONS");
	}

	public AppLanguageSelectionState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
