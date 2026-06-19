using System;
using I2.Loc;
using TH20.UI;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class MetagameButtonsMenu : AnimatedMenuBase, IGameEventsBase
	{
		[SerializeField]
		private DynamicButton _optionsButton;

		[SerializeField]
		private DynamicButton _leaderboardButton;

		[SerializeField]
		private DynamicButton _careerGoalsButton;

		[SerializeField]
		private GameObject _careerNotificationObject;

		[SerializeField]
		private TooltipSpawner _careerGoalsButtonTooltip;

		[NonSerialized]
		public Action OnMenuOpened;

		[NonSerialized]
		public Action OnMenuClosed;

		private App _app;

		private Metagame _metagame;

		private HUD _hud;

		private bool _registeredEvents;

		private bool _showCareerNotification;

		public void Setup(App app)
		{
			_app = app;
			_metagame = app.Metagame;
			_hud = app.MetagameMap.HUD;
			GameObjectUtils.SetActive(_leaderboardButton.gameObject, OnlineManager.IsInitializedAndLoggedOn());
			if (!_registeredEvents)
			{
				_optionsButton.onPrimaryDown.AddListener(OnOptionsPressed);
				_leaderboardButton.onPrimaryDown.AddListener(OnLeaderboardPressed);
				_careerGoalsButton.onPrimaryDown.AddListener(OnCareerGoalsPressed);
				ObjectiveEvents objectiveEvents = _metagame.ObjectiveEvents;
				objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
				_registeredEvents = true;
			}
			RefreshCareerMenuNotification();
			if (_careerGoalsButtonTooltip != null)
			{
				_careerGoalsButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					if (_showCareerNotification)
					{
						tooltip.Text = $"{ScriptLocalization.Menu_Metagame_Tooltips.CareerGoalsButton_CS}\n{ScriptLocalization.Menu_Metagame_Tooltips.CareerGoalsButtonRewards_CS}";
					}
					else
					{
						tooltip.Text = ScriptLocalization.Menu_Metagame_Tooltips.CareerGoalsButton_CS;
					}
				});
			}
			ConsoleCommandsDatabase.RegisterCommand("ShowModMenu", "Show mod menu", "Show mod menu", Debug_ShowModMenu);
		}

		public override void Destroy()
		{
			if (_registeredEvents)
			{
				_optionsButton.onPrimaryDown.RemoveListener(OnOptionsPressed);
				_leaderboardButton.onPrimaryDown.RemoveListener(OnLeaderboardPressed);
				_careerGoalsButton.onPrimaryDown.RemoveListener(OnCareerGoalsPressed);
				ObjectiveEvents objectiveEvents = _metagame.ObjectiveEvents;
				objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
				_registeredEvents = false;
			}
			ConsoleCommandsDatabase.UnRegisterCommand("ShowModMenu");
		}

		private ConsoleCommandResult Debug_ShowModMenu(string[] argd)
		{
			OpenModMenu();
			return ConsoleCommandResult.Succeeded();
		}

		protected override void Update()
		{
			base.Update();
			if ((_app.MetagameMap.StateMachine.TopState is MetagameStatePlayer || _app.MetagameMap.StateMachine.TopState is SandboxStatePlayer) && _app.InputManager.GetKeyDown(KeyCode.Escape))
			{
				OnOptionsPressed();
			}
		}

		public override bool AreTooltipsEnabled()
		{
			if (base.AreTooltipsEnabled())
			{
				return !_hud.IsOptionsMenuOpen;
			}
			return false;
		}

		public void CloseAllMenus()
		{
			CloseSelectedHospitalMenu();
			if (_hud.IsOptionsMenuOpen)
			{
				OnMenuClosed.InvokeSafe();
			}
			CloseCareersMenu();
			CloseLeaderboardsMenu();
		}

		private void CloseSelectedHospitalMenu()
		{
			SelectedHospitalMenu selectedHospitalMenu = _hud.FindMenu<SelectedHospitalMenu>(includeInactive: false);
			if (selectedHospitalMenu != null)
			{
				selectedHospitalMenu.CloseMenu();
			}
		}

		private void CloseCareersMenu()
		{
			CareersMenu careersMenu = _hud.FindMenu<CareersMenu>(includeInactive: false);
			if (careersMenu != null)
			{
				careersMenu.CloseMenu();
			}
		}

		private void CloseLeaderboardsMenu()
		{
			MetagameLeaderboardsMenu metagameLeaderboardsMenu = _hud.FindMenu<MetagameLeaderboardsMenu>(includeInactive: false);
			if (metagameLeaderboardsMenu != null)
			{
				metagameLeaderboardsMenu.CloseMenu();
			}
		}

		public void VerifyEvents()
		{
			OnMenuOpened.VerifyIsNull();
			OnMenuClosed.VerifyIsNull();
		}

		private void OpenModMenu()
		{
			ModMenu modMenu = _hud.FindMenu<ModMenu>();
			if (modMenu == null)
			{
				modMenu = _hud.CreateMenu<ModMenu>();
				modMenu.Initialise(_app);
			}
			if (modMenu.IsClosed() || modMenu.IsClosing())
			{
				CloseAllMenus();
				modMenu.OpenMenu();
			}
			else
			{
				modMenu.CloseMenu();
			}
		}

		public void OnCareerGoalsPressed()
		{
			if (_hud != null && !_hud.IsFullscreenMenuOpen() && !_hud.IsOptionsMenuOpen)
			{
				CareersMenu careersMenu = _hud.FindMenu<CareersMenu>();
				if (careersMenu == null)
				{
					CloseAllMenus();
					careersMenu = _hud.CreateMenu<CareersMenu>();
					careersMenu.Setup(_app.MetagameMap, this);
				}
				else
				{
					careersMenu.CloseMenu();
				}
			}
		}

		public void OnLeaderboardPressed()
		{
			if (_hud != null && !_hud.IsFullscreenMenuOpen() && !_hud.IsOptionsMenuOpen)
			{
				MetagameLeaderboardsMenu metagameLeaderboardsMenu = _hud.FindMenu<MetagameLeaderboardsMenu>();
				if (metagameLeaderboardsMenu == null)
				{
					CloseAllMenus();
					metagameLeaderboardsMenu = _hud.CreateMenu<MetagameLeaderboardsMenu>();
					metagameLeaderboardsMenu.Setup(_metagame);
				}
				else
				{
					metagameLeaderboardsMenu.CloseMenu();
				}
			}
		}

		public void OnOptionsPressed()
		{
			if (_hud == null || _hud.IsFullscreenMenuOpen())
			{
				return;
			}
			CloseSelectedHospitalMenu();
			CloseCareersMenu();
			CloseLeaderboardsMenu();
			if (!_app.PreferencesScreen.isActiveAndEnabled && !_hud.AreAnyMenusPreventingOpenPauseMenu() && !_app.MessageBox.IsVisibleOrClosing)
			{
				if (_hud.FindMenu<OptionsMenu>() == null)
				{
					CloseAllMenus();
					OptionsMenu optionsMenu = _hud.CreateMenu<OptionsMenu>();
					optionsMenu.Setup(_app, _app.MetagameMap, _app.SaveSystem, _app.UserPreferences, _app.MessageBox, _app.Save, _app.Load, _app.QuickSaveDeferred, _app.QuickLoad);
					optionsMenu.OnClosed = (Action)Delegate.Combine(optionsMenu.OnClosed, new Action(CloseOptions));
					_careerGoalsButton.interactable = false;
					_leaderboardButton.interactable = false;
					OnMenuOpened.InvokeSafe();
				}
				else
				{
					CloseOptions();
				}
			}
		}

		private void CloseOptions()
		{
			OptionsMenu optionsMenu = _hud.FindMenu<OptionsMenu>();
			if (!optionsMenu.IsClosed() && !optionsMenu.IsClosing())
			{
				optionsMenu.CloseMenu();
			}
			optionsMenu.OnClosed = (Action)Delegate.Remove(optionsMenu.OnClosed, new Action(CloseOptions));
			_careerGoalsButton.interactable = true;
			_leaderboardButton.interactable = true;
			OnMenuClosed.InvokeSafe();
		}

		public void RefreshCareerMenuNotification()
		{
			_showCareerNotification = false;
			foreach (MetagameObjective objective in _metagame.ObjectiveManager.Objectives)
			{
				if (objective.State == Objective.ObjectiveState.Finished && !objective.IsRewardCollected && objective.ShouldBeDisplayed() && !objective.MetagameObjectiveDefinition.HideFromUI)
				{
					_showCareerNotification = true;
					break;
				}
			}
			GameObjectUtils.SetActive(_careerNotificationObject, _showCareerNotification);
		}

		private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
		{
			_app.SaveMetagameDeferred();
			RefreshCareerMenuNotification();
		}
	}
}
