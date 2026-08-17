using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors;

public class AppStateMachine : StateMachine
{
	private sealed class _003CStart_003Ed__36(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AppStateMachine _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0160: Expected I4, but got I8
			//IL_01b5: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_010a: Expected I4, but got I8
			//IL_0052: Expected I4, but got I8
			AppStateMachine appStateMachine = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_01de;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null && appStateMachine.Options != null)
					{
						PlayerOptionsData config = appStateMachine.Options.Config;
						if (config != null)
						{
							bool flag2 = !config._003CShowTPCredits_003Ek__BackingField;
							string eventStr = "SHOW_WARNING";
							if (!flag2)
							{
								eventStr = "OPEN_TPCREDITS";
							}
							_003C_003E4__this.FireEvent(eventStr);
							goto IL_01de;
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						_003C_003E4__this.StartStateMachine<AppWaitState>();
						_003C_003E2__current = null;
						_003C_003E1__state = 2;
						return true;
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					_003C_003E4__this.AddAllTransitions();
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_01de:
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

	public SignalBus SignalBus;

	public PlayerOptions Options;

	public MultiplayerManager Multiplayer;

	private static AppStateMachine _003CInstance_003Ek__BackingField;

	public static AppStateMachine Instance
	{
		get
		{
			return _003CInstance_003Ek__BackingField;
		}
		private set
		{
			_003CInstance_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		AppStateMachine appStateMachine = _003CInstance_003Ek__BackingField;
		if ((object)_003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)appStateMachine).m_CachedPtr != (IntPtr)0)
		{
			Debug.LogError("More than one AppStateMachine in scene...");
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1870B8D80");
		Timers.InitManagers();
	}

	private void OnDestroy()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1870B8D80");
	}

	private void Construct(SignalBus signal, PlayerOptions options, MultiplayerManager multi)
	{
		SignalBus = signal;
		Options = options;
		Multiplayer = multi;
	}

	private IEnumerator Start()
	{
		_003CStart_003Ed__36 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void AddAllTransitions()
	{
		AddStateTransition<AppWaitState, AppWarningState>("SHOW_WARNING");
		AddStateTransition<AppWaitState, AppTPCreditsState>("OPEN_TPCREDITS");
		AddStateTransition<AppWarningState, AppStartState>("WARNING_SHOWN");
		AddStateTransition<AppStartState, AppLandingPageState>("LANDING_SCREEN");
		AddStateTransition<AppStartState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppLandingPageState, AppMainMenuState>("MAIN_MENU");
		AddStateTransition<AppMainMenuState, AppAchievementsState>("SHOW_ACHIEVEMENTS");
		AddStateTransition<AppMainMenuState, AppCollectionState>("SHOW_COLLECTIONS");
		AddStateTransition<AppMainMenuState, AppPowerUpState>("SHOW_POWER_UPS");
		AddStateTransition<AppMainMenuState, AppCreditsState>("SHOW_CREDITS");
		AddStateTransition<AppMainMenuState, AppCharacterSelectionState>("SELECT_CHARACTER");
		AddStateTransition<AppMainMenuState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppMainMenuState, AppOptionsState>("SHOW_OPTIONS");
		AddStateTransition<AppMainMenuState, AppGameplayState>("START_GAME");
		AddStateTransition<AppMainMenuState, AppDLCStoreState>("OPEN_DLC_STORE");
		AddStateTransition<AppMainMenuState, AppAccountPageState>("OPEN_ACCOUNT_PAGE");
		AddStateTransition<AppMainMenuState, AppSelectAdventureState>("SELECT_ADVENTURE");
		AddStateTransition<AppOnlineState, AppAchievementsState>("SHOW_ACHIEVEMENTS");
		AddStateTransition<AppOnlineState, AppCollectionState>("SHOW_COLLECTIONS");
		AddStateTransition<AppOnlineState, AppPowerUpState>("SHOW_POWER_UPS");
		AddStateTransition<AppOnlineState, AppCreditsState>("SHOW_CREDITS");
		AddStateTransition<AppOnlineState, AppOptionsState>("SHOW_OPTIONS");
		AddStateTransition<AppOnlineState, AppSelectAdventureState>("SELECT_ADVENTURE");
		AddStateTransition<AppPowerUpState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppCollectionState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppAchievementsState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppCreditsState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppCharacterSelectionState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppOnlineState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppOptionsState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppSelectAdventureState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppPowerUpState, AppOnlineState>("GO_BACK_ONLINE");
		AddStateTransition<AppCollectionState, AppOnlineState>("GO_BACK_ONLINE");
		AddStateTransition<AppAchievementsState, AppOnlineState>("GO_BACK_ONLINE");
		AddStateTransition<AppCreditsState, AppOnlineState>("GO_BACK_ONLINE");
		AddStateTransition<AppOptionsState, AppOnlineState>("GO_BACK_ONLINE");
		AddStateTransition<AppSelectAdventureState, AppOnlineState>("GO_BACK_ONLINE");
		AddStateTransition<AppOptionsState, AppLanguageSelectionState>("OPEN_LANGUAGES");
		AddStateTransition<AppLanguageSelectionState, AppOptionsState>("RETURN_TO_OPTIONS");
		AddStateTransition<AppMainMenuState, AppBestiaryState>("OPEN_BESTIARY");
		AddStateTransition<AppBestiaryState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppMainMenuState, AppSecretsState>("OPEN_SECRETS");
		AddStateTransition<AppSecretsState, AppGameplayState>("START_GAME");
		AddStateTransition<AppSecretsState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppSelectAdventureState, AppOnlineLobbyState>("SHOW_ONLINE_LOBBY");
		AddStateTransition<AppCharacterSelectionState, AppStageSelectState>("SELECT_STAGE");
		AddStateTransition<AppStageSelectState, AppGameplayState>("START_GAME");
		AddStateTransition<AppStageSelectState, AppCharacterSelectionState>("SELECT_CHARACTER");
		AddStateTransition<AppStageSelectState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppStageSelectState, AppOnlineLobbyState>("GO_BACK_ONLINE");
		AddStateTransition<AppDLCStoreState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppAccountPageState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppMainMenuState, AppTPCreditsState>("OPEN_TPCREDITS");
		AddStateTransition<AppTPCreditsState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppOnlineState, AppOnlineErrorState>("ONLINE_ERROR");
		AddStateTransition<AppOnlineLobbyState, AppOnlineErrorState>("ONLINE_ERROR");
		AddStateTransition<AppOnlineErrorState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppOnlineErrorState, AppMainMenuState>("GO_BACK");
		AddStateTransition<AppOnlineState, AppOnlineLobbyState>("SHOW_ONLINE_LOBBY");
		AddStateTransition<AppOnlineLobbyState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppOnlineLobbyState, AppStageSelectState>("SELECT_STAGE");
		AddStateTransition<AppOnlineLobbyState, AppGameplayState>("START_GAME");
		AddStateTransition<AppStageSelectState, AppOnlineLobbyState>("SHOW_ONLINE_LOBBY");
		AddStateTransition<AppOnlineLobbyState, AppAchievementsState>("SHOW_ACHIEVEMENTS");
		AddStateTransition<AppOnlineLobbyState, AppCollectionState>("SHOW_COLLECTIONS");
		AddStateTransition<AppOnlineLobbyState, AppPowerUpState>("SHOW_POWER_UPS");
		AddStateTransition<AppPowerUpState, AppOnlineLobbyState>("SHOW_ONLINE_LOBBY");
		AddStateTransition<AppCollectionState, AppOnlineLobbyState>("SHOW_ONLINE_LOBBY");
		AddStateTransition<AppAchievementsState, AppOnlineLobbyState>("SHOW_ONLINE_LOBBY");
		AddStateTransition<AppCreditsState, AppOnlineLobbyState>("SHOW_ONLINE_LOBBY");
		AddStateTransition<AppOptionsState, AppOnlineLobbyState>("SHOW_ONLINE_LOBBY");
		AddStateTransition<AppAchievementsState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppBestiaryState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppCollectionState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppCreditsState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppDLCStoreState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppOptionsState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppPowerUpState, AppOnlineState>("SHOW_ONLINE");
		AddStateTransition<AppSecretsState, AppOnlineState>("SHOW_ONLINE");
		if (SkipToGame)
		{
			AddStateTransition<AppStartState, AppGameplayState>("START_GAME");
		}
	}
}
