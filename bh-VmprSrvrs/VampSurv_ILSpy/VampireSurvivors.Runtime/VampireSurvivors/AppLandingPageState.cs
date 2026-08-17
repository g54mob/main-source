using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class AppLandingPageState : AppStateMachineState
{
	public override void OnEnter()
	{
		//IL_009b: Expected O, but got I4
		//IL_009b: Expected O, but got I
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_0154: Expected O, but got I
		base.OnEnter();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = ProgressToMainMenu;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.LandingScreenCompletedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.LandingScreenCompletedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = appStateMachine.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v14 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		AppStateMachine appStateMachine2 = base.appStateMachine;
		MultiplayerManager multiplayer = appStateMachine2.Multiplayer;
		multiplayer.AllowPlayerJoining = false;
		AppStateMachine appStateMachine3 = base.appStateMachine;
		MultiplayerManager multiplayer2 = appStateMachine3.Multiplayer;
		multiplayer2.AllowPlayerRemoval = true;
	}

	public override void OnExit()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		base.OnExit();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action token = ProgressToMainMenu;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		appStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
	}

	public void ProgressToMainMenu()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4291]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("MAIN_MENU");
		GameEventMessage.SendEvent("MAIN_MENU");
	}

	public AppLandingPageState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
