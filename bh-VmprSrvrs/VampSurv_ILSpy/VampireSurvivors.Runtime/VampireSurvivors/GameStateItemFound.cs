using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class GameStateItemFound : GameStateMachineState
{
	public override void OnEnter()
	{
		//IL_009b: Expected O, but got I4
		//IL_009b: Expected O, but got I
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_0204: Expected O, but got I
		//IL_015d: Expected O, but got I4
		//IL_015d: Expected O, but got I
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_023b: Expected O, but got I
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action action = Receive;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ReceivedNewItemSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.ReceivedNewItemSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = gameStateMachine.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v13 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action3 = Discard;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.DiscardNewItemSignal>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.DiscardNewItemSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = gameStateMachine2.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v29 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action5 = null;
		((GameStateItemFound)(object)action5).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateItemFound)(object)gameStateMachine3.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action5);
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		gameStateMachine4._003CGameplayManager_003Ek__BackingField.PauseGame();
	}

	public override void OnExit()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action token = Receive;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		gameStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action token2 = Discard;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		gameStateMachine2.SignalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action = null;
		((GameStateItemFound)(object)action).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateItemFound)(object)gameStateMachine3.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action);
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		gameStateMachine4._003CGameplayManager_003Ek__BackingField.ResumeGame();
	}

	private void Receive()
	{
		ReturnToGame();
	}

	private void Discard()
	{
		ReturnToGame();
	}

	private void ReturnToGame()
	{
		if (SoundManager._003CAllowUIFades_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.FadeMusic(bgmType, 0.3f, 500f);
		}
		FireEventWithDelay("RETURN_TO_GAME", 0.15f);
	}

	private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A430E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("CONNECTION_ERROR");
		GameEventMessage.SendEvent("CONNECTION_ERROR");
	}

	public GameStateItemFound()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
