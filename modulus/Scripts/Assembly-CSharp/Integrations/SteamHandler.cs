#define ENABLE_DEBUG_LOGS
using System;
using Integrations.Interfaces;
using Steamworks;
using UnityEngine;
using Utils;

namespace Integrations
{
	public class SteamHandler : MonoBehaviour, IPlatformHandler, ISocialHandler
	{
		private uint _supportersEditionAppId;

		private HAuthTicket? _ticket;

		private Callback<GetTicketForWebApiResponse_t> _authTicketCallback;

		private Action<string> _authComplete;

		private Action<string> _authError;

		public bool Ready { get; set; }

		public Action OnPlatformReady { get; set; }

		public Action OnSocialReady { get; set; }

		private void Start()
		{
			if (SteamManager.Initialized)
			{
				_authTicketCallback = Callback<GetTicketForWebApiResponse_t>.Create(OnAuthTicketReceived);
				Ready = true;
				OnPlatformReady?.Invoke();
				OnSocialReady?.Invoke();
			}
		}

		private void OnDestroy()
		{
			if (SteamManager.Initialized)
			{
				_authTicketCallback.Unregister();
			}
		}

		public void SetSupportersEditionAppId(string value)
		{
			uint.TryParse(value, out _supportersEditionAppId);
		}

		public void OpenWebPage(string url, bool forceWebLink = false)
		{
			if (!string.IsNullOrWhiteSpace(url))
			{
				if (forceWebLink)
				{
					Application.OpenURL(url);
				}
				else
				{
					SteamFriends.ActivateGameOverlayToWebPage(url);
				}
			}
		}

		public string GetUserId()
		{
			return SteamUser.GetSteamID().ToString();
		}

		public string GetUserName()
		{
			if (!SteamManager.Initialized)
			{
				return string.Empty;
			}
			return SteamFriends.GetPersonaName();
		}

		public void GetAuthToken(Action<string> authComplete, Action<string> authError)
		{
			_ticket = SteamUser.GetAuthTicketForWebApi("AzurePlayFab");
			_authComplete = authComplete;
			_authError = authError;
		}

		private void OnAuthTicketReceived(GetTicketForWebApiResponse_t callback)
		{
			if (callback.m_eResult != EResult.k_EResultOK)
			{
				Debug.LogError($"Steam auth ticket failed: {callback.m_eResult}");
				_authError?.Invoke(callback.m_eResult.ToString());
				_authError = null;
				_authComplete = null;
				return;
			}
			string obj = BitConverter.ToString(callback.m_rgubTicket).Replace("-", string.Empty);
			if (_authComplete != null)
			{
				_authComplete(obj);
			}
			_authError = null;
			_authComplete = null;
		}

		public bool HasSupportersEdition()
		{
			this.Log("SteamHandler evaluating subscription of Supporters Edition", "HasSupportersEdition", 109);
			if (!SteamManager.Initialized)
			{
				return false;
			}
			if (_supportersEditionAppId != 0)
			{
				return SteamApps.BIsSubscribedApp(new AppId_t(_supportersEditionAppId));
			}
			return false;
		}

		private void UpdatePresence(string state, string details, string largeImageKey = null, string largeImageText = null)
		{
			if (!Ready || !SteamManager.Initialized)
			{
				this.Log("Steam not ready, cannot update presence", "UpdatePresence", 124);
				return;
			}
			try
			{
				if (!string.IsNullOrEmpty(details))
				{
					SteamFriends.SetRichPresence("steam_display", details);
				}
				if (!string.IsNullOrEmpty(state))
				{
					SteamFriends.SetRichPresence("status", state);
				}
				this.Log("Steam presence updated: State=" + state + ", Details=" + details, "UpdatePresence", 142);
			}
			catch (Exception ex)
			{
				this.Log("Error updating Steam presence: " + ex.Message, "UpdatePresence", 146);
			}
		}

		public void ClearPresence()
		{
			if (!Ready || !SteamManager.Initialized)
			{
				return;
			}
			try
			{
				SteamFriends.ClearRichPresence();
				this.Log("Steam presence cleared", "ClearPresence", 157);
			}
			catch (Exception ex)
			{
				this.Log("Error clearing Steam presence: " + ex.Message, "ClearPresence", 161);
			}
		}

		public void UpdateSocialPresenceMainMenu()
		{
			UpdatePresence(LocalizationUtility.GetLocalizedText("RichPresence.MainMenu"), "#MainMenu");
		}

		public void UpdateSocialPresenceBasedOnRank(int rank)
		{
			string details = "#Rank" + rank;
			UpdatePresence(LocalizationUtility.GetLocalizedText("RichPresence.InGame"), details);
		}

		public void UpdateSocialPresenceCreativeMode()
		{
			UpdatePresence(LocalizationUtility.GetLocalizedText("RichPresence.InGame"), "#InCreativeMode");
		}

		public void CancelAuthToken()
		{
			if (_ticket.HasValue)
			{
				SteamUser.CancelAuthTicket(_ticket.Value);
				_ticket = null;
			}
		}
	}
}
