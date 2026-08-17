using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;

namespace VampireSurvivors;

public class AppDLCStoreState : AppStateMachineState
{
	public override void Init(StateMachine stateMachine)
	{
		base.Init(stateMachine);
		UsesBackButton = true;
	}

	public override void OnEnter()
	{
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = ShowOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7050");
		base.OnEnter();
	}

	public override void OnExit()
	{
		AppStateMachine appStateMachine = base.appStateMachine;
		Action action = ShowOnlineScreen;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA7350");
		base.OnExit();
	}

	private void ShowOnlineScreen()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A428D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_ONLINE");
		GameEventMessage.SendEvent("SHOW_ONLINE");
	}

	public AppDLCStoreState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
