using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors;

public class GameStateGameOver : GameStateMachineState
{
	public override void OnEnter()
	{
		GameManager core = GM.Core;
		core._inGameOverState = true;
		GameStateMachine gameStateMachine = _gameStateMachine;
		gameStateMachine._003CGameplayManager_003Ek__BackingField.PauseGame();
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action = ShowRecap;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004190");
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action2 = Revive;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8D30");
	}

	public override void OnExit()
	{
		GameManager core = GM.Core;
		core._inGameOverState = false;
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action action = ShowRecap;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800043D0");
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action2 = Revive;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8EB0");
	}

	private void ShowRecap()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4305]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("RECAP");
		GameEventMessage.SendEvent("RECAP");
	}

	private void Revive()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		gameStateMachine._003CGameplayManager_003Ek__BackingField.ResumeGame();
		if (SoundManager._003CAllowUIFades_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.FadeMusic(bgmType, 0.3f, 500f);
		}
		parentStateMachine.FireEvent("REVIVE");
		GameEventMessage.SendEvent("REVIVE");
	}

	public GameStateGameOver()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
