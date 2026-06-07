using Coherence.Cloud;

namespace Coherence.Runtime
{
	internal interface IPlayerAccountOperationRequest
	{
		private const string GetAccountInfoMethod = "GET";

		private const string GetOneTimeCodeMethod = "POST";

		private const string SetMethod = "POST";

		private const string LinkMethod = "POST";

		private const string UnlinkMethod = "DELETE";

		private const string RemoveMethod = "DELETE";

		static PlayerAccountOperationInfo<SetDisplayInfoRequest> SetDisplayInfo(string displayName, string imageUrl)
		{
			return default(PlayerAccountOperationInfo<SetDisplayInfoRequest>);
		}

		static PlayerAccountOperationInfo<SetDisplayInfoRequest> RemoveDisplayInfo()
		{
			return default(PlayerAccountOperationInfo<SetDisplayInfoRequest>);
		}

		static PlayerAccountOperationInfo<GetAccountInfoRequest> GetAccountInfo()
		{
			return default(PlayerAccountOperationInfo<GetAccountInfoRequest>);
		}

		static PlayerAccountOperationInfo<GetOneTimeCodeRequest> GetOneTimeCode()
		{
			return default(PlayerAccountOperationInfo<GetOneTimeCodeRequest>);
		}

		static PlayerAccountOperationInfo<SetUsernameRequest> SetUsername(string username, string password, bool force)
		{
			return default(PlayerAccountOperationInfo<SetUsernameRequest>);
		}

		static PlayerAccountOperationInfo<SetUsernameRequest> RemoveUsername(bool force)
		{
			return default(PlayerAccountOperationInfo<SetUsernameRequest>);
		}

		static PlayerAccountOperationInfo<SetEmailRequest> SetEmail(string email)
		{
			return default(PlayerAccountOperationInfo<SetEmailRequest>);
		}

		static PlayerAccountOperationInfo<SetEmailRequest> RemoveEmail()
		{
			return default(PlayerAccountOperationInfo<SetEmailRequest>);
		}

		static PlayerAccountOperationInfo<LinkSteamRequest> LinkSteam(string ticket, string identity, bool force)
		{
			return default(PlayerAccountOperationInfo<LinkSteamRequest>);
		}

		static PlayerAccountOperationInfo<LinkSteamRequest> UnlinkSteam(bool force)
		{
			return default(PlayerAccountOperationInfo<LinkSteamRequest>);
		}

		static PlayerAccountOperationInfo<LinkXboxRequest> LinkEpicGames(string token, bool force)
		{
			return default(PlayerAccountOperationInfo<LinkXboxRequest>);
		}

		static PlayerAccountOperationInfo<LinkXboxRequest> UnlinkEpicGames(bool force)
		{
			return default(PlayerAccountOperationInfo<LinkXboxRequest>);
		}

		static PlayerAccountOperationInfo<LinkPlayStationRequest> LinkPlayStation(string token, bool force)
		{
			return default(PlayerAccountOperationInfo<LinkPlayStationRequest>);
		}

		static PlayerAccountOperationInfo<LinkPlayStationRequest> UnlinkPlayStation(bool force)
		{
			return default(PlayerAccountOperationInfo<LinkPlayStationRequest>);
		}

		static PlayerAccountOperationInfo<LinkXboxRequest> LinkXbox(string token, bool force)
		{
			return default(PlayerAccountOperationInfo<LinkXboxRequest>);
		}

		static PlayerAccountOperationInfo<LinkXboxRequest> UnlinkXbox(bool force)
		{
			return default(PlayerAccountOperationInfo<LinkXboxRequest>);
		}

		static PlayerAccountOperationInfo<LinkNintendoRequest> LinkNintendo(string token, bool force)
		{
			return default(PlayerAccountOperationInfo<LinkNintendoRequest>);
		}

		static PlayerAccountOperationInfo<LinkNintendoRequest> UnlinkNintendo(bool force)
		{
			return default(PlayerAccountOperationInfo<LinkNintendoRequest>);
		}

		static PlayerAccountOperationInfo<LinkGuestRequest> LinkGuest(string guestId, bool force)
		{
			return default(PlayerAccountOperationInfo<LinkGuestRequest>);
		}

		static PlayerAccountOperationInfo<LinkGuestRequest> UnlinkGuest(string guestId, bool force)
		{
			return default(PlayerAccountOperationInfo<LinkGuestRequest>);
		}

		static PlayerAccountOperationInfo<LinkJwtRequest> LinkJwt(string token, bool force)
		{
			return default(PlayerAccountOperationInfo<LinkJwtRequest>);
		}

		static PlayerAccountOperationInfo<LinkJwtRequest> UnlinkJwt(bool force)
		{
			return default(PlayerAccountOperationInfo<LinkJwtRequest>);
		}
	}
}
