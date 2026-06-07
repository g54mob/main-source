using System;
using Steamworks;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public class AuthenticationSession
	{
		public bool IsClientSession { get; private set; } = true;

		public UserData User { get; private set; }

		public UserData GameOwner { get; private set; }

		public byte[] Data { get; private set; }

		public EAuthSessionResponse Response { get; private set; }

		public bool IsBarrowed => User != GameOwner;

		public Action<AuthenticationSession> OnStartCallback { get; private set; }

		public AuthenticationSession(CSteamID userId, Action<AuthenticationSession> callback, bool isClient = true)
		{
			IsClientSession = isClient;
			User = userId;
			OnStartCallback = callback;
		}

		internal void Authenticate(ValidateAuthTicketResponse_t response)
		{
			Response = response.m_eAuthSessionResponse;
			GameOwner = response.m_OwnerSteamID;
		}

		public void End()
		{
			if (IsClientSession)
			{
				SteamUser.EndAuthSession(User);
			}
			else
			{
				SteamGameServer.EndAuthSession(User);
			}
		}
	}
}
