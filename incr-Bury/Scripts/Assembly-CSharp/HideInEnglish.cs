using UnityEngine;
using UnityEngine.Localization.Settings;

public class HideInEnglish : MonoBehaviour
{
	private void Awake()
	{
		try
		{
			if (LocalizationSettings.SelectedLocale.Identifier.Code == "en")
			{
				base.gameObject.SetActive(value: false);
			}
		}
		catch
		{
			Debug.Log("Failed to detect language settings, ignoring!");
		}
	}
}
