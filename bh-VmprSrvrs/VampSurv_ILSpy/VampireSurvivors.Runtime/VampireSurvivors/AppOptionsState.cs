using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class AppOptionsState : AppStateMachineState
{
	private bool fromLanguage;

	public override void Init(StateMachine stateMachine)
	{
		base.Init(stateMachine);
		UsesBackButton = true;
		fromLanguage = false;
	}

	public override void OnEnter()
	{
		//IL_00aa: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_01bf: Expected O, but got I
		base.OnEnter();
		if (!fromLanguage)
		{
			OptionsState.LastSelectedTabIndex = 0;
		}
		AppStateMachine appStateMachine = base.appStateMachine;
		fromLanguage = false;
		Action action = OpenLanguages;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.OpenLanguagePageSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.OpenLanguagePageSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = appStateMachine.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v15 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action action3 = GoBackOnline;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6D50");
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action4 = GoOnlineLobby;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6ED0");
		AppStateMachine appStateMachine4 = base.appStateMachine;
		Action action5 = ShowOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7050");
	}

	public override void OnExit()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		base.OnExit();
		if (!fromLanguage)
		{
			OptionsState.LastSelectedTabIndex = 0;
		}
		AppStateMachine appStateMachine = base.appStateMachine;
		appStateMachine.Options.Save();
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action token = OpenLanguages;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		appStateMachine2.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action = GoBackOnline;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA71D0");
		AppStateMachine appStateMachine4 = base.appStateMachine;
		Action action2 = GoOnlineLobby;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7290");
		AppStateMachine appStateMachine5 = base.appStateMachine;
		Action action3 = ShowOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7350");
	}

	private void OpenLanguages()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42D0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		fromLanguage = true;
		parentStateMachine.FireEvent("OPEN_LANGUAGES");
		GameEventMessage.SendEvent("OPEN_LANGUAGES");
	}

	private void GoBackOnline()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42D1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("GO_BACK_ONLINE");
		GameEventMessage.SendEvent("GO_BACK_ONLINE");
	}

	private void GoOnlineLobby()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42D2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE_LOBBY");
		GameEventMessage.SendEvent("SHOW_ONLINE_LOBBY");
	}

	private void ShowOnlineScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42D3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE");
		GameEventMessage.SendEvent("SHOW_ONLINE");
	}

	public AppOptionsState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
