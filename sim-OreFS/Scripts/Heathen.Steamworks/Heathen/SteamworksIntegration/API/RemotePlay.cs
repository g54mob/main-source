using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration.API
{
	public static class RemotePlay
	{
		public static class Client
		{
			private static SteamRemotePlaySessionConnectedEvent eventSteamRemotePlaySessionConnected = new SteamRemotePlaySessionConnectedEvent();

			private static SteamRemotePlaySessionDisconnectedEvent eventSteamRemotePlaySessionDisconnected = new SteamRemotePlaySessionDisconnectedEvent();

			private static Callback<SteamRemotePlaySessionConnected_t> m_SteamRemotePlaySessionConnected_t;

			private static Callback<SteamRemotePlaySessionDisconnected_t> m_SteamRemotePlaySessionDisconnected_t;

			public static SteamRemotePlaySessionConnectedEvent EventSessionConnected
			{
				get
				{
					if (m_SteamRemotePlaySessionConnected_t == null)
					{
						m_SteamRemotePlaySessionConnected_t = Callback<SteamRemotePlaySessionConnected_t>.Create(eventSteamRemotePlaySessionConnected.Invoke);
					}
					return eventSteamRemotePlaySessionConnected;
				}
			}

			public static SteamRemotePlaySessionDisconnectedEvent EventSessionDisconnected
			{
				get
				{
					if (m_SteamRemotePlaySessionDisconnected_t == null)
					{
						m_SteamRemotePlaySessionDisconnected_t = Callback<SteamRemotePlaySessionDisconnected_t>.Create(eventSteamRemotePlaySessionDisconnected.Invoke);
					}
					return eventSteamRemotePlaySessionDisconnected;
				}
			}

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void Init()
			{
				eventSteamRemotePlaySessionConnected = new SteamRemotePlaySessionConnectedEvent();
				eventSteamRemotePlaySessionDisconnected = new SteamRemotePlaySessionDisconnectedEvent();
				m_SteamRemotePlaySessionConnected_t = null;
				m_SteamRemotePlaySessionDisconnected_t = null;
			}

			public static uint GetSessionCount()
			{
				return SteamRemotePlay.GetSessionCount();
			}

			public static RemotePlaySessionID_t GetSessionID(int index)
			{
				return SteamRemotePlay.GetSessionID(index);
			}

			public static RemotePlaySessionID_t[] GetSessions()
			{
				uint sessionCount = SteamRemotePlay.GetSessionCount();
				RemotePlaySessionID_t[] array = new RemotePlaySessionID_t[sessionCount];
				for (int i = 0; i < sessionCount; i++)
				{
					array[i] = SteamRemotePlay.GetSessionID(i);
				}
				return array;
			}

			public static UserData GetSessionUser(RemotePlaySessionID_t session)
			{
				return SteamRemotePlay.GetSessionSteamID(session);
			}

			public static string GetSessionClientName(RemotePlaySessionID_t session)
			{
				return SteamRemotePlay.GetSessionClientName(session);
			}

			public static ESteamDeviceFormFactor GetSessionClientFormFactor(RemotePlaySessionID_t session)
			{
				return SteamRemotePlay.GetSessionClientFormFactor(session);
			}

			public static Vector2Int GetSessionClientResolution(RemotePlaySessionID_t session)
			{
				SteamRemotePlay.BGetSessionClientResolution(session, out var pnResolutionX, out var pnResolutionY);
				return new Vector2Int(pnResolutionX, pnResolutionY);
			}

			public static bool SendInvite(UserData user)
			{
				return SteamRemotePlay.BSendRemotePlayTogetherInvite(user);
			}
		}
	}
}
