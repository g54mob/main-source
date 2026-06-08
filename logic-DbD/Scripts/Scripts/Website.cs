using UnityEngine;

public class Website : MonoBehaviour
{
	private WebBrowserController webController;

	protected Notification notifPlayer;

	protected ClosePanelAudio panelPlayer;

	protected virtual void Start()
	{
		Transform parent = base.transform;
		while (parent.GetComponent<WebBrowserController>() == null)
		{
			parent = parent.parent;
		}
		notifPlayer = SoundEffectUtils.GetNotificationPlayer();
		panelPlayer = SoundEffectUtils.GetOpenClosePanelPlayer();
		webController = parent.GetComponent<WebBrowserController>();
	}

	public virtual bool LoadPage(string url)
	{
		return true;
	}

	public void LaunchInnerSite(string url, bool playSound)
	{
		webController.OnWebsiteSearch(url, playSound);
	}

	public void LaunchInnerSite(string url)
	{
		webController.OnWebsiteSearch(url);
	}

	public void PlaySearch()
	{
		webController.PlaySearch();
	}

	public void PlayPopUp()
	{
		panelPlayer.PlayOpen();
	}

	public void PlayDoorClose()
	{
		panelPlayer.PlayDoorClose();
	}

	public void PlayWarning()
	{
		notifPlayer.PlayWarning();
	}

	public void SuccessPopup(GameObject notificationPrefab, string tableName)
	{
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tableName));
	}

	public void SuccessPopupMessage(GameObject notificationPrefab, string message)
	{
		PlayPopUp();
		PanelManager.OpenWindow(UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Success", message, NotificationHandler.Icon.DOWNLOAD_SUCCESS));
	}
}
