using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class DecayIconSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private StringFloatPair[] thresholds;

		public StringFloatPair[] Thresholds => thresholds;

		public override string GetID()
		{
			return id;
		}

		public string GetIconId(float value)
		{
			StringFloatPair[] array = thresholds;
			for (int i = 0; i < array.Length; i++)
			{
				StringFloatPair stringFloatPair = array[i];
				if (value <= stringFloatPair.Value)
				{
					return stringFloatPair.Key;
				}
			}
			return thresholds[^1].Key;
		}
	}
}
