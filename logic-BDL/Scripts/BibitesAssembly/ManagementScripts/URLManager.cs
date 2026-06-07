using System;
using UnityEngine;

namespace ManagementScripts
{
	public class URLManager : MonoBehaviour
	{
		[NonSerialized]
		public URLManager Instance;

		private void Awake()
		{
			Instance = this;
		}

		public void OpenYoutube()
		{
			Application.OpenURL("https://www.youtube.com/channel/UCjJEUMnBFHOP2zpBc7vCnsA");
		}

		public void OpenReddit()
		{
			Application.OpenURL("https://www.reddit.com/r/TheBibites/");
		}

		public void OpenTwitter()
		{
			Application.OpenURL("https://twitter.com/TBibites");
		}

		public void OpenItchIO()
		{
			Application.OpenURL("https://leocaussan.itch.io/the-bibites");
		}

		public void OpenBlueSky()
		{
			Application.OpenURL("https://bsky.app/profile/leocaussan.bsky.social");
		}

		public void OpenResearchDiscord()
		{
			Application.OpenURL("https://discord.gg/zTpMQrVER6");
		}

		public void OpenPatreon()
		{
			Application.OpenURL("https://www.patreon.com/leocaussan");
		}

		public void OpenGithub()
		{
			Application.OpenURL("https://github.com/TheBibites/Bibites_Shared_Content");
		}

		public static void OpenControlHelp()
		{
			Application.OpenURL("https://the-bibites.fandom.com/wiki/Key_Bindings");
		}

		public static void OpenWiki()
		{
			Application.OpenURL("https://the-bibites.fandom.com/wiki/");
		}

		public void OpenBraxTwitter()
		{
			Application.OpenURL("https://twitter.com/Braxiations");
		}

		public static void OpenSteamWorkshopStatic()
		{
			Application.OpenURL("https://steamcommunity.com/app/2736860/workshop/");
		}

		public void OpenSteamWorkshop()
		{
			OpenSteamWorkshopStatic();
		}
	}
}
