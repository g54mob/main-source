using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class UI_RebindOverlay : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private LocalizedString _overlayText;

		private void Awake()
		{
			_text.text = _overlayText.GetLocalizedString();
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			_text.text = _overlayText.GetLocalizedString();
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
		}
	}
}
