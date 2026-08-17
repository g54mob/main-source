using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class AppStageSelectState : AppStateMachineState
{
	public override void Init(StateMachine stateMachine)
	{
		base.Init(stateMachine);
		AppStateMachine appStateMachine = base.appStateMachine;
		AutoSelectBackButton = false;
		appStateMachine.Multiplayer.SelectPlayerOneToControlUI();
	}

	public override void OnEnter()
	{
		//IL_010c: Expected O, but got I4
		//IL_010c: Expected O, but got I
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_02ad: Expected O, but got I
		UsesBackButton = true;
		base.OnEnter();
		AppStateMachine appStateMachine = base.appStateMachine;
		MultiplayerManager multiplayer = appStateMachine.Multiplayer;
		multiplayer.AllowPlayerJoining = false;
		AppStateMachine appStateMachine2 = base.appStateMachine;
		MultiplayerManager multiplayer2 = appStateMachine2.Multiplayer;
		multiplayer2.AllowPlayerRemoval = false;
		BackButtonController instance = BackButtonController.Instance;
		instance.ListenForControllerInput = false;
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action = StageSelected;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ConfirmStageSelectionSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ConfirmStageSelectionSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = appStateMachine3.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v20 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		AppStateMachine appStateMachine4 = base.appStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA86F0");
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if (masterBridge._003CClient_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj4 = default(object);
			if (obj4 != null)
			{
				Debug.Log("[AppStageSelectState] Opening stage select for multiplayer");
				return;
			}
		}
		Debug.Log("[AppStageSelectState] Opening stage select for singleplayer");
		AppStateMachine appStateMachine5 = base.appStateMachine;
		PlayerOptionsData config = appStateMachine5.Options.Config;
		List<StageType> list = config._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v38 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		if ((nint)0 == 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
			object obj5 = default(object);
			if (obj5 == null)
			{
				AppStateMachine appStateMachine6 = base.appStateMachine;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA03B0");
			}
		}
	}

	public override void OnExit()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		base.OnExit();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action token = StageSelected;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		appStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		BackButtonController instance = BackButtonController.Instance;
		instance.ListenForControllerInput = true;
	}

	private void StageSelected()
	{
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		string text;
		if (masterBridge._003CClient_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				text = "SHOW_ONLINE_LOBBY";
				goto IL_0052;
			}
		}
		text = "START_GAME";
		goto IL_0052;
		IL_0052:
		parentStateMachine.FireEvent(text);
		GameEventMessage.SendEvent(text);
	}

	protected override void GoBack()
	{
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		string text;
		if (masterBridge._003CClient_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				text = "SHOW_ONLINE_LOBBY";
				goto IL_0052;
			}
		}
		text = "GO_BACK";
		goto IL_0052;
		IL_0052:
		parentStateMachine.FireEvent(text);
		GameEventMessage.SendEvent(text);
	}

	public AppStageSelectState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
