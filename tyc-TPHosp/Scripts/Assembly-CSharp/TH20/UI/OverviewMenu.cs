using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class OverviewMenu : MenuBase, IPauseTimeMenu
	{
		public enum Mode
		{
			None = 0,
			Awards = 1,
			Leaderboards = 2,
			Finance = 3,
			Staff = 4,
			Patients = 5,
			Policy = 6,
			Log = 7,
			MaxModes = 8
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class OverviewMenuSettings
		{
			[InspectorMargin(8)]
			[InspectorHeader("GUI Components")]
			public DynamicButton CloseButton;

			public DynamicButton AwardsButton;

			public DynamicButton LeaderboardsButton;

			public DynamicButton FinanceButton;

			public DynamicButton StaffButton;

			public DynamicButton PatientsButton;

			public DynamicButton PolicyButton;

			public DynamicButton LogButton;

			[InspectorMargin(8)]
			[InspectorHeader("Localisation")]
			public LocalisedString AwardsString;

			public LocalisedString LeaderboardString;

			public LocalisedString FinanceString;

			public LocalisedString StaffString;

			public LocalisedString PatientsString;

			public LocalisedString PolicyString;

			public LocalisedString LogString;

			[InspectorMargin(8)]
			[InspectorHeader("Advisor")]
			public GameObject _advisorPortraitPrefab;

			public GameObject _advisorPortraitAwardsPrefab;

			[InspectorMargin(8)]
			[InspectorHeader("Audio Event Names")]
			public string SelectItem;
		}

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private OverviewMenuSettings _overviewMenuSettings;

		[SerializeField]
		public GameObject _generalTooltipPrefab;

		[SerializeField]
		public GameObject _mainPanel;

		[SerializeField]
		public GameObject _imageOuterPanel;

		private GameObject _advisorPortraitSceneObject;

		private AdvisorPortraitScene _advisorPortraitScene;

		private GameObject _advisorPortraitAwardsSceneObject;

		private AdvisorPortraitScene _advisorPortraitAwardsScene;

		private ButtonAnimator[] _overviewButtonAnimators = new ButtonAnimator[8];

		private OverviewMenuTab[] _overviewMenuTabs = new OverviewMenuTab[8];

		public Mode CurrentMode
		{
			get
			{
				OverviewMenuTab[] overviewMenuTabs = _overviewMenuTabs;
				foreach (OverviewMenuTab overviewMenuTab in overviewMenuTabs)
				{
					if ((bool)overviewMenuTab && overviewMenuTab.gameObject.activeInHierarchy)
					{
						return overviewMenuTab.TheMode;
					}
				}
				return Mode.None;
			}
		}

		public bool IsEndOfYear { get; private set; }

		public Level TheLevel { get; private set; }

		public AdvisorPortraitScene TheAdvisorScene
		{
			get
			{
				return _advisorPortraitScene;
			}
			private set
			{
				_advisorPortraitScene = value;
			}
		}

		public AdvisorPortraitScene TheAdvisorAwardsScene
		{
			get
			{
				return _advisorPortraitAwardsScene;
			}
			private set
			{
				_advisorPortraitAwardsScene = value;
			}
		}

		public void Setup(Level level, bool isEndOfYear = false)
		{
			IsEndOfYear = isEndOfYear;
			TheLevel = level;
			TheLevel.InputManager.AddGraphicRayCaster(_graphicRaycaster);
			_overviewMenuSettings.CloseButton.onPrimaryDown.AddListener(OnCloseButton);
			base.OnClosed = (Action)Delegate.Combine(base.OnClosed, new Action(OnOverviewMenuClosed));
			App app = TheLevel.App;
			app.OnLevelAboutToBeUnloaded = (Action<Level>)Delegate.Combine(app.OnLevelAboutToBeUnloaded, new Action<Level>(OnLevelAboutToBeUnloaded));
			_advisorPortraitSceneObject = UnityEngine.Object.Instantiate(_overviewMenuSettings._advisorPortraitPrefab);
			_advisorPortraitScene = _advisorPortraitSceneObject.GetComponent<AdvisorPortraitScene>();
			if ((bool)_advisorPortraitScene)
			{
				_advisorPortraitScene.Setup();
				_advisorPortraitScene.transform.localPosition = new Vector3(_advisorPortraitScene.transform.localPosition.x, 1000f, _advisorPortraitScene.transform.localPosition.z);
			}
			if (_overviewMenuSettings._advisorPortraitAwardsPrefab != null)
			{
				_advisorPortraitAwardsSceneObject = UnityEngine.Object.Instantiate(_overviewMenuSettings._advisorPortraitAwardsPrefab);
				_advisorPortraitAwardsScene = _advisorPortraitAwardsSceneObject.GetComponent<AdvisorPortraitScene>();
				if ((bool)_advisorPortraitAwardsScene)
				{
					_advisorPortraitAwardsScene.Setup();
					_advisorPortraitAwardsScene.transform.localPosition = new Vector3(_advisorPortraitAwardsScene.transform.localPosition.x, 1000f, _advisorPortraitAwardsScene.transform.localPosition.z);
				}
			}
			ConfigureTab(_overviewMenuSettings.AwardsButton, _overviewMenuSettings.AwardsString.Translation, Mode.Awards);
			ConfigureTab(_overviewMenuSettings.LeaderboardsButton, _overviewMenuSettings.LeaderboardString.Translation, Mode.Leaderboards);
			ConfigureTab(_overviewMenuSettings.FinanceButton, _overviewMenuSettings.FinanceString.Translation, Mode.Finance);
			ConfigureTab(_overviewMenuSettings.StaffButton, _overviewMenuSettings.StaffString.Translation, Mode.Staff);
			ConfigureTab(_overviewMenuSettings.PatientsButton, _overviewMenuSettings.PatientsString.Translation, Mode.Patients);
			ConfigureTab(_overviewMenuSettings.PolicyButton, _overviewMenuSettings.PolicyString.Translation, Mode.Policy);
			ConfigureTab(_overviewMenuSettings.LogButton, _overviewMenuSettings.LogString.Translation, Mode.Log);
			SetupTabButtonsInteractivity(awardsFinished: false);
			SelectMode(isEndOfYear ? Mode.Awards : Mode.Finance, force: true);
			RestoreHUDState();
		}

		public void SetStandardAdvisor()
		{
			_advisorPortraitAwardsScene.Activate(bActive: false);
			_advisorPortraitScene.Activate(bActive: true);
		}

		public void SetAwardsAdvisor()
		{
			_advisorPortraitScene.Activate(bActive: false);
			_advisorPortraitAwardsScene.Activate(bActive: true);
		}

		public void SetCloseButtonActive(bool bActive)
		{
			_overviewMenuSettings.CloseButton.gameObject.SetActive(bActive);
		}

		public void SetupTabButtonsInteractivity(bool awardsFinished)
		{
			bool flag = !awardsFinished;
			bool interactive = !IsEndOfYear || !(IsEndOfYear && flag);
			if (!DebugVars.EnableAwardsScreen.Value)
			{
				flag = false;
				interactive = true;
			}
			SetTabButtonInteractive(_overviewMenuSettings.AwardsButton, flag);
			SetTabButtonInteractive(_overviewMenuSettings.LeaderboardsButton, interactive);
			SetTabButtonInteractive(_overviewMenuSettings.FinanceButton, interactive);
			SetTabButtonInteractive(_overviewMenuSettings.StaffButton, interactive);
			SetTabButtonInteractive(_overviewMenuSettings.PatientsButton, interactive);
			SetTabButtonInteractive(_overviewMenuSettings.PolicyButton, interactive);
			SetTabButtonInteractive(_overviewMenuSettings.LogButton, interactive);
		}

		public void SetupTabButtonsInteractivityAll(bool allActive)
		{
			SetTabButtonInteractive(_overviewMenuSettings.AwardsButton, allActive);
			SetTabButtonInteractive(_overviewMenuSettings.LeaderboardsButton, allActive);
			SetTabButtonInteractive(_overviewMenuSettings.FinanceButton, allActive);
			SetTabButtonInteractive(_overviewMenuSettings.StaffButton, allActive);
			SetTabButtonInteractive(_overviewMenuSettings.PatientsButton, allActive);
			SetTabButtonInteractive(_overviewMenuSettings.PolicyButton, allActive);
			SetTabButtonInteractive(_overviewMenuSettings.LogButton, allActive);
		}

		public void SelectFinanceMode()
		{
			SelectMode(Mode.Finance, force: true);
		}

		public void SelectAwardsMode()
		{
			SelectMode(Mode.Awards, force: true);
		}

		private void SetTabButtonInteractive(DynamicButton button, bool interactive)
		{
			ButtonAnimator component = button.GetComponent<ButtonAnimator>();
			if (component != null)
			{
				component.CurrentState = ((!interactive) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
		}

		protected void OnDestroy()
		{
			if (_graphicRaycaster != null)
			{
				TheLevel.InputManager.RemoveGraphicRayCaster(_graphicRaycaster);
			}
			UnityEngine.Object.Destroy(_advisorPortraitSceneObject);
			UnityEngine.Object.Destroy(_advisorPortraitAwardsSceneObject);
			base.OnClosed = (Action)Delegate.Remove(base.OnClosed, new Action(OnOverviewMenuClosed));
			App app = TheLevel.App;
			app.OnLevelAboutToBeUnloaded = (Action<Level>)Delegate.Remove(app.OnLevelAboutToBeUnloaded, new Action<Level>(OnLevelAboutToBeUnloaded));
		}

		private void ConfigureTab(DynamicButton theTabButton, string theTitleText, Mode theTabMode)
		{
			theTabButton.SetTMPText(theTitleText);
			_overviewButtonAnimators[(int)theTabMode] = theTabButton.GetComponent<ButtonAnimator>();
			OverviewMenuTabButton component = theTabButton.GetComponent<OverviewMenuTabButton>();
			if ((bool)component)
			{
				OverviewMenuTab component2 = UnityEngine.Object.Instantiate(component.AssociatedMenuTabPrefab, _mainPanel.transform, worldPositionStays: false).GetComponent<OverviewMenuTab>();
				_overviewMenuTabs[(int)theTabMode] = component2;
				component2.Setup(this, theTabMode);
				component2.gameObject.SetActive(value: false);
			}
			theTabButton.onPrimaryDown.AddListener(delegate
			{
				SelectMode(theTabMode);
			});
			if (_imageOuterPanel != null)
			{
				_imageOuterPanel.gameObject.transform.SetAsLastSibling();
			}
		}

		public void StopAwardsCeremony()
		{
			if (TheLevel.AwardCeremonyInProgress)
			{
				OverviewMenuAwardsTab overviewMenuAwardsTab = _overviewMenuTabs[1] as OverviewMenuAwardsTab;
				if (overviewMenuAwardsTab != null)
				{
					overviewMenuAwardsTab.StopAwardsCeremony();
				}
			}
		}

		private void OnLevelAboutToBeUnloaded(Level level)
		{
			StopAwardsCeremony();
		}

		private void OnOverviewMenuClosed()
		{
			OnOverviewMenuClosedInternal();
		}

		private void OnCloseButton()
		{
			OnOverviewMenuClosedInternal();
		}

		private void OnOverviewMenuClosedInternal()
		{
			StopAwardsCeremony();
			if (CurrentMode != Mode.None)
			{
				int currentMode = (int)CurrentMode;
				_overviewMenuTabs[currentMode].Activate(state: false);
				_overviewMenuTabs[currentMode].gameObject.SetActive(value: false);
			}
			SaveHUDState();
			TheLevel.HospitalHUDManager.HideOverviewMenu();
		}

		private void SaveHUDState()
		{
			OverviewMenuTab[] overviewMenuTabs = _overviewMenuTabs;
			foreach (OverviewMenuTab overviewMenuTab in overviewMenuTabs)
			{
				if (!(overviewMenuTab != null))
				{
					continue;
				}
				PanelItem[] componentsInChildren = overviewMenuTab.GetComponentsInChildren<PanelItem>(includeInactive: true);
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					if (componentsInChildren[j] is IHUDSaveState iHUDSaveState)
					{
						iHUDSaveState.SaveState(TheLevel.HUDSavedState);
					}
				}
			}
		}

		public void SaveHUDPanelItemState(PanelItem panelItem)
		{
			if (TheLevel.HUDSavedState != null && panelItem is IHUDSaveState iHUDSaveState)
			{
				iHUDSaveState.SaveState(TheLevel.HUDSavedState);
			}
		}

		private void RestoreHUDState()
		{
			OverviewMenuTab[] overviewMenuTabs = _overviewMenuTabs;
			foreach (OverviewMenuTab overviewMenuTab in overviewMenuTabs)
			{
				if (!(overviewMenuTab != null))
				{
					continue;
				}
				PanelItem[] componentsInChildren = overviewMenuTab.GetComponentsInChildren<PanelItem>(includeInactive: true);
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					if (componentsInChildren[j] is IHUDSaveState iHUDSaveState)
					{
						iHUDSaveState.RestoreState(TheLevel.HUDSavedState);
					}
				}
			}
		}

		public void SelectMode(Mode theMode, bool force = false)
		{
			Mode currentMode = CurrentMode;
			if (theMode != currentMode || force)
			{
				int num = (int)currentMode;
				if (currentMode != Mode.None)
				{
					_overviewButtonAnimators[num].CurrentState = ButtonAnimator.State.Selectable;
					_overviewMenuTabs[num].Activate(state: false);
					_overviewMenuTabs[num].gameObject.SetActive(value: false);
				}
				num = (int)theMode;
				_overviewButtonAnimators[num].CurrentState = ButtonAnimator.State.Selected;
				_overviewMenuTabs[num].gameObject.SetActive(value: true);
				_overviewMenuTabs[num].Activate(state: true);
			}
		}

		public void HushLittleCompilerDontYouCry()
		{
		}

		public void PressTabButton(Mode mode)
		{
			switch (mode)
			{
			case Mode.Finance:
				_overviewMenuSettings.FinanceButton.onPrimaryDown.Invoke();
				break;
			case Mode.Staff:
				_overviewMenuSettings.StaffButton.onPrimaryDown.Invoke();
				break;
			case Mode.Policy:
				_overviewMenuSettings.PolicyButton.onPrimaryDown.Invoke();
				break;
			case Mode.Patients:
				_overviewMenuSettings.PatientsButton.onPrimaryDown.Invoke();
				break;
			}
		}
	}
}
