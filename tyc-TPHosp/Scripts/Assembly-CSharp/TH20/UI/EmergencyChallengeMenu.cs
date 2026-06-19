using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TH20.UI
{
	public class EmergencyChallengeMenu : AnimatedMenuBase
	{
		[SerializeField]
		private DynamicButton _dispatchButton;

		[SerializeField]
		private DynamicButton _leagueTablesButton;

		[SerializeField]
		private UnseenNotificationsIcon _notificationsIcon;

		[SerializeField]
		private GameObject _tutorialCircle;

		private Level _level;

		private EmergencyDispatchMenu _dispatchMenu;

		private EmergencyStatsMenu _statsMenu;

		public EmergencyDispatchMenu EmergencyDispatchMenu => _dispatchMenu;

		public void Setup(Level level)
		{
			if (_level != level)
			{
				_level = level;
				_dispatchButton.onPrimaryDown.AddListener(OnDispatchButtonClick);
				_leagueTablesButton.onPrimaryDown.AddListener(OnLeagueTablesButtonClick);
				MetagameMap metagameMap = _level.MetagameMap;
				metagameMap.OnOpen = (Action)Delegate.Combine(metagameMap.OnOpen, new Action(CloseBoth));
				_dispatchMenu = null;
			}
			RefreshNotificationIcon();
		}

		public void OnDestroy()
		{
			_dispatchButton.onPrimaryDown.RemoveAllListeners();
			_leagueTablesButton.onPrimaryDown.RemoveAllListeners();
			if (_level != null)
			{
				MetagameMap metagameMap = _level.MetagameMap;
				metagameMap.OnOpen = (Action)Delegate.Remove(metagameMap.OnOpen, new Action(CloseBoth));
			}
			CloseBoth();
		}

		private void CloseBoth()
		{
			if (_dispatchMenu != null && !_dispatchMenu.IsClosed())
			{
				_dispatchMenu.CloseImmediately();
			}
			if (_statsMenu != null && !_statsMenu.IsClosed())
			{
				_statsMenu.CloseMenu();
			}
		}

		public void RefreshNotificationIcon()
		{
			List<ChallengeAmbulanceEmergency> list = (from emergency in _level.ChallengeManager.GetActiveChallengesOfType<ChallengeAmbulanceEmergency>()
				where !emergency.PlayerHasDispatched
				select emergency).ToList();
			_notificationsIcon.UnseenNotifications = list.Count;
		}

		private void OnDispatchButtonClick()
		{
			if (_dispatchMenu == null)
			{
				_level.HospitalHUDManager.TryHideRibbonMenu();
				_dispatchMenu = _level.HUD.CreateMenu<EmergencyDispatchMenu>();
				_dispatchMenu.Setup(_level);
				_statsMenu?.TryCloseMenu();
				_level.ChallengeManager.OnOpenSatNav.InvokeSafe(param: true);
			}
			else
			{
				_dispatchMenu.TryCloseMenu();
			}
		}

		private void OnLeagueTablesButtonClick()
		{
			if (_statsMenu == null)
			{
				_level.HospitalHUDManager.TryHideRibbonMenu();
				_statsMenu = _level.HUD.CreateMenu<EmergencyStatsMenu>();
				_statsMenu.Setup(_level);
				if (_dispatchMenu != null && !_dispatchMenu.IsClosed() && !_dispatchMenu.IsClosing())
				{
					_dispatchMenu.TryCloseMenu();
				}
			}
			else
			{
				_statsMenu.TryCloseMenu();
			}
		}

		public void TutorialCircleDispatchButton(bool active)
		{
			GameObjectUtils.SetActive(_tutorialCircle, active);
		}
	}
}
