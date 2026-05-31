using UnityEngine;
using UnityEngine.UI;

public class TooltipToggle : MonoBehaviour
{
	public Character character;

	public Button tooltipOn;

	public Button tooltipOff;

	private void Start()
	{
		updateToggleStatus();
	}

	public void turnOnTooltips()
	{
		character.settings.tooltipsOn = true;
		updateToggleStatus();
	}

	public void turnOffTooltips()
	{
		character.settings.tooltipsOn = false;
		updateToggleStatus();
	}

	private void updateToggleStatus()
	{
		if (character.settings.tooltipsOn)
		{
			tooltipOn.interactable = false;
			tooltipOff.interactable = true;
		}
		else
		{
			tooltipOn.interactable = true;
			tooltipOff.interactable = false;
		}
	}
}
