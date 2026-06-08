using UnityEngine;

public class WebsiteDownload : Website
{
	[SerializeField]
	protected GameObject notificationPrefab;

	protected IconGenerator iconGenerator;

	protected static GameObject failPopup;

	protected override void Start()
	{
		base.Start();
		iconGenerator = Object.FindObjectOfType<IconGenerator>();
	}

	protected void FailPopup(string message)
	{
		PlayWarning();
		if (failPopup == null)
		{
			failPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Error", message, NotificationHandler.Icon.WARNING);
		}
		else
		{
			UIUtils.SetTextPopup(failPopup, message);
		}
		PanelManager.OpenWindow(failPopup);
	}
}
