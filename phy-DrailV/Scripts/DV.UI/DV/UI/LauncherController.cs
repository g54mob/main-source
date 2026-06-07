using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using DV.Common;
using DV.Localization;
using DV.Scenarios.Common;
using DV.UI.PresetEditors;
using DV.UIFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI
{
	public class LauncherController : AUIController
	{
		public delegate void UpdateRequest(LauncherController launcherController);

		private static readonly IFormatProvider AmericanCulture = CultureInfo.CreateSpecificCulture("en-US");

		private ISaveGame saveGame;

		private UIStartGameData startGameData;

		private AUserProfileProvider userProvider;

		private AScenarioProvider scenarioProvider;

		private UpdateRequest updateCallback;

		private const string LAUNCHER_START_NEW_CAREER = "launcher/start_new_career";

		private const string LAUNCHER_START_NEW_SANDBOX = "launcher/start_new_sandbox";

		private const string LAUNCHER_CONTINUE_SESSION = "launcher/continue_session";

		private const string LAUNCHER_SAVE_NAME = "launcher/save_name";

		private const string LAUNCHER_SAVE_TYPE = "launcher/save_type";

		private const string LAUNCHER_GAME_MODE = "launcher/game_mode";

		private const string LAUNCHER_DIFFICULTY = "launcher/difficulty";

		private const string LAUNCHER_TIMESTAMP = "launcher/timestamp";

		private const string LAUNCHER_SESSION_NAME = "launcher/session_name";

		private const string LAUNCHER_SCENARIO = "launcher/scenario";

		private const string LAUNCHER_STARTING_TRACK = "launcher/starting_track";

		private const string LAUNCHER_DESTINATION_TRACK = "launcher/destination_track";

		private const string LAUNCHER_IN_GAME_DATE = "launcher/in_game_date";

		private const string LAUNCHER_IN_GAME_TIME_PASSED = "launcher/in_game_time_passed";

		private const string LAUNCHER_CASH = "launcher/cash";

		private const string LAUNCHER_FEE_DEBT = "launcher/fee_debt";

		private const string LAUNCHER_LICENSES_UNLOCKED = "launcher/licenses_unlocked";

		private const string LAUNCHER_ORDERS_ACTIVE = "launcher/orders_active";

		private const string LAUNCHER_SESSION_OLDEST_SAVE = "launcher/session_start_date";

		private const string LAUNCHER_CORRUPT_SAVE = "launcher/corrupt_save";

		[NullCheck]
		public Button runButton;

		[NullCheck]
		public TextMeshProUGUI headerTMPro;

		[NullCheck]
		public TextMeshProUGUI detailsTMPro;

		[NullCheck]
		public SaveThumbnailViewer thumbnail;

		[NullCheck]
		public Texture2D newCareerImage;

		[NullCheck]
		public Texture2D newSandboxImage;

		public event Action<UIStartGameData> StartNewRequested;

		public event Action<ISaveGame> ContinueGameRequested;

		public void SetData(ISaveGame saveGame, AUserProfileProvider userProvider, AScenarioProvider scenarioProvider, UpdateRequest updateCallback)
		{
			startGameData = null;
			this.saveGame = saveGame;
			this.userProvider = userProvider;
			this.scenarioProvider = scenarioProvider;
			this.updateCallback = updateCallback;
			RefreshInterface();
		}

		public void SetData(UIStartGameData startGameData, AUserProfileProvider userProvider, AScenarioProvider scenarioProvider, UpdateRequest updateCallback)
		{
			saveGame = null;
			this.startGameData = startGameData;
			this.userProvider = userProvider;
			this.scenarioProvider = scenarioProvider;
			this.updateCallback = updateCallback;
			RefreshInterface();
		}

		private void OnEnable()
		{
			SetupListeners(on: true);
			if ((saveGame == null && startGameData == null) || (saveGame != null && (!saveGame.ParentSession.Saves.Contains(saveGame) || !saveGame.ParentSession.Owner.Sessions.Any((KeyValuePair<string, ReadOnlyObservableCollection<IGameSession>> kvp) => kvp.Value.Contains(saveGame.ParentSession)) || userProvider.GetCurrentProfile() != saveGame.ParentSession.Owner)))
			{
				updateCallback?.Invoke(this);
			}
			RefreshInterface();
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				runButton.onClick.AddListener(OnRunClicked);
			}
			else
			{
				runButton.onClick.RemoveListener(OnRunClicked);
			}
		}

		private void OnRunClicked()
		{
			if (startGameData != null)
			{
				userProvider.ApplyNewGameData(startGameData.session, startGameData.scenario, scenarioProvider.CRUD);
				userProvider.SetLastUsedDifficulty(startGameData.session.Owner, startGameData.difficulty.Name, startGameData.session.GameMode);
				this.StartNewRequested?.Invoke(startGameData);
			}
			else if (saveGame != null)
			{
				userProvider.SetLastUsedDifficulty(saveGame.ParentSession.Owner, userProvider.GetSessionDifficulty(saveGame.ParentSession).Name, saveGame.ParentSession.GameMode);
				this.ContinueGameRequested?.Invoke(saveGame);
			}
			else
			{
				Debug.LogError("Both startGameData and saveGame are null, this shouldn't happen", this);
			}
		}

		private void RefreshInterface()
		{
			if (startGameData != null)
			{
				bool flag = startGameData.session.GameMode == "Career";
				headerTMPro.text = (flag ? LocalizationAPI.L("launcher/start_new_career") : LocalizationAPI.L("launcher/start_new_sandbox"));
				detailsTMPro.text = GetStartGameDetails(startGameData, flag);
				thumbnail.Show(flag ? newCareerImage : newSandboxImage);
				bool interactable = startGameData.difficulty == null || !flag || !startGameData.skipTutorial || userProvider.IsCustomCareerUnlocked || (startGameData.difficulty.IsReadOnly && !startGameData.difficulty.InitiallyLocked);
				runButton.interactable = interactable;
			}
			else if (saveGame != null)
			{
				headerTMPro.text = LocalizationAPI.L("launcher/continue_session", saveGame.ParentSession.Name);
				ISaveGameplayInfo saveGameplayInfo = userProvider.GetSaveGameplayInfo(saveGame);
				detailsTMPro.text = GetSaveGameDetails(saveGameplayInfo, saveGame);
				thumbnail.Show(saveGame);
				IDifficulty sessionDifficulty = userProvider.GetSessionDifficulty(saveGame.ParentSession);
				bool flag2 = sessionDifficulty == null || saveGame.GameMode != "Career" || userProvider.IsCustomCareerUnlocked || (sessionDifficulty.IsReadOnly && !sessionDifficulty.InitiallyLocked);
				runButton.interactable = flag2 && !saveGameplayInfo.IsCorrupt;
			}
			else
			{
				headerTMPro.text = "This is a bug";
				detailsTMPro.text = "You shouldn't encounter this text. No big deal, just press \"Start\" on the left";
				thumbnail.Hide();
				runButton.interactable = true;
			}
		}

		private static string KeyValueFormat(string locKey, string value)
		{
			return "<alpha=#50>" + LocalizationAPI.L(locKey) + "</color> " + value;
		}

		private string GetSaveGameDetails(ISaveGameplayInfo info, ISaveGame saveGame)
		{
			IScenario sessionScenario = userProvider.GetSessionScenario(saveGame.ParentSession, scenarioProvider.CRUD);
			if (info.IsCorrupt)
			{
				return LocalizationAPI.L("launcher/corrupt_save");
			}
			return string.Join("\n", KeyValueFormat("launcher/game_mode", userProvider.LocalizeGameMode(saveGame.GameMode)), KeyValueFormat("launcher/session_name", saveGame.ParentSession.Name), KeyValueFormat("launcher/save_name", saveGame.Name), KeyValueFormat("launcher/timestamp", saveGame.Timestamp.ToString("yyyy\\/MM\\/dd HH\\:mm\\:ss")), KeyValueFormat("launcher/difficulty", userProvider.GetSessionDifficulty(saveGame.ParentSession).ToLocalizedString()), KeyValueFormat("launcher/scenario", (sessionScenario != null) ? sessionScenario.Name : "N/A"), "", KeyValueFormat("launcher/in_game_date", (info.InGameDate != DateTime.MinValue) ? info.InGameDate.ToString("MM\\/dd HH\\:mm") : "N/A"), KeyValueFormat("launcher/in_game_time_passed", (info.InGameDate != DateTime.MinValue) ? info.InGameTimePassed.ToString("d\\d\\ hh\\h\\ mm\\m\\ ss\\s") : "N/A"), "", KeyValueFormat("launcher/cash", info.PlayerMoney.ToString("C", AmericanCulture)), KeyValueFormat("launcher/fee_debt", (info.FeeDebt >= 0f) ? info.FeeDebt.ToString("C", AmericanCulture) : "N/A"), KeyValueFormat("launcher/licenses_unlocked", info.LicensesUnlocked.ToString() + "/" + userProvider.TotalExistingLicenseCount), KeyValueFormat("launcher/orders_active", info.OrdersActive.ToString()), "", KeyValueFormat("launcher/session_start_date", saveGame.ParentSession.Saves.Last().Timestamp.ToString("yyyy\\/MM\\/dd HH\\:mm\\:ss")), KeyValueFormat("launcher/save_type", saveGame.Type.ToLocalizedString() + " v" + info.DataVersion));
		}

		private static string GetStartGameDetails(UIStartGameData data, bool isCareer)
		{
			List<string> list = new List<string>
			{
				KeyValueFormat("launcher/session_name", data.session?.Name ?? "N/A"),
				KeyValueFormat("launcher/difficulty", data.difficulty?.Name ?? "N/A")
			};
			if (!isCareer)
			{
				string value = data.scenario?.StartingTrackID ?? string.Empty;
				if (data.scenario != null && data.scenario.RandomStartingTrackID)
				{
					value = "?";
				}
				string value2 = data.scenario?.DestinationTrackID ?? string.Empty;
				if (data.scenario != null && data.scenario.RandomDestinationTrackID)
				{
					value2 = "?";
				}
				if (data.scenario != null && !string.IsNullOrEmpty(data.scenario.Name))
				{
					list.Add(KeyValueFormat("launcher/scenario", data.scenario.Name));
				}
				if (!string.IsNullOrEmpty(value))
				{
					list.Add(KeyValueFormat("launcher/starting_track", value));
				}
				if (!string.IsNullOrEmpty(value2))
				{
					list.Add(KeyValueFormat("launcher/destination_track", value2));
				}
			}
			return string.Join("\n", list);
		}
	}
}
