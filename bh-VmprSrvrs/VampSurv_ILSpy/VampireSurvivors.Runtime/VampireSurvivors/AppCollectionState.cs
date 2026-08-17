using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;

namespace VampireSurvivors;

public class AppCollectionState : AppStateMachineState
{
	public override void Init(StateMachine stateMachine)
	{
		base.Init(stateMachine);
		UsesBackButton = true;
	}

	public override void OnEnter()
	{
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = GoBackOnline;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6D50");
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action action2 = GoOnlineLobby;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6ED0");
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action3 = ShowOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7050");
		base.OnEnter();
	}

	public override void OnExit()
	{
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = GoBackOnline;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA71D0");
		AppStateMachine appStateMachine2 = base.appStateMachine;
		Action action2 = GoOnlineLobby;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7290");
		AppStateMachine appStateMachine3 = base.appStateMachine;
		Action action3 = ShowOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7350");
		base.OnExit();
	}

	private void GoBackOnline()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4283]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("GO_BACK_ONLINE");
		GameEventMessage.SendEvent("GO_BACK_ONLINE");
	}

	private void GoOnlineLobby()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4284]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE_LOBBY");
		GameEventMessage.SendEvent("SHOW_ONLINE_LOBBY");
	}

	private void ShowOnlineScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4285]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE");
		GameEventMessage.SendEvent("SHOW_ONLINE");
	}

	public AppCollectionState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
