using System;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.App.Framework;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class GameStateTreasure : GameStateMachineState
{
	public override void OnEnter()
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_01fa: Expected O, but got I
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action<GameplaySignals.OpenTreasureCompletedSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC860");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.OpenTreasureCompletedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.OpenTreasureCompletedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = gameStateMachine.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v13 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action3 = null;
		((GameStateTreasure)(object)action3).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateTreasure)(object)gameStateMachine2.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action3);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action4 = ForceReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8BB0");
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		gameStateMachine4._003CGameplayManager_003Ek__BackingField.PauseGame();
		if (TwitchIntegration._sInstance.IsTwitchOn() && TwitchIntegration._sInstance.IsTwitchWorking())
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._stageEventTwitchManager.QuickHide();
		}
	}

	public override void OnExit()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action<GameplaySignals.OpenTreasureCompletedSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC860");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		gameStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action = null;
		((GameStateTreasure)(object)action).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateTreasure)(object)gameStateMachine2.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action2 = ForceReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8970");
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		gameStateMachine4._003CGameplayManager_003Ek__BackingField.ResumeGame();
		if (TwitchIntegration._sInstance.IsTwitchOn() && TwitchIntegration._sInstance.IsTwitchWorking())
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._stageEventTwitchManager.QuickShow();
		}
	}

	private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48C4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("CONNECTION_ERROR");
		GameEventMessage.SendEvent("CONNECTION_ERROR");
	}

	private void ReturnToGame(GameplaySignals.OpenTreasureCompletedSignal sig)
	{
		//IL_004c: Expected O, but got I4
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		if (SoundManager._003CAllowUIFades_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.FadeMusic(bgmType, 0.3f, 500f);
		}
		bool flag = sig.TreasureHeldArcanaCount <= 0;
		object obj = 0;
		if (!flag)
		{
			do
			{
				GM.Core.QueueOpenArcana(ArcanaUiType.DRAFT, sig.TreasureWinner);
				obj++;
			}
			while ((nint)obj < sig.TreasureHeldArcanaCount);
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	private void ForceReturnToGame()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48C6]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	public GameStateTreasure()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
