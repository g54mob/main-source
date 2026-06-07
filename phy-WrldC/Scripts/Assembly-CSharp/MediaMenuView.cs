using UnityEngine;
using UnityEngine.UI;

public class MediaMenuView : BaseGUIPanelView
{
	private Button twitterButton;

	private Button facebookButton;

	private Button discordButton;

	private Button redditButton;

	private Button youtubeButton;

	private Button twitchButton;

	public MediaMenuView(MainMenuView mainMenuView)
	{
		base.MainPanel = mainMenuView.mainPanel.transform.FindChildRecursively("MediaPanel").gameObject;
		twitterButton = base.MainPanel.transform.FindComponent<Button>("TwitterButton", isRecursively: true);
		facebookButton = base.MainPanel.transform.FindComponent<Button>("FacebookButton", isRecursively: true);
		discordButton = base.MainPanel.transform.FindComponent<Button>("DiscordButton", isRecursively: true);
		redditButton = base.MainPanel.transform.FindComponent<Button>("RedditButton", isRecursively: true);
		youtubeButton = base.MainPanel.transform.FindComponent<Button>("YoutubeButton", isRecursively: true);
		twitchButton = base.MainPanel.transform.FindComponent<Button>("TwitchButton", isRecursively: true);
		twitterButton.onClick.AddListener(delegate
		{
			Application.OpenURL("https://twitter.com/WofContraptions");
		});
		facebookButton.onClick.AddListener(delegate
		{
			Application.OpenURL("https://www.facebook.com/World-of-Contraptions-109005664276623");
		});
		discordButton.onClick.AddListener(delegate
		{
			Application.OpenURL("https://discord.gg/7KmB56u");
		});
		redditButton.onClick.AddListener(delegate
		{
			Application.OpenURL("https://www.reddit.com/r/World_Of_Contraptions/");
		});
		youtubeButton.onClick.AddListener(delegate
		{
			Application.OpenURL("https://www.youtube.com/channel/UC8J4ighQYnjqz6GYSHYQ3HQ");
		});
		twitchButton.onClick.AddListener(delegate
		{
			Application.OpenURL("https://www.twitch.tv/juliocdep");
		});
	}
}
