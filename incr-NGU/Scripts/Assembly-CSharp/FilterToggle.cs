using UnityEngine;
using UnityEngine.UI;

public class FilterToggle : MonoBehaviour
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
		character.settings.filterOn = true;
		updateToggleStatus();
	}

	public void turnOff()
	{
		character.settings.filterOn = false;
		updateToggleStatus();
	}

	private void updateToggleStatus()
	{
		if (character.settings.filterOn)
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
