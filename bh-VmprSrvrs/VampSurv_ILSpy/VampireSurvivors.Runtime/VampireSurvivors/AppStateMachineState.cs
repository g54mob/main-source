using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class AppStateMachineState : StateMachineState
{
	protected AppStateMachine appStateMachine;

	protected bool UsesBackButton;

	protected bool AutoSelectBackButton;

	public LobbiesManager LobbiesManager;

	private void Construct(LobbiesManager lobbiesManager)
	{
		LobbiesManager = lobbiesManager;
	}

	public override void Init(StateMachine stateMachine)
	{
		//IL_0164: Expected I, but got O
		//IL_001c: Expected I, but got O
		//IL_002c: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_00ad: Expected I, but got O
		//IL_00b5: Expected I, but got O
		//IL_00c5: Expected O, but got I
		//IL_0101: Expected O, but got I
		parentStateMachine = stateMachine;
		nint num = (nint)typeof(AppStateMachine);
		if ((object)stateMachine == null)
		{
			appStateMachine = (AppStateMachine)stateMachine;
			return;
		}
		nint num2 = (nint)stateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v2 (Il2CppClass<VampireSurvivors.AppStateMachine>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v2 (Il2CppClass<VampireSurvivors.StateMachine>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v2 (Il2CppClass<VampireSurvivors.AppStateMachine>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r9_v2 (Il2CppClass<VampireSurvivors.StateMachine>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v16+FFFFFFF8+v114 @ rax_v11*8]");
			if (0 == (nint)typeof(AppStateMachine))
			{
				appStateMachine = (AppStateMachine)stateMachine;
				nint num4 = (nint)typeof(AppStateMachine);
				nint num5 = (nint)stateMachine;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v7 (Il2CppClass<VampireSurvivors.AppStateMachine>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r9_v4 (Il2CppClass<VampireSurvivors.StateMachine>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v7 (Il2CppClass<VampireSurvivors.AppStateMachine>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r9_v4 (Il2CppClass<VampireSurvivors.StateMachine>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v18+FFFFFFF8+v234 @ rax_v17*8]");
					if (0 == (nint)typeof(AppStateMachine))
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
	}

	public override void OnEnter()
	{
		//IL_0063: Expected I, but got O
		if (UsesBackButton)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v1 (Il2CppClass<VampireSurvivors.AppStateMachineState>)+1B0]");
			Action b = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			BackButtonController.AddListener(b);
			AppStateMachine appStateMachine = this.appStateMachine;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA86F0");
		}
	}

	private void ShowBackButton()
	{
		//IL_000a: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v2 (Il2CppClass<VampireSurvivors.AppStateMachineState>)+1B0]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v2 (Il2CppClass<VampireSurvivors.AppStateMachineState>)+1B0]");
		action._002Ector(this, (IntPtr)0);
		BackButtonController.AddListener(action);
		AppStateMachine appStateMachine = this.appStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA86F0");
	}

	public override void OnExit()
	{
		//IL_0076: Expected I, but got O
		if (UsesBackButton)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v2 (Il2CppClass<VampireSurvivors.AppStateMachineState>)+1B0]");
			Action b = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			BackButtonController.TryRemoveListener(b);
			AppStateMachine appStateMachine = this.appStateMachine;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0C30");
		}
		PixelFontManager.ClearCache();
	}

	private void HideBackButton()
	{
		//IL_000a: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v2 (Il2CppClass<VampireSurvivors.AppStateMachineState>)+1B0]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v2 (Il2CppClass<VampireSurvivors.AppStateMachineState>)+1B0]");
		action._002Ector(this, (IntPtr)0);
		BackButtonController.TryRemoveListener(action);
		AppStateMachine appStateMachine = this.appStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0C30");
	}

	protected virtual void GoBack()
	{
		if (!BackButtonController.BackButtonClosesPage)
		{
			return;
		}
		LobbiesManager lobbiesManager = LobbiesManager;
		string text;
		if (LobbiesManager != null && lobbiesManager._activeLobby != null)
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			if ((object)OnlineStageManager._instance != null)
			{
				bool flag = ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0;
				text = "GO_BACK_ONLINE";
				if (flag)
				{
					goto IL_00a0;
				}
			}
		}
		text = "GO_BACK";
		goto IL_00a0;
		IL_00a0:
		parentStateMachine.FireEvent(text);
		GameEventMessage.SendEvent(text);
	}

	public AppStateMachineState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
