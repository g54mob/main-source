using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class OnlineChallengeHome : MonoBehaviour
	{
		public struct FriendSortItem : IComparable<FriendSortItem>
		{
			public OnlinePlayerID OnlinePlayerID;

			public int PrimarySort;

			public uint SecondarySort;

			public RivalFoundationDefinition RivalDef;

			public FriendSortItem(OnlinePlayerID onlinePlayerID)
			{
				OnlinePlayerID = onlinePlayerID;
				PrimarySort = int.MaxValue;
				SecondarySort = uint.MaxValue;
				RivalDef = null;
			}

			public FriendSortItem(RivalFoundationDefinition rivalDef)
			{
				OnlinePlayerID = rivalDef.DummySteamID;
				PrimarySort = 10;
				SecondarySort = uint.MaxValue;
				RivalDef = rivalDef;
			}

			public int CompareTo(FriendSortItem obj)
			{
				int num = PrimarySort - obj.PrimarySort;
				if (num == 0)
				{
					return (int)(SecondarySort - obj.SecondarySort);
				}
				return num;
			}
		}

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _descriptionText;

		[SerializeField]
		private Button _backButton;

		[SerializeField]
		private Button _advancedButton;

		[SerializeField]
		private Button _playButton;

		[SerializeField]
		private TMP_Text _playButtonText;

		[SerializeField]
		private GraphicRaycaster _raycaster;

		[SerializeField]
		private OnlineChallengeHomeAdvanced _homeAdvanced;

		[SerializeField]
		private List<OnlineChallengeNotificationBox> _notification = new List<OnlineChallengeNotificationBox>();

		private readonly List<FriendSortItem> _friendsList = new List<FriendSortItem>();

		private OnlineChallengeObjective _onlineChallengeObjective;

		private OnlineMetadataManager _onlineMetadataManager;

		private LevelScriptManager _levelScriptManager;

		private InputManager _inputManager;

		private bool _isShowingAdvanced;

		public void Initialise(LevelScriptManager levelScriptManager, InputManager inputManager, OnlineMetadataManager onlineMetadataManager)
		{
			_levelScriptManager = levelScriptManager;
			_inputManager = inputManager;
			_onlineMetadataManager = onlineMetadataManager;
			if (_raycaster != null)
			{
				inputManager.AddGraphicRayCaster(_raycaster);
			}
			_playButton.onClick.AddListener(OnPlayPressed);
			if (_backButton != null)
			{
				_backButton.onClick.AddListener(OnBackPressed);
			}
			if (_advancedButton != null)
			{
				_advancedButton.onClick.AddListener(OnOptionsPressed);
			}
		}

		public void SetupForObjective(OnlineChallengeObjective onlineChallenge)
		{
			_onlineChallengeObjective = onlineChallenge;
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				VerifyFriendsList();
				SortFriendsList();
				if (_homeAdvanced != null)
				{
					_homeAdvanced.Setup(_onlineChallengeObjective.Definition, _friendsList);
				}
			}
			Refresh();
		}

		private void OnEnable()
		{
			Refresh();
		}

		private void OnDisable()
		{
			if (_homeAdvanced != null)
			{
				_homeAdvanced.gameObject.SetActive(value: false);
				_isShowingAdvanced = false;
			}
			if (_onlineChallengeObjective != null)
			{
				_onlineChallengeObjective.LogNotificationView();
				_onlineChallengeObjective.Level.Metagame.OnlineChallengeViewRecord.LogView(_onlineChallengeObjective.ObjectiveUniqueID);
			}
		}

		private void OnDestroy()
		{
			if (_raycaster != null)
			{
				_inputManager.RemoveGraphicRayCaster(_raycaster);
			}
			_playButton.onClick.RemoveListener(OnPlayPressed);
			if (_backButton != null)
			{
				_backButton.onClick.RemoveListener(OnBackPressed);
			}
			if (_advancedButton != null)
			{
				_advancedButton.onClick.RemoveListener(OnOptionsPressed);
			}
		}

		private void Refresh()
		{
			if (_onlineChallengeObjective != null)
			{
				_titleText.text = _onlineChallengeObjective.Definition.NameLocalised.Translation;
				_descriptionText.text = $"{_onlineChallengeObjective.Definition.DescriptionLocalised.Translation}\n<line-height=130%><color=#90FF8AFF>Length: {_onlineChallengeObjective.Definition.TimeLength} days\nReward: {RewardUtils.GetFullRewardString(_onlineChallengeObjective, _onlineChallengeObjective.Definition.CompletionRewards)}";
				if (_onlineChallengeObjective.State == Objective.ObjectiveState.Active)
				{
					_playButtonText.text = "ABANDON";
				}
				else if (_onlineChallengeObjective.State == Objective.ObjectiveState.Finished)
				{
					_playButtonText.text = "FINISH";
				}
				else if (OnlineManager.IsInitializedAndLoggedOn())
				{
					_playButtonText.text = "PLAY";
				}
				else
				{
					_playButtonText.text = "PLAY (Offline)";
				}
				if (_advancedButton != null)
				{
					_advancedButton.enabled = OnlineManager.IsInitializedAndLoggedOn();
					_advancedButton.gameObject.SetActive(_onlineChallengeObjective.State != Objective.ObjectiveState.Active);
				}
				if (_homeAdvanced != null)
				{
					_homeAdvanced.gameObject.SetActive(_isShowingAdvanced);
				}
				if (_backButton != null)
				{
					_backButton.gameObject.SetActive(_onlineChallengeObjective.State == Objective.ObjectiveState.Unstarted);
				}
				RefreshNotificationBoxes();
			}
		}

		public void RefreshNotificationBoxes()
		{
			if (_onlineChallengeObjective == null)
			{
				return;
			}
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				for (int i = 0; i < _notification.Count; i++)
				{
					_notification[i].Setup(null, hasSeen: true, 0);
				}
				return;
			}
			List<OnlineChallengeData> list = _onlineChallengeObjective.FriendDataCache.Values.ToList();
			list.Sort((OnlineChallengeData c1, OnlineChallengeData c2) => c2.LastUpdateTime.CompareTo(c1.LastUpdateTime));
			OnlineMetadata localPlayerData = _onlineChallengeObjective.Level.Metagame.OnlineMetadataManager.LocalPlayerData;
			for (int num = 0; num < _notification.Count; num++)
			{
				if (list.Count <= num)
				{
					_notification[num].Setup(null, hasSeen: true, 0);
					continue;
				}
				OnlineChallengeData onlineChallengeData = list[num];
				OnlineMetadata.ChallengeScore score;
				bool challengeScore = localPlayerData.GetChallengeScore(_onlineChallengeObjective.ObjectiveUniqueID, out score);
				_notification[num].Setup(onlineChallengeData, _onlineChallengeObjective.TimestampLastSeen >= onlineChallengeData.LastUpdateTime, challengeScore ? score.Score : 0);
			}
		}

		public void WorkOutPlayers()
		{
			_onlineChallengeObjective.PlayerInfoDictionary.Clear();
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				if (_homeAdvanced != null)
				{
					foreach (FriendSortItem selectedRivals in _homeAdvanced.SelectedRivalsList)
					{
						if (selectedRivals.RivalDef != null)
						{
							OnlineChallengeDefinition.RivalScoreData rivalScoreData = _onlineChallengeObjective.Definition.GetRivalScoreData(selectedRivals.RivalDef);
							if (rivalScoreData == null)
							{
								continue;
							}
							_onlineChallengeObjective.PlayerInfoDictionary[selectedRivals.OnlinePlayerID] = new OnlineChallengeObjective.PlayerInfo(selectedRivals.RivalDef, rivalScoreData);
						}
						else
						{
							_onlineChallengeObjective.PlayerInfoDictionary[selectedRivals.OnlinePlayerID] = new OnlineChallengeObjective.PlayerInfo(selectedRivals.OnlinePlayerID);
						}
						if (_onlineChallengeObjective.PlayerInfoDictionary.Count >= OnlineChallengeObjective.MaxChallengeRivals)
						{
							return;
						}
					}
				}
				foreach (FriendSortItem friends in _friendsList)
				{
					if (friends.PrimarySort < 9)
					{
						_onlineChallengeObjective.PlayerInfoDictionary[friends.OnlinePlayerID] = new OnlineChallengeObjective.PlayerInfo(friends.OnlinePlayerID);
						if (_onlineChallengeObjective.PlayerInfoDictionary.Count >= OnlineChallengeObjective.MaxChallengeRivals)
						{
							return;
						}
					}
				}
			}
			foreach (KeyValuePair<SharedInstance<RivalFoundationDefinition>, OnlineChallengeDefinition.RivalScoreData> aIRival in _onlineChallengeObjective.Definition.AIRivals)
			{
				RivalFoundationDefinition instance = aIRival.Key.Instance;
				if (instance != null)
				{
					OnlineChallengeObjective.PlayerInfo value = new OnlineChallengeObjective.PlayerInfo(instance, aIRival.Value);
					_onlineChallengeObjective.PlayerInfoDictionary[new OnlinePlayerID(instance.DummySteamID)] = value;
					if (_onlineChallengeObjective.PlayerInfoDictionary.Count >= OnlineChallengeObjective.MaxChallengeRivals)
					{
						break;
					}
				}
			}
		}

		private void VerifyFriendsList()
		{
			_friendsList.Clear();
			foreach (OnlinePlayerID friendPlayerID in OnlineManager.GetFriendPlayerIDs())
			{
				if (!(friendPlayerID == OnlineManager.GetLocalPlayerID()))
				{
					_friendsList.Add(new FriendSortItem(friendPlayerID));
				}
			}
		}

		private void SortFriendsList()
		{
			uint serverTime = OnlineManager.GetServerTime();
			for (int i = 0; i < _friendsList.Count; i++)
			{
				FriendSortItem value = _friendsList[i];
				OnlineChallengeData onlineChallengeData = _onlineChallengeObjective.GetData(value.OnlinePlayerID) as OnlineChallengeData;
				OnlineMetadata onlineMetadata = _onlineMetadataManager.GetOnlineMetadata(value.OnlinePlayerID);
				bool flag = onlineChallengeData != null && serverTime - onlineChallengeData.LastUpdateTime <= 3600;
				bool flag2 = onlineMetadata != null && onlineMetadata.LastPlayedLevel == _onlineChallengeObjective.Level.Config;
				bool flag3 = onlineMetadata?.HasPlayedLevel(_onlineChallengeObjective.Level.Config) ?? false;
				bool flag4 = onlineChallengeData != null;
				bool flag5 = onlineChallengeData != null && onlineChallengeData.ChallengeLength >= onlineChallengeData.GetMostRecentDay() && flag;
				bool flag6 = onlineChallengeData?.PlayersList.Contains(OnlineManager.GetLocalPlayerID()) ?? false;
				bool flag7 = OnlineManager.GetPlayerInfo(value.OnlinePlayerID)?.IsPlayingGame() ?? false;
				uint secondarySort = ((onlineChallengeData != null) ? (serverTime - onlineChallengeData.LastUpdateTime) : uint.MaxValue);
				value.SecondarySort = secondarySort;
				if (flag5 && flag6)
				{
					value.PrimarySort = 1;
				}
				else if (flag5)
				{
					value.PrimarySort = 2;
				}
				else if (flag2)
				{
					value.PrimarySort = 3;
				}
				else if (!flag7 && flag4 && flag6)
				{
					value.PrimarySort = 4;
				}
				else if (!flag7 && flag4)
				{
					value.PrimarySort = 5;
				}
				else if (flag7)
				{
					value.PrimarySort = 6;
				}
				else if (flag3)
				{
					value.PrimarySort = 7;
				}
				else if (onlineMetadata != null)
				{
					value.PrimarySort = 8;
				}
				else
				{
					value.PrimarySort = 9;
				}
				_friendsList[i] = value;
			}
			_friendsList.Sort();
		}

		public void OnPlayPressed()
		{
			if (_onlineChallengeObjective.State == Objective.ObjectiveState.Active)
			{
				_onlineChallengeObjective.Abandon();
				return;
			}
			if (_onlineChallengeObjective.State == Objective.ObjectiveState.Finished)
			{
				_levelScriptManager.SetActiveOnlineChallenge(null);
				return;
			}
			WorkOutPlayers();
			_onlineChallengeObjective.Start();
			_isShowingAdvanced = false;
		}

		public void OnOptionsPressed()
		{
			if (!(_homeAdvanced == null))
			{
				_isShowingAdvanced = !_isShowingAdvanced;
				Refresh();
			}
		}

		public void OnBackPressed()
		{
			_levelScriptManager.SetActiveOnlineChallenge(null);
		}
	}
}
