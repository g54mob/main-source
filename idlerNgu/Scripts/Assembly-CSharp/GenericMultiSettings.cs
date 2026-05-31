using UnityEngine;
using UnityEngine.UI;

public class GenericMultiSettings : MonoBehaviour
{
	public Character character;

	public Text nameText;

	public Button[] buttons;

	public string settingName;

	public int id;

	public int curState;

	private void Start()
	{
		setCurState();
		updateButtons();
	}

	public void setCurState()
	{
		switch (id)
		{
		case 0:
			curState = character.settings.autoTransform;
			break;
		case 1:
			curState = character.settings.themeID;
			break;
		case 2:
			curState = character.settings.genericRes3ColourID;
			break;
		}
		updateButtons();
	}

	public void updateSetting(int value)
	{
		switch (id)
		{
		case 0:
			character.settings.autoTransform = value;
			break;
		case 1:
			if ((value == 2 && !character.arbitrary.boughtAscendedNewbiePack) || (value == 3 && !character.arbitrary.boughtAscendedNewbiePack))
			{
				updateButtons();
				return;
			}
			character.settings.themeID = value;
			break;
		case 2:
			if ((value == 2 && !character.arbitrary.boughtAscendedNewbiePack) || (value == 3 && !character.arbitrary.boughtAscendedNewbiePack))
			{
				updateButtons();
				return;
			}
			character.settings.genericRes3ColourID = value;
			break;
		}
		curState = value;
		updateButtons();
	}

	public void updateButtons()
	{
		if (id == 0 && character.allChallenges.level100Challenge.completions() < character.allChallenges.level100Challenge.maxCompletions)
		{
			disable();
			return;
		}
		enable();
		for (int i = 0; i < buttons.Length; i++)
		{
			if (id == 1 && i == 4)
			{
				if (character.settings.prizePicked == 6)
				{
					buttons[i].gameObject.SetActive(value: true);
				}
				else
				{
					buttons[i].gameObject.SetActive(value: false);
				}
			}
			if (curState == i)
			{
				buttons[i].interactable = false;
			}
			else
			{
				buttons[i].interactable = true;
			}
		}
	}

	public void enable()
	{
		for (int i = 0; i < buttons.Length; i++)
		{
			buttons[i].gameObject.SetActive(value: true);
		}
		nameText.text = settingName;
	}

	public void disable()
	{
		for (int i = 0; i < buttons.Length; i++)
		{
			buttons[i].gameObject.SetActive(value: false);
		}
		nameText.text = "";
	}
}
