using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class AppOnlineErrorState : AppStateMachineState
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
		base.OnEnter();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = OnShowLobbyScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7050");
	}

	public override void OnExit()
	{
		base.OnExit();
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = OnShowLobbyScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7350");
	}

	private void OnShowLobbyScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A42A9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE");
		GameEventMessage.SendEvent("SHOW_ONLINE");
	}

	public AppOnlineErrorState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
