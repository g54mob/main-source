using UnityEngine;

public class ActiveSaveFile : MonoBehaviour
{
	private string activeSaveFile;

	public void SetActiveSaveFile(string fileName)
	{
		activeSaveFile = fileName;
	}

	public string GetActiveSaveFile()
	{
		if (activeSaveFile == null)
		{
			return SaveLoadManager.GetFirstFileName();
		}
		return activeSaveFile;
	}
}
