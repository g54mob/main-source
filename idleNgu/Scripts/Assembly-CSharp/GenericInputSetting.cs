using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenericInputSetting : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public InputField input;

	public int id;

	public string tooltipMessage;

	private bool state;

	private void Start()
	{
		updateInputText();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip(tooltipMessage);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public void updateInputText()
	{
		switch (id)
		{
		case 0:
			if (!character.arbitrary.hasNGUCapModifier)
			{
				base.gameObject.SetActive(value: false);
				break;
			}
			base.gameObject.SetActive(value: true);
			input.text = (character.settings.nguCapModifier * 100f).ToString("###.#") + "%";
			break;
		case 1:
			if (character.res3.capRes3 < 10000)
			{
				base.gameObject.SetActive(value: false);
				break;
			}
			base.gameObject.SetActive(value: true);
			input.text = character.res3.res3Name;
			break;
		}
	}

	public void parseNewValue()
	{
		switch (id)
		{
		case 0:
			parseNGUInput();
			break;
		case 1:
			parseRes3NameInput();
			break;
		}
	}

	public void parseNGUInput()
	{
		if (!character.arbitrary.hasNGUCapModifier)
		{
			tooltip.showOverrideTooltip("You need to purchase the NGU Cap Modifier in the Sellout Shop to modify this setting!", 2f);
			updateInputText();
			return;
		}
		if (input.text == "")
		{
			input.text = "100";
		}
		string text = input.text.ToLower();
		text = Regex.Replace(text, "[^0-9.]", "");
		text = text.Replace("%", "");
		if (text == "")
		{
			text = "100";
		}
		float num = 100f;
		try
		{
			num = float.Parse(text);
		}
		catch (Exception)
		{
			num = 100f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		if (num > 200f)
		{
			num = 200f;
		}
		num = (float)Math.Round(num, 1);
		character.settings.nguCapModifier = num / 100f;
		updateInputText();
	}

	public void parseRes3NameInput()
	{
		if (character.res3.capRes3 < 10000)
		{
			tooltip.showOverrideTooltip("You can't change the name of something you don't have yet!", 2f);
			updateInputText();
			return;
		}
		if (input.text == "")
		{
			input.text = "Butt";
		}
		string text = input.text;
		text = Regex.Replace(text, "[^a-zA-Z ]", "");
		if (text == "")
		{
			text = "Butt";
		}
		character.res3.res3Name = text;
		updateInputText();
	}
}
