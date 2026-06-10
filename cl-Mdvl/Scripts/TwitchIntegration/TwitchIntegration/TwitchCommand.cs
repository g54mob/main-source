using System;
using TwitchIntegration.Utils;

namespace TwitchIntegration
{
	[Serializable]
	public class TwitchCommand
	{
		[ReadOnly]
		public string name;

		public bool enabled;

		[ReadOnly]
		public float cooldown;

		public TwitchCommand()
		{
			name = "";
			enabled = true;
			cooldown = 0f;
		}

		public TwitchCommand(string name, float cooldown = 0f, bool enabled = true)
		{
			this.name = name;
			this.enabled = enabled;
			this.cooldown = cooldown;
		}
	}
}
