using System;
using UnityEngine;

[Serializable]
public class Choice
{
	public bool disabledInThisMode;

	public string name = "<nameHere>";

	[TextArea]
	public string tooltip = "<tooltipHere>";

	public Sprite icon;

	public EquippableBuildingUpgrade requiresUnlocked;

	public bool CanBePicked
	{
		get
		{
			if (!LevelProgressManager.instance.AreAllBuildOptionsUnlockedInThisLevel())
			{
				if (!(requiresUnlocked == null))
				{
					return requiresUnlocked.IsUnlocked;
				}
				return true;
			}
			return true;
		}
	}

	public Choice(string _name, string _tooltip, Sprite _icon = null)
	{
		name = _name;
		tooltip = _tooltip;
		icon = null;
	}
}
