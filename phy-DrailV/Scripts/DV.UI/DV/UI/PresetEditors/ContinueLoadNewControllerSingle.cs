using System;
using System.Collections.Generic;
using System.Linq;
using DV.Common;
using DV.Localization;
using DV.Scenarios.Common;
using DV.UIFramework;
using DV.Util;
using UnityEngine;

namespace DV.UI.PresetEditors
{
	public class ContinueLoadNewControllerSingle : APresetEditorController<IGameSession>
	{
		private const string LOC_CAREER_MODE = "mm/career_session";

		private const string LOC_SANDBOX_MODE = "mm/sandbox_session";

		private AUserProfileProvider userProfileProvider;

		private AScenarioProvider scenariosProvider;

		private readonly ObservableCollectionExt<IGameSession> sessions = new ObservableCollectionExt<IGameSession>();

		private readonly ObservableCollectionExt<IDifficulty> difficulties = new ObservableCollectionExt<IDifficulty>();

		private readonly ObservableCollectionExt<IScenario> scenarios = new ObservableCollectionExt<IScenario>();

		private IGameSession currentSession;

		private IDifficulty currentDifficulty;

		private IScenario currentScenario;

		private IUserProfile currentUser;

		private IScenarioCRUD crud;

		private int currentSessionIndex = -1;

		private int currentDifficultyIndex = -1;

		private int currentScenarioIndex = -1;

		private string gameMode;

		private const int DEFAULT_DIFFICULTY = 0;

		[Header("Mode 1 - first launch")]
		[NullCheck]
		public GameObject mode1Root;

		[NullCheck]
		public ButtonDV firstLaunchStartButton;

		[Header("Mode 2 - create new / continue")]
		[NullCheck]
		public GameObject mode2Root;

		public bool hideScenarioSelector;

		[NullCheck]
		public PresetSelectorLogicDifficulty difficultySelectorLogic;

		[NullCheck]
		public ButtonDV editDifficultyButton;

		[NullCheck]
		public PresetSelectorLogicScenario scenarioSelectorLogic;

		[NullCheck]
		public ButtonDV editScenarioButton;

		[NullCheck]
		public ToggleDV tutorialCheckbox;

		[NullCheck]
		public ButtonDV loadButton;

		[NullCheck]
		public ButtonDV continueButton;

		[NullCheck]
		public ButtonDV startNewSessionButton;

		[NullCheck]
		public Popup okPopupPrefab;

		private bool customDifficultiesUnlocked;

		private int lastSessionCount = -1;

		private bool reentrancyCheck_RefreshData;

		private bool reentrancyCheck_RefreshInterface;

		protected override string LOC_RENAME_PROMPT => "scenario/rename_session_prompt";

		protected override string LOC_DELETE_PROMPT => "scenario/delete_session_prompt";

		protected override string LOC_SAVE_OR_REVERT_PROMPT
		{
			get
			{
				throw new NotImplementedException("Reverting Sessions is not supported");
			}
		}

		protected override bool HasSaveButton => false;

		protected override bool HasOpenFolderButton => false;

		protected override bool HasDoneButton => false;

		public override IGameSession CurrentThing
		{
			get
			{
				return currentSession;
			}
			protected set
			{
				currentSession = value;
			}
		}

		public override IScenarioCRUD CRUD => crud;

		public override ObservableCollectionExt<IGameSession> Things => sessions;

		public event Action<ISaveGame> ContinueRequested;

		public event Action<IGameSession> LoadRequested;

		public event Action<UIStartGameData> StartNewRequested;

		public event Action<IScenario, ContinueLoadNewControllerSingle> EditScenarioRequested;

		public event Action<IDifficulty, ContinueLoadNewControllerSingle> EditDifficultyRequested;

		public void SetProvider(AUserProfileProvider userProfileProvider, AScenarioProvider scenariosProvider, string gameMode, bool isVR)
		{
			if ((bool)this.userProfileProvider || (bool)this.scenariosProvider || !string.IsNullOrEmpty(this.gameMode))
			{
				Util.RunOnce(this, "SetProvider");
				return;
			}
			this.userProfileProvider = userProfileProvider;
			this.scenariosProvider = scenariosProvider;
			this.gameMode = gameMode;
			base.isVR = isVR;
			base.IsInitialized = true;
			RefreshData();
		}

		public void ChangeDifficulty(IDifficulty difficulty, bool refreshInterface = true)
		{
			ChangeDifficulty(difficulties?.IndexOf(difficulty) ?? (-1), refreshInterface);
		}

		public void ChangeScenario(IScenario scenario, bool refreshInterface = true)
		{
			ChangeScenario(scenarios?.IndexOf(scenario) ?? (-1), refreshInterface);
		}

		public void ChangeSession(bool forward, bool refreshInterface = true)
		{
			_Change(sessions, out currentSession, ref currentSessionIndex, forward, refreshInterface);
		}

		public void ChangeDifficulty(bool forward, bool refreshInterface = true)
		{
			_Change(difficulties, out currentDifficulty, ref currentDifficultyIndex, forward, refreshInterface);
			if (currentDifficulty != null)
			{
				userProfileProvider.SetSessionDifficulty(CurrentThing, currentDifficulty);
			}
		}

		public void ChangeScenario(bool forward, bool refreshInterface = true)
		{
			_Change(scenarios, out currentScenario, ref currentScenarioIndex, forward, refreshInterface);
		}

		public void ChangeSession(int index, bool refreshInterface = true)
		{
			_Change(sessions, out currentSession, out currentSessionIndex, index, refreshInterface);
		}

		public void ChangeDifficulty(int index, bool refreshInterface = true)
		{
			_Change(difficulties, out currentDifficulty, out currentDifficultyIndex, index, refreshInterface);
			if (currentDifficulty != null && CurrentThing != null)
			{
				userProfileProvider.SetSessionDifficulty(CurrentThing, currentDifficulty);
			}
		}

		public void ChangeScenario(int index, bool refreshInterface = true)
		{
			_Change(scenarios, out currentScenario, out currentScenarioIndex, index, refreshInterface);
		}

		protected override bool IsDefaultPresetName(string name)
		{
			return false;
		}

		protected override void Awake()
		{
			base.Awake();
			mode1Root.SetActive(value: true);
			mode2Root.SetActive(value: true);
			difficultySelectorLogic.SetCallbacks(() => currentDifficulty, () => difficulties, () => CRUD);
			scenarioSelectorLogic.SetCallbacks(() => currentScenario, () => scenarios, () => CRUD);
		}

		public override void RefreshData()
		{
			if (reentrancyCheck_RefreshData)
			{
				Debug.LogError("Reentrancy check fail for RefreshData!", this);
			}
			reentrancyCheck_RefreshData = true;
			if (!base.IsInitialized)
			{
				Debug.LogWarning(string.Format("{0} fallback to empty lists (gameMode: '{1}', userProfileProvider null?: {2}, scenariosProvider null?: {3})", "RefreshData", gameMode, userProfileProvider == null, scenariosProvider == null), this);
				sessions.Clear();
				difficulties.Clear();
				scenarios.Clear();
				ChangeSession(0, refreshInterface: false);
				reentrancyCheck_RefreshData = false;
				return;
			}
			bool flag = currentUser != userProfileProvider.GetCurrentProfile();
			currentUser = userProfileProvider.GetCurrentProfile();
			sessions.Clear();
			sessions.AddRange(userProfileProvider.GetSessionsForGameMode(gameMode));
			customDifficultiesUnlocked = gameMode != "Career" || userProfileProvider.IsCustomCareerUnlocked;
			if (crud == null || flag)
			{
				IScenarioCRUD cRUD = scenariosProvider.CRUD;
				crud = cRUD;
			}
			if (flag)
			{
				currentSession = null;
				currentSessionIndex = 0;
				currentDifficulty = null;
				currentDifficultyIndex = 0;
				currentScenario = null;
				currentScenarioIndex = 0;
				if (userProfileProvider.HasLastPlayedSessionForGameMode(gameMode))
				{
					currentSessionIndex = FindIndex(userProfileProvider.GetLastPlayedSessionForGameMode(gameMode).SessionID);
				}
				else if (sessions.Count > 0)
				{
					currentSessionIndex = 0;
				}
				else
				{
					Debug.Log("User was changed, game mode '" + gameMode + "' has no sessions", this);
					currentSessionIndex = 0;
				}
			}
			else if (sessions.Count > 0)
			{
				if (lastSessionCount >= 0 && sessions.Count > lastSessionCount)
				{
					currentSessionIndex = sessions.Count - 1;
				}
				else if (currentSession != null)
				{
					currentSessionIndex = FindIndex(currentSession.SessionID);
				}
				else if (userProfileProvider.HasLastPlayedSessionForGameMode(gameMode))
				{
					currentSessionIndex = FindIndex(userProfileProvider.GetLastPlayedSessionForGameMode(gameMode).SessionID);
				}
				else
				{
					currentSessionIndex = 0;
				}
			}
			else
			{
				Debug.Log("Game mode '" + gameMode + "' has no sessions", this);
				currentSessionIndex = 0;
			}
			lastSessionCount = sessions.Count;
			difficulties.Clear();
			difficulties.AddRange(crud.Difficulties);
			scenarios.Clear();
			scenarios.AddRange(crud.Scenarios);
			ChangeSession(currentSessionIndex, refreshInterface: false);
			ChangeScenario(currentScenarioIndex, refreshInterface: false);
			if (CurrentThing != null)
			{
				IDifficulty sessionDifficulty = userProfileProvider.GetSessionDifficulty(CurrentThing);
				currentDifficultyIndex = FindDifficulty(sessionDifficulty);
				if (currentDifficultyIndex < 0)
				{
					Debug.LogWarning("Session '" + CurrentThing?.Name + "' has a difficulty '" + sessionDifficulty?.Name + "' that is not known to ScenarioCRUD, defaulting, this should not happen.");
					currentDifficulty = crud.Difficulties[0];
					currentDifficultyIndex = 0;
				}
				ChangeDifficulty(currentDifficultyIndex, refreshInterface: false);
			}
			RefreshInterface();
			reentrancyCheck_RefreshData = false;
			int FindIndex(int sessionID)
			{
				int result = -1;
				for (int i = 0; i < sessions.Count; i++)
				{
					if (sessions[i].SessionID == sessionID)
					{
						result = i;
					}
				}
				return result;
			}
		}

		private int FindDifficulty(IDifficulty target)
		{
			if (target == null)
			{
				return -1;
			}
			for (int i = 0; i < difficulties.Count; i++)
			{
				if (difficulties[i].Equals(target))
				{
					return i;
				}
			}
			return -1;
		}

		public override void RefreshInterface()
		{
			if (reentrancyCheck_RefreshInterface)
			{
				Debug.LogError("Reentrancy check fail for RefreshInterface!", this);
			}
			reentrancyCheck_RefreshInterface = true;
			if (!base.IsInitialized)
			{
				mode1Root.SetActive(value: false);
				mode2Root.SetActive(value: false);
			}
			else if (sessions.Count == 0)
			{
				mode1Root.SetActive(value: true);
				mode2Root.SetActive(value: false);
			}
			else if (currentSession != null)
			{
				mode1Root.SetActive(value: false);
				mode2Root.SetActive(value: true);
				bool flag = currentSession.Saves.Count > 0;
				loadButton.gameObject.SetActive(flag);
				continueButton.gameObject.SetActive(flag);
				startNewSessionButton.gameObject.SetActive(!flag);
				bool flag2 = hideScenarioSelector;
				bool flag3 = flag2 && !flag;
				tutorialCheckbox.gameObject.SetActive(flag3);
				bool newInteractable = currentDifficulty == null || !flag2 || (flag3 && tutorialCheckbox.isOn) || customDifficultiesUnlocked || (currentDifficulty.IsReadOnly && !currentDifficulty.InitiallyLocked);
				startNewSessionButton.ToggleInteractable(newInteractable);
				continueButton.ToggleInteractable(newInteractable);
				loadButton.ToggleInteractable(newInteractable);
				newPresetButton.ToggleInteractable(currentUser.CanCreateNewSessions(gameMode));
				presetSelectorLogic.RefreshInterface();
				difficultySelectorLogic.RefreshInterface();
				scenarioSelectorLogic.RefreshInterface();
				bool active = userProfileProvider.IsDifficultyPicked(currentSession) && (!flag3 || !tutorialCheckbox.isOn);
				difficultySelectorLogic.selector.gameObject.SetActive(active);
				editDifficultyButton.gameObject.SetActive(active);
				bool active2 = !hideScenarioSelector && !flag;
				scenarioSelectorLogic.selector.gameObject.SetActive(active2);
				editScenarioButton.gameObject.SetActive(active2);
			}
			else
			{
				Debug.LogError("Unhandled null current session", this);
			}
			reentrancyCheck_RefreshInterface = false;
		}

		protected override void OnPresetSelected(IClickable _, int selectedIndex)
		{
			CurrentThing = Things[selectedIndex];
			RefreshData();
		}

		protected override void OnSavePresetClicked()
		{
			throw new NotImplementedException();
		}

		protected override string GetSuggestedNameForNew()
		{
			List<IGameSession> sessionsForGameMode = userProfileProvider.GetSessionsForGameMode(gameMode);
			int num = sessionsForGameMode.Count + 1;
			string potentialName;
			while (true)
			{
				potentialName = LocalizationAPI.L((gameMode == "Career") ? "mm/career_session" : "mm/sandbox_session", num.ToString());
				if (!sessionsForGameMode.Any((IGameSession t) => t.Name == potentialName))
				{
					break;
				}
				num++;
			}
			return potentialName;
		}

		protected override void CreateNewImpl(string nameToUse)
		{
			nameToUse = nameToUse ?? GetSuggestedNameForNew();
			IGameSession gameSession = userProfileProvider.CreateNewSession(nameToUse, gameMode);
			string lastDifficultyName = userProfileProvider.GetLastUsedDifficulty(currentUser, gameMode);
			IDifficulty difficulty = crud.Difficulties.FirstOrDefault((IDifficulty d) => d.Name == lastDifficultyName);
			if (difficulty == null)
			{
				string defaultDiffName = userProfileProvider.GetDefaultDifficultyForGameMode(gameMode);
				difficulty = crud.Difficulties.FirstOrDefault((IDifficulty d) => d.Name == defaultDiffName);
				if (difficulty == null)
				{
					Debug.LogWarning("Default difficulty for game mode '" + gameMode + "' is reported as '" + defaultDiffName + "', but such difficulty is not known, defaulting to first one in the list.");
					difficulty = crud.Difficulties[0];
				}
			}
			userProfileProvider.SetSessionDifficulty(gameSession, difficulty);
			CurrentThing = gameSession;
			RefreshData();
		}

		protected override void DeleteImpl()
		{
			IGameSession currentThing = CurrentThing;
			CurrentThing = null;
			userProfileProvider.DeleteSession(currentThing);
		}

		protected override void FlushChanges()
		{
			userProfileProvider.FlushChanges();
		}

		protected override void SetupListeners(bool on)
		{
			base.SetupListeners(on);
			if (on)
			{
				firstLaunchStartButton.Clicked += OnFirstLaunchStartClicked;
				difficultySelectorLogic.selector.PreviousOrNextClicked += DifficultySelector_PreviousOrNextClicked;
				editDifficultyButton.Clicked += EditDifficultyClicked;
				scenarioSelectorLogic.selector.PreviousOrNextClicked += ScenarioSelector_PreviousOrNextClicked;
				editScenarioButton.Clicked += EditScenarioClicked;
				startNewSessionButton.Clicked += OnStartNewSessionClicked;
				loadButton.Clicked += OnLoadClicked;
				continueButton.Clicked += OnContinueClicked;
				tutorialCheckbox.onValueChanged.AddListener(OnTutorialCheckboxChanged);
			}
			else
			{
				firstLaunchStartButton.Clicked -= OnFirstLaunchStartClicked;
				difficultySelectorLogic.selector.PreviousOrNextClicked -= DifficultySelector_PreviousOrNextClicked;
				editDifficultyButton.Clicked -= EditDifficultyClicked;
				scenarioSelectorLogic.selector.PreviousOrNextClicked -= ScenarioSelector_PreviousOrNextClicked;
				editScenarioButton.Clicked -= EditScenarioClicked;
				startNewSessionButton.Clicked -= OnStartNewSessionClicked;
				loadButton.Clicked -= OnLoadClicked;
				continueButton.Clicked -= OnContinueClicked;
				tutorialCheckbox.onValueChanged.RemoveListener(OnTutorialCheckboxChanged);
			}
		}

		private void OnFirstLaunchStartClicked(IClickable clickable)
		{
			OnNewPresetClicked(clickable);
		}

		private void OnStartNewSessionClicked(IClickable _)
		{
			var (flag, reasonLocKey) = scenariosProvider.CanStartNewSession(currentSession, currentScenario, currentDifficulty);
			if (!flag)
			{
				ShowCantStartPopup(reasonLocKey);
				return;
			}
			IScenario randomizedScenario = currentScenario;
			if (gameMode == "FreeRoam" && scenariosProvider.IsAnythingRandomized(currentScenario))
			{
				randomizedScenario = scenariosProvider.GetRandomizedScenario(randomizedScenario);
			}
			bool skipTutorial = !tutorialCheckbox.isOn;
			this.StartNewRequested?.Invoke(new UIStartGameData(currentSession, currentDifficulty, randomizedScenario, skipTutorial));
		}

		private void OnContinueClicked(IClickable _)
		{
			this.ContinueRequested?.Invoke(currentSession.LatestSave);
		}

		private void OnLoadClicked(IClickable _)
		{
			this.LoadRequested?.Invoke(currentSession);
		}

		private void DifficultySelector_PreviousOrNextClicked(ISelector _, bool nextClicked)
		{
			ChangeDifficulty(nextClicked);
		}

		private void ScenarioSelector_PreviousOrNextClicked(ISelector _, bool nextClicked)
		{
			ChangeScenario(nextClicked);
		}

		private void _Change<T>(ObservableCollectionExt<T> collection, out T current, ref int currentIndex, bool forward, bool refreshInterface) where T : class
		{
			int num = currentIndex + (forward ? 1 : (-1));
			if (forward && num >= collection.Count)
			{
				num = 0;
			}
			else if (!forward && num < 0)
			{
				num = collection.Count - 1;
			}
			_Change(collection, out current, out currentIndex, num, refreshInterface);
		}

		private void _Change<T>(ObservableCollectionExt<T> collection, out T current, out int currentIndex, int targetIndex, bool refreshInterface) where T : class
		{
			if (collection == null || collection.Count == 0)
			{
				currentIndex = -1;
				current = null;
			}
			else
			{
				if (targetIndex < 0 || targetIndex >= collection.Count)
				{
					Debug.LogWarning($"{typeof(T).Name} index {targetIndex} for '{gameMode}' is out of range ({collection.Count}), clamping.", this);
					targetIndex = Mathf.Clamp(targetIndex, 0, collection.Count - 1);
				}
				currentIndex = targetIndex;
				current = collection[currentIndex];
			}
			if (refreshInterface)
			{
				RefreshInterface();
			}
		}

		private void EditDifficultyClicked(IClickable clickable)
		{
			this.EditDifficultyRequested?.Invoke(currentDifficulty, this);
		}

		private void EditScenarioClicked(IClickable clickable)
		{
			this.EditScenarioRequested?.Invoke(currentScenario, this);
		}

		private void OnTutorialCheckboxChanged(bool _)
		{
			RefreshInterface();
		}

		private void ShowCantStartPopup(string reasonLocKey)
		{
			if (!base.PopupManager.CanShowPopup())
			{
				Debug.LogWarning("PopupManager can't show popups at this moment", this);
				return;
			}
			PopupLocalizationKeys locKeys = new PopupLocalizationKeys
			{
				labelKey = reasonLocKey
			};
			base.PopupManager.ShowPopup(okPopupPrefab, locKeys);
		}

		protected override string GetTargetFilePath()
		{
			return "";
		}
	}
}
