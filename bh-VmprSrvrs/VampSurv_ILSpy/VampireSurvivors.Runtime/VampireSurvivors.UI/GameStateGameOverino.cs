using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;

namespace VampireSurvivors.UI;

public class GameStateGameOverino : GameStateMachineState
{
	public override void OnEnter()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		gameStateMachine._003CGameplayManager_003Ek__BackingField.PauseGame();
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8D30");
	}

	public override void OnExit()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		gameStateMachine._003CGameplayManager_003Ek__BackingField.ResumeGame();
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8EB0");
	}

	private void ReturnToGame()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D69]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	public GameStateGameOverino()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
