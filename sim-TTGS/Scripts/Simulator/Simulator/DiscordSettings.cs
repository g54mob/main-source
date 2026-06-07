using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	[Settings("Discord", Scope.Project)]
	public class DiscordSettings : CustomSettings<DiscordSettings>
	{
		[SerializeField]
		private string m_serverInvitationURL;

		public static string ServerInvitationURL => CustomSettings<DiscordSettings>.I.m_serverInvitationURL;
	}
}
