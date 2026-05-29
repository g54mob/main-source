using UnityEngine;

public class SaveSettings : MonoBehaviour
{
	private bool quitting;

	private void OnDisable()
	{
		if (!quitting)
		{
			Save();
		}
	}

	private void Save()
	{
		if ((bool)this && (bool)SaveData.ins)
		{
			SaveData.ins.SaveSettings();
		}
	}

	private void OnApplicationQuit()
	{
		quitting = true;
	}
}
