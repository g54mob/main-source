using UnityEngine;

public class IconNotificationManager : MonoBehaviour
{
	[SerializeField]
	private Icon clueFolder;

	[SerializeField]
	private Icon webBrowser;

	[SerializeField]
	private Icon manual;

	[SerializeField]
	private Icon mailIcon;

	private static int WEB_BROWSER_NOTIFICATION_LEVEL = 4;

	private static int MAX_MANUAL_NOTIFICATION_LEVEL = 2;

	private void Start()
	{
		if (!LevelManager.IsCredits())
		{
			SetIconNotifications();
		}
	}

	public void SetIconNotifications()
	{
		PlayNotificationIfNotClicked(mailIcon, playAnimation: true);
		PlayNotificationIfNotClicked(clueFolder, playAnimation: true);
		int currLevel = LevelManager.GetCurrLevel();
		if (currLevel == WEB_BROWSER_NOTIFICATION_LEVEL)
		{
			PlayNotificationIfNotClicked(webBrowser, playAnimation: true);
		}
		if (currLevel <= MAX_MANUAL_NOTIFICATION_LEVEL)
		{
			PlayNotificationIfNotClicked(manual, playAnimation: true);
		}
	}

	private void PlayNotificationIfNotClicked(Icon icon, bool playAnimation)
	{
		if (playAnimation)
		{
			icon.PlayAnimation();
		}
	}
}
