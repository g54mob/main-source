using System;
using Steamworks;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CampusPromotionScreen : MonoBehaviour
	{
		[SerializeField]
		private Button _backing;

		[SerializeField]
		private DynamicButton _storeButton;

		[SerializeField]
		private DynamicButton _backButton;

		private CloudDataManager _cloudDataManager;

		private void Awake()
		{
			_backing.onClick.AddListener(Hide);
			_backButton.onPrimaryDown.AddListener(Hide);
			_storeButton.interactable = false;
		}

		public void Show(CloudDataManager cloudDataManager)
		{
			base.gameObject.SetActive(value: true);
			_cloudDataManager = cloudDataManager;
			if (_cloudDataManager.DownloadedCloudData != null)
			{
				SetupStoreButton(_cloudDataManager.DownloadedCloudData);
				return;
			}
			CloudDataManager cloudDataManager2 = _cloudDataManager;
			cloudDataManager2.OnCloudDataFileReceived = (Action<CloudData>)Delegate.Combine(cloudDataManager2.OnCloudDataFileReceived, new Action<CloudData>(SetupStoreButton));
		}

		private void SetupStoreButton(CloudData cloudData)
		{
			_storeButton.onPrimaryDown.RemoveAllListeners();
			_storeButton.onPrimaryDown.AddListener(delegate
			{
				if (cloudData.SteamCampusPreorderID > 0)
				{
					SteamFriends.ActivateGameOverlayToStore((AppId_t)(uint)cloudData.SteamCampusPreorderID, EOverlayToStoreFlag.k_EOverlayToStoreFlag_None);
				}
			});
			_storeButton.interactable = true;
		}

		public void Hide()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
