using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsWrapper : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
	public static readonly int MIN_TREASURES_FOR_FAST_FORWARD = 21;

	public static readonly int TREASURE_COUNT_TO_FAST_FORWARD = 380;

	public static readonly float COOLDOWN_FOR_FAST_FORWARD_WITH_AD = 70f;

	public static readonly int PRICE_PER_TREASURE_FAST_FORWARD = 20;

	private static string GAME_ID_ANDROID = "4876281";

	private static string GAME_ID_IOS = "4876280";

	private static string UNIT_ID_REWARDED = "Rewarded_Android";

	private static Action<bool> _callback;

	private static int initCooldown;

	private static bool isInitializing;

	private static int loadCooldown;

	private static bool isLoading;

	private static bool hasLoaded;

	public static AdsWrapper singleton { get; private set; }

	public bool IsReady()
	{
		if (Advertisement.isInitialized)
		{
			return hasLoaded;
		}
		return false;
	}

	public bool IsShowing()
	{
		return Advertisement.isShowing;
	}

	public void ShowRewardedAd(Action<bool> callback)
	{
		if (IsReady())
		{
			_callback = callback;
			Advertisement.Show(UNIT_ID_REWARDED, this);
		}
		else
		{
			callback?.Invoke(obj: false);
		}
	}

	private void Start()
	{
	}

	private IEnumerator _InitAndLoad()
	{
		while (true)
		{
			if (!Advertisement.isInitialized)
			{
				Init();
			}
			else
			{
				LoadRewardedAd();
			}
			if (IsReady())
			{
				yield return new WaitForSeconds(4f);
			}
			else
			{
				yield return new WaitForSeconds(1f);
			}
		}
	}

	private void Init()
	{
		if (!isInitializing)
		{
			isInitializing = true;
		}
	}

	private void LoadRewardedAd()
	{
		if (!isLoading && !hasLoaded && !Advertisement.isShowing && (!QuestController.singleton || QuestController.singleton.IsAvailable("fungus_forest")))
		{
			isLoading = true;
			hasLoaded = false;
			Advertisement.Load(UNIT_ID_REWARDED, this);
		}
	}

	public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
	{
		if (_callback != null)
		{
			_callback(obj: false);
		}
		_callback = null;
		Debug.LogError("Unity Ads failed to show placement " + placementId + " with code " + error.ToString() + ". " + message);
	}

	public void OnUnityAdsShowStart(string placementId)
	{
	}

	public void OnUnityAdsShowClick(string placementId)
	{
	}

	public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
	{
		hasLoaded = false;
		if (_callback != null)
		{
			_callback(obj: true);
		}
		_callback = null;
	}

	public void OnUnityAdsAdLoaded(string placementId)
	{
		isLoading = false;
		hasLoaded = true;
	}

	public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
	{
		isLoading = false;
		hasLoaded = false;
		Debug.LogError("Unity Ads failed to load placement " + placementId + " with code " + error.ToString() + ". " + message);
	}

	void IUnityAdsInitializationListener.OnInitializationComplete()
	{
		Debug.Log("Unity Ads initialization complete.");
		LoadRewardedAd();
		isInitializing = false;
	}

	void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
	{
		Debug.LogError("Unity Ads failed to initialize with code " + error.ToString() + ". " + message);
		isInitializing = false;
	}

	private void Awake()
	{
		singleton = this;
	}
}
