using UnityEngine;

public class broker_login : Login
{
	private static GameObject notificationPopup;

	public override void LaunchNotificationPopup()
	{
		PlayWarning();
		if (notificationPopup == null)
		{
			notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Login Failed", "Invalid account name or password.\nAre you a registered trader?\nSee our FAQ for more info.", NotificationHandler.Icon.ERROR);
		}
		PanelManager.OpenWindow(notificationPopup);
	}
}
