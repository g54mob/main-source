using UnityEngine;

public class rateyourdictator_login : Login
{
	[SerializeField]
	protected AudioClip loginSound;

	private static GameObject notificationPopup;

	public static string USERNAME = "admin";

	public static string PASSWORD = "123";

	public static bool LOGGED_IN = false;

	public void Awake()
	{
		LOGGED_IN = GetLogin();
	}

	public static bool GetLogin()
	{
		return Save.GLOBAL_SAVE.rydl;
	}

	public override void LaunchNotificationPopup()
	{
		if (!login.interactable)
		{
			return;
		}
		if (username.text == USERNAME && password.text == PASSWORD)
		{
			LOGGED_IN = true;
			Save.GLOBAL_SAVE.rydl = true;
			Save.SaveGame();
			SoundEffectUtils.GetNotificationPlayer().PlayLogin();
			LaunchInnerSite("rateyourdictator.gov/admin", playSound: false);
			HintManager.SetHintState(5, 2);
		}
		else
		{
			PlayWarning();
			if (notificationPopup == null)
			{
				notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Error", "Invalid username or password.", NotificationHandler.Icon.ERROR);
			}
			PanelManager.OpenWindow(notificationPopup);
		}
	}
}
