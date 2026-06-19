using System;
using System.Collections.Generic;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CollaborativeProjectInviteFriend : MonoBehaviour
	{
		private struct OnlineFriendSortItem : IComparable<OnlineFriendSortItem>
		{
			public OnlinePlayerID PlayerID;

			public int PrimarySortValue;

			public uint SecondarySortValue;

			public int CompareTo(OnlineFriendSortItem obj)
			{
				int num = obj.PrimarySortValue - PrimarySortValue;
				if (num == 0)
				{
					return (int)(obj.SecondarySortValue - SecondarySortValue);
				}
				return num;
			}
		}

		[SerializeField]
		private ScrollRect _scroller;

		[SerializeField]
		private GameObject _itemPrefab;

		[SerializeField]
		private int _spacing;

		[SerializeField]
		private DynamicButton _closeButton;

		private readonly List<OnlineFriendSortItem> _sortedList = new List<OnlineFriendSortItem>();

		private readonly List<CollaborativeProjectInviteFriendItem> _items = new List<CollaborativeProjectInviteFriendItem>();

		private OnlineMetadataManager _metadataManager;

		public List<OnlinePlayerID> ExclusionList;

		public Action<OnlinePlayerID> OnFriendSelected;

		public Action OnCancelSelected;

		public void Setup(OnlineMetadataManager metadataManager)
		{
			_metadataManager = metadataManager;
			_closeButton.onPrimaryDown.AddListener(OnClosePressed);
		}

		private void OnEnable()
		{
			int num = OnlineManager.GetFriendPlayerIDs().Count - _items.Count;
			for (int i = 0; i < num; i++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(_itemPrefab);
				obj.transform.SetParent(_scroller.content.transform, worldPositionStays: false);
				CollaborativeProjectInviteFriendItem component = obj.GetComponent<CollaborativeProjectInviteFriendItem>();
				_items.Add(component);
				component.OnSelected = (Action<OnlinePlayerID>)Delegate.Combine(component.OnSelected, OnFriendSelected);
			}
			for (int num2 = 0; num2 > num; num2--)
			{
				CollaborativeProjectInviteFriendItem collaborativeProjectInviteFriendItem = _items[_items.Count - 1];
				collaborativeProjectInviteFriendItem.OnSelected = (Action<OnlinePlayerID>)Delegate.Remove(collaborativeProjectInviteFriendItem.OnSelected, OnFriendSelected);
				_items.RemoveAt(_items.Count - 1);
				UnityEngine.Object.Destroy(collaborativeProjectInviteFriendItem);
			}
			RefreshSortedList();
			for (int j = 0; j < _sortedList.Count; j++)
			{
				CollaborativeProjectInviteFriendItem collaborativeProjectInviteFriendItem2 = _items[j];
				OnlineFriendSortItem onlineFriendSortItem = _sortedList[j];
				if (ExclusionList != null && ExclusionList.Contains(onlineFriendSortItem.PlayerID))
				{
					collaborativeProjectInviteFriendItem2.gameObject.SetActive(value: false);
					continue;
				}
				collaborativeProjectInviteFriendItem2.gameObject.SetActive(value: true);
				collaborativeProjectInviteFriendItem2.Setup(onlineFriendSortItem.PlayerID);
			}
		}

		private void OnDisable()
		{
			ExclusionList = null;
		}

		private void OnDestroy()
		{
			for (int i = 0; i < OnlineManager.GetFriendPlayerIDs().Count; i++)
			{
				if (i < _items.Count)
				{
					CollaborativeProjectInviteFriendItem collaborativeProjectInviteFriendItem = _items[i];
					if (!(collaborativeProjectInviteFriendItem == null))
					{
						collaborativeProjectInviteFriendItem.OnSelected = (Action<OnlinePlayerID>)Delegate.Remove(collaborativeProjectInviteFriendItem.OnSelected, OnFriendSelected);
					}
				}
			}
			_closeButton.onPrimaryDown.RemoveListener(OnClosePressed);
		}

		private void OnClosePressed()
		{
			OnCancelSelected.InvokeSafe();
		}

		private void RefreshSortedList()
		{
			_sortedList.Clear();
			foreach (OnlinePlayerID friendPlayerID in OnlineManager.GetFriendPlayerIDs())
			{
				OnlineMetadata onlineMetadata = _metadataManager.GetOnlineMetadata(friendPlayerID);
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(friendPlayerID);
				bool flag = onlineMetadata != null;
				bool flag2 = false;
				if (playerInfo != null)
				{
					flag2 = playerInfo.IsPlayingGame();
				}
				else
				{
					OnlinePlayerID onlinePlayerID = friendPlayerID;
					UnityEngine.Debug.LogError("playerInfo is null for " + onlinePlayerID.ToString() + " needs investigating");
					ExclusionList.AddUnique(friendPlayerID);
				}
				int num = 0;
				uint secondarySortValue = 0u;
				if (flag2)
				{
					num = 2;
					secondarySortValue = 0u;
				}
				else if (flag)
				{
					num = 1;
					secondarySortValue = onlineMetadata.LastUpdateTime;
				}
				else
				{
					num = 0;
				}
				if (playerInfo.InvitesBlocked)
				{
					ExclusionList.AddUnique(friendPlayerID);
				}
				_sortedList.Add(new OnlineFriendSortItem
				{
					PlayerID = friendPlayerID,
					PrimarySortValue = num,
					SecondarySortValue = secondarySortValue
				});
			}
			_sortedList.Sort();
		}
	}
}
