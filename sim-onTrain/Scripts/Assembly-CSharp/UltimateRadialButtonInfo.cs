using System;
using UnityEngine;

[Serializable]
public class UltimateRadialButtonInfo
{
	public UltimateRadialMenu.UltimateRadialButton radialButton;

	public string key;

	public int id;

	public string name;

	public string description;

	public Sprite icon;

	public int GetButtonIndex
	{
		get
		{
			if (RadialButtonError)
			{
				return 0;
			}
			return radialButton.buttonIndex;
		}
	}

	public bool IsSelected
	{
		get
		{
			if (RadialButtonError)
			{
				return false;
			}
			return radialButton.Selected;
		}
	}

	private bool RadialButtonError
	{
		get
		{
			if (radialButton == null || radialButton.radialMenu == null)
			{
				Debug.LogWarning("Ultimate Radial Button\nNo Radial Menu Button component has been assigned to this Ultimate Radial Button. Have you initialized a new Radial Menu Button using the AddRadialMenuButtonAtIndex function?");
				return true;
			}
			return false;
		}
	}

	public void UpdateText(string newText)
	{
		if (!RadialButtonError)
		{
			if (radialButton.text == null)
			{
				Debug.LogWarning("Ultimate Radial Button\nThe radial button's text component is not assigned. Please make sure that the radial button is using text and has a text component assigned.");
			}
			else
			{
				radialButton.text.text = newText;
			}
		}
	}

	public void UpdateIcon(Sprite newIcon)
	{
		icon = newIcon;
		if (!RadialButtonError)
		{
			if (radialButton.icon == null)
			{
				Debug.LogWarning("Ultimate Radial Button\nThe radial button's icon image component is not assigned. Please make sure that the radial button is using an icon and has a image component assigned.");
				return;
			}
			radialButton.icon.sprite = newIcon;
			radialButton.icon.color = radialButton.radialMenu.iconNormalColor;
		}
	}

	public void UpdateName(string newName)
	{
		name = newName;
		if (!RadialButtonError)
		{
			radialButton.name = name;
			if (radialButton.radialMenu.displayNameOnButton && radialButton.text != null)
			{
				radialButton.text.text = name;
			}
		}
	}

	public void UpdateDescription(string newDescription)
	{
		description = newDescription;
		if (!RadialButtonError)
		{
			radialButton.description = description;
		}
	}

	public void EnableButton()
	{
		if (!RadialButtonError)
		{
			radialButton.EnableButton();
		}
	}

	public void DisableButton()
	{
		if (!RadialButtonError)
		{
			radialButton.DisableButton();
		}
	}

	public void SelectButton()
	{
		if (!RadialButtonError)
		{
			radialButton.OnSelect();
		}
	}

	public void DeselectButton()
	{
		if (!RadialButtonError)
		{
			radialButton.OnDeselect();
		}
	}

	public void RemoveRadialButton()
	{
		if (!RadialButtonError)
		{
			radialButton.radialMenu.RemoveRadialButton(radialButton.buttonIndex);
			radialButton = null;
		}
	}

	public bool ExistsOnRadialMenu()
	{
		if (radialButton != null && radialButton.radialMenu != null)
		{
			return true;
		}
		return false;
	}

	public void RemoveInfoFromRadialButton()
	{
		if (!RadialButtonError)
		{
			radialButton.ClearButtonInformation();
			radialButton = null;
		}
	}

	public void OnClearButtonInformation()
	{
		radialButton = null;
	}
}
