using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class guild_profile : WebsiteDownload
{
	public const string URL = "guildsofnewhampshire.net/guild/";

	[SerializeField]
	private GameObject profileNotFoundObject;

	[SerializeField]
	private GameObject profileFoundObject;

	[SerializeField]
	private Image guildImage;

	[SerializeField]
	private TextMeshProUGUI guildTitle;

	[SerializeField]
	private TextMeshProUGUI description;

	[SerializeField]
	private TextMeshProUGUI joining;

	private static Dictionary<string, GuildProfile> guilds;

	private static string currentGuild;

	protected override void Start()
	{
		base.Start();
		iconGenerator = Object.FindObjectOfType<IconGenerator>();
	}

	public void LaunchForumLogin()
	{
		if (guild_login.IsLoggedIn(currentGuild))
		{
			LaunchInnerSite("guildsofnewhampshire.net/forum/" + currentGuild);
		}
		else
		{
			LaunchInnerSite("guildsofnewhampshire.net/forum/login/" + currentGuild, playSound: false);
		}
	}

	public override bool LoadPage(string url)
	{
		currentGuild = url.Substring("guildsofnewhampshire.net/guild/".Length);
		if (!IsValidGuild(currentGuild))
		{
			return false;
		}
		GuildProfile guildProfile = guilds[currentGuild];
		guildTitle.text = guildProfile.guildTitle;
		description.text = guildProfile.description;
		joining.text = guildProfile.joining;
		guildImage.sprite = ResourcesManager.GetImage("Website UI/guilds/" + guildProfile.image);
		return true;
	}

	public static GuildProfile GetGuild(string guild)
	{
		return guilds[guild];
	}

	public static bool IsValidGuild(string guild)
	{
		return guilds.ContainsKey(guild);
	}

	public static void SetProfiles(Dictionary<string, GuildProfile> guild_profiles)
	{
		guilds = guild_profiles;
	}

	public void DownloadMembers()
	{
		if (LevelManager.GetCurrLevel() != 6)
		{
			FailPopup(Messages.GuildMembersServerDown());
			return;
		}
		string text = ((currentGuild == "$") ? "CASH" : currentGuild);
		string tableName = "members_" + text;
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.GuildMembersDownloadFailed(currentGuild));
			return;
		}
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tableName));
		WikiLevel.CreateGuildMembersTable(currentGuild, tableName);
		iconGenerator.GenerateDeleteonlyIcon(tableName);
	}
}
