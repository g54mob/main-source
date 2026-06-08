namespace TwitchLib.Client.Models
{
	public class Capabilities
	{
		public bool Membership { get; }

		public bool Tags { get; }

		public bool Commands { get; }

		public Capabilities(bool membership = true, bool tags = true, bool commands = true)
		{
			Membership = membership;
			Tags = tags;
			Commands = commands;
		}
	}
}
