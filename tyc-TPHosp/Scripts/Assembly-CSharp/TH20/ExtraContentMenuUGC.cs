using TH20.ExtContent;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class ExtraContentMenuUGC : MonoBehaviour
	{
		[SerializeField]
		private DynamicButton _button;

		private void OnEnable()
		{
			_button.onPrimaryDown.AddListener(OnButtonPressed);
		}

		private void OnDisable()
		{
			_button.onPrimaryDown.RemoveListener(OnButtonPressed);
		}

		private void OnButtonPressed()
		{
			string steamURL = string.Empty;
			string browserURL = string.Empty;
			ExtContentSourceWorkshop.GetSteamOverlayWorkshopURLs(ref steamURL, ref browserURL);
			WorkshopUtils.OpenSteamOverlay(steamURL, browserURL);
		}
	}
}
