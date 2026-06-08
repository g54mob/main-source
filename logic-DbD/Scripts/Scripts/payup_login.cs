using UnityEngine;

public class payup_login : Login
{
	private static GameObject notificationPopup;

	public override void LaunchNotificationPopup()
	{
		PlayWarning();
		if (notificationPopup == null)
		{
			notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Login Failed", "Invalid account name or password.", NotificationHandler.Icon.ERROR);
		}
		PanelManager.OpenWindow(notificationPopup);
	}
}
