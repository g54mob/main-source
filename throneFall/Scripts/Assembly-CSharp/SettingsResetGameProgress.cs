using UnityEngine;

public class SettingsResetGameProgress : MonoBehaviour
{
	public void ResetGameProgress()
	{
		SettingsManager.Instance.ResetGameProgress();
	}
}
