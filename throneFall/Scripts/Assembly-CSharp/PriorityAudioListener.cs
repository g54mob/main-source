using System.Collections;
using UnityEngine;

public class PriorityAudioListener : MonoBehaviour
{
	private void OnEnable()
	{
		StartCoroutine(ExecuteAfterTime());
	}

	private IEnumerator ExecuteAfterTime()
	{
		while (BackupAudioListener.Instance == null)
		{
			yield return null;
		}
		BackupAudioListener.Instance.EnableBackupListener(enable: false);
	}

	private void OnDisable()
	{
		if (BackupAudioListener.Instance != null)
		{
			BackupAudioListener.Instance.EnableBackupListener(enable: true);
		}
	}
}
