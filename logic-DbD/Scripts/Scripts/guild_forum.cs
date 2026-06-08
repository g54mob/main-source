public class guild_forum : Website
{
	public const string URL = "guildsofnewhampshire.net/forum/";

	private static string currentGuild;

	protected override void Start()
	{
		base.Start();
		if (guild_profile.IsValidGuild(currentGuild) && !guild_login.IsLoggedIn(currentGuild))
		{
			LaunchInnerSite("guildsofnewhampshire.net/forum/login/" + currentGuild, playSound: false);
		}
		if (currentGuild == "LLM")
		{
			HintManager.SetHintState(6, 6);
		}
		else if (currentGuild == "$")
		{
			HintManager.SetHintState(6, 7);
		}
	}

	public override bool LoadPage(string url)
	{
		currentGuild = url.Substring("guildsofnewhampshire.net/forum/".Length);
		return guild_profile.IsValidGuild(currentGuild);
	}
}
