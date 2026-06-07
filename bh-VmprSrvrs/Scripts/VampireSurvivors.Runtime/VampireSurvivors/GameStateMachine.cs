using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors
{
	public class GameStateMachine : StateMachine
	{
		public delegate void OnBroadcastStateChange(string eventString);

		[CompilerGenerated]
		private sealed class _003CStart_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameStateMachine _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CStart_003Ed__51(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
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

		[HideInInspector]
		public SignalBus SignalBus;

		public Player Player { get; private set; }

		public GameManager GameplayManager { get; private set; }

		public PlayerOptions PlayerOptions { get; private set; }

		public string CurrentStateName => null;

		public event OnBroadcastStateChange StateChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Inject]
		private void Construct(SignalBus signalBus, GameManager gameManager, PlayerOptions playerOptions)
		{
		}

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__51))]
		private IEnumerator Start()
		{
			return null;
		}

		private void AddTransitions()
		{
		}

		public void StartGame()
		{
		}

		public void PauseGame()
		{
		}

		public void UnpauseGame()
		{
		}

		public void BroadcastEvent(string eventStr)
		{
		}
	}
}
