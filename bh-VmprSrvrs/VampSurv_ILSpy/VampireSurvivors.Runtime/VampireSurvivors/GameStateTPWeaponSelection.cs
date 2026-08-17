using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors;

public class GameStateTPWeaponSelection : GameStateMachineState
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
	}

	private void Complete()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48C1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	public GameStateTPWeaponSelection()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
