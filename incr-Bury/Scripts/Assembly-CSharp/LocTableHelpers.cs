using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocTableHelpers : MonoBehaviour
{
	public static string GetStringFromTable(string _locTableKey)
	{
		return LocalizationSettings.StringDatabase.GetLocalizedStringAsync(_locTableKey, null, FallbackBehavior.UseProjectSettings).Result;
	}
}
