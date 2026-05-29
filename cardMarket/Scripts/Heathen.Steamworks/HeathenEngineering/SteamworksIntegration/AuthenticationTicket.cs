using System;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class AuthenticationTicket
	{
		public bool IsClientTicket { get; private set; } = true;

		public HAuthTicket Handle { get; private set; }

		public byte[] Data { get; private set; }

		public bool Verified { get; private set; }

		public uint CreatedOn { get; private set; }

		public EResult Result { get; private set; }

		public Action<AuthenticationTicket, bool> Callback { get; private set; }

		public TimeSpan Age => new TimeSpan(0, 0, (int)(SteamUtils.GetServerRealTime() - CreatedOn));

		public AuthenticationTicket(SteamNetworkingIdentity forIdentity, Action<AuthenticationTicket, bool> callback, bool isClient = true)
		{
			Callback = callback;
			IsClientTicket = isClient;
			byte[] array = new byte[1024];
			uint pcbTicket;
			if (isClient)
			{
				Handle = SteamUser.GetAuthSessionTicket(array, 1024, out pcbTicket, ref forIdentity);
			}
			else
			{
				Handle = SteamGameServer.GetAuthSessionTicket(array, 1024, out pcbTicket, ref forIdentity);
			}
			CreatedOn = SteamUtils.GetServerRealTime();
			Array.Resize(ref array, (int)pcbTicket);
			Data = array;
		}

		public AuthenticationTicket(byte[] dataToInclude, Action<AuthenticationTicket, bool> callback)
		{
			AuthenticationTicket authenticationTicket = this;
			Callback = callback;
			IsClientTicket = true;
			SteamAPICall_t hAPICall = SteamUser.RequestEncryptedAppTicket(dataToInclude, dataToInclude.Length);
			Authentication.m_EncryptedAppTicketResponse.Set(hAPICall, delegate(EncryptedAppTicketResponse_t result, bool error)
			{
				if (!error)
				{
					if (result.m_eResult == EResult.k_EResultOK)
					{
						byte[] pTicket = new byte[1024];
						if (SteamUser.GetEncryptedAppTicket(pTicket, 1024, out var pcbTicket))
						{
							pTicket = new byte[1024];
							Array.Resize(ref pTicket, (int)pcbTicket);
							authenticationTicket.Data = pTicket;
							authenticationTicket.CreatedOn = SteamUtils.GetServerRealTime();
							callback?.Invoke(authenticationTicket, error);
						}
					}
					else
					{
						Debug.LogError("Invalid encrypted ticket, no action taken.");
						callback?.Invoke(authenticationTicket, arg2: true);
					}
				}
			});
		}

		public AuthenticationTicket(string webIdentity, Action<AuthenticationTicket, bool> callback)
		{
			Callback = callback;
			IsClientTicket = true;
			Handle = SteamUser.GetAuthTicketForWebApi(webIdentity);
			CreatedOn = SteamUtils.GetServerRealTime();
			Data = null;
		}

		public void Authenticate(GetAuthSessionTicketResponse_t response)
		{
			if (Handle != default(HAuthTicket) && Handle != HAuthTicket.Invalid && response.m_eResult == EResult.k_EResultOK)
			{
				Result = response.m_eResult;
				Verified = true;
				Callback?.Invoke(this, arg2: false);
			}
			else
			{
				Result = response.m_eResult;
				Callback?.Invoke(this, arg2: true);
			}
		}

		public void Authenticate(GetTicketForWebApiResponse_t response)
		{
			Data = response.m_rgubTicket;
			if (Handle != default(HAuthTicket) && Handle != HAuthTicket.Invalid && response.m_eResult == EResult.k_EResultOK)
			{
				Result = response.m_eResult;
				Verified = true;
				Callback?.Invoke(this, arg2: false);
			}
			else
			{
				Result = response.m_eResult;
				Callback?.Invoke(this, arg2: true);
			}
		}

		public void Cancel()
		{
			if (IsClientTicket)
			{
				SteamUser.CancelAuthTicket(Handle);
			}
			else
			{
				SteamGameServer.CancelAuthTicket(Handle);
			}
		}
	}
}
