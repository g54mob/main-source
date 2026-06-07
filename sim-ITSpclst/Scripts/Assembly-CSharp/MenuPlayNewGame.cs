using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlayNewGame : MonoBehaviour
{
	[Header("Game Name")]
	public TMP_InputField GameName;

	[Header("Difficulty Level")]
	public List<string> GameDifficultyLevel;

	public List<MenuPlayDifficultyInfo> InformationLevel;

	public TMP_Text viewGameDifficultyLevel;

	public TMP_Text viewInformationLeft;

	public TMP_Text viewInformationRight;

	private int nowindexGameDifficultyLevel;

	private string selectedGameDifficultyLevel;

	[Header("Game Name")]
	public Button ButtonUICreateGame;

	[Header("Avatar")]
	public Sprite[] AvatarPlayerList;

	public Image AvatarPlayer;

	public int currentAvatarID;

	[Header("Without tutorial")]
	public RectTransform WithoutTutorialSection;

	public Toggle WithoutTutorialToggle;

	private void OnValidate()
	{
	}

	public void SetNextDifficultyLevelButton(int value)
	{
	}

	private void SetDifficultyLevelAction(int value, bool increment = true)
	{
	}

	public void OpenMenu()
	{
	}

	public void UpadateLanguageInformationAboutLevelDif()
	{
	}

	public void UpdateName()
	{
	}

	public void ButtonCreateGame()
	{
	}

	public static int AddValue(int now, int value, bool increment)
	{
		return 0;
	}

	public static float AddValue(float now, float value, bool increment)
	{
		return 0f;
	}

	public void NextAvatar(int step)
	{
	}
}
