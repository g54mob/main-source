using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors;

public class GameStatePlaying : GameStateMachineState
{
	private bool _enteredThisFrame;

	public override void OnEnter()
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_0453: Expected O, but got I
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action<GameplaySignals.GamePausedSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB960");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.GamePausedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.GamePausedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = gameStateMachine.SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v13 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action3 = LevelUp;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA93F0");
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action4 = OpenTreasure;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9570");
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action<GameplaySignals.CharacterDiedSignal> action5 = null;
		((GameStatePlaying)(object)action5).PlayerDied((GameplaySignals.CharacterDiedSignal)this);
		((GameStatePlaying)(object)gameStateMachine4.SignalBus).PlayerDied((GameplaySignals.CharacterDiedSignal)action5);
		GameStateMachine gameStateMachine5 = _gameStateMachine;
		Action action6 = FoundNewItem;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA96F0");
		GameStateMachine gameStateMachine6 = _gameStateMachine;
		Action action7 = FoundNewCharacter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9870");
		GameStateMachine gameStateMachine7 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action8 = null;
		((GameStatePlaying)(object)action8).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStatePlaying)(object)gameStateMachine7.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action8);
		GameStateMachine gameStateMachine8 = _gameStateMachine;
		Action action9 = ShowWeaponSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA99F0");
		GameStateMachine gameStateMachine9 = _gameStateMachine;
		Action action10 = ShowMerchant;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9B70");
		GameStateMachine gameStateMachine10 = _gameStateMachine;
		Action action11 = ShowHealer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9CF0");
		GameStateMachine gameStateMachine11 = _gameStateMachine;
		Action action12 = ShowInitialArcanaSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9E70");
		GameStateMachine gameStateMachine12 = _gameStateMachine;
		Action action13 = ShowSurvarotsSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA9FF0");
		GameStateMachine gameStateMachine13 = _gameStateMachine;
		Action action14 = ShowDirector;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA170");
		GameStateMachine gameStateMachine14 = _gameStateMachine;
		Action action15 = OpenPiano;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA2F0");
		GameStateMachine gameStateMachine15 = _gameStateMachine;
		Action action16 = ShowGameoverino;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA470");
		GameStateMachine gameStateMachine16 = _gameStateMachine;
		Action action17 = ShowFinalFireworks;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA5F0");
		GameStateMachine gameStateMachine17 = _gameStateMachine;
		Action action18 = ShowEndCredits;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA770");
		GameStateMachine gameStateMachine18 = _gameStateMachine;
		Action action19 = ShowLevelBonus;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAA8F0");
		GameStateMachine gameStateMachine19 = _gameStateMachine;
		Action action20 = OpenTPWeaponSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAAA70");
		_enteredThisFrame = true;
	}

	public override void OnExit()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		GameStateMachine gameStateMachine = _gameStateMachine;
		Action<GameplaySignals.GamePausedSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB960");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		gameStateMachine.SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		Action action = LevelUp;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAACB0");
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		Action action2 = OpenTreasure;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAAD70");
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		Action<GameplaySignals.CharacterDiedSignal> action3 = null;
		((GameStatePlaying)(object)action3).PlayerDied((GameplaySignals.CharacterDiedSignal)this);
		((GameStatePlaying)(object)gameStateMachine4.SignalBus).PlayerDied((GameplaySignals.CharacterDiedSignal)action3);
		GameStateMachine gameStateMachine5 = _gameStateMachine;
		Action action4 = FoundNewItem;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAAE30");
		GameStateMachine gameStateMachine6 = _gameStateMachine;
		Action action5 = FoundNewCharacter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAAEF0");
		GameStateMachine gameStateMachine7 = _gameStateMachine;
		Action<GameplaySignals.ConnectionErrorSignal> action6 = null;
		((GameStatePlaying)(object)action6).OnConnectionError((GameplaySignals.ConnectionErrorSignal)this);
		((GameStatePlaying)(object)gameStateMachine7.SignalBus).OnConnectionError((GameplaySignals.ConnectionErrorSignal)action6);
		GameStateMachine gameStateMachine8 = _gameStateMachine;
		Action action7 = ShowWeaponSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAAFB0");
		GameStateMachine gameStateMachine9 = _gameStateMachine;
		Action action8 = ShowMerchant;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB070");
		GameStateMachine gameStateMachine10 = _gameStateMachine;
		Action action9 = ShowHealer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB130");
		GameStateMachine gameStateMachine11 = _gameStateMachine;
		Action action10 = ShowInitialArcanaSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB1F0");
		GameStateMachine gameStateMachine12 = _gameStateMachine;
		Action action11 = ShowSurvarotsSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB2B0");
		GameStateMachine gameStateMachine13 = _gameStateMachine;
		Action action12 = ShowDirector;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB370");
		GameStateMachine gameStateMachine14 = _gameStateMachine;
		Action action13 = OpenPiano;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB430");
		GameStateMachine gameStateMachine15 = _gameStateMachine;
		Action action14 = ShowGameoverino;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB4F0");
		GameStateMachine gameStateMachine16 = _gameStateMachine;
		Action action15 = ShowFinalFireworks;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB5B0");
		GameStateMachine gameStateMachine17 = _gameStateMachine;
		Action action16 = ShowEndCredits;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB670");
		GameStateMachine gameStateMachine18 = _gameStateMachine;
		Action action17 = ShowLevelBonus;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB730");
		GameStateMachine gameStateMachine19 = _gameStateMachine;
		Action action18 = OpenTPWeaponSelection;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB7F0");
	}

	public unsafe void Update()
	{
		//IL_03cf: Expected O, but got Ref
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Expected O, but got Unknown
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
		if (!_enteredThisFrame)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
			MultiplayerManager multiplayerManager = default(MultiplayerManager);
			if (multiplayerManager.IsUIBeingBlocked)
			{
				return;
			}
			GameManager core = GM.Core;
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				GameStateMachine gameStateMachine3 = _gameStateMachine;
				PlayerOptionsData config = gameStateMachine3._003CPlayerOptions_003Ek__BackingField.Config;
				if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
				{
					GameManager core2 = GM.Core;
					List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core2._mainCharacters;
					if (mainCharacters._size > 0)
					{
						VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
						VampireSurvivors.Objects.Characters.CharacterController characterController = items[0];
						if (!characterController._multiplayerRevivalUI.IsVisible())
						{
							goto IL_03af;
						}
						GameManager core3 = GM.Core;
						List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = core3._mainCharacters;
						if (mainCharacters2._size > 0)
						{
							VampireSurvivors.Objects.Characters.CharacterController[] items2 = mainCharacters2._items;
							VampireSurvivors.Objects.Characters.CharacterController characterController2 = items2[0];
							if (!Extensions.AnyDown(characterController2._player))
							{
								goto IL_03af;
							}
							while (true)
							{
								AdvanceFreeRoamCameraTarget();
								GameManager core4 = GM.Core;
								List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters3 = core4._mainCharacters;
								GameManager core5 = GM.Core;
								int num = core5._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField;
								if (core5._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField >= mainCharacters3._size)
								{
									break;
								}
								VampireSurvivors.Objects.Characters.CharacterController[] items3 = mainCharacters3._items;
								if (items3[num].IsDisconnectedFromOnlinePlay)
								{
									continue;
								}
								goto IL_02e6;
							}
						}
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					throw new NullReferenceException();
				}
			}
			goto IL_03af;
		}
		_enteredThisFrame = false;
		return;
		IL_03af:
		GameManager core6 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return;
		IL_02e6:
		GameStateMachine gameStateMachine4 = _gameStateMachine;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1382 @ rbx_v18 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1399 @ rbx_v19 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		gameStateMachine4.SignalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		goto IL_03af;
	}

	private bool ChangePlayerSpectate()
	{
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
		if (mainCharacters._size > 0)
		{
			VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
			VampireSurvivors.Objects.Characters.CharacterController characterController = items[0];
			return Extensions.AnyDown(characterController._player);
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	private bool IsSpectateModeActive()
	{
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			GameStateMachine gameStateMachine = _gameStateMachine;
			PlayerOptionsData config = gameStateMachine._003CPlayerOptions_003Ek__BackingField.Config;
			if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
			{
				GameManager core2 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core2._mainCharacters;
				if (mainCharacters._size > 0)
				{
					VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
					VampireSurvivors.Objects.Characters.CharacterController characterController = items[0];
					return characterController._multiplayerRevivalUI.IsVisible();
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				bool result = default(bool);
				return result;
			}
		}
		return false;
	}

	private bool IsPlayerProperTarget()
	{
		GameManager core = GM.Core;
		GameManager core2 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
		int num = core2._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField;
		if (core2._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField < mainCharacters._size)
		{
			VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
			bool isDisconnectedFromOnlinePlay = items[num].IsDisconnectedFromOnlinePlay;
			return (byte)((isDisconnectedFromOnlinePlay ? 1u : 0u) ^ 1u) != 0;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	private void AdvanceFreeRoamCameraTarget()
	{
		GameManager core = GM.Core;
		int num = core._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField + 1;
		core._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField = num;
		GameManager core2 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core2._mainCharacters;
		GameManager core3 = GM.Core;
		if (mainCharacters._size <= core3._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField)
		{
			GameManager core4 = GM.Core;
			core4._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField = 0;
		}
	}

	private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4342]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("CONNECTION_ERROR");
		GameEventMessage.SendEvent("CONNECTION_ERROR");
	}

	private void PauseGame(GameplaySignals.GamePausedSignal signal)
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		GameManager gameManager = gameStateMachine._003CGameplayManager_003Ek__BackingField;
		if (!gameManager._003CCanPause_003Ek__BackingField || gameManager._003CFreezingFrame_003Ek__BackingField)
		{
			return;
		}
		GameplaySignals.GamePausedSignal gamePausedSignal;
		if ((object)signal != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+GamePausedSignal)+10]");
			bool flag = (nint)0 != 0;
			gamePausedSignal = signal;
			if (flag)
			{
				goto IL_00bd;
			}
		}
		VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
		gamePausedSignal = (GameplaySignals.GamePausedSignal)playerOne;
		goto IL_00bd;
		IL_00bd:
		GameStateMachine gameStateMachine2 = _gameStateMachine;
		GameManager gameManager2 = gameStateMachine2._003CGameplayManager_003Ek__BackingField;
		gameManager2._003CPausingPlayer_003Ek__BackingField = (VampireSurvivors.Objects.Characters.CharacterController)gamePausedSignal;
		GameStateMachine gameStateMachine3 = _gameStateMachine;
		gameStateMachine3._003CGameplayManager_003Ek__BackingField.OverrideLatestUIPlayer((VampireSurvivors.Objects.Characters.CharacterController)gamePausedSignal);
		parentStateMachine.FireEvent("PAUSE_GAME");
		GameEventMessage.SendEvent("PAUSE_GAME");
	}

	private void OpenTreasure()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4344]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		FadeAudioDown(0f);
		parentStateMachine.FireEvent("OPEN_TREASURE");
		GameEventMessage.SendEvent("OPEN_TREASURE");
	}

	private void ShowGameoverino()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4345]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("SHOW_GAMEOVERINO");
		GameEventMessage.SendEvent("SHOW_GAMEOVERINO");
	}

	private void ShowFinalFireworks()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA09F0");
		parentStateMachine.FireEvent("SHOW_FINAL_FIREWORKS");
		GameEventMessage.SendEvent("SHOW_FINAL_FIREWORKS");
	}

	private void ShowEndCredits()
	{
		GameStateMachine gameStateMachine = _gameStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA09F0");
		parentStateMachine.FireEvent("PLAY_FINAL_CREDITS");
		GameEventMessage.SendEvent("PLAY_FINAL_CREDITS");
	}

	private void LevelUp()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4348]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		FadeAudioDown();
		parentStateMachine.FireEvent("LEVEL_UP");
		GameEventMessage.SendEvent("LEVEL_UP");
	}

	private void ShowLevelBonus()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4349]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		FadeAudioDown();
		parentStateMachine.FireEvent("OPEN_LEVEL_BONUS_SELECTION");
		GameEventMessage.SendEvent("OPEN_LEVEL_BONUS_SELECTION");
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

	private void FoundNewItem()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A434B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		FadeAudioDown();
		parentStateMachine.FireEvent("ITEM_FOUND");
		GameEventMessage.SendEvent("ITEM_FOUND");
	}

	private void FoundNewCharacter()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A434C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		FadeAudioDown(0f);
		parentStateMachine.FireEvent("CHARACTER_FOUND");
		GameEventMessage.SendEvent("CHARACTER_FOUND");
	}

	private void OpenPiano()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A434D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("OPEN_PIANO");
		GameEventMessage.SendEvent("OPEN_PIANO");
	}

	private void ShowInitialArcanaSelection()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A434E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		FadeAudioDown();
		parentStateMachine.FireEvent("SELECT_ARCANA");
		GameEventMessage.SendEvent("SELECT_ARCANA");
	}

	private void ShowSurvarotsSelection()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A434F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		FadeAudioDown();
		parentStateMachine.FireEvent("SELECT_SURVAROTS");
		GameEventMessage.SendEvent("SELECT_SURVAROTS");
	}

	private void ShowMerchant()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4350]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		FadeAudioDown();
		parentStateMachine.FireEvent("OPEN_SHOP");
		GameEventMessage.SendEvent("OPEN_SHOP");
	}

	private void ShowWeaponSelection()
	{
		FadeAudioDown();
		GameStateMachine gameStateMachine = _gameStateMachine;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAB8B0");
		parentStateMachine.FireEvent("OPEN_WEAPON_SELECTION");
		GameEventMessage.SendEvent("OPEN_WEAPON_SELECTION");
	}

	private void ShowHealer()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4352]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		parentStateMachine.FireEvent("OPEN_HEALER");
		GameEventMessage.SendEvent("OPEN_HEALER");
	}

	private void ShowDirector()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4353]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4355]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)parentStateMachine != null)
		{
			parentStateMachine.FireEvent("OPEN_TP_WEAPON_SELECTION");
			GameEventMessage.SendEvent("OPEN_TP_WEAPON_SELECTION");
			return;
		}
		throw new NullReferenceException();
	}

	public GameStatePlaying()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
