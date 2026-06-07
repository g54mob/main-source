using I2.Loc;
using Kamgam.LocalizationForSettings;
using UnityEngine;

[DefaultExecutionOrder(-11)]
public class SettingsLocalizationInitializer : MonoBehaviour
{
	public LocalizationProvider Provider;

	private void Awake()
	{
		if (Provider == null)
		{
			Debug.LogError("SettingsLocalizationInitializer: LocalizationProvider is not assigned!");
			return;
		}
		Provider.GetLocalization().SetDynamicLocalizationCallback(DynamicLocalization);
		LocalizationManager.OnLocalizeEvent += OnI2LLocalizeEvent;
	}

	private void OnDestroy()
	{
		LocalizationManager.OnLocalizeEvent -= OnI2LLocalizeEvent;
	}

	private void OnI2LLocalizeEvent()
	{
		Provider.GetLocalization().TriggerLanguageChangeEvent();
	}

	private string DynamicLocalization(string term, string language)
	{
		if (!LocalizationManager.TryGetTranslation(term, out var Translation))
		{
			return Provider.GetLocalization().Get(term, ignoreDynamic: true);
		}
		return Translation;
	}
}
