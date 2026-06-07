using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors
{
	public class AppStateMachine : StateMachine
	{
		[CompilerGenerated]
		private sealed class _003CStart_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AppStateMachine _003C_003E4__this;

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
			public _003CStart_003Ed__36(int _003C_003E1__state)
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

		public const string LANDING_SCREEN = "LANDING_SCREEN";

		public const string MAIN_MENU = "MAIN_MENU";

		public const string SHOW_POWER_UPS = "SHOW_POWER_UPS";

		public const string SHOW_OPTIONS = "SHOW_OPTIONS";

		public const string GO_BACK = "GO_BACK";

		public const string SHOW_ACHIEVEMENTS = "SHOW_ACHIEVEMENTS";

		public const string SHOW_COLLECTIONS = "SHOW_COLLECTIONS";

		public const string SHOW_CREDITS = "SHOW_CREDITS";

		public const string SELECT_CHARACTER = "SELECT_CHARACTER";

		public const string SHOW_ONLINE = "SHOW_ONLINE";

		public const string SHOW_ONLINE_LOBBY = "SHOW_ONLINE_LOBBY";

		public const string ONLINE_ERROR = "ONLINE_ERROR";

		public const string GO_BACK_ONLINE = "GO_BACK_ONLINE";

		public const string START_GAME = "START_GAME";

		public const string SELECT_STAGE = "SELECT_STAGE";

		public const string OPEN_LANGUAGES = "OPEN_LANGUAGES";

		public const string RETURN_TO_OPTIONS = "RETURN_TO_OPTIONS";

		public const string WARNING_SHOWN = "WARNING_SHOWN";

		public const string OPEN_BESTIARY = "OPEN_BESTIARY";

		public const string OPEN_SECRETS = "OPEN_SECRETS";

		public const string OPEN_DLC_STORE = "OPEN_DLC_STORE";

		public const string OPEN_ACCOUNT_PAGE = "OPEN_ACCOUNT_PAGE";

		public const string SELECT_ADVENTURE = "SELECT_ADVENTURE";

		public const string OPEN_TPCREDITS = "OPEN_TPCREDITS";

		public const string SHOW_WARNING = "SHOW_WARNING";

		public bool SkipToGame;

		[HideInInspector]
		public SignalBus SignalBus;

		[HideInInspector]
		public PlayerOptions Options;

		[HideInInspector]
		public MultiplayerManager Multiplayer;

		public static AppStateMachine Instance { get; private set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		[Inject]
		private void Construct(SignalBus signal, PlayerOptions options, MultiplayerManager multi)
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__36))]
		private IEnumerator Start()
		{
			return null;
		}

		private void AddAllTransitions()
		{
		}
	}
}
