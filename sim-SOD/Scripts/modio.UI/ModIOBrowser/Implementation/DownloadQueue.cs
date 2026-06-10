using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
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
		}

		internal void OpenDownloadQueuePanel(Selectable selectionOnClose = null)
		{
		}

		public void Close()
		{
		}

		internal void RefreshDownloadHistoryPanel()
		{
		}

		public void UpdateDownloadQueueCurrentDownloadDisplay(ProgressHandle handle)
		{
		}

		public void UnsubscribeToCurrentDownloadQueueOperation()
		{
		}

		public void LogoutButton()
		{
		}
	}
}
