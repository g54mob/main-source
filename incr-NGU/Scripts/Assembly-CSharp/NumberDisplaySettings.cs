using UnityEngine;
using UnityEngine.UI;

public class NumberDisplaySettings : MonoBehaviour
{
	public Character character;

	public Button suffixButton;

	public Button engiButton;

	public Button sciButton;

	private void Start()
	{
		updateButtons();
	}

	public void suffixMode()
	{
		if (character.settings.numberDisplay != 3)
		{
			character.settings.numberDisplay = 0;
			updateButtons();
		}
	}

	public void engiMode()
	{
		if (character.settings.numberDisplay != 3)
		{
			character.settings.numberDisplay = 1;
			updateButtons();
		}
	}

	public void sciMode()
	{
		if (character.settings.numberDisplay != 3)
		{
			character.settings.numberDisplay = 2;
			updateButtons();
		}
	}

	public void updateButtons()
	{
		suffixButton.interactable = true;
		engiButton.interactable = true;
		sciButton.interactable = true;
		switch (character.settings.numberDisplay)
		{
		case 0:
			suffixButton.interactable = false;
			break;
		case 1:
			engiButton.interactable = false;
			break;
		case 2:
			sciButton.interactable = false;
			break;
		}
	}
}
