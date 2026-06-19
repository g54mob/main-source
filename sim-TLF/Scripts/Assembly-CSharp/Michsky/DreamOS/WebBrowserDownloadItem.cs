using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class WebBrowserDownloadItem : MonoBehaviour
	{
		[Header("Resources")]
		public ButtonManager buttonObject;

		[SerializeField]
		private Image fileIconObject;

		[SerializeField]
		private TextMeshProUGUI fileNameObject;

		[SerializeField]
		private TextMeshProUGUI fileSizeObject;

		[SerializeField]
		private Slider downloadBar;

		[SerializeField]
		private TextMeshProUGUI downloadStatus;

		[Header("Settings")]
		[SerializeField]
		private Sprite notificationIcon;

		[SerializeField]
		private string notificationDescription = "Download completed";

		private float downloadMultiplier;

		[HideInInspector]
		public WebBrowserManager manager;

		[HideInInspector]
		public Sprite fileIcon;

		[HideInInspector]
		public string fileName;

		[HideInInspector]
		public float fileSize;

		[HideInInspector]
		public bool isFinished;

		[HideInInspector]
		public bool isProcessing;

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.Network;

		public void ProcessItem()
		{
			if (isFinished)
			{
				base.enabled = false;
			}
			else
			{
				if (!isProcessing || manager == null || !manager.networkManager.isConnected)
				{
					return;
				}
				if (manager.networkManager.dynamicNetwork)
				{
					downloadMultiplier = manager.networkManager.networkItems[manager.networkManager.currentNetworkIndex].networkSpeed;
				}
				else if (!manager.networkManager.dynamicNetwork && downloadMultiplier != manager.networkManager.defaultSpeed)
				{
					downloadMultiplier = manager.networkManager.defaultSpeed;
				}
				downloadBar.value += Time.deltaTime * downloadMultiplier;
				downloadStatus.text = string.Format("{0} MB / {1} MB", downloadBar.value.ToString("F1"), downloadBar.maxValue.ToString("F1"));
				if (downloadBar.value != fileSize)
				{
					return;
				}
				ProcessComplete();
				for (int i = 0; i < manager.activeDownloads.Count; i++)
				{
					if (manager.activeDownloads[i].fileName == fileName)
					{
						manager.activeDownloads.RemoveAt(i);
						break;
					}
				}
			}
		}

		public void ProcessDownload()
		{
			fileIconObject.sprite = fileIcon;
			fileNameObject.text = fileName;
			fileSizeObject.text = $"{fileSize.ToString()} MB";
			downloadBar.value = 0f;
			downloadBar.maxValue = fileSize;
			buttonObject.Interactable(value: false);
			isProcessing = true;
			isFinished = false;
			if (DreamOSDataManager.ReadIntData(dataCat, fileName + "_DownloadState") != 1)
			{
				DreamOSDataManager.WriteIntData(dataCat, fileName + "_DownloadState", 1);
			}
		}

		public void ProcessComplete()
		{
			fileIconObject.sprite = fileIcon;
			fileNameObject.text = fileName;
			fileSizeObject.text = $"{fileSize.ToString()} MB";
			if (isProcessing && NotificationManager.instance != null)
			{
				NotificationManager.instance.CreateNotification(notificationIcon, fileName, notificationDescription, true, true);
			}
			buttonObject.Interactable(value: true);
			isProcessing = false;
			isFinished = true;
			if (DreamOSDataManager.ReadIntData(dataCat, fileName + "_DownloadState") != 2)
			{
				DreamOSDataManager.WriteIntData(dataCat, fileName + "_DownloadState", 2);
			}
			Object.Destroy(downloadBar.gameObject);
			Object.Destroy(downloadStatus.gameObject);
		}

		public void DeleteFile()
		{
			manager.DeleteDownloadedFile(fileName);
		}
	}
}
