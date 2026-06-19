using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class DownloadQueue : SelfInstancingMonoSingleton<DownloadQueue>
	{
		[Header("Download History Panel")]
		[SerializeField]
		public GameObject DownloadQueuePanel;

		[SerializeField]
		private GameObject DownloadQueueCurrentProgressBar;

		[SerializeField]
		private TMP_Text DownloadQueueCurrentJobText;

		[SerializeField]
		private Image DownloadQueueCurrentProgressBarFill;

		[SerializeField]
		private TMP_Text DownloadQueueUsernameText;

		[SerializeField]
		private TMP_Text DownloadQueueCurrentModName;

		[SerializeField]
		private TMP_Text DownloadQueueCurrentDownloadedAmount;

		[SerializeField]
		private TMP_Text DownloadQueueCurrentDownloadSpeed;

		[SerializeField]
		private Button DownloadQueueCurrentUnsubscribeButton;

		[SerializeField]
		private Button DownloadQueueCurrentLogoutButton;

		[SerializeField]
		private Transform DownloadQueueList;

		[SerializeField]
		private RectTransform DownloadQueueListViewport;

		[SerializeField]
		private GameObject DownloadQueueListItem;

		[SerializeField]
		private GameObject DownloadQueueNoPendingNotice;

		[SerializeField]
		private GameObject DownloadQueueNoCurrentNotice;

		[SerializeField]
		public Image Avatar_DownloadQueue;

		private ModProfile downloadQueueCurrentModProfileOfOperationInProgress;

		private Selectable downloadQueueSelectionOnClose;

		internal Translation DownloadQueueCurrentJobTextTranslation;

		internal void ToggleDownloadQueuePanel()
		{
			if (DownloadQueuePanel.activeSelf)
			{
				Close();
			}
			else
			{
				OpenDownloadQueuePanel(EventSystem.current.currentSelectedGameObject?.GetComponent<Selectable>());
			}
		}

		internal void OpenDownloadQueuePanel(Selectable selectionOnClose = null)
		{
			downloadQueueSelectionOnClose = selectionOnClose ?? downloadQueueSelectionOnClose;
			DownloadQueuePanel.SetActive(value: true);
			RefreshDownloadHistoryPanel();
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.Downloads);
		}

		public void Close()
		{
			DownloadQueuePanel.SetActive(value: false);
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(downloadQueueSelectionOnClose);
			RefreshDownloadHistoryPanel();
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectPreviousView();
		}

		internal void RefreshDownloadHistoryPanel()
		{
			DownloadQueueNoPendingNotice.SetActive(value: false);
			DownloadQueueNoCurrentNotice.SetActive(value: false);
			DownloadQueueUsernameText.text = SelfInstancingMonoSingleton<Authentication>.Instance.currentUserProfile.portal_username ?? SelfInstancingMonoSingleton<Authentication>.Instance.currentUserProfile.username;
			Navigation navigation = DownloadQueueCurrentUnsubscribeButton.navigation;
			navigation.mode = Navigation.Mode.Explicit;
			navigation.selectOnUp = DownloadQueueCurrentLogoutButton;
			navigation.selectOnLeft = null;
			navigation.selectOnRight = null;
			bool flag = false;
			ListItem.HideListItems<DownloadQueueListItem>();
			Selectable selectable = null;
			SubscribedMod[] subscribedMods = SelfInstancingMonoSingleton<Collection>.Instance.subscribedMods;
			for (int i = 0; i < subscribedMods.Length; i++)
			{
				SubscribedMod mod = subscribedMods[i];
				if (mod.status != SubscribedModStatus.Installed && !SelfInstancingMonoSingleton<Collection>.Instance.pendingUnsubscribes.Contains(mod.modProfile.id) && (long?)Mods.CurrentModManagementOperationHandle?.modId != (long)mod.modProfile.id)
				{
					ListItem listItem = ListItem.GetListItem<DownloadQueueListItem>(DownloadQueueListItem, DownloadQueueList, SharedUi.colorScheme);
					listItem.Setup(mod);
					listItem.SetViewportRestraint(DownloadQueueList as RectTransform, DownloadQueueListViewport);
					flag = true;
					Navigation navigation2 = listItem.selectable.navigation;
					navigation2.mode = Navigation.Mode.Explicit;
					navigation2.selectOnUp = null;
					navigation2.selectOnDown = null;
					navigation2.selectOnLeft = null;
					navigation2.selectOnRight = null;
					if (selectable == null)
					{
						navigation2.selectOnUp = DownloadQueueCurrentUnsubscribeButton;
						navigation.selectOnDown = listItem.selectable;
					}
					else
					{
						Navigation navigation3 = selectable.navigation;
						navigation2.selectOnUp = selectable;
						navigation3.selectOnDown = listItem.selectable;
						selectable.navigation = navigation3;
					}
					listItem.selectable.navigation = navigation2;
					selectable = listItem.selectable;
				}
			}
			DownloadQueueCurrentUnsubscribeButton.navigation = navigation;
			if (!flag)
			{
				DownloadQueueNoPendingNotice.SetActive(value: true);
			}
			if (!DownloadQueueCurrentUnsubscribeButton.gameObject.activeSelf)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(DownloadQueueCurrentLogoutButton);
			}
		}

		public void UpdateDownloadQueueCurrentDownloadDisplay(ProgressHandle handle)
		{
			DownloadQueueNoCurrentNotice.SetActive(value: false);
			bool flag = true;
			if ((long)downloadQueueCurrentModProfileOfOperationInProgress.id != (long?)handle?.modId)
			{
				SubscribedMod[] subscribedMods = SelfInstancingMonoSingleton<Collection>.Instance.subscribedMods;
				for (int i = 0; i < subscribedMods.Length; i++)
				{
					SubscribedMod subscribedMod = subscribedMods[i];
					if ((long)subscribedMod.modProfile.id == (long?)handle?.modId)
					{
						flag = false;
						downloadQueueCurrentModProfileOfOperationInProgress = subscribedMod.modProfile;
						break;
					}
				}
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				DownloadQueueCurrentUnsubscribeButton.gameObject.SetActive(value: false);
				DownloadQueueCurrentProgressBar.SetActive(value: false);
				DownloadQueueNoCurrentNotice.SetActive(value: true);
				return;
			}
			if (handle.OperationType == ModManagementOperationType.Download)
			{
				Translation.Get(DownloadQueueCurrentJobTextTranslation, "Downloading", DownloadQueueCurrentJobText);
			}
			else
			{
				Translation.Get(DownloadQueueCurrentJobTextTranslation, "Installing", DownloadQueueCurrentJobText);
			}
			DownloadQueueCurrentModName.text = downloadQueueCurrentModProfileOfOperationInProgress.name;
			DownloadQueueCurrentDownloadSpeed.text = ((handle.OperationType == ModManagementOperationType.Download) ? Utility.GenerateHumanReadableStringForBytes(handle.BytesPerSecond) : "");
			DownloadQueueCurrentDownloadedAmount.text = "";
			DownloadQueueCurrentProgressBarFill.fillAmount = handle.Progress;
			DownloadQueueCurrentProgressBar.SetActive(value: true);
			DownloadQueueCurrentUnsubscribeButton.gameObject.SetActive(value: true);
		}

		public void UnsubscribeToCurrentDownloadQueueOperation()
		{
			Mods.UnsubscribeFromEvent(downloadQueueCurrentModProfileOfOperationInProgress);
			RefreshDownloadHistoryPanel();
		}

		public void LogoutButton()
		{
			ToggleDownloadQueuePanel();
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Logout(delegate
			{
				OpenDownloadQueuePanel();
			});
		}
	}
}
