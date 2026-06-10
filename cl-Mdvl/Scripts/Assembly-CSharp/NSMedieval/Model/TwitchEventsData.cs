using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.GameEventSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class TwitchEventsData : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private InterpolatedValueList interpolatedValues;

		[SerializeField]
		private List<SerializablePair<string, float>> animalTypeChances;

		public override string GetID()
		{
			return id;
		}

		public float GetInterpolatedValue(int value)
		{
			return interpolatedValues.GetMultiplierInterpolated(value);
		}

		public AnimalType GetRandomAnimalType()
		{
			float maxInclusive = animalTypeChances.Sum((SerializablePair<string, float> serializablePair) => serializablePair.Value);
			float num = UnityEngine.Random.Range(0f, maxInclusive);
			foreach (SerializablePair<string, float> animalTypeChance in animalTypeChances)
			{
				if (Enum.TryParse<AnimalType>(animalTypeChance.Key, ignoreCase: true, out var result))
				{
					if (num <= animalTypeChance.Value)
					{
						return result;
					}
					num -= animalTypeChance.Value;
				}
			}
			return AnimalType.WildAggressive;
		}
	}
}
