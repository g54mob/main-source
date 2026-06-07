using System.Collections.Generic;
using Localization;
using UnityEngine.UI;

public class UrlButton : ActiveComponent
{
	public string url;

	public string urlKey;

	public bool tutorialButton;

	public bool steamOveraly;

	private void Start()
	{
		base.gameObject.GetComponent<Button>().onClick.AddListener(Click);
	}

	private void Click()
	{
		url = TextResources.GetString(urlKey);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("url", urlKey);
		if (tutorialButton)
		{
			dictionary.Add("keyName", base.gameObject.transform.parent.name);
			dictionary.Add("type", base.gameObject.name);
			Logic.SendAnalytics("TUTNODE_URL_OPEN", dictionary);
		}
		else
		{
			Logic.SendAnalytics("URL", dictionary);
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_LinkClick");
		List<string> list = new List<string>();
		if (url.Contains(";"))
		{
			string[] array = url.Split(';');
			foreach (string item in array)
			{
				list.Add(item);
			}
		}
		else
		{
			list.Add(url);
		}
		foreach (string item2 in list)
		{
			if (steamOveraly)
			{
				if (Steam.IsAvailable())
				{
					Steam.ActivateGameOverlayToWebPage(item2);
				}
				else
				{
					Logic.OpenUrl(item2);
				}
			}
			else
			{
				Logic.OpenUrl(item2);
			}
		}
	}
}
