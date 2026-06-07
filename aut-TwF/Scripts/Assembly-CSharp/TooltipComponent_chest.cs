using System.Collections.Generic;
using UnityEngine;

public class TooltipComponent_chest : TooltipComponent
{
	protected override Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object> { 
		{
			"chest",
			GetComponent<Chest>()
		} };
	}

	public override void ShowTooltip(Transform parentTransform)
	{
		if (SettingsController.instance.AutoLootChests)
		{
			base.ShowTooltip(parentTransform);
		}
	}
}
