using System.Collections.Generic;
using UnityEngine;

public class TooltipComponent_goldenCoinsChest : TooltipComponent
{
	protected override Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object> { 
		{
			"chest",
			GetComponent<GoldenCoinsChest>()
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
