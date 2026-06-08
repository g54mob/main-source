using TwitchLib.Client.Interfaces;

namespace TwitchLib.Client.Extensions
{
	public static class ReplyWhisperExt
	{
		public static void ReplyToLastWhisper(this ITwitchClient client, string message = "", bool dryRun = false)
		{
			if (client.PreviousWhisper != null)
			{
				client.SendWhisper(client.PreviousWhisper.Username, message, dryRun);
			}
		}
	}
}
