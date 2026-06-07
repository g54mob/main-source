using System.Net.Sockets;

namespace Lexone.UnityTwitchChat
{
	public static class Extensions
	{
		public static void WriteLine(this NetworkStream stream, string output, bool showDebug = false)
		{
		}

		public static string GetDescription(this IRCReply alert)
		{
			return null;
		}
	}
}
