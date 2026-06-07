using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Assets.Scripts.Web;
using Jundroo.Services.Ads;
using ModApi;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Services.Ads
{
	public class AdManagerScript : AdManagerBase<AdManagerScript, AdManagerScript.AdManagerConfiguration>
	{
		public class AdManagerConfiguration : AdManagerConfigurationBase
		{
			public class DownloadCraftConfig
			{
				public int MaxLoadsBetweenAds { get; set; }

				public float MaxTimeBetweenAds { get; set; }
			}

			public class FlightSceneLoadConfig
			{
				public int MaxLoadsBetweenAds { get; set; }

				public float MaxTimeBetweenAds { get; set; }
			}

			public const int CurrentVersion = 1;

			public DownloadCraftConfig DownloadCraft { get; set; }

			public FlightSceneLoadConfig FlightSceneLoad { get; set; }

			public bool LogAdNotShownMessage { get; set; }

			public bool LogAdShownMessage { get; set; }

			public float MinimumTimeBetweenAds { get; set; }

			public AdManagerConfiguration()
			{
			}

			public AdManagerConfiguration(XElement xml)
			{
				DownloadCraft = new DownloadCraftConfig();
				XElement element = xml.Element("DownloadCraftConfig");
				DownloadCraft.MaxLoadsBetweenAds = element.GetIntAttribute("maxLoadsBetweenAds");
				DownloadCraft.MaxTimeBetweenAds = element.GetFloatAttribute("maxTimeBetweenAds");
				FlightSceneLoad = new FlightSceneLoadConfig();
				XElement element2 = xml.Element("FlightSceneLoad");
				FlightSceneLoad.MaxLoadsBetweenAds = element2.GetIntAttribute("maxLoadsBetweenAds");
				FlightSceneLoad.MaxTimeBetweenAds = element2.GetFloatAttribute("maxTimeBetweenAds");
				LogAdNotShownMessage = xml.GetBoolAttribute("logAdNotShownMessage");
				LogAdShownMessage = xml.GetBoolAttribute("logAdShownMessage");
				MinimumTimeBetweenAds = xml.GetFloatAttribute("minimumTimeBetweenAds");
				base.FailedAdLoadRetryCooldownTime = xml.GetFloatAttribute("failedAdLoadRetryCooldownTime");
				base.MaxCachedInterstitialAds = xml.GetIntAttribute("maxCachedInterstitialAds");
				XElement xElement = xml.Element("AdUnits");
				if (xElement != null)
				{
					if (Device.IsAndroidBuild)
					{
						base.AdUnitId = xElement.GetStringAttribute("android");
					}
					else if (Device.IsIosBuild)
					{
						base.AdUnitId = xElement.GetStringAttribute("iOS");
					}
				}
			}
		}

		private class DownloadCraftAd
		{
			public float LastShownTime { get; set; }

			public int LoadsSinceLastShown { get; set; }

			public DownloadCraftAd()
			{
				LastShownTime = Time.realtimeSinceStartup;
				LoadsSinceLastShown = 0;
			}
		}

		private class FlightSceneLoadAd
		{
			public float LastShownTime { get; set; }

			public int LoadsSinceLastShown { get; set; }

			public FlightSceneLoadAd()
			{
				LastShownTime = Time.realtimeSinceStartup;
				LoadsSinceLastShown = 0;
			}
		}

		private const string CachedAdManagerConfigurationFile = "AdManagerConfiguration.xml";

		private DownloadCraftAd _downloadCraftAd;

		private FlightSceneLoadAd _flightSceneLoadAd;

		private float _lastAdShownTime;

		public bool AdsEnabled => AdsService.Enabled;

		public static AdManagerScript Create(GameObject parentGameObject)
		{
			AdManagerConfiguration adManagerConfiguration = null;
			try
			{
				adManagerConfiguration = new AdManagerConfiguration(GameData.LoadXml("AdManagerConfiguration.xml").Root);
				Debug.Log("Loaded cached ad manager configuration. Using ad unit '" + adManagerConfiguration.AdUnitId + "'");
			}
			catch (Exception)
			{
				Debug.Log("Could not load cached configuration. Creating default ad manager configuration.");
				adManagerConfiguration = new AdManagerConfiguration
				{
					AdUnitId = string.Empty,
					MaxCachedInterstitialAds = 2,
					FailedAdLoadRetryCooldownTime = 90f,
					MinimumTimeBetweenAds = 90f,
					FlightSceneLoad = new AdManagerConfiguration.FlightSceneLoadConfig
					{
						MaxLoadsBetweenAds = 4,
						MaxTimeBetweenAds = 600f
					},
					DownloadCraft = new AdManagerConfiguration.DownloadCraftConfig
					{
						MaxLoadsBetweenAds = 4,
						MaxTimeBetweenAds = 600f
					},
					LogAdShownMessage = true,
					LogAdNotShownMessage = true
				};
			}
			return AdManagerBase<AdManagerScript, AdManagerConfiguration>.Create(parentGameObject, adManagerConfiguration);
		}

		public async Task ShowAdForDownloadCraft()
		{
			if (!AdsEnabled || Game.Instance.InAppPurchases.Features.RemoveAds.Unlocked)
			{
				return;
			}
			_downloadCraftAd.LoadsSinceLastShown++;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (realtimeSinceStartup - _lastAdShownTime < base.Config.MinimumTimeBetweenAds)
			{
				if (base.Config.LogAdNotShownMessage)
				{
					Debug.Log($"Ad not shown (Craft Download): Time since last ad ({realtimeSinceStartup - _lastAdShownTime:F2}) " + $"less than minimum time between ads ({base.Config.MinimumTimeBetweenAds:F2}).");
				}
			}
			else if (realtimeSinceStartup - _downloadCraftAd.LastShownTime > base.Config.DownloadCraft.MaxTimeBetweenAds || _downloadCraftAd.LoadsSinceLastShown > base.Config.DownloadCraft.MaxLoadsBetweenAds)
			{
				IInterstitialAd ad = Game.Instance.Ads.GetInterstitialAd();
				if (ad?.CanShowAd() ?? false)
				{
					_downloadCraftAd.LoadsSinceLastShown = 0;
					_downloadCraftAd.LastShownTime = realtimeSinceStartup;
					_lastAdShownTime = realtimeSinceStartup;
					if (base.Config.LogAdShownMessage)
					{
						Debug.Log("Showing Ad (Craft Download)");
					}
					await ShowAd(ad);
					if (base.Config.LogAdShownMessage)
					{
						Debug.Log("Closing Ad (Craft Download)");
					}
					ad.Destroy();
				}
				else if (base.Config.LogAdNotShownMessage)
				{
					Debug.Log("Ad not shown (Craft Download): Ad is null is unable to be shown.");
				}
			}
			else if (base.Config.LogAdNotShownMessage)
			{
				Debug.Log($"Ad not shown (Craft Download): LoadCount={_downloadCraftAd.LoadsSinceLastShown}, " + $"TimeSinceLast={realtimeSinceStartup - _downloadCraftAd.LastShownTime:F2}.");
			}
		}

		public async Task ShowAdForFlightSceneLoad(Action onWillShowAd)
		{
			if (!AdsEnabled || Game.Instance.InAppPurchases.Features.RemoveAds.Unlocked)
			{
				return;
			}
			_flightSceneLoadAd.LoadsSinceLastShown++;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (realtimeSinceStartup - _lastAdShownTime < base.Config.MinimumTimeBetweenAds)
			{
				if (base.Config.LogAdNotShownMessage)
				{
					Debug.Log($"Ad not shown (Flight Scene Load): Time since last ad ({realtimeSinceStartup - _lastAdShownTime:F2}) " + $"less than minimum time between ads ({base.Config.MinimumTimeBetweenAds:F2}).");
				}
			}
			else if (realtimeSinceStartup - _flightSceneLoadAd.LastShownTime > base.Config.FlightSceneLoad.MaxTimeBetweenAds || _flightSceneLoadAd.LoadsSinceLastShown > base.Config.FlightSceneLoad.MaxLoadsBetweenAds)
			{
				IInterstitialAd ad = Game.Instance.Ads.GetInterstitialAd();
				if (ad?.CanShowAd() ?? false)
				{
					_flightSceneLoadAd.LoadsSinceLastShown = 0;
					_flightSceneLoadAd.LastShownTime = realtimeSinceStartup;
					_lastAdShownTime = realtimeSinceStartup;
					onWillShowAd();
					if (base.Config.LogAdShownMessage)
					{
						Debug.Log("Showing Ad (Flight Scene Load)");
					}
					await ShowAd(ad);
					if (base.Config.LogAdShownMessage)
					{
						Debug.Log("Closing Ad (Flight Scene Load)");
					}
					ad.Destroy();
				}
				else if (base.Config.LogAdNotShownMessage)
				{
					Debug.Log("Ad not shown (Flight Scene Load): Ad is null or is unable to be shown.");
				}
			}
			else if (base.Config.LogAdNotShownMessage)
			{
				Debug.Log($"Ad not shown (Flight Scene Load): LoadCount={_flightSceneLoadAd.LoadsSinceLastShown}, " + $"TimeSinceLast={realtimeSinceStartup - _flightSceneLoadAd.LastShownTime:F2}.");
			}
		}

		protected virtual void Awake()
		{
			_flightSceneLoadAd = new FlightSceneLoadAd();
			_downloadCraftAd = new DownloadCraftAd();
			_lastAdShownTime = Time.realtimeSinceStartup;
		}

		protected virtual void Start()
		{
			StartCoroutine(DownloadAdManagerConfiguration());
		}

		private IEnumerator DownloadAdManagerConfiguration()
		{
			string url = $"{Game.SimpleRocketsWebsiteUrl}/Client/AdManagerConfiguration?version={1}&store={Device.StoreId}";
			WebRequest request = WebRequest.Create(url);
			while (!request.IsDone)
			{
				yield return new WaitForEndOfFrame();
			}
			if (request.Error == null)
			{
				try
				{
					using MemoryStream input = new MemoryStream(request.Bytes);
					using XmlTextReader reader = new XmlTextReader(input);
					XDocument xDocument = XDocument.Load(reader);
					AdManagerConfiguration adManagerConfiguration = new AdManagerConfiguration(xDocument.Root);
					UpdateConfiguration(adManagerConfiguration);
					Debug.Log("Successfully downloaded and updated AdManagerConfiguration. Using ad unit '" + adManagerConfiguration.AdUnitId + "'");
					try
					{
						GameData.SaveXml(xDocument, "AdManagerConfiguration.xml");
						yield break;
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						yield break;
					}
				}
				catch (Exception ex)
				{
					Debug.LogError("Failed to read AdManagerConfiguration.\n" + ex.ToString());
					yield break;
				}
			}
			Debug.LogError("AdManagerConfiguration request failed:\n" + request.Error);
		}

		private async Task ShowAd(IInterstitialAd ad)
		{
			float masterVolume = Game.Instance.Settings.Game.Audio.MasterVolume.Value;
			Game.Instance.AudioPlayer.SetMasterVolume(0f);
			AdsService.SetApplicationVolume(masterVolume);
			await ad.ShowAsync();
			Game.Instance.AudioPlayer.SetMasterVolume(masterVolume);
		}
	}
}
