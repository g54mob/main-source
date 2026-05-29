using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration.API
{
	public static class Authentication
	{
		public static List<AuthenticationTicket> ActiveTickets = new List<AuthenticationTicket>();

		public static List<AuthenticationSession> ActiveSessions = new List<AuthenticationSession>();

		private static Callback<GetAuthSessionTicketResponse_t> m_GetAuthSessionTicketResponse;

		private static Callback<GetAuthSessionTicketResponse_t> m_GetAuthSessionTicketResponseServer;

		private static Callback<GetTicketForWebApiResponse_t> m_GetTicketForWebApiResponse;

		private static Callback<ValidateAuthTicketResponse_t> m_ValidateAuthSessionTicketResponse;

		private static Callback<ValidateAuthTicketResponse_t> m_ValidateAuthSessionTicketResponseServer;

		internal static CallResult<EncryptedAppTicketResponse_t> m_EncryptedAppTicketResponse;

		private static CallResult<StoreAuthURLResponse_t> m_StoreAuthURLResponse;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Init()
		{
			ActiveTickets = new List<AuthenticationTicket>();
			ActiveSessions = new List<AuthenticationSession>();
			m_GetAuthSessionTicketResponse = null;
			m_GetAuthSessionTicketResponseServer = null;
			m_ValidateAuthSessionTicketResponse = null;
			m_ValidateAuthSessionTicketResponseServer = null;
			m_GetTicketForWebApiResponse = null;
			m_EncryptedAppTicketResponse = null;
			m_StoreAuthURLResponse = null;
		}

		public static bool IsAuthTicketValid(AuthenticationTicket ticket)
		{
			if (ticket.Handle == default(HAuthTicket) || ticket.Handle == HAuthTicket.Invalid)
			{
				return false;
			}
			return true;
		}

		public static string EncodedAuthTicket(AuthenticationTicket ticket)
		{
			if (!IsAuthTicketValid(ticket))
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			byte[] data = ticket.Data;
			foreach (byte b in data)
			{
				stringBuilder.AppendFormat("{0:X2}", b);
			}
			return stringBuilder.ToString();
		}

		public static void GetAuthSessionTicket(CSteamID authenticatingIdentity, Action<AuthenticationTicket, bool> callback)
		{
			SteamNetworkingIdentity forIdentity = new SteamNetworkingIdentity
			{
				m_eType = ESteamNetworkingIdentityType.k_ESteamNetworkingIdentityType_SteamID
			};
			forIdentity.SetSteamID(authenticatingIdentity);
			GetAuthSessionTicket(forIdentity, callback);
		}

		public static void GetAuthSessionTicket(SteamNetworkingIdentity forIdentity, Action<AuthenticationTicket, bool> callback)
		{
			if (m_GetAuthSessionTicketResponse == null)
			{
				m_GetAuthSessionTicketResponse = Callback<GetAuthSessionTicketResponse_t>.Create(HandleGetAuthSessionTicketResponse);
			}
			AuthenticationTicket item = new AuthenticationTicket(forIdentity, callback);
			if (ActiveTickets == null)
			{
				ActiveTickets = new List<AuthenticationTicket>();
			}
			ActiveTickets.Add(item);
		}

		public static void GetEncryptedAuthSessionTicket(byte[] dataToInclude, Action<AuthenticationTicket, bool> callback)
		{
			if (m_EncryptedAppTicketResponse == null)
			{
				m_EncryptedAppTicketResponse = CallResult<EncryptedAppTicketResponse_t>.Create();
			}
			AuthenticationTicket item = new AuthenticationTicket(dataToInclude, callback);
			if (ActiveTickets == null)
			{
				ActiveTickets = new List<AuthenticationTicket>();
			}
			ActiveTickets.Add(item);
		}

		public static void GetWebAuthSessionTicket(string webIdentity, Action<AuthenticationTicket, bool> callback)
		{
			if (m_GetTicketForWebApiResponse == null)
			{
				m_GetTicketForWebApiResponse = Callback<GetTicketForWebApiResponse_t>.Create(HandleGetTicketForWebApiResponse);
			}
			AuthenticationTicket item = new AuthenticationTicket(webIdentity, callback);
			if (ActiveTickets == null)
			{
				ActiveTickets = new List<AuthenticationTicket>();
			}
			ActiveTickets.Add(item);
		}

		public static void GetStoreAuthURL(string redirectUrl, Action<string, bool> callback)
		{
			if (m_StoreAuthURLResponse == null)
			{
				m_StoreAuthURLResponse = CallResult<StoreAuthURLResponse_t>.Create();
			}
			SteamAPICall_t hAPICall = SteamUser.RequestStoreAuthURL(redirectUrl);
			m_StoreAuthURLResponse.Set(hAPICall, delegate(StoreAuthURLResponse_t result, bool error)
			{
				callback?.Invoke(result.m_szURL, error);
			});
		}

		public static void CancelAuthTicket(AuthenticationTicket ticket)
		{
			ticket.Cancel();
			ActiveTickets.Remove(ticket);
		}

		public static EBeginAuthSessionResult BeginAuthSession(byte[] authTicket, UserData user, Action<AuthenticationSession> callback)
		{
			if (m_ValidateAuthSessionTicketResponse == null)
			{
				m_ValidateAuthSessionTicketResponse = Callback<ValidateAuthTicketResponse_t>.Create(HandleValidateAuthTicketResponse);
			}
			AuthenticationSession item = new AuthenticationSession(user, callback);
			if (ActiveSessions == null)
			{
				ActiveSessions = new List<AuthenticationSession>();
			}
			ActiveSessions.Add(item);
			return SteamUser.BeginAuthSession(authTicket, authTicket.Length, user);
		}

		public static void EndAuthSession(UserData user)
		{
			SteamUser.EndAuthSession(user);
			ActiveSessions.RemoveAll((AuthenticationSession p) => p.User == user);
		}

		public static EUserHasLicenseForAppResult UserHasLicenseForApp(UserData user, AppData appId)
		{
			return SteamUser.UserHasLicenseForApp(user, appId);
		}

		private static void HandleGetAuthSessionTicketResponse(GetAuthSessionTicketResponse_t pCallback)
		{
			if (ActiveTickets != null && ActiveTickets.Any((AuthenticationTicket p) => p.Handle == pCallback.m_hAuthTicket))
			{
				ActiveTickets.First((AuthenticationTicket p) => p.Handle == pCallback.m_hAuthTicket).Authenticate(pCallback);
			}
		}

		private static void HandleGetTicketForWebApiResponse(GetTicketForWebApiResponse_t pCallback)
		{
			if (ActiveTickets != null && ActiveTickets.Any((AuthenticationTicket p) => p.Handle == pCallback.m_hAuthTicket))
			{
				ActiveTickets.First((AuthenticationTicket p) => p.Handle == pCallback.m_hAuthTicket).Authenticate(pCallback);
			}
		}

		private static void HandleValidateAuthTicketResponse(ValidateAuthTicketResponse_t param)
		{
			if (ActiveSessions != null && ActiveSessions.Any((AuthenticationSession p) => p.User == param.m_SteamID))
			{
				AuthenticationSession authenticationSession = ActiveSessions.First((AuthenticationSession p) => p.User == param.m_SteamID);
				authenticationSession.Authenticate(param);
				if (App.isDebugging)
				{
					Debug.Log("Processing session request data for " + param.m_SteamID.m_SteamID + " status = " + param.m_eAuthSessionResponse);
				}
				if (param.m_eAuthSessionResponse != EAuthSessionResponse.k_EAuthSessionResponseOK)
				{
					ActiveSessions.Remove(authenticationSession);
				}
				if (authenticationSession.OnStartCallback != null)
				{
					authenticationSession.OnStartCallback(authenticationSession);
				}
			}
			else if (App.isDebugging)
			{
				Debug.LogWarning("Received an authentication ticket response for user " + param.m_SteamID.m_SteamID + " no matching session was found for this user.");
			}
		}

		public static void EndAllSessions()
		{
			foreach (AuthenticationSession activeSession in ActiveSessions)
			{
				activeSession.End();
			}
			ActiveSessions.Clear();
		}

		public static void CancelAllTickets()
		{
			foreach (AuthenticationTicket activeTicket in ActiveTickets)
			{
				activeTicket.Cancel();
			}
			ActiveTickets.Clear();
		}
	}
}
