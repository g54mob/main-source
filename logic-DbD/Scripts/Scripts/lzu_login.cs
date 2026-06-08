using UnityEngine;

public class lzu_login : Login
{
	[SerializeField]
	private Animator passwordHint;

	private bool passwordHintShowing;

	private static GameObject notificationPopup;

	public static string PASSWORD = "cortland92";

	protected override void Start()
	{
		base.Start();
		if (Save.GLOBAL_SAVE.lzul)
		{
			password.text = PASSWORD;
		}
	}

	protected override bool CheckLogin()
	{
		if (password.isFocused)
		{
			return password.text.Length > 0;
		}
		return false;
	}

	public override void CheckEnableLogin()
	{
		login.interactable = password.text.Length > 0;
	}

	public override void LaunchNotificationPopup()
	{
		if (password.text == PASSWORD)
		{
			Save.GLOBAL_SAVE.lzul = true;
			Save.SaveGame();
			SoundEffectUtils.GetNotificationPlayer().PlayLogin();
			LaunchInnerSite("teach3rz0n1y.com", playSound: false);
			return;
		}
		PlayWarning();
		if (notificationPopup == null)
		{
			notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Error", "Invalid password.", NotificationHandler.Icon.ERROR);
		}
		PanelManager.OpenWindow(notificationPopup);
	}

	public void ForgotPassword()
	{
		if (!passwordHintShowing)
		{
			HintManager.SetHintState(7, 4);
			passwordHint.Play("slide");
			passwordHintShowing = true;
		}
		else
		{
			passwordHint.Play("slide back");
			passwordHintShowing = false;
		}
	}
}
