using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeveloperWindow : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField levelInput;

	[SerializeField]
	private MouseClick mouseClick;

	[SerializeField]
	private Toggle toggle;

	[SerializeField]
	private Toggle devToggle;

	public void LoadLevel()
	{
		int level = int.Parse(levelInput.text);
		Save.EraseSave();
		DatabaseUtils.DropAllTables();
		mouseClick.RemoveAllListeners();
		LevelManager.SetLevel(level);
		SceneManager.LoadScene("Splash");
	}

	public void UseCustomParser()
	{
		QueryButton.USE_CUSTOM_PARSER = toggle.isOn;
	}

	public void EnableDevMode()
	{
		CreateTables.DEV_MODE = devToggle.isOn;
	}
}
