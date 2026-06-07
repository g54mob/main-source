using DV.Localization;
using DV.Mods;
using DV.Utils;
using TMPro;
using UnityEngine;

public class DisplayLoadingInfo : MonoBehaviour
{
	public const string LOADING_TEXT = "loading/please_wait";

	public const string MODS_NOTICE_TEXT = "loading/mods_notice";

	public TextMeshProUGUI percentageLoadedTMP;

	public TextMeshProUGUI loadProgressTMP;

	public TextMeshProUGUI modsNoticeTMP;

	private void Start()
	{
		WorldStreamingInit.LoadingStatusChanged += OnLoadingStatusChanged;
		WorldStreamingInit.LoadingFinished += OnLoadingFinished;
		if (Bootstrap.bootstrapped)
		{
			SingletonBehaviour<LoadingScreenManager>.Instance.StartLoading(finishOnStableFps: false, gameLoading: true);
		}
	}

	private void OnLoadingStatusChanged(string message, bool isError, float percentageLoaded)
	{
		string text = "\n" + (isError ? "[error]" : "") + message;
		loadProgressTMP.text += text;
		percentageLoadedTMP.text = LocalizationAPI.L("loading/please_wait", percentageLoaded.ToString("N0"));
		modsNoticeTMP.gameObject.SetActive(ModManagerInfo.CurrentSavegameHasMods);
		modsNoticeTMP.text = LocalizationAPI.L("loading/mods_notice");
		if (modsNoticeTMP.text.Contains("MISSING TRANSLATION"))
		{
			modsNoticeTMP.text = LocalizationAPI.Lo("loading/mods_notice", "English");
		}
		if (Bootstrap.bootstrapped)
		{
			SingletonBehaviour<LoadingScreenManager>.Instance.UpdateProgress(percentageLoaded / 100f);
		}
	}

	private void OnLoadingFinished()
	{
		WorldStreamingInit.LoadingStatusChanged -= OnLoadingStatusChanged;
		WorldStreamingInit.LoadingFinished -= OnLoadingFinished;
		if (Bootstrap.bootstrapped)
		{
			SingletonBehaviour<LoadingScreenManager>.Instance.FinishLoading();
		}
		Object.Destroy(base.gameObject);
	}

	private void OnDestroy()
	{
		WorldStreamingInit.LoadingStatusChanged -= OnLoadingStatusChanged;
		WorldStreamingInit.LoadingFinished -= OnLoadingFinished;
	}
}
