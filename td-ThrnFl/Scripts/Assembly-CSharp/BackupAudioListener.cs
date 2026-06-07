using UnityEngine;

public class BackupAudioListener : MonoBehaviour
{
	public static BackupAudioListener Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void EnableBackupListener(bool enable)
	{
		GetComponent<AudioListener>().enabled = enable;
	}
}
