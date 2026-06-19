using System;
using System.Collections.Generic;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class ChallengeFriendPanel : MonoBehaviour
	{
		private struct FriendSortItem : IComparable<FriendSortItem>
		{
			public readonly OnlinePlayerID OnlinePlayerID;

			public int PrimarySort;

			public uint SecondarySort;

			public FriendSortItem(OnlinePlayerID onlinePlayerID)
			{
				OnlinePlayerID = onlinePlayerID;
				PrimarySort = int.MaxValue;
				SecondarySort = uint.MaxValue;
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
		private DynamicButton _leftButton;

		[SerializeField]
		private DynamicButton _rightButton;

		[SerializeField]
		private PlayerAvatar[] _avatarList;

		[SerializeField]
		private ButtonAnimator[] _avatarButtonList;

		[SerializeField]
		private Color _selectedColor = Color.white;

		[SerializeField]
		private Color _unselectedColor = Color.grey;

		[SerializeField]
		private Color _disabledColor = Color.clear;

		[SerializeField]
		private GameObject _onlinePanel;

		[SerializeField]
		private GameObject _offlinePanel;

		[NonSerialized]
		public List<OnlinePlayerID> SelectedFriendsList = new List<OnlinePlayerID>();

		public const int CMaxSelectable = 4;

		private readonly List<FriendSortItem> _friendsList = new List<FriendSortItem>();

		private int _currentPageIndex;

		private Action _onSelectionChanged;

		private void Start()
		{
			for (int i = 0; i < _avatarButtonList.Length; i++)
			{
				int i2 = i;
				_avatarButtonList[i].Button.onPrimaryDown.AddListener(delegate
				{
					OnAvatarPressed(_avatarList[i2]);
				});
			}
			for (int num = 0; num < _avatarList.Length; num++)
			{
				if (_avatarList[num] == null)
				{
					_avatarList[num] = new PlayerAvatar();
				}
			}
			_leftButton.onPrimaryDown.AddListener(OnLeftPressed);
			_rightButton.onPrimaryDown.AddListener(OnRightPressed);
			bool flag = OnlineManager.IsInitializedAndLoggedOn();
			GameObjectUtils.SetActive(_onlinePanel, flag);
			GameObjectUtils.SetActive(_offlinePanel, !flag);
		}

		public void Initialise(OnlineChallengeObjective objective, OnlineMetadataManager onlineMetadataManager, Action onSelectionChanged)
		{
			bool flag = OnlineManager.IsInitializedAndLoggedOn();
			GameObjectUtils.SetActive(_onlinePanel, flag);
			GameObjectUtils.SetActive(_offlinePanel, !flag);
			if (!flag)
			{
				SelectedFriendsList.Clear();
				return;
			}
			_onSelectionChanged = onSelectionChanged;
			_friendsList.Clear();
			for (int i = 0; i < _avatarList.Length; i++)
			{
				if (_avatarList[i] == null)
				{
					_avatarList[i] = new PlayerAvatar();
				}
				_avatarList[i].SetupForChallengeTooltip(objective.Level.Config, objective.Level.Metagame.OnlineMetadataManager, objective.Level.Metagame.CareerStatsManager);
			}
			foreach (OnlinePlayerID friendPlayerID in OnlineManager.GetFriendPlayerIDs())
			{
				if (friendPlayerID == OnlineManager.GetLocalPlayerID())
				{
					continue;
				}
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(friendPlayerID);
				if (playerInfo != null && !playerInfo.InvitesBlocked)
				{
					OnlineMetadata onlineMetadata = onlineMetadataManager.GetOnlineMetadata(friendPlayerID);
					if (onlineMetadata == null || onlineMetadata.IsVisible())
					{
						_friendsList.Add(new FriendSortItem(friendPlayerID));
					}
				}
			}
			SortFriendsList(objective, onlineMetadataManager);
			for (int j = 0; j < 4; j++)
			{
				if (j < _friendsList.Count)
				{
					SelectedFriendsList.AddUnique(_friendsList[j].OnlinePlayerID);
				}
			}
			Refresh();
			if (_onSelectionChanged != null)
			{
				_onSelectionChanged.InvokeSafe();
			}
		}

		public void SelectFriend(OnlinePlayerID onlinePlayerID)
		{
			SelectedFriendsList.AddUnique(onlinePlayerID);
			Refresh();
		}

		public void UnselectFriend(OnlinePlayerID onlinePlayerID)
		{
			if (SelectedFriendsList.Contains(onlinePlayerID))
			{
				SelectedFriendsList.Remove(onlinePlayerID);
			}
			Refresh();
		}

		private void Refresh()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return;
			}
			int num = _currentPageIndex * _avatarList.Length;
			int num2 = num + _avatarList.Length - 1;
			GameObjectUtils.SetActive(_leftButton.gameObject, _currentPageIndex > 0);
			GameObjectUtils.SetActive(_rightButton.gameObject, _friendsList.Count > num2 + 1);
			int num3 = 0;
			int num4 = num;
			while (num4 <= num2)
			{
				if (num4 >= _friendsList.Count)
				{
					GameObjectUtils.SetActive(_avatarButtonList[num3].gameObject, isActive: false);
					_avatarList[num3].PlayerID = OnlinePlayerID.Nil;
				}
				else
				{
					_avatarList[num3].PlayerID = _friendsList[num4].OnlinePlayerID;
					GameObjectUtils.SetActive(_avatarButtonList[num3].gameObject, isActive: true);
					bool flag = SelectedFriendsList.Contains(_friendsList[num4].OnlinePlayerID);
					if (SelectedFriendsList.Count >= 4)
					{
						_avatarButtonList[num3].CurrentState = ((!flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
						_avatarButtonList[num3].Button.image.color = (flag ? _selectedColor : _disabledColor);
					}
					else
					{
						_avatarButtonList[num3].CurrentState = ButtonAnimator.State.Selectable;
						_avatarButtonList[num3].Button.image.color = (flag ? _selectedColor : _unselectedColor);
					}
				}
				num4++;
				num3++;
			}
		}

		private void OnLeftPressed()
		{
			_currentPageIndex = Mathf.Max(0, _currentPageIndex - 1);
			Refresh();
		}

		private void OnRightPressed()
		{
			int b = _friendsList.Count / _avatarList.Length;
			_currentPageIndex = Mathf.Min(_currentPageIndex + 1, b);
			Refresh();
		}

		private void OnAvatarPressed(PlayerAvatar avatar)
		{
			if (OnlineManager.IsInitializedAndLoggedOn() && !(avatar.PlayerID == OnlinePlayerID.Nil))
			{
				if (SelectedFriendsList.Contains(avatar.PlayerID))
				{
					SelectedFriendsList.Remove(avatar.PlayerID);
				}
				else
				{
					SelectedFriendsList.AddUnique(avatar.PlayerID);
				}
				if (_onSelectionChanged != null)
				{
					_onSelectionChanged.InvokeSafe();
				}
				Refresh();
			}
		}

		private void SortFriendsList(OnlineChallengeObjective objective, OnlineMetadataManager onlineMetadataManager)
		{
			uint serverTime = OnlineManager.GetServerTime();
			for (int i = 0; i < _friendsList.Count; i++)
			{
				FriendSortItem value = _friendsList[i];
				OnlineMetadata onlineMetadata = onlineMetadataManager.GetOnlineMetadata(value.OnlinePlayerID);
				OnlineMetadata.ChallengeScore value2 = null;
				onlineMetadata?.ChallengeScores.TryGetValue(objective.ObjectiveUniqueID, out value2);
				bool flag = onlineMetadata != null;
				bool flag2 = onlineMetadata != null && onlineMetadata.LastPlayedLevel == objective.Level.Config;
				bool flag3 = onlineMetadata?.HasPlayedLevel(objective.Level.Config) ?? false;
				bool flag4 = value2 != null;
				bool flag5 = value2?.Rivals.Contains(OnlineManager.GetLocalPlayerID()) ?? false;
				bool flag6 = OnlineManager.GetPlayerInfo(value.OnlinePlayerID)?.IsPlayingGame() ?? false;
				uint secondarySort = ((value2 != null) ? (serverTime - value2.TimeStamp) : uint.MaxValue);
				value.SecondarySort = secondarySort;
				if (flag2 && flag5)
				{
					value.PrimarySort = 1;
				}
				else if (flag5)
				{
					value.PrimarySort = 2;
				}
				else if (flag2 && flag4)
				{
					value.PrimarySort = 3;
				}
				else if (flag2)
				{
					value.PrimarySort = 4;
				}
				else if (flag4)
				{
					value.PrimarySort = 5;
				}
				else if (flag6)
				{
					value.PrimarySort = 6;
				}
				else if (flag3)
				{
					value.PrimarySort = 7;
				}
				else if (flag)
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
	}
}
