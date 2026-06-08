using UnityEngine;

public class mmdb_login : Login
{
	private static GameObject notificationPopup;

	public override void LaunchNotificationPopup()
	{
		PlayWarning();
		if (notificationPopup == null)
		{
			notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Login Failed", "Invalid username or password.", NotificationHandler.Icon.ERROR);
		}
		PanelManager.OpenWindow(notificationPopup);
	}
}
