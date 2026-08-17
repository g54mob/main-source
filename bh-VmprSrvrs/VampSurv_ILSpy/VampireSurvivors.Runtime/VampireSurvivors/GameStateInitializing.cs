using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Signals;

namespace VampireSurvivors;

public class GameStateInitializing : GameStateMachineState
{
	public override void OnEnter()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		GameStateMachine gameStateMachine = _gameStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		gameStateMachine.SignalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action = null;
		((GameStateInitializing)(object)action).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateInitializing)(object)gameStateMachine2.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action2 = OnGameSessionInitialized;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2530");
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			GameStateMachine gameStateMachine4 = _gameStateMachine;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5BC0");
			return;
		}
		PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
		myPlayerInfo._sceneLoaded = true;
		GameManager core2 = GM.Core;
		if (core2._inOnlineErrorState)
		{
			parentStateMachine.FireEvent("CONNECTION_ERROR");
			GameEventMessage.SendEvent("CONNECTION_ERROR");
		}
	}

	public override void OnExit()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action = null;
		((GameStateInitializing)(object)action).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateInitializing)(object)gameStateMachine.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action2 = OnGameSessionInitialized;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA64D0");
	}

	private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4309]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("CONNECTION_ERROR");
		GameEventMessage.SendEvent("CONNECTION_ERROR");
	}

	private void OnGameSessionInitialized()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A430A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("GAME_READY");
		GameEventMessage.SendEvent("GAME_READY");
	}

	public GameStateInitializing()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
