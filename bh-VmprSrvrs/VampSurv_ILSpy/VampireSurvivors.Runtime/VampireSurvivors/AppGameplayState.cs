using Cpp2ILInjected;
using DG.Tweening.Core;
using Doozy.Engine;
using UnityEngine;
using UnityEngine.SceneManagement;
using VampireSurvivors.App.Scripts.Framework;
using VampireSurvivors.Framework;

namespace VampireSurvivors;

public class AppGameplayState : AppStateMachineState
{
	public override void OnEnter()
	{
		//IL_009e: Expected O, but got I4
		base.OnEnter();
		int num = DG.Tweening.Core.TweenManager.DespawnAll();
		PixelFontManager._dirty = false;
		AppStateMachine appStateMachine = base.appStateMachine;
		MultiplayerManager multiplayer = appStateMachine.Multiplayer;
		multiplayer.AllowPlayerJoining = false;
		AppStateMachine appStateMachine2 = base.appStateMachine;
		MultiplayerManager multiplayer2 = appStateMachine2.Multiplayer;
		multiplayer2.AllowPlayerRemoval = false;
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("ScenePreloader", (LoadSceneParameters)1);
	}

	public override void OnExit()
	{
		base.OnExit();
	}

	private void ReceiveGameplayStateEvent(string eventstr)
	{
		parentStateMachine.FireEvent(eventstr);
		GameEventMessage.SendEvent(eventstr);
	}

	public override void Init(StateMachine stateMachine)
	{
		UsesBackButton = true;
		base.Init(stateMachine);
	}

	public AppGameplayState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
