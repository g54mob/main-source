using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SwapByFeatureWithObserver<UnderlyingType> where UnderlyingType : IFeatureSwapObserver
{
	[Serializable]
	public class PerFeatureToggle
	{
		[StringEnumSearch(typeof(Feature))]
		[SerializeField]
		public string ifFeatureIsEnabled;

		private string lastFeatureConversionValue;

		private Feature convertedToFeature;

		[SerializeField]
		public UnderlyingType useThisValue;

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
	public UnderlyingType defaultValue;

	private int lastChosenIndex = -2;

	public static explicit operator UnderlyingType(SwapByFeatureWithObserver<UnderlyingType> swapByFeature)
	{
		UnderlyingType useThisValue = swapByFeature.defaultValue;
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

	public SwapByFeatureWithObserver<UnderlyingType> SetValueToCurrentFeature(UnderlyingType newValue)
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

	public void MigrateData(UnderlyingType oldField)
	{
		defaultValue = oldField;
	}
}
