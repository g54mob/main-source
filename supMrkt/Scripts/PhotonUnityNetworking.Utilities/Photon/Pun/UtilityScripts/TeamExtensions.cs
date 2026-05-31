using System;
using Photon.Realtime;

namespace Photon.Pun.UtilityScripts
{
	public static class TeamExtensions
	{
		[Obsolete("Use player.GetPhotonTeam")]
		public static PunTeams.Team GetTeam(this Player player)
		{
			return default(PunTeams.Team);
		}

		[Obsolete("Use player.JoinTeam")]
		public static void SetTeam(this Player player, PunTeams.Team team)
		{
		}
	}
}
