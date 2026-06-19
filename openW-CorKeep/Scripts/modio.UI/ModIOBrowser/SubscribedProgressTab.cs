using ModIO;
using ModIO.Util;
using ModIOBrowser.Implementation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class SubscribedProgressTab : MonoBehaviour
	{
		public GameObject progressBar;

		public Image progressBarFill;

		public TMP_Text progressBarText;

		public GameObject progressBarQueuedOutline;

		public ModProfile profile;

		private Translation progressBarTextTranslation;

		public void Setup(ModProfile profile)
		{
			this.profile = profile;
			if (SelfInstancingMonoSingleton<Collection>.Instance.IsSubscribed(profile.id, out var status))
			{
				if (status == SubscribedModStatus.Installed)
				{
					Translation.Get(progressBarTextTranslation, "Subscribed", progressBarText);
					progressBarFill.fillAmount = 1f;
					progressBarQueuedOutline.SetActive(value: false);
				}
				else
				{
					Translation.Get(progressBarTextTranslation, "Queued", progressBarText);
					progressBarFill.fillAmount = 0f;
					progressBarQueuedOutline.SetActive(value: true);
				}
				progressBar.SetActive(value: true);
			}
			else
			{
				progressBar.SetActive(value: false);
				progressBarQueuedOutline.SetActive(value: false);
			}
		}

		public void MimicOtherProgressTab(SubscribedProgressTab other)
		{
			if (other == null)
			{
				Debug.LogWarning("Other is null");
			}
			if (progressBar == null)
			{
				Debug.LogWarning("progressBar is null");
			}
			progressBar.SetActive(other.progressBar.activeSelf);
			progressBarFill.fillAmount = other.progressBarFill.fillAmount;
			progressBarText.text = other.progressBarText.text;
			progressBarQueuedOutline.SetActive(other.progressBarQueuedOutline.activeSelf);
		}

		public void UpdateProgress(ProgressHandle handle)
		{
			if (handle != null && (long)handle.modId == (long)profile.id)
			{
				progressBarQueuedOutline.SetActive(value: false);
				if (SelfInstancingMonoSingleton<Collection>.Instance.IsSubscribed(handle.modId))
				{
					progressBar.SetActive(value: true);
				}
				else
				{
					progressBar.SetActive(value: false);
				}
				progressBarFill.fillAmount = handle.Progress;
				switch (handle.OperationType)
				{
				case ModManagementOperationType.None_AlreadyInstalled:
					progressBar.SetActive(value: true);
					Translation.Get(progressBarTextTranslation, "Subscribed", progressBarText);
					break;
				case ModManagementOperationType.Install:
					progressBar.SetActive(value: true);
					Translation.Get(progressBarTextTranslation, "Installing", progressBarText);
					break;
				case ModManagementOperationType.Download:
					progressBar.SetActive(value: true);
					Translation.Get(progressBarTextTranslation, "Downloading", progressBarText);
					break;
				case ModManagementOperationType.Update:
					progressBar.SetActive(value: true);
					Translation.Get(progressBarTextTranslation, "Updating", progressBarText);
					break;
				case ModManagementOperationType.None_ErrorOcurred:
				case ModManagementOperationType.Uninstall:
					break;
				}
			}
		}

		internal void UpdateStatus(ModManagementEventType updatedStatus, ModId id)
		{
			if ((long)profile.id == (long)id)
			{
				progressBar.SetActive(value: false);
				progressBarQueuedOutline.SetActive(value: false);
				switch (updatedStatus)
				{
				case ModManagementEventType.InstallFailed:
				case ModManagementEventType.DownloadFailed:
				case ModManagementEventType.UninstallStarted:
				case ModManagementEventType.Uninstalled:
				case ModManagementEventType.UninstallFailed:
				case ModManagementEventType.UpdateFailed:
					Translation.Get(progressBarTextTranslation, "Error", progressBarText);
					progressBarFill.fillAmount = 0f;
					break;
				case ModManagementEventType.InstallStarted:
					Translation.Get(progressBarTextTranslation, "Installing", progressBarText);
					progressBarFill.fillAmount = 1f;
					progressBar.SetActive(value: true);
					break;
				case ModManagementEventType.Installed:
					Translation.Get(progressBarTextTranslation, "Subscribed", progressBarText);
					progressBarFill.fillAmount = 1f;
					progressBar.SetActive(value: true);
					break;
				case ModManagementEventType.DownloadStarted:
					Translation.Get(progressBarTextTranslation, "Downloading", progressBarText);
					progressBar.SetActive(value: true);
					break;
				case ModManagementEventType.Downloaded:
					Translation.Get(progressBarTextTranslation, "Downloaded", progressBarText);
					progressBarFill.fillAmount = 1f;
					progressBar.SetActive(value: true);
					break;
				case ModManagementEventType.UpdateStarted:
					Translation.Get(progressBarTextTranslation, "Updating", progressBarText);
					progressBar.SetActive(value: true);
					break;
				case ModManagementEventType.Updated:
					Translation.Get(progressBarTextTranslation, "Subscribed", progressBarText);
					progressBarFill.fillAmount = 1f;
					progressBar.SetActive(value: true);
					break;
				}
			}
		}
	}
}
