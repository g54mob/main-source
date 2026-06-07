using UnityEngine;

public class ResetAudioSettings : MonoBehaviour
{
	public GameObject objToRefresh;

	public void Trigger()
	{
		SettingsManager.Instance.ResetAudioSettings();
		objToRefresh.SetActive(value: false);
		objToRefresh.SetActive(value: true);
	}
}
