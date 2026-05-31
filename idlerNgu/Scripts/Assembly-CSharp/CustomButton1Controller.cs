using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton1Controller : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public InputField energyInput;

	public Text buttonText;

	public int id;

	public void Start()
	{
	}

	public void updateButtons()
	{
		switch (id)
		{
		case 1:
			if (character.settings.customEnergy1 > 0)
			{
				buttonText.text = character.display(character.settings.customEnergy1);
			}
			else
			{
				buttonText.text = "Custom Input 1";
			}
			break;
		case 2:
			if (character.settings.customEnergy2 > 0)
			{
				buttonText.text = character.display(character.settings.customEnergy2);
			}
			else
			{
				buttonText.text = "Custom Input 3";
			}
			break;
		case 3:
			if (character.settings.customMagic1 > 0)
			{
				buttonText.text = character.display(character.settings.customMagic1);
			}
			else
			{
				buttonText.text = "Custom Input 2";
			}
			break;
		case 4:
			if (character.settings.customMagic2 > 0)
			{
				buttonText.text = character.display(character.settings.customMagic2);
			}
			else
			{
				buttonText.text = "Custom Input 4";
			}
			break;
		case 5:
			buttonText.text = (character.settings.customEnergyPercent1 * 100f).ToString();
			break;
		case 6:
			buttonText.text = (character.settings.customEnergyPercent2 * 100f).ToString();
			break;
		case 7:
			buttonText.text = (character.settings.customMagicPercent1 * 100f).ToString();
			break;
		case 8:
			buttonText.text = (character.settings.customMagicPercent2 * 100f).ToString();
			break;
		case 9:
			buttonText.text = "<color=green>" + character.settings.customIdleEnergyPercent1 * 100f + "</color>";
			break;
		case 10:
			buttonText.text = "<color=blue>" + character.settings.customIdleMagicPercent1 * 100f + "</color>";
			break;
		case 11:
			buttonText.text = (character.settings.customRes3Percent1 * 100f).ToString();
			break;
		case 12:
			buttonText.text = (character.settings.customRes3Percent2 * 100f).ToString();
			break;
		case 13:
			buttonText.text = "<color=#" + character.res3.colourHexString() + ">" + character.settings.customIdleRes3Percent1 * 100f + "</color>";
			break;
		}
	}

	public void customEnergy1Click()
	{
		if (character.purchases.hasCustomEnergyButton1)
		{
			if (Input.GetKey("left shift") || Input.GetKey("right shift"))
			{
				buttonText.text = energyInput.text;
				switch (id)
				{
				case 1:
					character.settings.customEnergy1 = character.input.energyMagicInput;
					break;
				case 2:
					character.settings.customEnergy2 = character.input.energyMagicInput;
					break;
				case 3:
					character.settings.customMagic1 = character.input.energyMagicInput;
					break;
				case 4:
					character.settings.customMagic2 = character.input.energyMagicInput;
					break;
				}
			}
			else
			{
				switch (id)
				{
				case 1:
					energyInput.text = character.settings.customEnergy1.ToString();
					break;
				case 2:
					energyInput.text = character.settings.customEnergy2.ToString();
					break;
				case 3:
					energyInput.text = character.settings.customMagic1.ToString();
					break;
				case 4:
					energyInput.text = character.settings.customMagic2.ToString();
					break;
				}
				character.input.validateInput();
			}
		}
		else
		{
			tooltip.showTooltip("You must purchase the ability to use this button in the \"Spend EXP\" menu!", 2f);
		}
	}

	public void customEnergy2Click()
	{
		if (character.purchases.hasCustomEnergyButton2)
		{
			if (Input.GetKey("left shift") || Input.GetKey("right shift"))
			{
				switch (id)
				{
				case 1:
					character.settings.customEnergy1 = character.input.energyMagicInput;
					break;
				case 2:
					character.settings.customEnergy2 = character.input.energyMagicInput;
					break;
				case 3:
					character.settings.customMagic1 = character.input.energyMagicInput;
					break;
				case 4:
					character.settings.customMagic2 = character.input.energyMagicInput;
					break;
				}
				updateButtons();
			}
			else
			{
				switch (id)
				{
				case 1:
					energyInput.text = character.settings.customEnergy1.ToString();
					break;
				case 2:
					energyInput.text = character.settings.customEnergy2.ToString();
					break;
				case 3:
					energyInput.text = character.settings.customMagic1.ToString();
					break;
				case 4:
					energyInput.text = character.settings.customMagic2.ToString();
					break;
				}
				character.input.validateInput();
			}
		}
		else
		{
			tooltip.showTooltip("You must purchase the ability to use this button in the \"Spend EXP\" menu!", 2f);
		}
	}

	public void customMagic1Click()
	{
		if (character.purchases.hasCustomMagicButton1)
		{
			if (Input.GetKey("left shift") || Input.GetKey("right shift"))
			{
				switch (id)
				{
				case 1:
					character.settings.customEnergy1 = character.input.energyMagicInput;
					break;
				case 2:
					character.settings.customEnergy2 = character.input.energyMagicInput;
					break;
				case 3:
					character.settings.customMagic1 = character.input.energyMagicInput;
					break;
				case 4:
					character.settings.customMagic2 = character.input.energyMagicInput;
					break;
				}
				updateButtons();
			}
			else
			{
				switch (id)
				{
				case 1:
					energyInput.text = character.settings.customEnergy1.ToString();
					break;
				case 2:
					energyInput.text = character.settings.customEnergy2.ToString();
					break;
				case 3:
					energyInput.text = character.settings.customMagic1.ToString();
					break;
				case 4:
					energyInput.text = character.settings.customMagic2.ToString();
					break;
				}
				character.input.validateInput();
			}
		}
		else
		{
			tooltip.showTooltip("You must purchase the ability to use this button in the \"Spend EXP\" menu!", 2f);
		}
	}

	public void customMagic2Click()
	{
		if (character.purchases.hasCustomMagicButton2)
		{
			if (Input.GetKey("left shift") || Input.GetKey("right shift"))
			{
				buttonText.text = energyInput.text;
				switch (id)
				{
				case 1:
					character.settings.customEnergy1 = character.input.energyMagicInput;
					break;
				case 2:
					character.settings.customEnergy2 = character.input.energyMagicInput;
					break;
				case 3:
					character.settings.customMagic1 = character.input.energyMagicInput;
					break;
				case 4:
					character.settings.customMagic2 = character.input.energyMagicInput;
					break;
				}
				updateButtons();
			}
			else
			{
				switch (id)
				{
				case 1:
					energyInput.text = character.settings.customEnergy1.ToString();
					break;
				case 2:
					energyInput.text = character.settings.customEnergy2.ToString();
					break;
				case 3:
					energyInput.text = character.settings.customMagic1.ToString();
					break;
				case 4:
					energyInput.text = character.settings.customMagic2.ToString();
					break;
				}
				character.input.validateInput();
			}
		}
		else
		{
			tooltip.showTooltip("You must purchase the ability to use this button in the \"Spend EXP\" menu!", 2f);
		}
	}

	public void customPercentClick()
	{
		if ((id == 5 && character.purchases.hasCustomEnergyPercent1) || (id == 6 && character.purchases.hasCustomEnergyPercent2) || (id == 7 && character.purchases.hasCustomMagicPercent1) || (id == 8 && character.purchases.hasCustomMagicPercent2) || (id == 11 && character.purchases.hasCustomRes3Percent1) || (id == 12 && character.purchases.hasCustomRes3Percent2))
		{
			if (Input.GetKey("left shift") || Input.GetKey("right shift"))
			{
				float num = (float)character.input.energyMagicInput / 100f;
				if (num < 0.01f)
				{
					num = 0.01f;
				}
				if (num > 1f)
				{
					num = 1f;
				}
				switch (id)
				{
				case 5:
					character.settings.customEnergyPercent1 = num;
					break;
				case 6:
					character.settings.customEnergyPercent2 = num;
					break;
				case 7:
					character.settings.customMagicPercent1 = num;
					break;
				case 8:
					character.settings.customMagicPercent2 = num;
					break;
				case 11:
					character.settings.customRes3Percent1 = num;
					break;
				case 12:
					character.settings.customRes3Percent2 = num;
					break;
				}
				updateButtons();
				return;
			}
			long num2 = 0L;
			switch (id)
			{
			case 5:
				num2 = Convert.ToInt64((float)character.totalCapEnergy() * character.settings.customEnergyPercent1);
				energyInput.text = num2.ToString();
				character.input.validateInput();
				break;
			case 6:
				num2 = Convert.ToInt64((float)character.totalCapEnergy() * character.settings.customEnergyPercent2);
				energyInput.text = num2.ToString();
				character.input.validateInput();
				break;
			case 7:
				num2 = Convert.ToInt64((float)character.totalCapMagic() * character.settings.customMagicPercent1);
				energyInput.text = num2.ToString();
				character.input.validateInput();
				break;
			case 8:
				num2 = Convert.ToInt64((float)character.totalCapMagic() * character.settings.customMagicPercent2);
				energyInput.text = num2.ToString();
				character.input.validateInput();
				break;
			case 11:
				num2 = Convert.ToInt64((float)character.totalCapRes3() * character.settings.customRes3Percent1);
				energyInput.text = num2.ToString();
				character.input.validateInput();
				break;
			case 12:
				num2 = Convert.ToInt64((float)character.totalCapRes3() * character.settings.customRes3Percent2);
				energyInput.text = num2.ToString();
				character.input.validateInput();
				break;
			case 9:
			case 10:
				break;
			}
		}
		else
		{
			tooltip.showTooltip("You must purchase the ability to use this button in 4G's Sellout Shop!", 2f);
		}
	}

	public void customPercentIdleClick()
	{
		if ((id == 9 && character.purchases.hasCustomIdleEnergyPercent1) || (id == 10 && character.purchases.hasCustomIdleMagicPercent1) || (id == 13 && character.purchases.hasCustomIdleRes3Percent1))
		{
			if (Input.GetKey("left shift") || Input.GetKey("right shift"))
			{
				float num = (float)character.input.energyMagicInput / 100f;
				if (num < 0.01f)
				{
					num = 0.01f;
				}
				if (num > 1f)
				{
					num = 1f;
				}
				switch (id)
				{
				case 9:
					character.settings.customIdleEnergyPercent1 = num;
					break;
				case 10:
					character.settings.customIdleMagicPercent1 = num;
					break;
				case 13:
					character.settings.customIdleRes3Percent1 = num;
					break;
				}
				updateButtons();
			}
			else
			{
				long num2 = 0L;
				switch (id)
				{
				case 9:
					num2 = Convert.ToInt64((float)character.idleEnergy * character.settings.customIdleEnergyPercent1);
					energyInput.text = num2.ToString();
					character.input.validateInput();
					break;
				case 10:
					num2 = Convert.ToInt64((float)character.magic.idleMagic * character.settings.customIdleMagicPercent1);
					energyInput.text = num2.ToString();
					character.input.validateInput();
					break;
				case 13:
					num2 = Convert.ToInt64((float)character.res3.idleRes3 * character.settings.customIdleRes3Percent1);
					energyInput.text = num2.ToString();
					character.input.validateInput();
					break;
				}
				updateButtons();
			}
		}
		else
		{
			tooltip.showTooltip("You must purchase the ability to use this button in 4G's Sellout Shop!", 2f);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (id == 9 || id == 10 || id == 13)
		{
			tooltip.showTooltip("These buttons work like the other custom buttons, but they output a % of your idle Energy or Magic. For example, enter 20 in the input box and shift+click this button, and it now acts as a '20 % of Cap' button! Set any % from 1-100!");
		}
		else if (id == 5 || id == 6 || id == 7 || id == 8 || id == 11 || id == 12)
		{
			tooltip.showTooltip("These buttons work like the other custom buttons, but they output a % of your total Cap. For example, enter 20 in the input box and shift+click this button, and it now acts as a '20 % of Cap' button! Set any % from 1-100!");
		}
		else
		{
			tooltip.showTooltip("If purchased, you can use this button to set a custom amount in the Input box. Clicking the button will put its numerical value into the Input box, while holding SHIFT+click sets the button's number to the value of the Input box!");
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		switch (id)
		{
		case 1:
			customEnergy1Click();
			break;
		case 2:
			customEnergy2Click();
			break;
		case 3:
			customMagic1Click();
			break;
		case 4:
			customMagic2Click();
			break;
		case 5:
			customPercentClick();
			break;
		case 6:
			customPercentClick();
			break;
		case 7:
			customPercentClick();
			break;
		case 8:
			customPercentClick();
			break;
		case 9:
			customPercentIdleClick();
			break;
		case 10:
			customPercentIdleClick();
			break;
		case 11:
			customPercentClick();
			break;
		case 12:
			customPercentClick();
			break;
		case 13:
			customPercentIdleClick();
			break;
		}
	}
}
