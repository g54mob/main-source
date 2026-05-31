using UnityEngine;

public class MenuPlayLastGame : MonoBehaviour
{
	public MenuPlayNewGame MenuPlayNewGame;

	public MenuPlayerSaveAdapter MenuPlayerSaveAdapter;

	public bool update;

	private void Update()
	{
	}

	private string GetString(string key, SaveManager.SaveData data, string defaultValue = "")
	{
		return null;
	}

	private int GetInt(string key, SaveManager.SaveData data, int defaultValue = 0)
	{
		return 0;
	}

	private bool GetBool(string key, SaveManager.SaveData data, bool defaultValue = false)
	{
		return false;
	}

	public void Translate()
	{
	}
}
