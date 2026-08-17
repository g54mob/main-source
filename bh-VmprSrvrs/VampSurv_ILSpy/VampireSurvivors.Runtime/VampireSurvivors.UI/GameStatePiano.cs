using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class GameStatePiano : GameStateMachineState
{
	public override void OnEnter()
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_016f: Expected O, but got I
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action<UISignals.ClosePianoSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB22A0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ClosePianoSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ClosePianoSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = gameStateMachine.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v13 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action3 = null;
		((GameStatePiano)(object)action3).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStatePiano)(object)gameStateMachine2.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action3);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action4 = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8BB0");
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		gameStateMachine4._003CGameplayManager_003Ek__BackingField.PauseGame();
	}

	public override void OnExit()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action<UISignals.ClosePianoSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB22A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		gameStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action = null;
		((GameStatePiano)(object)action).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStatePiano)(object)gameStateMachine2.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action2 = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8970");
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		gameStateMachine4._003CGameplayManager_003Ek__BackingField.ResumeGame();
	}

	private void ResumeGame(UISignals.ClosePianoSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D70]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	private void ReturnToGame()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D70]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D71]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("CONNECTION_ERROR");
		GameEventMessage.SendEvent("CONNECTION_ERROR");
	}

	public GameStatePiano()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
