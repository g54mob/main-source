using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnergyInputController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public InputField energyRequested;

	public CustomButton1Controller energy1;

	public CustomButton1Controller energy2;

	public CustomButton1Controller magic1;

	public CustomButton1Controller magic2;

	public CustomButton1Controller energyPercent1;

	public CustomButton1Controller energyPercent2;

	public CustomButton1Controller magicPercent1;

	public CustomButton1Controller magicPercent2;

	public CustomButton1Controller res3Percent1;

	public CustomButton1Controller res3Percent2;

	public CustomButton1Controller energyIdlePercent1;

	public CustomButton1Controller magicIdlePercent1;

	public CustomButton1Controller res3IdlePercent1;

	public long energyMagicInput = 500L;

	public void halfIdleEnergy()
	{
		long num = (long)Math.Ceiling((double)character.idleEnergy / 2.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void quarterIdleEnergy()
	{
		long num = (long)Math.Ceiling((double)character.idleEnergy / 4.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void halfTotalEnergy()
	{
		long num = (long)Math.Ceiling((double)character.totalCapEnergy() / 2.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void quarterTotalEnergy()
	{
		long num = (long)Math.Ceiling((double)character.totalCapEnergy() / 4.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void maxEnergy()
	{
		long num = (long)Math.Ceiling((double)character.totalCapEnergy());
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void halfIdleMagic()
	{
		long num = (long)Math.Ceiling((double)character.magic.idleMagic / 2.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void quarterIdleMagic()
	{
		long num = (long)Math.Ceiling((double)character.magic.idleMagic / 4.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void halfTotalMagic()
	{
		long num = (long)Math.Ceiling((double)character.totalCapMagic() / 2.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void quarterTotalMagic()
	{
		long num = (long)Math.Ceiling((double)character.totalCapMagic() / 4.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void maxMagic()
	{
		long num = (long)Math.Ceiling((double)character.totalCapMagic());
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void halfIdleRes3()
	{
		long num = (long)Math.Ceiling((double)character.res3.idleRes3 / 2.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void quarterIdleRes3()
	{
		long num = (long)Math.Ceiling((double)character.res3.idleRes3 / 4.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void halfTotalRes3()
	{
		long num = (long)Math.Ceiling((double)character.totalCapRes3() / 2.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void quarterTotalRes3()
	{
		long num = (long)Math.Ceiling((double)character.totalCapRes3() / 4.0);
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void maxRes3()
	{
		long num = (long)Math.Ceiling((double)character.totalCapRes3());
		energyRequested.text = num.ToString();
		validateInput();
	}

	public void validateInput()
	{
		try
		{
			string text = energyRequested.text.ToLower();
			text = text.Replace("uadrillion", "").Replace("rillion", "").Replace("illion", "");
			double num = 1.0;
			if (text.EndsWith("k"))
			{
				num = 1000.0;
			}
			else if (text.EndsWith("m"))
			{
				num = 1000000.0;
			}
			else if (text.EndsWith("b"))
			{
				num = 1000000000.0;
			}
			else if (text.EndsWith("t"))
			{
				num = 1000000000000.0;
			}
			else if (text.EndsWith("q"))
			{
				num = 1000000000000000.0;
			}
			string[] array = Regex.Split(text, "\\+");
			text = ((array.Length > 1) ? array[0] : text);
			text = Regex.Replace("0" + text, "[^0-9.]", "");
			if (text.Split('.').Length - 1 > 1)
			{
				int num2 = text.Length - text.LastIndexOf(".");
				text = text.Replace(".", "");
				text = text.Insert(text.Length + 1 - num2, ".");
			}
			double num3 = double.Parse(text) * num;
			if (array.Length > 1 && array[1].Length > 0)
			{
				array[1] = Regex.Replace("0" + array[1], "[^0-9]", "");
				num3 *= Math.Pow(10.0, Math.Min(308.0, double.Parse(array[1])));
			}
			if (num3 <= 0.0)
			{
				num3 = 1.0;
			}
			energyMagicInput = ((num3 <= 9.223372036854776E+18) ? ((long)num3) : 1);
			character.settings.inputAmount = energyMagicInput;
			energyRequested.text = character.display(energyMagicInput);
		}
		catch (Exception message)
		{
			energyMagicInput = 1L;
			character.settings.inputAmount = 1L;
			energyRequested.text = character.display(energyMagicInput);
			Debug.Log(message);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("Whenever you click a '+' button to assign Energy or Magic to something, you'll attempt to add this much. Simple.");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public void updateMenu()
	{
		energyMagicInput = character.settings.inputAmount;
		energyRequested.text = energyMagicInput.ToString();
		validateInput();
		energy1.updateButtons();
		energy2.updateButtons();
		magic1.updateButtons();
		magic2.updateButtons();
		energyPercent1.updateButtons();
		energyPercent2.updateButtons();
		magicPercent1.updateButtons();
		magicPercent2.updateButtons();
		res3Percent1.updateButtons();
		res3Percent2.updateButtons();
		energyIdlePercent1.updateButtons();
		magicIdlePercent1.updateButtons();
		res3IdlePercent1.updateButtons();
	}
}
