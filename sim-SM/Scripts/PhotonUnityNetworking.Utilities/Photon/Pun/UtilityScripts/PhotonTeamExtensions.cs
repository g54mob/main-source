using Photon.Realtime;

namespace Photon.Pun.UtilityScripts
{
	public static class PhotonTeamExtensions
	{
		public static PhotonTeam GetPhotonTeam(this Player player)
		{
			return null;
		}

		public static bool JoinTeam(this Player player, PhotonTeam team)
		{
			return false;
		}

		public static bool JoinTeam(this Player player, byte teamCode)
		{
			return false;
		}

		public static bool JoinTeam(this Player player, string teamName)
		{
			return false;
		}

		public static bool SwitchTeam(this Player player, PhotonTeam team)
		{
			return false;
		}

		public static bool SwitchTeam(this Player player, byte teamCode)
		{
			return false;
		}

		public static bool SwitchTeam(this Player player, string teamName)
		{
			return false;
		}

		public static bool LeaveCurrentTeam(this Player player)
		{
			return false;
		}

		public static bool TryGetTeamMates(this Player player, out Player[] teamMates)
		{
			teamMates = null;
			return false;
		}
	}
}
