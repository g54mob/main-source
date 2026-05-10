using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TooltipUI_snowfallInfo_effectUI : UIListElement
{
	[Serializable]
	private struct FSnowfallLevelColor
	{
		public int level;

		public Color color;
	}

	[SerializeField]
	private UIList geList;

	[SerializeField]
	private TextMeshProUGUI temperatureText;

	[SerializeField]
	private FSnowfallLevelColor[] levelColors;

	public override void LoadData()
	{
		SnowfallController.FSnowfallLevelInfo snowfallEffectData = (SnowfallController.FSnowfallLevelInfo)base.Data;
		temperatureText.text = (snowfallEffectData.level * -1).ToString() ?? "";
		temperatureText.color = levelColors.First((FSnowfallLevelColor x) => x.level == snowfallEffectData.level).color;
		List<SnowfallEffectUI.FSnowfallEffectUIData> list = new List<SnowfallEffectUI.FSnowfallEffectUIData>();
		GameplayEffectData[] gEToApply = snowfallEffectData.GEToApply;
		for (int num = 0; num < gEToApply.Length; num++)
		{
			GameplayEffectData[] effectsToApply = (gEToApply[num] as GE_GiveEffectToBuildingData).EffectsToApply;
			foreach (GameplayEffectData geData in effectsToApply)
			{
				list.Add(new SnowfallEffectUI.FSnowfallEffectUIData(geData, snowfallEffectData.level < 0));
			}
		}
		geList.LoadList(list);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}
}
