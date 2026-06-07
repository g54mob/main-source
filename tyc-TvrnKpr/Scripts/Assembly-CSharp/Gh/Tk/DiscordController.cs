using Discord;

namespace Gh.Tk
{
	public class DiscordController : SingletonMonoBehaviour<DiscordController>
	{
		private static global::Discord.Discord _discord;

		private static ActivityManager _activityManager;

		private const long _discordClientId = 1333953979075268661L;

		private static long _timestampStart;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void UpdateGamePresence(string state, string details)
		{
		}

		public override void OnApplicationQuit()
		{
		}

		public static bool IsDiscordRunning()
		{
			return false;
		}
	}
}
