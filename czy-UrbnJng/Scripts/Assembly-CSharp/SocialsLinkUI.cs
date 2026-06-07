using UnityEngine;
using UnityEngine.UI;

public class SocialsLinkUI : MonoBehaviour
{
	[SerializeField]
	private Button tiktokButton;

	[SerializeField]
	private Button twitterButton;

	[SerializeField]
	private Button discordButton;

	private void Start()
	{
		tiktokButton.onClick.AddListener(delegate
		{
			OpenTikTok();
		});
		twitterButton.onClick.AddListener(delegate
		{
			OpenTwitter();
		});
		discordButton.onClick.AddListener(delegate
		{
			OpenDiscord();
		});
	}

	private void OnDestroy()
	{
		tiktokButton.onClick.RemoveAllListeners();
		twitterButton.onClick.RemoveAllListeners();
		discordButton.onClick.RemoveAllListeners();
	}

	private void OpenTikTok()
	{
		Application.OpenURL("https://www.tiktok.com/@kylykgames");
	}

	private void OpenTwitter()
	{
		Application.OpenURL("https://twitter.com/Kylyk_Games");
	}

	private void OpenDiscord()
	{
		Application.OpenURL("https://discord.gg/Fe4hJKP2gP");
	}
}
