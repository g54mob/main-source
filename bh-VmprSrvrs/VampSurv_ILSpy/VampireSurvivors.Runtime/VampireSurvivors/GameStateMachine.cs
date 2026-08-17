using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class GameStateMachine : StateMachine
{
	public delegate void OnBroadcastStateChange(string eventString);

	private sealed class _003CStart_003Ed__51(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameStateMachine _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_008c: Expected I4, but got I8
			//IL_011e: Expected I4, but got O
			GameStateMachine gameStateMachine = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					_003C_003E4__this.AddTransitions();
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_010a;
				}
				_003C_003E1__state = -1;
				ReInput.PlayerHelper players = ReInput.players;
				if (players != null)
				{
					Player player = players.GetPlayer(0);
					if ((object)_003C_003E4__this != null)
					{
						gameStateMachine._003CPlayer_003Ek__BackingField = player;
						_003C_003E4__this.StartStateMachine<GameStateInitializing>();
						goto IL_010a;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_010a:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public const string INITIALIZE_GAME = "INITIALIZE_GAME";

	public const string GAME_READY = "GAME_READY";

	public const string PAUSE_GAME = "PAUSE_GAME";

	public const string RETURN_TO_GAME = "RETURN_TO_GAME";

	public const string OPEN_TREASURE = "OPEN_TREASURE";

	public const string LEVEL_UP = "LEVEL_UP";

	public const string PLAYER_DIED = "PLAYER_DIED";

	public const string GAME_OVER = "GAME_OVER";

	public const string QUIT_GAME = "QUIT_GAME";

	public const string ITEM_FOUND = "ITEM_FOUND";

	public const string RELIC_FOUND = "RELIC_FOUND";

	public const string CHARACTER_FOUND = "CHARACTER_FOUND";

	public const string REVIVE = "REVIVE";

	public const string RECAP = "RECAP";

	public const string SELECT_ARCANA = "SELECT_ARCANA";

	public const string SELECT_SURVAROTS = "SELECT_SURVAROTS";

	public const string OPEN_SHOP = "OPEN_SHOP";

	public const string DIRECT_TO_RECAP = "DIRECT_TO_RECAP";

	public const string RETURN_TO_LANDING = "RETURN_TO_LANDING";

	public const string OPEN_WEAPON_SELECTION = "OPEN_WEAPON_SELECTION";

	public const string OPEN_SKILL_SELECTION = "OPEN_SKILL_SELECTION";

	public const string OPEN_HEALER = "OPEN_HEALER";

	public const string OPEN_DIRECTOR = "OPEN_DIRECTOR";

	public const string OPEN_PIANO = "OPEN_PIANO";

	public const string PLAY_FINAL_CREDITS = "PLAY_FINAL_CREDITS";

	public const string SHOW_GAMEOVERINO = "SHOW_GAMEOVERINO";

	public const string SHOW_FINAL_FIREWORKS = "SHOW_FINAL_FIREWORKS";

	public const string OPEN_LEVEL_BONUS_SELECTION = "OPEN_LEVEL_BONUS_SELECTION";

	public const string OPEN_TP_WEAPON_SELECTION = "OPEN_TP_WEAPON_SELECTION";

	public const string CONNECTION_ERROR = "CONNECTION_ERROR";

	private OnBroadcastStateChange m_StateChange;

	public SignalBus SignalBus;

	private Player _003CPlayer_003Ek__BackingField;

	private GameManager _003CGameplayManager_003Ek__BackingField;

	private PlayerOptions _003CPlayerOptions_003Ek__BackingField;

	public Player Player
	{
		get
		{
			return _003CPlayer_003Ek__BackingField;
		}
		private set
		{
			_003CPlayer_003Ek__BackingField = value;
		}
	}

	public GameManager GameplayManager
	{
		get
		{
			return _003CGameplayManager_003Ek__BackingField;
		}
		private set
		{
			_003CGameplayManager_003Ek__BackingField = value;
		}
	}

	public PlayerOptions PlayerOptions
	{
		get
		{
			return _003CPlayerOptions_003Ek__BackingField;
		}
		private set
		{
			_003CPlayerOptions_003Ek__BackingField = value;
		}
	}

	public string CurrentStateName
	{
		get
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_00ac: Expected O, but got I
			//IL_00bc: Expected O, but got I
			StateMachineState stateMachineState = currentState;
			if ((object)currentState != null && ((UnityEngine.Object)stateMachineState).m_CachedPtr != (IntPtr)0)
			{
				StateMachineState stateMachineState2 = currentState;
				if ((object)currentState != null)
				{
					object obj = stateMachineState2 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					object obj2 = default(object);
					if (obj2 != null)
					{
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdx_v1+168]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdx_v1+170]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v151 @ r8_v1 (should have been resolved before IL gen)");
						goto IL_00c6;
					}
				}
				return (string)(object)new NullReferenceException();
			}
			goto IL_00c6;
			IL_00c6:
			return "No Active State";
		}
	}

	public event OnBroadcastStateChange StateChange
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 88;
			Delegate obj2 = this.m_StateChange;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnBroadcastStateChange);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 88;
			Delegate obj2 = this.m_StateChange;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnBroadcastStateChange);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	private void Construct(SignalBus signalBus, GameManager gameManager, PlayerOptions playerOptions)
	{
		SignalBus = signalBus;
		_003CGameplayManager_003Ek__BackingField = gameManager;
		_003CPlayerOptions_003Ek__BackingField = playerOptions;
	}

	private void Awake()
	{
		Timers.InitManagers();
	}

	private IEnumerator Start()
	{
		_003CStart_003Ed__51 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void AddTransitions()
	{
		AddStateTransition<GameStateInitializing, GameStatePlaying>("GAME_READY");
		AddStateTransition<GameStatePlaying, GameStatePaused>("PAUSE_GAME");
		AddStateTransition<GameStatePaused, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateTreasure>("OPEN_TREASURE");
		AddStateTransition<GameStatePaused, GameStateTreasure>("OPEN_TREASURE");
		AddStateTransition<GameStateTreasure, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStateTreasure, GameStateArcanaSelectionMain>("SELECT_ARCANA");
		AddStateTransition<GameStatePlaying, GameStateLevelUp>("LEVEL_UP");
		AddStateTransition<GameStatePaused, GameStateLevelUp>("LEVEL_UP");
		AddStateTransition<GameStateLevelUp, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateCharacterFound>("CHARACTER_FOUND");
		AddStateTransition<GameStatePaused, GameStateCharacterFound>("CHARACTER_FOUND");
		AddStateTransition<GameStateCharacterFound, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateItemFound>("ITEM_FOUND");
		AddStateTransition<GameStatePaused, GameStateItemFound>("ITEM_FOUND");
		AddStateTransition<GameStateItemFound, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateGameOver>("PLAYER_DIED");
		AddStateTransition<GameStatePaused, GameStateGameOver>("PLAYER_DIED");
		AddStateTransition<GameStateGameOver, GameStatePlaying>("REVIVE");
		AddStateTransition<GameStateGameOver, GameStateRecap>("RECAP");
		AddStateTransition<GameStatePlaying, GameStateArcanaSelectionMain>("SELECT_ARCANA");
		AddStateTransition<GameStatePaused, GameStateArcanaSelectionMain>("SELECT_ARCANA");
		AddStateTransition<GameStateArcanaSelectionMain, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateSurvarotsSelection>("SELECT_SURVAROTS");
		AddStateTransition<GameStatePaused, GameStateSurvarotsSelection>("SELECT_SURVAROTS");
		AddStateTransition<GameStateSurvarotsSelection, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateMerchant>("OPEN_SHOP");
		AddStateTransition<GameStatePaused, GameStateMerchant>("OPEN_SHOP");
		AddStateTransition<GameStateMerchant, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateRecap>("DIRECT_TO_RECAP");
		AddStateTransition<GameStatePaused, GameStateRecap>("DIRECT_TO_RECAP");
		AddStateTransition<GameStateRecap, GameStateInactive>("RETURN_TO_LANDING");
		AddStateTransition<GameStatePaused, GameStateRecap>("QUIT_GAME");
		AddStateTransition<GameStatePlaying, GameStateWeaponSelection>("OPEN_WEAPON_SELECTION");
		AddStateTransition<GameStatePaused, GameStateWeaponSelection>("OPEN_WEAPON_SELECTION");
		AddStateTransition<GameStateWeaponSelection, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateWeaponSelection>("OPEN_SKILL_SELECTION");
		AddStateTransition<GameStatePaused, GameStateWeaponSelection>("OPEN_SKILL_SELECTION");
		AddStateTransition<GameStatePlaying, GameStateHealer>("OPEN_HEALER");
		AddStateTransition<GameStateHealer, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateDirector>("OPEN_DIRECTOR");
		AddStateTransition<GameStatePaused, GameStateDirector>("OPEN_DIRECTOR");
		AddStateTransition<GameStateDirector, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStateDirector, GameStateItemFound>("ITEM_FOUND");
		AddStateTransition<GameStatePlaying, GameStatePiano>("OPEN_PIANO");
		AddStateTransition<GameStatePaused, GameStatePiano>("OPEN_PIANO");
		AddStateTransition<GameStatePiano, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateGameOverino>("SHOW_GAMEOVERINO");
		AddStateTransition<GameStatePaused, GameStateGameOverino>("SHOW_GAMEOVERINO");
		AddStateTransition<GameStateGameOverino, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateFinalFireworks>("SHOW_FINAL_FIREWORKS");
		AddStateTransition<GameStatePaused, GameStateFinalFireworks>("SHOW_FINAL_FIREWORKS");
		AddStateTransition<GameStateFinalFireworks, GameStateFinalCredits>("PLAY_FINAL_CREDITS");
		AddStateTransition<GameStatePlaying, GameStateFinalCredits>("PLAY_FINAL_CREDITS");
		AddStateTransition<GameStatePaused, GameStateFinalCredits>("PLAY_FINAL_CREDITS");
		AddStateTransition<GameStatePlaying, GameStateLevelBonusSelection>("OPEN_LEVEL_BONUS_SELECTION");
		AddStateTransition<GameStatePaused, GameStateLevelBonusSelection>("OPEN_LEVEL_BONUS_SELECTION");
		AddStateTransition<GameStateLevelBonusSelection, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStatePlaying, GameStateTPWeaponSelection>("OPEN_TP_WEAPON_SELECTION");
		AddStateTransition<GameStatePaused, GameStateTPWeaponSelection>("OPEN_TP_WEAPON_SELECTION");
		AddStateTransition<GameStateTPWeaponSelection, GameStatePlaying>("RETURN_TO_GAME");
		AddStateTransition<GameStateConnectionError, GameStateRecap>("RECAP");
		AddStateTransition<GameStateConnectionError, GameStateInactive>("RETURN_TO_LANDING");
		AddStateTransition<GameStateInitializing, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStatePlaying, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStatePaused, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStateHealer, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStatePiano, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStateDirector, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStateItemFound, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStateWeaponSelection, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStateMerchant, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStateArcanaSelectionMain, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStateCharacterFound, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStateLevelUp, GameStateConnectionError>("CONNECTION_ERROR");
		AddStateTransition<GameStateTreasure, GameStateConnectionError>("CONNECTION_ERROR");
	}

	public void StartGame()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A431B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.FireEvent("INITIALIZE_GAME");
	}

	public void PauseGame()
	{
		_003CGameplayManager_003Ek__BackingField.PauseGame();
	}

	public void UnpauseGame()
	{
		_003CGameplayManager_003Ek__BackingField.ResumeGame();
	}

	public void BroadcastEvent(string eventStr)
	{
		OnBroadcastStateChange stateChange = this.m_StateChange;
		if (this.m_StateChange != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}
}
