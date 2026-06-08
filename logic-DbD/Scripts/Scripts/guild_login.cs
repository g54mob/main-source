using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class guild_login : Website
{
	public const string URL = "guildsofnewhampshire.net/forum/login/";

	[SerializeField]
	private Image guildBanner;

	[SerializeField]
	private TextMeshProUGUI guildName1;

	[SerializeField]
	private TextMeshProUGUI guildName2;

	[SerializeField]
	private GameObject profileNotFoundObject;

	[SerializeField]
	private GameObject profileFoundObject;

	[SerializeField]
	private GameObject notificationPrefab;

	[SerializeField]
	private Button login;

	[SerializeField]
	private TMP_InputField password;

	private static GameObject notificationPopup;

	private static string currentGuild;

	private static Dictionary<string, string> ACCESSIBLE_GUILDS = new Dictionary<string, string>
	{
		{ "LLM", "newshirecity" },
		{ "$", "makemoney" },
		{ "KAD", "shining" }
	};

	protected override void Start()
	{
		base.Start();
		GetComponent<PlayerInput>().actions["Enter"].performed += delegate
		{
			if (password.isFocused && CanEnableLogin())
			{
				LaunchNotificationPopup();
			}
		};
	}

	public override bool LoadPage(string url)
	{
		currentGuild = url.Substring("guildsofnewhampshire.net/forum/login/".Length);
		if (!guild_profile.IsValidGuild(currentGuild))
		{
			return false;
		}
		ProfileFound(found: true);
		GuildProfile guild = guild_profile.GetGuild(currentGuild);
		string text = guild.guildTitle.ToUpperInvariant();
		guildName1.text = text;
		guildName2.text = text;
		guildBanner.sprite = ResourcesManager.GetImage("Website UI/guilds/" + guild.image);
		return true;
	}

	private void ProfileFound(bool found)
	{
		profileNotFoundObject.SetActive(!found);
		profileFoundObject.SetActive(found);
	}

	public static bool IsLoggedIn(string guild)
	{
		return Save.GetGuilds().Contains(guild);
	}

	public void CheckEnableLogin()
	{
		login.interactable = CanEnableLogin();
	}

	public bool CanEnableLogin()
	{
		return password.text.Length > 0;
	}

	public void LaunchNotificationPopup()
	{
		if (ACCESSIBLE_GUILDS.ContainsKey(currentGuild) && password.text == ACCESSIBLE_GUILDS[currentGuild])
		{
			Save.AddGuilds(currentGuild);
			SoundEffectUtils.GetNotificationPlayer().PlayLogin();
			LaunchInnerSite("guildsofnewhampshire.net/forum/" + currentGuild, playSound: false);
			return;
		}
		PlayWarning();
		if (notificationPopup == null)
		{
			notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Error", "Invalid guild password.", NotificationHandler.Icon.ERROR);
		}
		PanelManager.OpenWindow(notificationPopup);
	}
}
