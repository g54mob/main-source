using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class GameStateFinalCredits : GameStateMachineState
{
	public override void OnEnter()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		gameStateMachine._003CGameplayManager_003Ek__BackingField.PauseGame();
	}

	public override void OnExit()
	{
	}

	public GameStateFinalCredits()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
