using WebSocketSharp;

namespace Platforms
{
	public static class PlatformHelpers
	{
		public static string[] NetworkInvitePrefixes = new string[6] { "STEAM_LOBBY:", "STEAM_CODE:", "PHOTON_CODE:", "NPLN_LOBBY:", "NPLN_CODE:", "PS_ID:" };

		public const string STEAM_NETWORK_LOBBY = "STEAM_LOBBY:";

		public const string STEAM_NETWORK_JOINCODE = "STEAM_CODE:";

		public const string PHOTON_NETWORK_JOINCODE = "PHOTON_CODE:";

		public const string NPLN_NETWORK_LOBBY = "NPLN_LOBBY:";

		public const string NPLN_NETWORK_CODE = "NPLN_CODE:";

		public const string PS_SESSION_ID = "PS_ID:";

		public const char SEPARATOR = '/';

		public static string AppendToInvite(string current, string platform_prefix, string platform_invite)
		{
			string text = CreateNetworkInvite(platform_prefix, platform_invite);
			if (current.IsNullOrEmpty())
			{
				return text;
			}
			return $"{current}{'/'}{text}";
		}

		public static string CreateNetworkInvite(string platform_prefix, string platform_invite)
		{
			return platform_prefix + platform_invite;
		}

		public static string GetInviteOfPrefix(string invite, string platform_prefix)
		{
			if (invite == null)
			{
				return null;
			}
			string[] array = invite.Split('/');
			for (int i = 0; i < array.Length; i++)
			{
				var (text, result) = SplitNetworkInvite(array[i]);
				if (text == platform_prefix)
				{
					return result;
				}
			}
			return null;
		}

		public static (string, string) SplitNetworkInvite(string network_invite)
		{
			string[] networkInvitePrefixes = NetworkInvitePrefixes;
			foreach (string text in networkInvitePrefixes)
			{
				if (network_invite.StartsWith(text))
				{
					return (text, network_invite.Substring(text.Length));
				}
			}
			return (null, network_invite);
		}
	}
}
