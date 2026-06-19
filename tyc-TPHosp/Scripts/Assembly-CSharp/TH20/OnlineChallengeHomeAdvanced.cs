using System;
using System.Collections.Generic;
using FullInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class OnlineChallengeHomeAdvanced : MonoBehaviour
	{
		[NonSerialized]
		public readonly List<OnlineChallengeHome.FriendSortItem> SelectedRivalsList = new List<OnlineChallengeHome.FriendSortItem>();

		[SerializeField]
		private RectTransform _rivalsPanel;

		[SerializeField]
		private GameObject _rivalItemPrefab;

		[SerializeField]
		private TMP_Text _numSelectedLabel;

		[SerializeField]
		private ScrollRect _scroller;

		[SerializeField]
		private float _spacing;

		[SerializeField]
		private float _rowHeight;

		private const int MaxNumRivals = 4;

		private readonly List<OnlineChallengeRivalSelectItem> _rivalRowElements = new List<OnlineChallengeRivalSelectItem>();

		private List<OnlineChallengeHome.FriendSortItem> _sortedFriendsList = new List<OnlineChallengeHome.FriendSortItem>();

		public void Setup(OnlineChallengeDefinition definition, List<OnlineChallengeHome.FriendSortItem> sortedFriendsList)
		{
			_sortedFriendsList = sortedFriendsList;
			foreach (KeyValuePair<SharedInstance<RivalFoundationDefinition>, OnlineChallengeDefinition.RivalScoreData> aIRival in definition.AIRivals)
			{
				RivalFoundationDefinition instance = aIRival.Key.Instance;
				if (instance != null)
				{
					_sortedFriendsList.Add(new OnlineChallengeHome.FriendSortItem(instance));
				}
			}
			Refresh();
		}

		public void OnEnable()
		{
			Refresh();
		}

		public void Refresh()
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				AllocateTableRows();
				for (int i = 0; i < _sortedFriendsList.Count; i++)
				{
					_rivalRowElements[i].SetupForFriend(this, _sortedFriendsList[i], SelectedRivalsList.Contains(_sortedFriendsList[i]), SelectedRivalsList.Count >= 4);
				}
				_numSelectedLabel.text = $"{SelectedRivalsList.Count}/{4}";
			}
		}

		private void AllocateTableRows()
		{
			int num = _rivalRowElements.Count - _sortedFriendsList.Count;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					_rivalRowElements.Pop();
				}
			}
			else if (num < 0)
			{
				for (int j = 0; j < -num; j++)
				{
					GameObject obj = UnityEngine.Object.Instantiate(_rivalItemPrefab);
					RectTransform obj2 = obj.transform as RectTransform;
					obj2.SetParent(_rivalsPanel.gameObject.transform, worldPositionStays: false);
					obj2.sizeDelta = new Vector2(obj2.sizeDelta.x, _rowHeight);
					obj2.localPosition = new Vector3(0f, (float)(-_rivalRowElements.Count) * (_rowHeight + _spacing), 0f);
					OnlineChallengeRivalSelectItem component = obj.GetComponent<OnlineChallengeRivalSelectItem>();
					_rivalRowElements.Add(component);
				}
			}
			_scroller.content.sizeDelta = new Vector2(_scroller.content.sizeDelta.x, (float)_sortedFriendsList.Count * (_rowHeight + _spacing));
		}

		public void OnRivalSelected(OnlineChallengeRivalSelectItem item)
		{
			if (SelectedRivalsList.Contains(item.Friend))
			{
				SelectedRivalsList.Remove(item.Friend);
			}
			else
			{
				SelectedRivalsList.Add(item.Friend);
			}
			Refresh();
		}
	}
}
