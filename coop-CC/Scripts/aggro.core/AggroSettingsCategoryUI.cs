using System;
using Aggro.Core;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AggroSettingsCategoryUI : MonoBehaviour
{
	public TextMeshProUGUI text;

	public Button button;

	public bool changeColorOnSelected;

	public Color selectedColor = Color.magenta;

	public EventReference sfxSelected;

	private Action<int> _onCategorySelected;

	private int _categoryIndex;

	private Color _origColor;

	private string _label;

	private void Awake()
	{
		_origColor = button.colors.normalColor;
	}

	public void Set(int categoryIndex, string label, Action<int> onCategorySelected)
	{
		if (AggroSettings.isLocalizing)
		{
			text.text = LocalizedText.GetText(label, printDebug: false);
		}
		else
		{
			text.text = label;
		}
		_label = label;
		_categoryIndex = categoryIndex;
		_onCategorySelected = onCategorySelected;
	}

	public void Refresh()
	{
		text.text = LocalizedText.GetText(_label, printDebug: false);
	}

	public void OnCategorySelected()
	{
		_onCategorySelected(_categoryIndex);
	}

	public void SetSelection(bool selected)
	{
		if (changeColorOnSelected)
		{
			ColorBlock colors = button.colors;
			if (selected)
			{
				colors.normalColor = selectedColor;
			}
			else
			{
				colors.normalColor = _origColor;
			}
			button.colors = colors;
		}
		if (selected)
		{
			AggroUtil.PlaySfxIfValid(sfxSelected);
		}
	}
}
