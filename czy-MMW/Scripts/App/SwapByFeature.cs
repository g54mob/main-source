using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SwapByFeature<UnderlyingType>
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

	public static explicit operator UnderlyingType(SwapByFeature<UnderlyingType> swapByFeature)
	{
		if (swapByFeature.priorityOrder.Count > 0)
		{
			foreach (PerFeatureToggle item in swapByFeature.priorityOrder)
			{
				if (FeatureToggle.IsDynamicFeatureEnabled(item.ifFeatureIsEnabledEnum))
				{
					return item.useThisValue;
				}
			}
		}
		return swapByFeature.defaultValue;
	}

	public SwapByFeature<UnderlyingType> SetValueToCurrentFeature(UnderlyingType newValue)
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
