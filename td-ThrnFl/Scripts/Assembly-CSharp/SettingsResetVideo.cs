using UnityEngine;

public class SettingsResetVideo : MonoBehaviour
{
	public GameObject objToRefresh;

	public void ResetVideoSettings()
	{
		SettingsManager.Instance.ResetVideoSettings();
		objToRefresh.SetActive(value: false);
		objToRefresh.SetActive(value: true);
	}
}
