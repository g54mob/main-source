using System;
using Cpp2ILInjected;
using DG.Tweening.Core;
using Doozy.Engine;
using UnityEngine;
using UnityEngine.SceneManagement;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors;

public class GameStateConnectionError : GameStateMachineState
{
	public override void OnEnter()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action action = OnGameQuit;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004010");
		GameManager core = GM.Core;
		core._Preloader.SetActive(value: false);
		GM.Core.PauseGame();
	}

	public override void OnExit()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action action = OnGameQuit;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004490");
	}

	private void OnGameQuit()
	{
		//IL_0100: Expected I, but got O
		GameManager core = GM.Core;
		if (core._isGameRunning)
		{
			Debug.Log("<color=yellow>[GameStateConnectionError] - OnGameQuit FireEvent(GameStateMachine.RECAP); </color>");
			parentStateMachine.FireEvent("RECAP");
			GameEventMessage.SendEvent("RECAP");
			return;
		}
		Debug.Log("<color=yellow>[GameStateConnectionError] - OnGameQuit FireEvent(GameStateMachine.RETURN_TO_LANDING); </color>");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v9+C0]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
		}
		GameManager core2 = GM.Core;
		core2._playerOptions.DestroyOnlineConfigs();
		StateMachine stateMachine = parentStateMachine;
		nint num = (nint)stateMachine;
		stateMachine.FireEvent("RETURN_TO_LANDING");
		GameEventMessage.SendEvent("RETURN_TO_LANDING");
		int num2 = DG.Tweening.Core.TweenManager.DespawnAll();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
		BgmType bgmType = default(BgmType);
		SoundManager.StopMusic(bgmType);
		SceneManager.LoadScene("ScenePreloader", LoadSceneMode.Additive);
	}

	public GameStateConnectionError()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
