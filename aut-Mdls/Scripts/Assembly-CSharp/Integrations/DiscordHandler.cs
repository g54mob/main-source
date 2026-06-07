#define ENABLE_DEBUG_LOGS
using System;
using Discord.Sdk;
using Integrations.Interfaces;
using UnityEngine;
using Utils;

namespace Integrations
{
	public class DiscordHandler : MonoBehaviour, ISocialHandler
	{
		private ulong _discordApplicationID = 1374351682829291650uL;

		private Client _client;

		public bool Ready { get; set; }

		public bool Connected { get; set; }

		public Action OnSocialReady { get; set; }

		private void Awake()
		{
			_discordApplicationID = 1374351682829291650uL;
		}

		private void Start()
		{
			try
			{
				_client = new Client();
				_client.SetApplicationId(_discordApplicationID);
				Connected = true;
				this.Log("Discord handler initialized successfully", "Start", 47);
			}
			catch (Exception ex)
			{
				this.Log("Failed to initialize Discord: " + ex.Message, "Start", 51);
				Connected = false;
			}
			Ready = true;
			OnSocialReady?.Invoke();
		}

		private void UpdatePresence(string state, string details, string largeImageKey = null, string largeImageText = null)
		{
			if (!Connected)
			{
				this.Log("Discord not ready, cannot update presence", "UpdatePresence", 66);
				return;
			}
			try
			{
				Activity activity = new Activity();
				activity.SetName(Application.productName);
				activity.SetState(state);
				activity.SetDetails(details);
				activity.SetType(ActivityTypes.Playing);
				ActivityTimestamps activityTimestamps = new ActivityTimestamps();
				activityTimestamps.SetStart((ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds());
				activity.SetTimestamps(activityTimestamps);
				if (string.IsNullOrEmpty(largeImageKey))
				{
					largeImageKey = "modulus";
				}
				if (string.IsNullOrEmpty(largeImageText))
				{
					largeImageText = "modulus";
				}
				ActivityAssets activityAssets = new ActivityAssets();
				activityAssets.SetLargeImage(largeImageKey);
				activityAssets.SetLargeText(largeImageText);
				activity.SetAssets(activityAssets);
				_client.UpdateRichPresence(activity, delegate(ClientResult result)
				{
					if (result.Type() == ErrorType.None)
					{
						this.Log("Discord presence updated: " + state + " / " + details, "UpdatePresence", 105);
					}
					else
					{
						this.Log($"Failed to update Discord presence: {result}", "UpdatePresence", 109);
					}
				});
			}
			catch (Exception ex)
			{
				this.Log("Error updating Discord presence: " + ex.Message, "UpdatePresence", 115);
			}
		}

		public void ClearPresence()
		{
			if (!Connected)
			{
				return;
			}
			try
			{
				_client.ClearRichPresence();
				this.Log("Discord presence cleared", "ClearPresence", 126);
			}
			catch (Exception ex)
			{
				this.Log("Error clearing Discord presence: " + ex.Message, "ClearPresence", 130);
			}
		}

		public void UpdateSocialPresenceMainMenu()
		{
			UpdatePresence(LocalizationUtility.GetLocalizedText("RichPresence.MainMenu"), LocalizationUtility.GetLocalizedText("RichPresence.IdleInMainMenu"));
		}

		public void UpdateSocialPresenceBasedOnRank(int rank)
		{
			string text = LocalizationUtility.GetLocalizedText("Rank.Rank").Replace("{0}", rank.ToString());
			string localizedText = LocalizationUtility.GetLocalizedText($"RichPresence.Rank{rank}");
			UpdatePresence(LocalizationUtility.GetLocalizedText("RichPresence.InGame"), text + ": " + localizedText);
		}

		public void UpdateSocialPresenceCreativeMode()
		{
			UpdatePresence(LocalizationUtility.GetLocalizedText("RichPresence.InGame"), LocalizationUtility.GetLocalizedText("RichPresence.InCreativeMode"));
		}

		private void OnDestroy()
		{
			ClearPresence();
			_client?.Dispose();
		}
	}
}
