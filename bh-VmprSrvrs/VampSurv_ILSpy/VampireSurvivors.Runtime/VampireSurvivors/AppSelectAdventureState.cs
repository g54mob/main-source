using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class AppSelectAdventureState : AppStateMachineState
{
	public override void Init(StateMachine stateMachine)
	{
		base.Init(stateMachine);
		UsesBackButton = true;
	}

	public override void OnEnter()
	{
		base.OnEnter();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = OnShowLobbyScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6ED0");
	}

	public override void OnExit()
	{
		base.OnExit();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = OnShowLobbyScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7290");
	}

	private void OnShowLobbyScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42DF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE_LOBBY");
		GameEventMessage.SendEvent("SHOW_ONLINE_LOBBY");
	}

	protected override void GoBack()
	{
		LobbiesManager lobbiesManager = LobbiesManager;
		if (LobbiesManager != null && lobbiesManager._activeLobby != null)
		{
			if (BackButtonController.BackButtonClosesPage)
			{
				parentStateMachine.FireEvent("GO_BACK_ONLINE");
				GameEventMessage.SendEvent("GO_BACK_ONLINE");
			}
		}
		else
		{
			base.GoBack();
		}
	}

	public AppSelectAdventureState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
