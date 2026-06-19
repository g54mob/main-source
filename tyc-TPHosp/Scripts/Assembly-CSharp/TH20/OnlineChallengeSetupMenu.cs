using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class OnlineChallengeSetupMenu : AnimatedMenuBase, IPauseTimeMenu
	{
		[SerializeField]
		private Localize _nameText;

		[SerializeField]
		private Localize _descriptionText;

		[SerializeField]
		private TMP_Text _lengthLabel;

		[SerializeField]
		private TMP_Text _rewardLabel;

		[SerializeField]
		private GameObject _notificationGameObject;

		[SerializeField]
		private GameObject _notificationRowPrefab;

		[SerializeField]
		private ScrollRect _notificationScroller;

		[SerializeField]
		private ChallengeRivalItem[] _rivalItems;

		[SerializeField]
		private ChallengeFriendPanel _friendPanel;

		[SerializeField]
		private DynamicButton _playButton;

		private Level _level;

		private OnlineChallengeObjective _objective;

		private readonly List<OnlineChallengeNotificationBox> _notificationBoxList = new List<OnlineChallengeNotificationBox>();

		private ObjectiveEvents _objectiveEvents;

		protected override void OnEnable()
		{
			_playButton.onPrimaryDown.AddListener(OnPlayPressed);
			for (int i = 0; i < _rivalItems.Length; i++)
			{
				ChallengeRivalItem obj = _rivalItems[i];
				obj.OnRemoveFriend = (Action<OnlinePlayerID>)Delegate.Combine(obj.OnRemoveFriend, new Action<OnlinePlayerID>(OnRemoveFriend));
			}
		}

		protected void OnDisable()
		{
			_playButton.onPrimaryDown.RemoveListener(OnPlayPressed);
			if (_objective != null)
			{
				_objective.LogNotificationView();
			}
			if (_objectiveEvents != null)
			{
				ObjectiveEvents objectiveEvents = _objectiveEvents;
				objectiveEvents.OnFriendDataUpdated = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>)Delegate.Remove(objectiveEvents.OnFriendDataUpdated, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>(OnFriendDataReceived));
			}
			for (int i = 0; i < _rivalItems.Length; i++)
			{
				ChallengeRivalItem obj = _rivalItems[i];
				obj.OnRemoveFriend = (Action<OnlinePlayerID>)Delegate.Remove(obj.OnRemoveFriend, new Action<OnlinePlayerID>(OnRemoveFriend));
			}
		}

		public void Initialise(Level level, ObjectiveEvents objectiveEvents)
		{
			_level = level;
			if (_objectiveEvents == null)
			{
				_objectiveEvents = objectiveEvents;
				ObjectiveEvents objectiveEvents2 = _objectiveEvents;
				objectiveEvents2.OnFriendDataUpdated = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>)Delegate.Combine(objectiveEvents2.OnFriendDataUpdated, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>(OnFriendDataReceived));
				_level.HospitalHUDManager.HideAllInfoMenus();
				HospitalHUDManager hospitalHUDManager = _level.HospitalHUDManager;
				hospitalHUDManager.OnRibbonMenuEnterMode = (Action<RibbonMenu.Mode>)Delegate.Combine(hospitalHUDManager.OnRibbonMenuEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode));
				HUDEvents hUDEvents = _level.HUDEvents;
				hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Combine(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
			}
		}

		public override void Destroy()
		{
			UnregisterEvents();
			if (_objective != null)
			{
				_objective.LogNotificationView();
			}
			_objective = null;
			base.Destroy();
		}

		public override void CloseMenu()
		{
			UnregisterEvents();
			base.CloseMenu();
		}

		private void UnregisterEvents()
		{
			HospitalHUDManager hospitalHUDManager = _level.HospitalHUDManager;
			hospitalHUDManager.OnRibbonMenuEnterMode = (Action<RibbonMenu.Mode>)Delegate.Remove(hospitalHUDManager.OnRibbonMenuEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode));
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Remove(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
		}

		public void Setup(OnlineChallengeObjective objective, OnlineMetadataManager onlineMetadataManager)
		{
			if (_objective != null)
			{
				_objective.LogNotificationView();
			}
			_objective = objective;
			_nameText.SetTerm(objective.Definition.NameLocalised.Term);
			_descriptionText.SetTerm(objective.Definition.DescriptionLocalised.Term);
			_lengthLabel.text = LocalisedString.GetTranslationPlural("Menu/OnlineSetup/ChallengeLength_CS", objective.Definition.TimeLength);
			_lengthLabel.text = string.Format(_lengthLabel.text, objective.Definition.TimeLength);
			_rewardLabel.text = string.Format(ScriptLocalization.Menu_OnlineSetup.ChallengeReward_CS, RewardUtils.GetFullRewardString(objective, objective.Definition.CompletionRewards, ","));
			_friendPanel.Initialise(objective, onlineMetadataManager, RefreshRivals);
			Refresh();
		}

		private void Refresh()
		{
			RefreshNotifications();
			RefreshRivals();
		}

		private void RefreshNotifications()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn() || _level.Metagame.OnlineMetadataManager.LocalPlayerData == null)
			{
				GameObjectUtils.SetActive(_notificationGameObject, isActive: false);
				return;
			}
			List<OnlineChallengeData> list = _objective.FriendDataCache.Values.Where((OnlineChallengeData data) => data.PlayerID != OnlineManager.GetLocalPlayerID()).ToList();
			if (list.Count < 1)
			{
				GameObjectUtils.SetActive(_notificationGameObject, isActive: false);
				return;
			}
			list.Sort((OnlineChallengeData c1, OnlineChallengeData c2) => c2.LastUpdateTime.CompareTo(c1.LastUpdateTime));
			AllocateNotificationRows(list.Count);
			OnlineMetadata localPlayerData = _level.Metagame.OnlineMetadataManager.LocalPlayerData;
			bool isActive = false;
			for (int num = 0; num < _notificationBoxList.Count; num++)
			{
				if (list.Count <= num)
				{
					GameObjectUtils.SetActive(_notificationBoxList[num].gameObject, isActive: false);
					continue;
				}
				OnlineChallengeData onlineChallengeData = list[num];
				if (OnlineManager.IsUserBlockingInvites(onlineChallengeData.PlayerID))
				{
					GameObjectUtils.SetActive(_notificationBoxList[num].gameObject, isActive: false);
					continue;
				}
				OnlineMetadata.ChallengeScore score;
				bool challengeScore = localPlayerData.GetChallengeScore(_objective.ObjectiveUniqueID, out score);
				_notificationBoxList[num].Setup(onlineChallengeData, _objective.TimestampLastSeen >= onlineChallengeData.LastUpdateTime, challengeScore ? score.Score : 0);
				GameObjectUtils.SetActive(_notificationBoxList[num].gameObject, isActive: true);
				isActive = true;
			}
			GameObjectUtils.SetActive(_notificationGameObject, isActive);
		}

		private void RefreshRivals()
		{
			int num = 0;
			for (int i = 0; i < _rivalItems.Length; i++)
			{
				if (i >= _friendPanel.SelectedFriendsList.Count)
				{
					List<SharedInstance<RivalFoundationDefinition>> list = _objective.Definition.AIRivals.Keys.ToList();
					if (num >= list.Count)
					{
						_rivalItems[i].SetupEmpty();
						continue;
					}
					_rivalItems[i].SetupForAI(list[num].Instance);
					num++;
				}
				else
				{
					_rivalItems[i].SetupForFriend(_friendPanel.SelectedFriendsList[i]);
				}
			}
		}

		private void OnPlayPressed()
		{
			_objective.PlayerInfoDictionary.Clear();
			for (int i = 0; i < _rivalItems.Length; i++)
			{
				if (_objective.PlayerInfoDictionary.Count >= OnlineChallengeObjective.MaxChallengeRivals)
				{
					break;
				}
				ChallengeRivalItem challengeRivalItem = _rivalItems[i];
				if (challengeRivalItem.RivalFoundation != null)
				{
					OnlineChallengeDefinition.RivalScoreData rivalScoreData = _objective.Definition.GetRivalScoreData(challengeRivalItem.RivalFoundation);
					if (rivalScoreData != null)
					{
						_objective.PlayerInfoDictionary[challengeRivalItem.OnlinePlayerID] = new OnlineChallengeObjective.PlayerInfo(challengeRivalItem.RivalFoundation, rivalScoreData);
					}
				}
				else
				{
					_objective.PlayerInfoDictionary[challengeRivalItem.OnlinePlayerID] = new OnlineChallengeObjective.PlayerInfo(challengeRivalItem.OnlinePlayerID);
				}
			}
			_level.LevelScriptManager.SetActiveOnlineChallenge(_objective);
			_objective.Start();
			CloseMenu();
		}

		private void OnRemoveFriend(OnlinePlayerID onlinePlayerID)
		{
			_friendPanel.UnselectFriend(onlinePlayerID);
			RefreshRivals();
		}

		private void AllocateNotificationRows(int numRows)
		{
			for (int i = 0; i < numRows; i++)
			{
				if (_notificationBoxList.Count <= i)
				{
					OnlineChallengeNotificationBox component = UnityEngine.Object.Instantiate(_notificationRowPrefab, _notificationScroller.content, worldPositionStays: false).GetComponent<OnlineChallengeNotificationBox>();
					_notificationBoxList.Add(component);
				}
			}
		}

		private void OnFriendDataReceived(OnlineChallengeObjective objective, OnlinePlayerID onlinePlayerID, OnlineChallengeData data)
		{
			if (objective == _objective)
			{
				RefreshNotifications();
			}
		}

		private void OnMenuOpen(MenuBase menuBase)
		{
			if (menuBase != this)
			{
				if (base.isActiveAndEnabled)
				{
					CloseMenu();
				}
				else
				{
					CloseMenuImmediately();
				}
			}
		}

		private void OnRibbonMenuEnterMode(RibbonMenu.Mode mode)
		{
			CloseMenu();
		}
	}
}
