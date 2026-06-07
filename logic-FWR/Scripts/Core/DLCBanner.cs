using Steamworks;
using UnityEngine;

public class DLCBanner : MonoBehaviour
{
	public uint dlcAppId;

	public string dlcUrl;

	public bool hideAfterShow;

	private const string DlcBannerOptionName = "show dlc banner";

	private const string OptionDisabledValue = "disabled";

	public void ShowDLC()
	{
		if (!TryShowOverlay())
		{
			Application.OpenURL(dlcUrl);
		}
		if (hideAfterShow)
		{
			HideBanner();
		}
	}

	public void Close()
	{
		HideBanner();
	}

	private void Start()
	{
		if (OptionHolder.GetString("show dlc banner") == "disabled")
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private bool TryShowOverlay()
	{
		if (!SteamManager.Initialized)
		{
			return false;
		}
		if (!SteamUtils.IsOverlayEnabled())
		{
			return false;
		}
		SteamFriends.ActivateGameOverlayToStore(new AppId_t(dlcAppId), EOverlayToStoreFlag.k_EOverlayToStoreFlag_None);
		return true;
	}

	private void HideBanner()
	{
		base.gameObject.SetActive(value: false);
		OptionHolder.SetOption("show dlc banner", "disabled");
	}
}
