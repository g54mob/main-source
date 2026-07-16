using UnityEngine;

public class GameDataSceneHandler : MonoBehaviour
{
	private string fileToLoad;

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	public string ReadData()
	{
		return fileToLoad;
	}

	public void WriteData(string saveFile)
	{
		fileToLoad = saveFile;
	}
}
