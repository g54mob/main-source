using System.Collections.Generic;
using UnityEngine;

public class TooltipUI_snowfallInfo : TooltipUI
{
	[SerializeField]
	private UIList snowfallEffectsList;

	[SerializeField]
	private UIList flameEffectsList;

	public override void Setup(Dictionary<string, object> data)
	{
		SnowfallController obj = data["snowfallController"] as SnowfallController;
		List<SnowfallController.FSnowfallLevelInfo> list = new List<SnowfallController.FSnowfallLevelInfo>();
		List<SnowfallController.FSnowfallLevelInfo> list2 = new List<SnowfallController.FSnowfallLevelInfo>();
		SnowfallController.FSnowfallLevelInfo[] snowafallLevels = obj.SnowafallLevels;
		foreach (SnowfallController.FSnowfallLevelInfo fSnowfallLevelInfo in snowafallLevels)
		{
			if (fSnowfallLevelInfo.level > 0)
			{
				list.Add(fSnowfallLevelInfo);
			}
			else if (fSnowfallLevelInfo.level < 0)
			{
				list2.Add(fSnowfallLevelInfo);
			}
		}
		snowfallEffectsList.LoadList(list);
		flameEffectsList.LoadList(list2);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}
}
