using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Setting", menuName = "Settings")]
public class Setting : ScriptableObject
{
	public enum CycleDirection
	{
		Left = 0,
		Right = 1
	}

	public string settingID;

	public SettingOption currentOption;

	public List<SettingOption> settingOptions;

	public void CycleSettingOption(CycleDirection cycleDirection)
	{
		int num = settingOptions.IndexOf(currentOption);
		switch (cycleDirection)
		{
		case CycleDirection.Left:
			if (num > 0)
			{
				currentOption = settingOptions[num - 1];
			}
			else
			{
				currentOption = settingOptions[settingOptions.Count - 1];
			}
			break;
		case CycleDirection.Right:
			if (num < settingOptions.Count - 1)
			{
				currentOption = settingOptions[num + 1];
			}
			else
			{
				currentOption = settingOptions[0];
			}
			break;
		}
	}
}
