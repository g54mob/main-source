using Lexone.UnityTwitchChat;

namespace Game.Twitch
{
	public class TwitchSettings
	{
		public static void SetChannelName(string channelName)
		{
			if (!(IRC.Instance == null))
			{
				IRC.Instance.channel = channelName;
				IRC.Instance.OnTwitchSettingsChanged.Invoke();
			}
		}

		public static void SetQueueLimitation(bool value)
		{
			TW_GlobalCommands.queuelineRestriction = value;
			IRC.Instance.OnTwitchSettingsChanged.Invoke();
		}

		public static void SetCommandActiveState(int cmdIndex, bool active)
		{
			if (TwitchCommandList.IsValidated())
			{
				TwitchCommandList.GetCommandByIndex(cmdIndex).enabled = active;
				IRC.Instance.OnTwitchSettingsChanged.Invoke();
			}
		}

		public static void SetCommandCooldown(int cmdIndex, float cooldown)
		{
			if (TwitchCommandList.IsValidated())
			{
				TwitchCommandList.GetCommandByIndex(cmdIndex).cooldown = cooldown;
				IRC.Instance.OnTwitchSettingsChanged.Invoke();
			}
		}
	}
}
