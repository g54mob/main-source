using System;
using System.Collections.Generic;
using FullInspector;
using Steamworks;
using TH20.Analytics;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ExtraContentMenu : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect _scroller;

		[SerializeField]
		private GameObject _extraContentItemPrefab;

		[SerializeField]
		private GameObject _sideBarBackground;

		[SerializeField]
		private ExtraContentMenuUGC _ugcMenuItem;

		private readonly List<ExtraContentMenuItem> _contentItemList = new List<ExtraContentMenuItem>();

		private Callback<GameOverlayActivated_t> _gameOverlayCallback;

		private DLCManager _dlcManager;

		private AnalyticsManager _analyticsManager;

		private MessageBox _messageBox;

		private void Start()
		{
			if (OnlineManager.IsInitialized())
			{
				_gameOverlayCallback = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
			}
		}

		private void OnDestroy()
		{
			for (int i = 0; i < _contentItemList.Count; i++)
			{
				ExtraContentMenuItem extraContentMenuItem = _contentItemList[i];
				extraContentMenuItem.OnPurchasePressed = (Action<DLCItemDefinition>)Delegate.Remove(extraContentMenuItem.OnPurchasePressed, new Action<DLCItemDefinition>(OnPurchaseSelected));
			}
			_contentItemList.Clear();
		}

		public void Initialise(DLCManager dlcManager, AnalyticsManager analyticsManager, MessageBox messageBox)
		{
			_dlcManager = dlcManager;
			_analyticsManager = analyticsManager;
			_messageBox = messageBox;
			Refresh();
		}

		private void Refresh()
		{
			PopulateScrollView();
			GameObjectUtils.SetActive(_sideBarBackground, _dlcManager.AvailableItems.Count > 0);
			int i = 0;
			foreach (SharedInstance<DLCItemDefinition> availableItem in _dlcManager.AvailableItems)
			{
				if (i >= _contentItemList.Count)
				{
					break;
				}
				if (!availableItem.IsNull() && (availableItem.Instance.IsPurchasable || DLCUtils.IsDLCInstalled(availableItem.Instance)))
				{
					_contentItemList[i].Setup(availableItem.Instance);
					GameObjectUtils.SetActive(_contentItemList[i].gameObject, isActive: true);
					i++;
				}
			}
			for (; i < _contentItemList.Count; i++)
			{
				GameObjectUtils.SetActive(_contentItemList[i].gameObject, isActive: false);
			}
			GameObjectUtils.SetActive(_ugcMenuItem.gameObject, OnlineManager.IsInitializedAndLoggedOn());
			_ugcMenuItem.transform.SetAsLastSibling();
		}

		private void PopulateScrollView()
		{
			int num = _dlcManager.AvailableItems.Count - _contentItemList.Count;
			for (int i = 0; i < num; i++)
			{
				ExtraContentMenuItem component = UnityEngine.Object.Instantiate(_extraContentItemPrefab).GetComponent<ExtraContentMenuItem>();
				component.OnPurchasePressed = (Action<DLCItemDefinition>)Delegate.Combine(component.OnPurchasePressed, new Action<DLCItemDefinition>(OnPurchaseSelected));
				component.transform.SetParent(_scroller.content.transform, worldPositionStays: false);
				_contentItemList.Add(component);
			}
		}

		public static void ShowBrowser(DLCItemDefinition dlcItemDefinition, AnalyticsManager analyticsManager, MessageBox messageBox, string overrideUrl = null)
		{
			if (OnlineManager.IsInitialized() && SteamUtils.IsOverlayEnabled())
			{
				if (dlcItemDefinition != null && dlcItemDefinition.IsHospitalPassSignup && analyticsManager != null)
				{
					GameEvent gameEvent = new GameEvent(analyticsManager.Config.HospitalSignupInfo);
					analyticsManager.RecordEvent(gameEvent);
				}
				if (overrideUrl != null)
				{
					SteamFriends.ActivateGameOverlayToWebPage(overrideUrl);
				}
				else if (dlcItemDefinition != null && !dlcItemDefinition.OverrideUrl.IsNullOrEmpty())
				{
					SteamFriends.ActivateGameOverlayToWebPage(dlcItemDefinition.OverrideUrl);
				}
				else if (dlcItemDefinition != null)
				{
					SteamFriends.ActivateGameOverlayToStore((AppId_t)dlcItemDefinition.AppID, EOverlayToStoreFlag.k_EOverlayToStoreFlag_AddToCartAndShow);
				}
			}
		}

		private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
		{
			if (pCallback.m_bActive == 0)
			{
				RevalidatePurchasedDLCAndRefresh();
			}
		}

		private void RevalidatePurchasedDLCAndRefresh()
		{
			if (_dlcManager != null)
			{
				_dlcManager.RevalidatePurchasedDLC();
				Refresh();
			}
		}

		private void OnPurchaseSelected(DLCItemDefinition dlcItemDefinition)
		{
			ShowBrowser(dlcItemDefinition, _analyticsManager, _messageBox);
		}
	}
}
