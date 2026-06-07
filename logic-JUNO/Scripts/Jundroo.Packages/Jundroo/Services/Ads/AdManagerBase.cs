using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

namespace Jundroo.Services.Ads
{
	public class AdManagerBase<TAdManager, TAdManagerConfig> : MonoBehaviour where TAdManager : AdManagerBase<TAdManager, TAdManagerConfig> where TAdManagerConfig : AdManagerBase<TAdManager, TAdManagerConfig>.AdManagerConfigurationBase
	{
		protected enum PreloadedAdStatus
		{
			Unknown = 0,
			Loading = 1,
			Loaded = 2,
			LoadFailed = 3
		}

		public class AdManagerConfigurationBase
		{
			public string AdUnitId { get; set; }

			public float FailedAdLoadRetryCooldownTime { get; set; }

			public int MaxCachedInterstitialAds { get; set; }
		}

		protected class PreloadedAd<T>
		{
			public T Ad { get; set; }

			public long Id { get; set; }

			public float? LoadCompletedTime { get; set; }

			public float LoadStartedTime { get; set; }

			public PreloadedAdStatus Status { get; set; }
		}

		private static long _nextAdId = 1L;

		private Stopwatch _stopwatch = Stopwatch.StartNew();

		public float AdLoadCooldownTime { get; private set; }

		protected TAdManagerConfig Config { get; private set; }

		protected List<PreloadedAd<IInterstitialAd>> PreloadedInterstitialAds { get; } = new List<PreloadedAd<IInterstitialAd>>();

		public static TAdManager Create(GameObject parentGameObject, TAdManagerConfig config)
		{
			TAdManager val = new GameObject("AdManager").AddComponent<TAdManager>();
			val.gameObject.transform.SetParent(parentGameObject.transform, worldPositionStays: false);
			val.UpdateConfiguration(config);
			return val;
		}

		public IInterstitialAd GetInterstitialAd()
		{
			if (AdsService.Enabled && PreloadedInterstitialAds.Count > 0)
			{
				PreloadedAd<IInterstitialAd> preloadedAd = PreloadedInterstitialAds[0];
				if (preloadedAd.Status == PreloadedAdStatus.Loaded)
				{
					PreloadedInterstitialAds.RemoveAt(0);
					return preloadedAd.Ad;
				}
			}
			return null;
		}

		public void UpdateConfiguration(TAdManagerConfig config)
		{
			Config = config;
			OnConfigurationUpdated();
		}

		protected virtual void OnConfigurationUpdated()
		{
		}

		protected virtual void PreloadAds()
		{
			PreloadAds(PreloadedInterstitialAds, Config.MaxCachedInterstitialAds);
		}

		protected virtual void PreloadAds<T>(List<PreloadedAd<T>> preloadedAds, int maxCached) where T : IAd
		{
			if (preloadedAds.Count >= maxCached)
			{
				return;
			}
			if (preloadedAds.Count != 0)
			{
				if (preloadedAds[preloadedAds.Count - 1].Status == PreloadedAdStatus.Loading)
				{
					return;
				}
			}
			PreloadedAd<T> preloadedAd = new PreloadedAd<T>();
			preloadedAd.Id = _nextAdId++;
			preloadedAd.LoadStartedTime = (float)_stopwatch.Elapsed.TotalSeconds;
			preloadedAd.Status = PreloadedAdStatus.Loading;
			preloadedAds.Add(preloadedAd);
			Task<T> loadTask = null;
			if (typeof(T) == typeof(IInterstitialAd))
			{
				loadTask = (Task<T>)(object)AdLoader.LoadInterstitialAdAsync(Config.AdUnitId);
				Task.Run(async delegate
				{
					try
					{
						T ad = await loadTask;
						if (preloadedAd.Status == PreloadedAdStatus.LoadFailed)
						{
							return;
						}
						preloadedAd.Ad = ad;
					}
					catch (Exception exception)
					{
						UnityEngine.Debug.LogException(exception);
						preloadedAd.Ad = default(T);
						preloadedAd.Status = PreloadedAdStatus.LoadFailed;
					}
					finally
					{
						preloadedAd.LoadCompletedTime = (float)_stopwatch.Elapsed.TotalSeconds;
						preloadedAd.Status = ((preloadedAd.Ad == null) ? PreloadedAdStatus.LoadFailed : PreloadedAdStatus.Loaded);
					}
					if (AdsService.LoggingFlags.HasFlag(AdLoggingFlags.LogAdLoads))
					{
						string text = ((preloadedAd.Status == PreloadedAdStatus.Loaded) ? "succeeded" : "failed");
						float num = preloadedAd.LoadCompletedTime.Value - preloadedAd.LoadStartedTime;
						UnityEngine.Debug.Log($"Ad '{preloadedAd.Id}' of type '{typeof(T).FullName}' load {text} in {num:F2} seconds");
					}
					if (preloadedAd.Status == PreloadedAdStatus.LoadFailed)
					{
						AdLoadCooldownTime = Config.FailedAdLoadRetryCooldownTime;
					}
				});
				return;
			}
			base.gameObject.SetActive(value: false);
			throw new NotSupportedException("Ads of type '" + typeof(T).FullName + "' are not currently supported.");
		}

		protected virtual void UnloadInvalidAndExpiredAds<T>(List<PreloadedAd<T>> preloadedAds) where T : IAd
		{
			for (int num = preloadedAds.Count - 1; num >= 0; num--)
			{
				PreloadedAd<T> preloadedAd = preloadedAds[num];
				if (preloadedAd.Status == PreloadedAdStatus.LoadFailed)
				{
					T ad = preloadedAd.Ad;
					if (ad != null)
					{
						ad.Destroy();
					}
					preloadedAds.RemoveAt(num);
				}
				else if (preloadedAd.Status == PreloadedAdStatus.Loading)
				{
					if (Time.realtimeSinceStartup - preloadedAd.LoadStartedTime > 900f)
					{
						preloadedAd.Status = PreloadedAdStatus.LoadFailed;
						T ad = preloadedAd.Ad;
						if (ad != null)
						{
							ad.Destroy();
						}
						preloadedAds.RemoveAt(num);
						UnityEngine.Debug.LogError($"Loading of ad '{preloadedAd.Id}' of type '{typeof(T).FullName}' timed out after {15} minutes of loading.");
					}
				}
				else if (preloadedAd.Status == PreloadedAdStatus.Loaded && Time.realtimeSinceStartup - (preloadedAd.LoadCompletedTime ?? preloadedAd.LoadStartedTime) > 3600f)
				{
					T ad = preloadedAd.Ad;
					if (ad != null)
					{
						ad.Destroy();
					}
					preloadedAds.RemoveAt(num);
					UnityEngine.Debug.LogError($"Unloading expired ad '{preloadedAd.Id}' of type '{typeof(T).FullName}'.");
				}
			}
		}

		protected virtual void UnloadInvalidAndExpiredAds()
		{
			UnloadInvalidAndExpiredAds(PreloadedInterstitialAds);
		}

		protected virtual void Update()
		{
			if (AdsService.Enabled)
			{
				AdLoadCooldownTime = Mathf.Max(0f, AdLoadCooldownTime - Time.unscaledDeltaTime);
				UnloadInvalidAndExpiredAds();
				if (AdLoadCooldownTime <= 0f)
				{
					AdLoadCooldownTime = 5f;
					PreloadAds();
				}
			}
		}
	}
}
