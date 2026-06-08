using Dorfromantik;
using UnityEngine;
using UnityEngine.Analytics;

public class LinkOpener : ScriptableObject
{
	public void OpenPrivacySettingsLink()
	{
		DataPrivacy.FetchPrivacyUrl(Application.OpenURL);
	}

	public void OpenTwitterLink()
	{
		Application.OpenURL("https://twitter.com/_Toukana");
	}

	public void OpenInstagramLink()
	{
		Application.OpenURL("https://www.instagram.com/toukana_interactive/");
	}

	public void OpenDiscordLink()
	{
		Application.OpenURL("https://discord.gg/WbbgeutjGq");
	}

	public void OpenSteamAwardsLink()
	{
		SteamOverlayOpener.OpenURLInSteamOverlay("https://store.steampowered.com/steamawards#option_70_1455840");
	}

	public void OpenStarBirdsLink()
	{
		Application.OpenURL("https://star-birds.com/gamelinkdorfromantik");
	}

	public void OpenLinkById(string linkId)
	{
		if (!(linkId == "unity_privacy_policy"))
		{
			if (linkId == "toukana_privacy_policy")
			{
				Debug.Log("Toukana Privacy Link Clicked");
				Application.OpenURL("https://toukana.com/dorfromantik/privacy-notice");
			}
		}
		else
		{
			Debug.Log("Unity Privacy Link Clicked");
			OpenPrivacySettingsLink();
		}
	}
}
