using UnityEngine;
using UnityEngine.UI;

public class TitanFilterToggle : MonoBehaviour
{
	public Character character;

	public Button onButton;

	public Button offButton;

	private void Start()
	{
		updateToggleStatus();
	}

	public void turnOn()
	{
		character.settings.filterTitan = true;
		updateToggleStatus();
	}

	public void turnOff()
	{
		character.settings.filterTitan = false;
		updateToggleStatus();
	}

	private void updateToggleStatus()
	{
		if (character.settings.filterTitan)
		{
			onButton.interactable = false;
			offButton.interactable = true;
		}
		else
		{
			onButton.interactable = true;
			offButton.interactable = false;
		}
	}
}
