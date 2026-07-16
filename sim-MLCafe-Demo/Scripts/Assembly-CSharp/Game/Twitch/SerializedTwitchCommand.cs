using System;

namespace Game.Twitch
{
	[Serializable]
	public class SerializedTwitchCommand
	{
		public string cmd;

		public bool active;

		public float cooldown;
	}
}
