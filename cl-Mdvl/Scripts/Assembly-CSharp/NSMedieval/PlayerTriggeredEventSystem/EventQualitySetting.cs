using System;
using System.Linq;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[Serializable]
	public class EventQualitySetting : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private BasePair<float, float>[] eventQualityThresholds;

		public BasePair<float, float>[] EventQualityThresholds => eventQualityThresholds;

		public LocKeys[] LocKeys => locKeys;

		public override string GetID()
		{
			return id;
		}

		public float GetThresholdValue(float threshold)
		{
			BasePair<float, float>[] array = eventQualityThresholds;
			foreach (BasePair<float, float> basePair in array)
			{
				if (threshold <= basePair.Key)
				{
					return basePair.Value;
				}
			}
			return eventQualityThresholds.LastOrDefault().Value;
		}

		public float GetMaxThreshold()
		{
			float num = 0f;
			BasePair<float, float>[] array = eventQualityThresholds;
			foreach (BasePair<float, float> basePair in array)
			{
				if (basePair.Key > num)
				{
					num = basePair.Key;
				}
			}
			return num;
		}
	}
}
