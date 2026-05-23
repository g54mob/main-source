using I2.Loc;
using UnityEngine;

public class SettingsLanguageReset : MonoBehaviour
{
	public GameObject objToRefresh;

	public void ResetLanguage()
	{
		LocalizationManager.CurrentLanguage = LocalizationManager.GetCurrentDeviceLanguage();
		objToRefresh.SetActive(value: false);
		objToRefresh.SetActive(value: true);
	}
}
