using System;
using System.Collections.Generic;
using Motorways;
using UnityEngine;

[Serializable]
public class SwapByFeature_CityTilemap
{
	[Serializable]
	public class PerFeatureToggle
	{
		[SerializeField]
		[StringEnumSearch(typeof(Feature))]
		public string ifFeatureIsEnabled;

		private string lastFeatureConversionValue;

		private Feature convertedToFeature;

		[SerializeField]
		public CityTilemap useThisValue;

		public Feature ifFeatureIsEnabledEnum
		{
			get
			{
				if (ifFeatureIsEnabled != lastFeatureConversionValue)
				{
					lastFeatureConversionValue = ifFeatureIsEnabled;
					if (!Enum.TryParse<Feature>(lastFeatureConversionValue, out convertedToFeature))
					{
						convertedToFeature = Feature.NotSelected;
					}
				}
				return convertedToFeature;
			}
		}
	}

	[SerializeField]
	public List<PerFeatureToggle> priorityOrder = new List<PerFeatureToggle>();

	[SerializeField]
	public CityTilemap defaultValue;

	private int lastChosenIndex = -2;

	public static explicit operator CityTilemap(SwapByFeature_CityTilemap swapByFeature)
	{
		CityTilemap useThisValue = swapByFeature.defaultValue;
		int num = -1;
		if (swapByFeature.priorityOrder.Count > 0)
		{
			for (int i = 0; i < swapByFeature.priorityOrder.Count; i++)
			{
				PerFeatureToggle perFeatureToggle = swapByFeature.priorityOrder[i];
				if (num == -1 && FeatureToggle.IsDynamicFeatureEnabled(perFeatureToggle.ifFeatureIsEnabledEnum))
				{
					useThisValue = perFeatureToggle.useThisValue;
					num = i;
					break;
				}
			}
		}
		if (num != swapByFeature.lastChosenIndex)
		{
			if (num != -1)
			{
				swapByFeature.defaultValue.OnNotChosen();
			}
			for (int j = 0; j < swapByFeature.priorityOrder.Count; j++)
			{
				if (j != num)
				{
					swapByFeature.priorityOrder[j].useThisValue.OnNotChosen();
				}
			}
			useThisValue?.OnChosen();
			swapByFeature.lastChosenIndex = num;
		}
		return useThisValue;
	}

	public SwapByFeature_CityTilemap SetValueToCurrentFeature(CityTilemap newValue)
	{
		if (priorityOrder.Count > 0)
		{
			foreach (PerFeatureToggle item in priorityOrder)
			{
				if (FeatureToggle.IsDynamicFeatureEnabled(item.ifFeatureIsEnabledEnum))
				{
					item.useThisValue = newValue;
				}
			}
		}
		defaultValue = newValue;
		return this;
	}

	public void MigrateData(CityTilemap oldField)
	{
		defaultValue = oldField;
	}
}
