using System;
using System.Collections.Generic;
using I2.Loc;
using Kamgam.UGUIComponentsForSettings;
using TMPro;
using UnityEngine;

public class CustomizationOptionUI : MonoBehaviour
{
	[Header("References")]
	public TextMeshProUGUI labelText;

	public OptionsButtonUGUI optionsButton;

	public void Setup(string i2Key, int count, int currentValue, OptionsButtonUGUI.OnValueChangedDelegate onChange)
	{
		if (labelText != null)
		{
			string translation = LocalizationManager.GetTranslation(i2Key);
			labelText.text = ((!string.IsNullOrEmpty(translation)) ? translation : i2Key);
		}
		if (count <= 0)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		base.gameObject.SetActive(value: true);
		if (!(optionsButton == null))
		{
			optionsButton.SetOptions(BuildNumberOptions(count));
			int selectedIndex = Mathf.Clamp(currentValue, 0, count - 1);
			optionsButton.SelectedIndex = selectedIndex;
			OptionsButtonUGUI optionsButtonUGUI = optionsButton;
			optionsButtonUGUI.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Combine(optionsButtonUGUI.OnValueChanged, onChange);
		}
	}

	public void Refresh(int newCount, OptionsButtonUGUI.OnValueChangedDelegate onChange)
	{
		Refresh(newCount, 0, onChange);
	}

	public void Refresh(int newCount, int currentValue, OptionsButtonUGUI.OnValueChangedDelegate onChange)
	{
		if (!(optionsButton == null))
		{
			optionsButton.OnValueChanged = null;
			if (newCount <= 0)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			base.gameObject.SetActive(value: true);
			optionsButton.SetOptions(BuildNumberOptions(newCount));
			int selectedIndex = Mathf.Clamp(currentValue, 0, newCount - 1);
			optionsButton.SelectedIndex = selectedIndex;
			OptionsButtonUGUI optionsButtonUGUI = optionsButton;
			optionsButtonUGUI.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Combine(optionsButtonUGUI.OnValueChanged, onChange);
		}
	}

	private static List<string> BuildNumberOptions(int count)
	{
		List<string> list = new List<string>(count);
		for (int i = 0; i < count; i++)
		{
			list.Add((i + 1).ToString());
		}
		return list;
	}
}
