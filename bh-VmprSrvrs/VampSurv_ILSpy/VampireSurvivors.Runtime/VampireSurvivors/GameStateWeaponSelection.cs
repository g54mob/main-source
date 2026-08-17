using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;

namespace VampireSurvivors;

public class GameStateWeaponSelection : GameStateMachineState
{
	public override void OnEnter()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		gameStateMachine._003CGameplayManager_003Ek__BackingField.PauseGame();
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action = Complete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC1A0");
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action2 = Complete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC320");
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action action3 = Complete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC4A0");
		GameStateMachine gameStateMachine5 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action4 = null;
		((GameStateWeaponSelection)(object)action4).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateWeaponSelection)(object)gameStateMachine5.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action4);
		GameStateMachine gameStateMachine6 = _gameStateMachine;
		Action action5 = Complete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8BB0");
	}

	public override void OnExit()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		gameStateMachine._003CGameplayManager_003Ek__BackingField.ResumeGame();
		if (SoundManager._003CAllowUIFades_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.FadeMusic(bgmType, 0.3f, 500f);
		}
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action = Complete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC620");
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action2 = Complete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC6E0");
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action action3 = Complete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC7A0");
		GameStateMachine gameStateMachine5 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action4 = null;
		((GameStateWeaponSelection)(object)action4).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateWeaponSelection)(object)gameStateMachine5.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action4);
		GameStateMachine gameStateMachine6 = _gameStateMachine;
		Action action5 = Complete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8970");
	}

	private void Complete()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48C9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48CA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("CONNECTION_ERROR");
		GameEventMessage.SendEvent("CONNECTION_ERROR");
	}

	public GameStateWeaponSelection()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
