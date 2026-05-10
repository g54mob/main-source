using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class localization_example : MonoBehaviour
	{
		[SerializeField]
		private LocalizedString test1;

		private void Start()
		{
			Debug.Log(test1.GetLocalizedString() ?? "");
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettingsOnSelectedLocaleChanged;
		}

		private void OnDisable()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettingsOnSelectedLocaleChanged;
		}

		private void LocalizationSettingsOnSelectedLocaleChanged(Locale obj)
		{
			Debug.Log(test1.GetLocalizedString() ?? "");
		}
	}
}
