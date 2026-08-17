using System;
using Cpp2ILInjected;
using Doozy.Engine;
using Rewired;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class GameStatePaused : GameStateMachineState
{
	private bool _enteredThisFrame;

	public override void OnEnter()
	{
		//IL_0121: Expected O, but got I4
		//IL_0121: Expected O, but got I
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_0609: Expected O, but got I
		//IL_01e3: Expected O, but got I4
		//IL_01e3: Expected O, but got I
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_0640: Expected O, but got I
		GameManager core = GM.Core;
		core._003CIsInPauseGameState_003Ek__BackingField = true;
		GameManager core2 = GM.Core;
		if (!core2._multiplayer.IsOnlineMultiplayer)
		{
			GameStateMachine gameStateMachine = _gameStateMachine;
			gameStateMachine._003CGameplayManager_003Ek__BackingField.PauseGame();
		}
		else
		{
			OnlineStageManager._instance.SendFreezeMyPlayer(freeze: true);
		}
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action = ReturnToGame;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.BackButtonPressedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.BackButtonPressedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = gameStateMachine2.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v18 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action3 = ReturnToGame;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.SummonWhiteHandSignal>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.SummonWhiteHandSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = gameStateMachine3.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v34 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action action5 = QuitGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004010");
		GameStateMachine gameStateMachine5 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action6 = null;
		((GameStatePaused)(object)action6).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStatePaused)(object)gameStateMachine5.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action6);
		GameStateMachine gameStateMachine6 = _gameStateMachine;
		Action action7 = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8BB0");
		GameStateMachine gameStateMachine7 = _gameStateMachine;
		Action<GameplaySignals.CharacterDiedSignal> action8 = null;
		((GameStatePaused)(object)action8).PlayerDied((GameplaySignals.CharacterDiedSignal)this);
		((GameStatePaused)(object)gameStateMachine7.SignalBus).PlayerDied((GameplaySignals.CharacterDiedSignal)action8);
		GameStateMachine gameStateMachine8 = _gameStateMachine;
		Action action9 = LevelUp;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA93F0");
		GameStateMachine gameStateMachine9 = _gameStateMachine;
		Action action10 = OpenTreasure;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9570");
		GameStateMachine gameStateMachine10 = _gameStateMachine;
		Action action11 = FoundNewItem;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA96F0");
		GameStateMachine gameStateMachine11 = _gameStateMachine;
		Action action12 = FoundNewCharacter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9870");
		GameStateMachine gameStateMachine12 = _gameStateMachine;
		Action action13 = ShowWeaponSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA99F0");
		GameStateMachine gameStateMachine13 = _gameStateMachine;
		Action action14 = ShowMerchant;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9B70");
		GameStateMachine gameStateMachine14 = _gameStateMachine;
		Action action15 = ShowHealer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9CF0");
		GameStateMachine gameStateMachine15 = _gameStateMachine;
		Action action16 = ShowInitialArcanaSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9E70");
		GameStateMachine gameStateMachine16 = _gameStateMachine;
		Action action17 = ShowSurvarotsSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9FF0");
		GameStateMachine gameStateMachine17 = _gameStateMachine;
		Action action18 = ShowDirector;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA170");
		GameStateMachine gameStateMachine18 = _gameStateMachine;
		Action action19 = OpenPiano;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA2F0");
		GameStateMachine gameStateMachine19 = _gameStateMachine;
		Action action20 = ShowGameoverino;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA470");
		GameStateMachine gameStateMachine20 = _gameStateMachine;
		Action action21 = ShowFinalFireworks;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA5F0");
		GameStateMachine gameStateMachine21 = _gameStateMachine;
		Action action22 = ShowEndCredits;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA770");
		GameStateMachine gameStateMachine22 = _gameStateMachine;
		Action action23 = ShowLevelBonus;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA8F0");
		GameStateMachine gameStateMachine23 = _gameStateMachine;
		Action action24 = OpenTPWeaponSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAAA70");
		Debug.Log("Entered this frame");
		_enteredThisFrame = true;
	}

	public override void OnExit()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		GameManager core = GM.Core;
		core._003CIsInPauseGameState_003Ek__BackingField = false;
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
		Action action = QuitGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004490");
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action2 = null;
		((GameStatePaused)(object)action2).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStatePaused)(object)gameStateMachine4.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action2);
		GameStateMachine gameStateMachine5 = _gameStateMachine;
		Action action3 = ReturnToGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8970");
		GameStateMachine gameStateMachine6 = _gameStateMachine;
		Action<GameplaySignals.CharacterDiedSignal> action4 = null;
		((GameStatePaused)(object)action4).PlayerDied((GameplaySignals.CharacterDiedSignal)this);
		((GameStatePaused)(object)gameStateMachine6.SignalBus).PlayerDied((GameplaySignals.CharacterDiedSignal)action4);
		GameStateMachine gameStateMachine7 = _gameStateMachine;
		Action action5 = LevelUp;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAACB0");
		GameStateMachine gameStateMachine8 = _gameStateMachine;
		Action action6 = OpenTreasure;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAAD70");
		GameStateMachine gameStateMachine9 = _gameStateMachine;
		Action action7 = FoundNewItem;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAAE30");
		GameStateMachine gameStateMachine10 = _gameStateMachine;
		Action action8 = FoundNewCharacter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAAEF0");
		GameStateMachine gameStateMachine11 = _gameStateMachine;
		Action action9 = ShowWeaponSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAAFB0");
		GameStateMachine gameStateMachine12 = _gameStateMachine;
		Action action10 = ShowMerchant;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB070");
		GameStateMachine gameStateMachine13 = _gameStateMachine;
		Action action11 = ShowHealer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB130");
		GameStateMachine gameStateMachine14 = _gameStateMachine;
		Action action12 = ShowInitialArcanaSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB1F0");
		GameStateMachine gameStateMachine15 = _gameStateMachine;
		Action action13 = ShowSurvarotsSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB2B0");
		GameStateMachine gameStateMachine16 = _gameStateMachine;
		Action action14 = ShowDirector;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB370");
		GameStateMachine gameStateMachine17 = _gameStateMachine;
		Action action15 = OpenPiano;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB430");
		GameStateMachine gameStateMachine18 = _gameStateMachine;
		Action action16 = ShowGameoverino;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB4F0");
		GameStateMachine gameStateMachine19 = _gameStateMachine;
		Action action17 = ShowFinalFireworks;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB5B0");
		GameStateMachine gameStateMachine20 = _gameStateMachine;
		Action action18 = ShowEndCredits;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB670");
		GameStateMachine gameStateMachine21 = _gameStateMachine;
		Action action19 = ShowLevelBonus;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB730");
		GameStateMachine gameStateMachine22 = _gameStateMachine;
		Action action20 = OpenTPWeaponSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB7F0");
	}

	public void Update()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		if ((object)_gameStateMachine == null || ((UnityEngine.Object)gameStateMachine).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		if (gameStateMachine2._003CPlayer_003Ek__BackingField == null)
		{
			return;
		}
		GameManager gameManager = gameStateMachine2._003CGameplayManager_003Ek__BackingField;
		if ((object)gameStateMachine2._003CGameplayManager_003Ek__BackingField == null || ((UnityEngine.Object)gameManager).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		GameManager gameManager2 = gameStateMachine3._003CGameplayManager_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterController = gameManager2._003CPausingPlayer_003Ek__BackingField;
		if ((object)gameManager2._003CPausingPlayer_003Ek__BackingField == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (!_enteredThisFrame)
		{
			GameStateMachine gameStateMachine4 = _gameStateMachine;
			GameManager gameManager3 = gameStateMachine4._003CGameplayManager_003Ek__BackingField;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = gameManager3._003CPausingPlayer_003Ek__BackingField;
			if (characterController2._player != null && !MultiplayerManager.s_instance.IsUIBeingBlocked && (characterController2._player.GetButtonDown(6) || characterController2._player.GetButtonDown(9) || characterController2._player.GetButtonDown(10)))
			{
				Debug.Log("Not pressed this frame");
				GameManager core = GM.Core;
				if (!core._multiplayer.IsOnlineMultiplayer)
				{
					GameStateMachine gameStateMachine5 = _gameStateMachine;
					gameStateMachine5._003CGameplayManager_003Ek__BackingField.ResumeGame();
				}
				else
				{
					OnlineStageManager._instance.SendFreezeMyPlayer(freeze: false);
				}
				parentStateMachine.FireEvent("RETURN_TO_GAME");
				GameEventMessage.SendEvent("RETURN_TO_GAME");
			}
		}
		else
		{
			_enteredThisFrame = false;
		}
	}

	private bool IsButtonPressed(Player pausingPlayer)
	{
		//IL_00ba: Expected I4, but got O
		if (MultiplayerManager.s_instance != null)
		{
			if (MultiplayerManager.s_instance.IsUIBeingBlocked)
			{
				return false;
			}
			if (pausingPlayer != null)
			{
				if (!pausingPlayer.GetButtonDown(6) && !pausingPlayer.GetButtonDown(9))
				{
					return pausingPlayer.GetButtonDown(10);
				}
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4325]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("CONNECTION_ERROR");
		GameEventMessage.SendEvent("CONNECTION_ERROR");
	}

	private void ReturnToGame()
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			GameStateMachine gameStateMachine = _gameStateMachine;
			gameStateMachine._003CGameplayManager_003Ek__BackingField.ResumeGame();
		}
		else
		{
			OnlineStageManager._instance.SendFreezeMyPlayer(freeze: false);
		}
		parentStateMachine.FireEvent("RETURN_TO_GAME");
		GameEventMessage.SendEvent("RETURN_TO_GAME");
	}

	public void QuitGame()
	{
		Debug.Log("<color=yellow>[GameStatePaused] - QuitGame FireEvent(GameStateMachine.QUIT_GAME); </color>");
		parentStateMachine.FireEvent("QUIT_GAME");
		GameEventMessage.SendEvent("QUIT_GAME");
	}

	private void PlayerDied(GameplaySignals.CharacterDiedSignal sig)
	{
		//IL_00a4: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		object obj;
		if (config._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_Solution)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			bool flag = config2._selectedChar == CharacterType.SIGMA;
			obj = 0;
			if (flag)
			{
				goto IL_00a9;
			}
		}
		FadeAudioDown(0f);
		obj = 0;
		goto IL_00a9;
		IL_00a9:
		string text;
		if ((object)sig != null)
		{
			GameStateMachine gameStateMachine = _gameStateMachine;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA09F0");
			text = "DIRECT_TO_RECAP";
		}
		else
		{
			text = "PLAYER_DIED";
		}
		parentStateMachine.FireEvent(text);
		GameEventMessage.SendEvent(text);
	}

	private void LevelUp()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4329]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		FadeAudioDown();
		parentStateMachine.FireEvent("LEVEL_UP");
		GameEventMessage.SendEvent("LEVEL_UP");
	}

	private void UnfreezePlayer()
	{
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			OnlineStageManager._instance.SendFreezeMyPlayer(freeze: false);
		}
	}

	private void ShowLevelBonus()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A432B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		FadeAudioDown();
		parentStateMachine.FireEvent("OPEN_LEVEL_BONUS_SELECTION");
		GameEventMessage.SendEvent("OPEN_LEVEL_BONUS_SELECTION");
	}

	private void FoundNewItem()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A432C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		FadeAudioDown();
		parentStateMachine.FireEvent("ITEM_FOUND");
		GameEventMessage.SendEvent("ITEM_FOUND");
	}

	private void FoundNewCharacter()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A432D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		FadeAudioDown(0f);
		parentStateMachine.FireEvent("CHARACTER_FOUND");
		GameEventMessage.SendEvent("CHARACTER_FOUND");
	}

	private void OpenPiano()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A432E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		parentStateMachine.FireEvent("OPEN_PIANO");
		GameEventMessage.SendEvent("OPEN_PIANO");
	}

	private void ShowInitialArcanaSelection()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A432F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		FadeAudioDown();
		parentStateMachine.FireEvent("SELECT_ARCANA");
		GameEventMessage.SendEvent("SELECT_ARCANA");
	}

	private void ShowSurvarotsSelection()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4330]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		FadeAudioDown();
		parentStateMachine.FireEvent("SELECT_SURVAROTS");
		GameEventMessage.SendEvent("SELECT_SURVAROTS");
	}

	private void ShowMerchant()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4331]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		FadeAudioDown();
		parentStateMachine.FireEvent("OPEN_SHOP");
		GameEventMessage.SendEvent("OPEN_SHOP");
	}

	private void ShowWeaponSelection()
	{
		UnfreezePlayer();
		FadeAudioDown();
		GameStateMachine gameStateMachine = _gameStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB8B0");
		parentStateMachine.FireEvent("OPEN_WEAPON_SELECTION");
		GameEventMessage.SendEvent("OPEN_WEAPON_SELECTION");
	}

	private void ShowHealer()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4333]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		parentStateMachine.FireEvent("OPEN_HEALER");
		GameEventMessage.SendEvent("OPEN_HEALER");
	}

	private void ShowDirector()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4334]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		parentStateMachine.FireEvent("OPEN_DIRECTOR");
		GameEventMessage.SendEvent("OPEN_DIRECTOR");
	}

	private static void FadeAudioDown(float volume = 0.2f)
	{
		if (SoundManager._003CAllowUIFades_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.FadeMusic(bgmType, volume, 500f);
		}
	}

	private void OpenTPWeaponSelection()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4336]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		parentStateMachine.FireEvent("OPEN_TP_WEAPON_SELECTION");
		GameEventMessage.SendEvent("OPEN_TP_WEAPON_SELECTION");
	}

	private void OpenTreasure()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4337]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		FadeAudioDown(0f);
		parentStateMachine.FireEvent("OPEN_TREASURE");
		GameEventMessage.SendEvent("OPEN_TREASURE");
	}

	private void ShowGameoverino()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4338]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UnfreezePlayer();
		parentStateMachine.FireEvent("SHOW_GAMEOVERINO");
		GameEventMessage.SendEvent("SHOW_GAMEOVERINO");
	}

	private void ShowFinalFireworks()
	{
		UnfreezePlayer();
		GameStateMachine gameStateMachine = _gameStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA09F0");
		parentStateMachine.FireEvent("SHOW_FINAL_FIREWORKS");
		GameEventMessage.SendEvent("SHOW_FINAL_FIREWORKS");
	}

	private void ShowEndCredits()
	{
		UnfreezePlayer();
		GameStateMachine gameStateMachine = _gameStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA09F0");
		parentStateMachine.FireEvent("PLAY_FINAL_CREDITS");
		GameEventMessage.SendEvent("PLAY_FINAL_CREDITS");
	}

	public GameStatePaused()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
