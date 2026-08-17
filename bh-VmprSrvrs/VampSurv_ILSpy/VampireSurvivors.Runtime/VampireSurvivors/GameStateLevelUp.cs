using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.App.Framework;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class GameStateLevelUp : GameStateMachineState
{
	public override void OnEnter()
	{
		//IL_00ca: Expected O, but got I4
		//IL_00ca: Expected O, but got I
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_02da: Expected O, but got I
		//IL_0300: Expected O, but got I4
		//IL_0213: Expected F4, but got O
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action action = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8F70");
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action2 = ReturnToGame;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action3 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.SkipLevelUpSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.SkipLevelUpSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = gameStateMachine2.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v17 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> action4 = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, action4);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action5 = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA90F0");
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action6 = null;
		((GameStateLevelUp)(object)action6).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateLevelUp)(object)gameStateMachine4.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action6);
		GameStateMachine gameStateMachine5 = _gameStateMachine;
		Action action7 = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8BB0");
		GameStateMachine gameStateMachine6 = _gameStateMachine;
		gameStateMachine6._003CGameplayManager_003Ek__BackingField.PauseGame();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = config._003CClassicMusic_003Ek__BackingField;
		SfxType sfxType = SfxType.LevelUp;
		if (!flag)
		{
			sfxType = SfxType.LevelUpB;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 0f, 10, (float)action4);
		if (TwitchIntegration._sInstance.IsTwitchOn() && TwitchIntegration._sInstance.IsTwitchWorking())
		{
			GameManager core2 = GM.Core;
			Stage stage = core2._stage;
			stage._stageEventTwitchManager.QuickHide();
		}
	}

	public override void OnExit()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action token = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		gameStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action token2 = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		gameStateMachine2.SignalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action token3 = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		gameStateMachine3.SignalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action = null;
		((GameStateLevelUp)(object)action).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStateLevelUp)(object)gameStateMachine4.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action);
		GameStateMachine gameStateMachine5 = _gameStateMachine;
		Action action2 = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8970");
		GameStateMachine gameStateMachine6 = _gameStateMachine;
		gameStateMachine6._003CGameplayManager_003Ek__BackingField.ResumeGame();
		if (TwitchIntegration._sInstance.IsTwitchOn() && TwitchIntegration._sInstance.IsTwitchWorking())
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._stageEventTwitchManager.QuickShow();
		}
	}

	private void ReturnToGame()
	{
		if (SoundManager._003CAllowUIFades_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.FadeMusic(bgmType, 0.3f, 500f);
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4315]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("CONNECTION_ERROR");
		GameEventMessage.SendEvent("CONNECTION_ERROR");
	}

	public GameStateLevelUp()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
