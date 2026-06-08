using UnityEngine;

public class guild_user_login : Login
{
	private static GameObject notificationPopup;

	public override void LaunchNotificationPopup()
	{
		PlayWarning();
		if (notificationPopup == null)
		{
			notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Error", "Player account not found.", NotificationHandler.Icon.ERROR);
		}
		PanelManager.OpenWindow(notificationPopup);
	}
}
