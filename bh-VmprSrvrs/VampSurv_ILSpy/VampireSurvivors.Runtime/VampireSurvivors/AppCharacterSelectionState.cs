using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class AppCharacterSelectionState : AppStateMachineState
{
	public override void Init(StateMachine stateMachine)
	{
		//IL_003e: Expected I, but got O
		base.Init(stateMachine);
		UsesBackButton = true;
		nint num = (nint)typeof(BackButtonController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v3 (Il2CppClass<VampireSurvivors.UI.BackButtonController>)+E4]");
		if ((nint)0 == 0)
		{
			BackButtonController.BackButtonClosesPage = true;
		}
		else
		{
			BackButtonController.BackButtonClosesPage = true;
		}
	}

	public override void OnEnter()
	{
		//IL_02b9: Expected O, but got I4
		//IL_02e7: Expected O, but got I4
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_004b: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_024a: Expected O, but got I4
		//IL_024a: Expected O, but got I
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0339: Expected O, but got I
		base.OnEnter();
		BackButtonController instance = BackButtonController.Instance;
		instance.ListenForControllerInput = false;
		object obj = Application.platform;
		bool flag;
		if ((nint)obj == 11)
		{
			flag = true;
		}
		else
		{
			object obj2 = Application.platform;
			object obj3 = obj2 - 8;
			bool flag2 = obj3 == null;
			flag = flag2;
		}
		bool isPortrait = UIHelper.IsPortrait;
		object obj4 = flag & isPortrait;
		bool flag3 = obj4 == null;
		object obj5 = !flag3;
		if (obj5 == null)
		{
			AppStateMachine appStateMachine = base.appStateMachine;
			MultiplayerManager multiplayer = appStateMachine.Multiplayer;
			int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
			bool allowPlayerJoining = playerCount > 1 || MultiplayerManager.s_instance.IsOnlineMultiplayer;
			multiplayer.AllowPlayerJoining = allowPlayerJoining;
			AppStateMachine appStateMachine2 = base.appStateMachine;
			MultiplayerManager multiplayer2 = appStateMachine2.Multiplayer;
			multiplayer2.AllowPlayerRemoval = true;
		}
		else
		{
			Debug.Log("Sorry, our generic employee unsubscribed from supporting mobile portrait multiplayer");
			AppStateMachine appStateMachine3 = base.appStateMachine;
			MultiplayerManager multiplayer3 = appStateMachine3.Multiplayer;
			multiplayer3.AllowPlayerJoining = false;
			AppStateMachine appStateMachine4 = base.appStateMachine;
			MultiplayerManager multiplayer4 = appStateMachine4.Multiplayer;
			multiplayer4.AllowPlayerRemoval = false;
			MultiplayerManager.s_instance.ClearAllExtraPlayers();
		}
		AppStateMachine appStateMachine5 = base.appStateMachine;
		Action action = ConfirmCharacter;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj6 = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ConfirmCharacterSignal>)obj6)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ConfirmCharacterSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = appStateMachine5.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v31 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		AppStateMachine appStateMachine6 = base.appStateMachine;
		Action action3 = ShowOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7050");
	}

	public override void OnExit()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		base.OnExit();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action token = ConfirmCharacter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		appStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action action = ShowOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7350");
		BackButtonController.BackButtonClosesPage = true;
		BackButtonController instance = BackButtonController.Instance;
		instance.ListenForControllerInput = true;
		Debug.Log("Stack");
	}

	private void ConfirmCharacter()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A427F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SELECT_STAGE");
		GameEventMessage.SendEvent("SELECT_STAGE");
	}

	private void ShowOnlineScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4280]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE");
		GameEventMessage.SendEvent("SHOW_ONLINE");
	}

	public AppCharacterSelectionState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
