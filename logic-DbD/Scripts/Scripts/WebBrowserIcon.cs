using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WebBrowserIcon : Icon
{
	public static readonly int MAX_WEB_BROWSERS = 3;

	[SerializeField]
	private NotificationHandler errorHandler;

	private static GameObject[] webBrowsers = new GameObject[MAX_WEB_BROWSERS];

	private GameObject notification;

	public override void PlayAnimation()
	{
		if (!Save.IsIconClicked(GetIconName()))
		{
			notificationIcon.GetComponent<Image>().enabled = true;
			animator.Play("Icon Web Browser Wiggle");
		}
	}

	public override void OnPointerClick(PointerEventData data)
	{
		if (data.button != PointerEventData.InputButton.Left)
		{
			return;
		}
		if (sfxPlayer == null)
		{
			sfxPlayer = SoundEffectUtils.GetIconClickPlayer();
		}
		float num = data.clickTime - lastClick;
		if (lastClick > 0f && num < 0.5f)
		{
			int activeWebBrowsers = GetActiveWebBrowsers();
			if (activeWebBrowsers == MAX_WEB_BROWSERS)
			{
				if (notification != null)
				{
					Object.Destroy(notification);
				}
				notification = errorHandler.CreateNotificationPanel($"Having more than {MAX_WEB_BROWSERS} web browsers\nat once is against the law!");
				PanelManager.OpenWindow(notification);
				return;
			}
			if (taskbarManager.IsMaximumTaskbarButtons())
			{
				return;
			}
			StopAnimation();
			audioPlayer.PlayOpen();
			GameObject gameObject = Object.Instantiate(windowPanel, base.transform.position, Quaternion.identity, canvas.transform);
			UIUtils.SetPenultimateLayer(gameObject);
			PanelManager.OpenWindow(gameObject);
			CacheWebBrowser(gameObject);
			sfxPlayer.PlayDoubleClick(1f);
			taskbarManager.AddTaskbar(gameObject, icon1, $"{UIUtils.ToTitleCase(Icon.GetName(this))} {activeWebBrowsers + 1}");
			if (iconBackground != null)
			{
				UnselectIcons();
			}
		}
		else
		{
			sfxPlayer.PlayDoubleClick(0.8f);
		}
		lastClick = data.clickTime;
	}

	private int GetActiveWebBrowsers()
	{
		int num = 0;
		for (int i = 0; i < webBrowsers.Length; i++)
		{
			if (webBrowsers[i] != null)
			{
				num++;
			}
		}
		return num;
	}

	private void CacheWebBrowser(GameObject browser)
	{
		for (int i = 0; i < webBrowsers.Length; i++)
		{
			if (webBrowsers[i] == null)
			{
				webBrowsers[i] = browser;
				break;
			}
		}
	}
}
