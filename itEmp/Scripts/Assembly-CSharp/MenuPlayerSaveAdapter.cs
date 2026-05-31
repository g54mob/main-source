using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlayerSaveAdapter : MonoBehaviour
{
	public TMP_Text GameName;

	public TMP_Text PlayerTitle;

	public TMP_Text LoadGameData;

	public TMP_Text CreateGameData;

	public TMP_Text LevelDifficulty;

	public Image Screenshot;

	public RectTransform SS;

	public RectTransform SS_Null;

	public string dirPath;

	public string lastGame;

	public string version;

	public string createGame;

	public string levelDifficulty;

	public int idLevelDifficulty;

	public string currentScene;

	public bool completedTutorial;

	public Sprite screenshot;

	public MenuPlayNewGame MenuPlayNewGame;

	public void ButtonPlay()
	{
	}

	private void ButtonPlayAction()
	{
	}

	private void SetValue(string key, string value, string type, SaveManager.SaveData data)
	{
	}

	public void SetData(string name, string playerTitle, string version, string lastGame, string createGame, string levelDifficulty, int idLevelDifficulty, string currentScene, bool completedTutorial, MenuPlayNewGame MenuPlayNewGame, string dirPath, Sprite ss)
	{
	}

	public void Translate()
	{
	}
}
