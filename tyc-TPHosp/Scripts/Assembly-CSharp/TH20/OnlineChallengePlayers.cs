using System;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using JetBrains.Annotations;
using TH20.EventStaffHired;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class OnlineChallengePlayers : MonoBehaviour, Interface, IGameEventCallback
	{
		[Serializable]
		public class Tab
		{
			public Image AvatarImage;

			public DynamicButton Button;

			public GameObject TabGameObject;

			public Image TabLeftImage;

			public Image TabRightImage;

			[NonSerialized]
			public OnlinePlayerID OnlinePlayerID;

			[NonSerialized]
			public Color PlayerColor;
		}

		[SerializeField]
		private Tab[] _tabs;

		[SerializeField]
		private Image _folderTopImage;

		[SerializeField]
		private Image _folderBottomImage;

		[SerializeField]
		private TMP_Text _dayLabel;

		[SerializeField]
		private TMP_Text _playerCashText;

		[SerializeField]
		private TMP_Text _playerPositionText;

		[SerializeField]
		private HospitalStarIcons _starIcons;

		[SerializeField]
		private ProgressBarMaskable _reputationBar;

		[SerializeField]
		private ProgressBarMaskable _prestigeBar;

		[SerializeField]
		private TMP_Text _prestigeLevelLabel;

		[SerializeField]
		private TMP_Text _doctorCountText;

		[SerializeField]
		private TMP_Text _nurseCountText;

		[SerializeField]
		private TMP_Text _janitorCountText;

		[SerializeField]
		private TMP_Text _assistantCountText;

		[SerializeField]
		private TMP_Text _cureCountText;

		[SerializeField]
		private TMP_Text _ineffectiveCountText;

		[SerializeField]
		private TMP_Text _rageQuitCountText;

		[SerializeField]
		private TMP_Text _deathCountText;

		[SerializeField]
		private PlayerAvatar _latestLogAvatar;

		[SerializeField]
		private TMP_Text _latestLogText;

		[SerializeField]
		private TMP_Text _foundationNameLabel;

		[SerializeField]
		private TMP_Text _foundationValueLabel;

		[SerializeField]
		private TMP_Text _foundationStarsLabel;

		[SerializeField]
		private TMP_Text _foundationSilverLabel;

		[SerializeField]
		private GameObject _dataOverlay;

		[SerializeField]
		private GameObject _noDataOverlay;

		[SerializeField]
		private GameObject _downloadingOverlay;

		[SerializeField]
		private GameObject _noConnectionOverlay;

		[SerializeField]
		private GameObject _rivalOverlay;

		private string[] _positionStrings;

		private Level _level;

		private OnlineChallengeScores _scores;

		private OnlineChallengeObjective _levelObjective;

		private Tab _currentPlayerTab;

		private OnlineChallengeData _currentData;

		private BaseOnlineDataFile _currentPlayerFile;

		private bool _staffInfoFinalised;

		private bool _dailyInfoFinalised;

		private void InitialisePositionStrings()
		{
			if (_positionStrings == null)
			{
				_positionStrings = new string[8]
				{
					ScriptLocalization.Online.OrdinalNumber_First_Big_CS,
					ScriptLocalization.Online.OrdinalNumber_Second_Big_CS,
					ScriptLocalization.Online.OrdinalNumber_Third_Big_CS,
					ScriptLocalization.Online.OrdinalNumber_Fourth_Big_CS,
					ScriptLocalization.Online.OrdinalNumber_Fifth_Big_CS,
					ScriptLocalization.Online.OrdinalNumber_Sixth_Big_CS,
					ScriptLocalization.Online.OrdinalNumber_Seventh_Big_CS,
					ScriptLocalization.Online.OrdinalNumber_Eigth_Big_CS
				};
			}
		}

		private void OnEnable()
		{
			InitialisePositionStrings();
			_level.CharacterEvents.OnStaffHired.Add(this);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFiredEvent));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdatedEvent));
			ReputationTracker reputationTracker = _level.ReputationTracker;
			reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Combine(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedEvent));
			Tab[] tabs = _tabs;
			foreach (Tab tab in tabs)
			{
				Tab closureTab = tab;
				tab.Button.onPrimaryDown.AddListener(delegate
				{
					OnPlayerSelected(closureTab);
				});
			}
			RefreshAll();
		}

		private void OnDisable()
		{
			_level.CharacterEvents.OnStaffHired.Remove(this);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFiredEvent));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdatedEvent));
			ReputationTracker reputationTracker = _level.ReputationTracker;
			reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Remove(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedEvent));
			Tab[] tabs = _tabs;
			for (int i = 0; i < tabs.Length; i++)
			{
				tabs[i].Button.onPrimaryDown.RemoveAllListeners();
			}
		}

		public void SetupForChallenge(OnlineChallengeObjective levelObjective, OnlineChallengeScores scores, Level level)
		{
			InitialisePositionStrings();
			_levelObjective = levelObjective;
			_scores = scores;
			_level = level;
			IOrderedEnumerable<KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo>> orderedEnumerable = _levelObjective.PlayerInfoDictionary.OrderByDescending(delegate(KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> pair)
			{
				KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> keyValuePair = pair;
				return keyValuePair.Value.IsLocalPlayer;
			});
			int num = 0;
			foreach (KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> item in orderedEnumerable)
			{
				OnlineChallengeObjective.PlayerInfo value = item.Value;
				if (value != null)
				{
					_tabs[num].OnlinePlayerID = value.OnlinePlayerID;
					_tabs[num].PlayerColor = value.PlayerColor;
					_tabs[num].TabLeftImage.color = value.PlayerColor;
					_tabs[num].TabRightImage.color = value.PlayerColor;
					GameObjectUtils.SetActive(_tabs[num].TabGameObject, isActive: true);
					if (value.IsAI)
					{
						_tabs[num].AvatarImage.overrideSprite = ((value.RivalIcon != null) ? value.RivalIcon : null);
						_tabs[num].PlayerColor = ((value.RivalIcon != null) ? Color.white : value.PlayerColor);
					}
					else if (value.OnlinePlayerID != OnlinePlayerID.Nil)
					{
						Sprite avatar = OnlineManager.GetAvatar(value.OnlinePlayerID);
						_tabs[num].AvatarImage.overrideSprite = avatar;
					}
					else
					{
						_tabs[num].AvatarImage.overrideSprite = (value.IsLocalPlayer ? OnlineManager.DefaultOrganisationSprite : OnlineManager.DefaultAvatarSprite);
					}
					num++;
				}
			}
			for (; num < 5; num++)
			{
				GameObjectUtils.SetActive(_tabs[num].TabGameObject, isActive: false);
			}
			_dailyInfoFinalised = false;
			_staffInfoFinalised = false;
			_currentPlayerTab = _tabs[0];
		}

		public void OnFriendDataUpdated()
		{
			RefreshAll();
		}

		public void OnFriendScreenDataUpdated()
		{
			RefreshAll();
		}

		private void OnPlayerSelected(Tab tab)
		{
			_currentPlayerTab = tab;
			_currentPlayerFile = _levelObjective.GetDownloadFileInfo(_currentPlayerTab.OnlinePlayerID);
			RefreshAll();
		}

		public void RefreshAll()
		{
			OnlineChallengeObjective.PlayerInfo playerInfo = _levelObjective.GetPlayerInfo(_currentPlayerTab.OnlinePlayerID);
			if (playerInfo == null)
			{
				return;
			}
			_folderBottomImage.color = playerInfo.PlayerColor;
			_folderTopImage.color = playerInfo.PlayerColor;
			GameObjectUtils.SetActive(_dataOverlay, isActive: false);
			GameObjectUtils.SetActive(_noDataOverlay, isActive: false);
			GameObjectUtils.SetActive(_downloadingOverlay, isActive: false);
			GameObjectUtils.SetActive(_noConnectionOverlay, isActive: false);
			GameObjectUtils.SetActive(_rivalOverlay, isActive: false);
			if (playerInfo.IsLocalPlayer && _levelObjective.State != Objective.ObjectiveState.Finished)
			{
				GameObjectUtils.SetActive(_dataOverlay, isActive: true);
				MetagameHospitalRecord hospitalRecord = _level.Metagame.GetHospitalRecord(_level.Config);
				if (hospitalRecord != null)
				{
					_starIcons.Setup(hospitalRecord.TotalLevelStars());
				}
				else
				{
					_starIcons.Setup(0);
				}
				_playerCashText.text = StringUtils.FormatCurrency(_level.FinanceManager.Balance);
				int playerPosition = _scores.GetPlayerPosition(_currentPlayerTab.OnlinePlayerID);
				if (playerPosition == -1)
				{
					_playerPositionText.text = string.Empty;
				}
				else
				{
					_playerPositionText.text = _positionStrings[playerPosition];
				}
				RefreshStaffNumbers();
				RefreshDailyInfo();
				_cureCountText.text = _levelObjective.LocalPlayerObjectiveData.CountEventsOfType(OnlineChallengeEvent.Event.PatientCured).ToString();
				_ineffectiveCountText.text = _levelObjective.LocalPlayerObjectiveData.CountEventsOfType(OnlineChallengeEvent.Event.PatientCureIneffective).ToString();
				_rageQuitCountText.text = _levelObjective.LocalPlayerObjectiveData.CountEventsOfType(OnlineChallengeEvent.Event.PatientRageQuit).ToString();
				_deathCountText.text = _levelObjective.LocalPlayerObjectiveData.CountEventsOfType(OnlineChallengeEvent.Event.PatientDeath).ToString();
				_latestLogAvatar.PlayerID = _levelObjective.LocalPlayerID;
				OnlineChallengeEvent mostRecentDisplayableEvent = _levelObjective.LocalPlayerObjectiveData.GetMostRecentDisplayableEvent(_levelObjective.DaysElapsed);
				if (mostRecentDisplayableEvent != null)
				{
					_latestLogText.text = $"{OnlineChallengeEventLog.GetChallengeEventDayString(mostRecentDisplayableEvent.Day + 1, colored: true)} {OnlineChallengeEventLog.GetChallengeEventString(mostRecentDisplayableEvent)}";
					_latestLogText.color = new Color(1f, 1f, 1f, 1f);
				}
				else
				{
					_latestLogText.text = ScriptLocalization.Online.EventLog_NoEvent_CS;
					_latestLogText.color = new Color(1f, 1f, 1f, 0.5f);
				}
				_foundationNameLabel.text = playerInfo.PlayerName;
				_foundationValueLabel.text = $"{StringUtils.FormatCurrency(_level.Metagame.TotalFoundationValue())} - {StringUtils.FormatShareValue(_level.Metagame.GetShareValue())}";
				_foundationStarsLabel.text = StringUtils.FormatNumber(_level.Metagame.TotalStars());
				_foundationSilverLabel.text = StringUtils.FormatNumber(_level.Metagame.TotalSilver());
				return;
			}
			_currentData = playerInfo.ChallengeData as OnlineChallengeData;
			if (_currentData == null)
			{
				if (playerInfo.IsAI)
				{
					GameObjectUtils.SetActive(_rivalOverlay, isActive: true);
				}
				else if (!OnlineManager.IsInitializedAndLoggedOn())
				{
					GameObjectUtils.SetActive(_noConnectionOverlay, isActive: true);
				}
				else if (_currentPlayerFile != null && _currentPlayerFile.IsDownloading())
				{
					GameObjectUtils.SetActive(_downloadingOverlay, isActive: true);
				}
				else
				{
					GameObjectUtils.SetActive(_noDataOverlay, isActive: true);
				}
				return;
			}
			OnlineChallengeEventHospitalStatus mostRecentEventOfType = _currentData.GetMostRecentEventOfType<OnlineChallengeEventHospitalStatus>(_levelObjective.DaysElapsed);
			if (mostRecentEventOfType == null)
			{
				if (!OnlineManager.IsInitializedAndLoggedOn())
				{
					GameObjectUtils.SetActive(_noConnectionOverlay, isActive: true);
				}
				else
				{
					GameObjectUtils.SetActive(_noDataOverlay, isActive: true);
				}
				return;
			}
			GameObjectUtils.SetActive(_dataOverlay, isActive: true);
			OnlineMetadata onlineMetadata = _level.Metagame.OnlineMetadataManager.GetOnlineMetadata(_currentPlayerTab.OnlinePlayerID);
			if (onlineMetadata != null)
			{
				if (onlineMetadata.GetStarProgress(_level.Config, out var starScore))
				{
					_starIcons.Setup(starScore);
				}
				else
				{
					_starIcons.Setup(0);
				}
			}
			else
			{
				MetagameHospitalRecord hospitalRecord2 = _level.Metagame.GetHospitalRecord(_level.Config);
				if (playerInfo.IsLocalPlayer && hospitalRecord2 != null)
				{
					_starIcons.Setup(hospitalRecord2.TotalLevelStars());
				}
				else
				{
					_starIcons.Setup(0);
				}
			}
			_playerCashText.text = StringUtils.FormatCurrency(mostRecentEventOfType.Balance);
			int playerPosition2 = _scores.GetPlayerPosition(_currentPlayerTab.OnlinePlayerID);
			if (playerPosition2 == -1)
			{
				_playerPositionText.text = string.Empty;
			}
			else
			{
				_playerPositionText.text = _positionStrings[playerPosition2];
			}
			_doctorCountText.text = mostRecentEventOfType.DoctorCount.ToString();
			_nurseCountText.text = mostRecentEventOfType.NurseCount.ToString();
			_janitorCountText.text = mostRecentEventOfType.JanitorCount.ToString();
			_assistantCountText.text = mostRecentEventOfType.AssistantCount.ToString();
			_reputationBar.SetProgressSmooth(mostRecentEventOfType.Reputation);
			_prestigeBar.SetProgressSmooth(mostRecentEventOfType.PrestigeProgress);
			_prestigeLevelLabel.text = string.Format(ScriptLocalization.Misc.PrestigeLevel_CS, mostRecentEventOfType.PrestigeLevel);
			_cureCountText.text = _currentData.CountEventsOfType(OnlineChallengeEvent.Event.PatientCured).ToString();
			_ineffectiveCountText.text = _currentData.CountEventsOfType(OnlineChallengeEvent.Event.PatientCureIneffective).ToString();
			_rageQuitCountText.text = _currentData.CountEventsOfType(OnlineChallengeEvent.Event.PatientRageQuit).ToString();
			_deathCountText.text = _currentData.CountEventsOfType(OnlineChallengeEvent.Event.PatientDeath).ToString();
			OnlineChallengeEvent mostRecentDisplayableEvent2 = _currentData.GetMostRecentDisplayableEvent(_levelObjective.DaysElapsed);
			if (mostRecentDisplayableEvent2 != null)
			{
				_latestLogText.text = OnlineChallengeEventLog.GetChallengeEventString(mostRecentDisplayableEvent2);
				GameObjectUtils.SetActive(_latestLogAvatar.gameObject, isActive: true);
				_latestLogAvatar.PlayerID = _currentData.PlayerID;
			}
			else
			{
				GameObjectUtils.SetActive(_latestLogAvatar.gameObject, isActive: false);
				_latestLogText.text = string.Empty;
			}
			_foundationNameLabel.text = playerInfo.PlayerName;
			_foundationValueLabel.text = $"{StringUtils.FormatCurrency(mostRecentEventOfType.FoundationValue)} - {StringUtils.FormatShareValue(mostRecentEventOfType.FoundationShareValue)}";
			_foundationStarsLabel.text = StringUtils.FormatNumber(mostRecentEventOfType.FoundationStars);
			_foundationSilverLabel.text = StringUtils.FormatNumber(mostRecentEventOfType.FoundationSilver);
		}

		private void RefreshStaffNumbers()
		{
			if (_levelObjective.State == Objective.ObjectiveState.Finished)
			{
				if (_staffInfoFinalised)
				{
					return;
				}
				_staffInfoFinalised = true;
			}
			if (_levelObjective.LocalPlayerID == _currentPlayerTab.OnlinePlayerID)
			{
				_doctorCountText.text = _level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Doctor && staff.CurrentMode != Staff.Mode.Fired && staff.CurrentMode != Staff.Mode.Resigned).ToString();
				_nurseCountText.text = _level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Nurse && staff.CurrentMode != Staff.Mode.Fired && staff.CurrentMode != Staff.Mode.Resigned).ToString();
				_janitorCountText.text = _level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Janitor && staff.CurrentMode != Staff.Mode.Fired && staff.CurrentMode != Staff.Mode.Resigned).ToString();
				_assistantCountText.text = _level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == StaffDefinition.Type.Assistant && staff.CurrentMode != Staff.Mode.Fired && staff.CurrentMode != Staff.Mode.Resigned).ToString();
			}
		}

		private void RefreshDailyInfo()
		{
			if (_levelObjective.State == Objective.ObjectiveState.Finished)
			{
				if (_dailyInfoFinalised)
				{
					return;
				}
				_dailyInfoFinalised = true;
			}
			int num = Mathf.Min(_levelObjective.DaysElapsed + 1, _levelObjective.Definition.TimeLength);
			_dayLabel.text = num.ToString("D2");
			if (_levelObjective.LocalPlayerID == _currentPlayerTab.OnlinePlayerID)
			{
				_playerCashText.text = StringUtils.FormatCurrency(_level.FinanceManager.Balance);
				_reputationBar.SetProgressSmooth(_level.ReputationTracker.OverallReputation);
				_prestigeLevelLabel.text = string.Format(ScriptLocalization.Misc.PrestigeLevel_CS, _level.PrestigeTracker.Level);
				_prestigeBar.SetProgressSmooth(_level.PrestigeTracker.Progress);
			}
		}

		public void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee)
		{
			RefreshStaffNumbers();
		}

		private void OnStaffFiredEvent(Staff staff)
		{
			RefreshStaffNumbers();
		}

		private void OnBalanceUpdatedEvent(int balance)
		{
			RefreshDailyInfo();
		}

		private void OnReputationChangedEvent(float reputation)
		{
			RefreshDailyInfo();
		}

		public void OnTimelineUpdated()
		{
			RefreshDailyInfo();
		}
	}
}
