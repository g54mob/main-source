using System.Collections.Generic;
using UnityEngine;

public class RadicalPopUpMenu : RadicalMenu
{
	public PopUpText popUpText;

	private List<MenuHelperButtons.HelpButtonTypes> noHelpButtons = new List<MenuHelperButtons.HelpButtonTypes>();

	private List<MenuHelperButtons.HelpButtonTypes> onlySelectHelpButtons = new List<MenuHelperButtons.HelpButtonTypes> { MenuHelperButtons.HelpButtonTypes.SELECT };

	private List<MenuHelperButtons.HelpButtonTypes> allHelpButtons = new List<MenuHelperButtons.HelpButtonTypes>
	{
		MenuHelperButtons.HelpButtonTypes.NAVIGATE,
		MenuHelperButtons.HelpButtonTypes.SELECT,
		MenuHelperButtons.HelpButtonTypes.BACK
	};

	public override bool UseCustomHelpButtons => true;

	public void UpdateOptionTexts(List<string> optionTexts)
	{
		if (optionTexts == null)
		{
			return;
		}
		ResetSelectedIndex();
		menuOptions.Clear();
		if (optionTexts.Count > popUpText.Options.Count)
		{
			Debug.LogWarning(string.Format("{0}.{1}: there are more requested option texts ({2}) than supported ({3}). Some of the options will not work!", "RadicalPopUpMenu", "UpdateOptionTexts", optionTexts.Count, popUpText.Options.Count));
		}
		for (int i = 0; i < popUpText.Options.Count; i++)
		{
			bool flag = i < optionTexts.Count;
			popUpText.Options[i].forceDeactive = !flag;
			popUpText.Options[i].labelText.gameObject.SetActive(flag);
			popUpText.Options[i].labelText.SetText(flag ? optionTexts[i] : "");
			if (flag)
			{
				menuOptions.Add(popUpText.Options[i]);
			}
		}
	}

	public override void Activate()
	{
		base.Activate();
		SelectOptionIndex(0);
	}

	public override void Deactivate(bool pop)
	{
		base.Deactivate(pop);
		if (!popUpText.IsOptionPressed)
		{
			popUpText.OptionPressed(value: false);
		}
	}

	public override List<MenuHelperButtons.HelpButtonTypes> GetHelpButtonsToShow()
	{
		int num = 0;
		foreach (RadicalMenuOption menuOption in menuOptions)
		{
			if (!string.IsNullOrEmpty(menuOption.labelText.GetText()))
			{
				num++;
			}
		}
		return num switch
		{
			0 => noHelpButtons, 
			1 => onlySelectHelpButtons, 
			_ => allHelpButtons, 
		};
	}
}
