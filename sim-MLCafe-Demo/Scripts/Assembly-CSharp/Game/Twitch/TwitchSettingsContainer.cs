using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Twitch
{
	[Serializable]
	public class TwitchSettingsContainer
	{
		public string channel;

		[Header("Commands")]
		public SerializedTwitchCommand[] commands;

		public bool queuelineLimitation = true;

		public static TwitchSettingsContainer DefaultSettings()
		{
			return new TwitchSettingsContainer();
		}

		public TwitchSettingsContainer()
		{
			List<SerializedTwitchCommand> list = new List<SerializedTwitchCommand>();
			channel = string.Empty;
			queuelineLimitation = true;
			string[] array = new string[2] { "Speak", "Upsi" };
			int num = (TwitchCommandList.IsValidated() ? TwitchCommandList.GetCommandList().Count : array.Length);
			for (int i = 0; i < num; i++)
			{
				list.Add(new SerializedTwitchCommand
				{
					cmd = (TwitchCommandList.IsValidated() ? TwitchCommandList.GetCommandByIndex(i).command : array[i]),
					active = true,
					cooldown = 15f
				});
			}
			commands = list.ToArray();
		}
	}
}
