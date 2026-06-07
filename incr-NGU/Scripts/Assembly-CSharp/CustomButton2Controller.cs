using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton2Controller : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public InputField energyInput;

	public Text buttonText;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (character.purchases.hasCustomEnergyButton2)
		{
			if (Input.GetKey("left shift") || Input.GetKey("right shift"))
			{
				buttonText.text = energyInput.text;
			}
			else
			{
				energyInput.text = buttonText.text;
			}
		}
		else
		{
			tooltip.showTooltip("You must purchase the ability to use this button in the \"Spend EXP\" menu!", 2f);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("If purchased, you can use this button to set a custom amount of energy in the Input box. Clicking the button will put its numerical value into the Input box, while holding SHIFT+click sets the button's number to the value of the Input box!");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
