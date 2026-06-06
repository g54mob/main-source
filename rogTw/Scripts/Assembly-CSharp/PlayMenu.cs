using UnityEngine;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
	[SerializeField]
	private Text record1Text;

	[SerializeField]
	private Text record2Text;

	[SerializeField]
	private Text record3Text;

	[SerializeField]
	private Text record4Text;

	[SerializeField]
	private Toggle monsterModeToggle;

	[SerializeField]
	private Toggle splitModeToggle;

	[SerializeField]
	private Toggle firstPersonModeToggle;

	private void Start()
	{
		record1Text.text = "Current Record\nLevel " + PlayerPrefs.GetInt("Record1", 0);
		record2Text.text = "Current Record\nLevel " + PlayerPrefs.GetInt("Record2", 0);
		record3Text.text = "Current Record\nLevel " + PlayerPrefs.GetInt("Record3", 0);
		record4Text.text = "Current Record\nLevel " + PlayerPrefs.GetInt("Record4", 0);
		if (PlayerPrefs.GetInt("MonsterMode", 0) == 1)
		{
			monsterModeToggle.isOn = true;
		}
		else
		{
			monsterModeToggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("SplitMode", 0) == 1)
		{
			splitModeToggle.isOn = true;
		}
		else
		{
			splitModeToggle.isOn = false;
		}
		if (PlayerPrefs.GetInt("FirstPersonMode", 0) == 1)
		{
			firstPersonModeToggle.isOn = true;
		}
		else
		{
			firstPersonModeToggle.isOn = false;
		}
	}

	public void StartGame(int mode)
	{
		PlayerPrefs.SetInt("GameMode", Mathf.Clamp(mode, 1, 4));
		LevelLoader.instance.LoadLevel("GameScene");
	}

	public void ToggleMonsterMode()
	{
		PlayerPrefs.SetInt("MonsterMode", monsterModeToggle.isOn ? 1 : 0);
		if (SFXManager.instance != null)
		{
			SFXManager.instance.ButtonClick();
		}
	}

	public void ToggleSplitMode()
	{
		PlayerPrefs.SetInt("SplitMode", splitModeToggle.isOn ? 1 : 0);
		if (SFXManager.instance != null)
		{
			SFXManager.instance.ButtonClick();
		}
	}

	public void ToggleFirstPersonMode()
	{
		PlayerPrefs.SetInt("FirstPersonMode", firstPersonModeToggle.isOn ? 1 : 0);
		if (SFXManager.instance != null)
		{
			SFXManager.instance.ButtonClick();
		}
	}
}
