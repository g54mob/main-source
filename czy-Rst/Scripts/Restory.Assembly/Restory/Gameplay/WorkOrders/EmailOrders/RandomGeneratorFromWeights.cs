using System.Collections.Generic;
using UnityEngine;

namespace Restory.Gameplay.WorkOrders.EmailOrders
{
	public static class RandomGeneratorFromWeights
	{
		public static bool TryToGetRandomObject<T>(IEnumerable<RandomWeightObjectPair<T>> possibleObjects, out T chosenObject)
		{
			int num = 0;
			foreach (RandomWeightObjectPair<T> possibleObject in possibleObjects)
			{
				num += possibleObject.Weight;
			}
			int num2 = Random.Range(1, num + 1);
			int num3 = 0;
			foreach (RandomWeightObjectPair<T> possibleObject2 in possibleObjects)
			{
				num3 += possibleObject2.Weight;
				if (num3 >= num2)
				{
					chosenObject = possibleObject2.PossibleObject;
					return true;
				}
			}
			chosenObject = default(T);
			return false;
		}

		public static bool TryToGetRandomObject<T>(IEnumerable<T> possibleObjects, out T chosenObject) where T : IRandomnessWeightHolder
		{
			int num = 0;
			foreach (T possibleObject in possibleObjects)
			{
				num += possibleObject.Weight;
			}
			int num2 = Random.Range(1, num + 1);
			int num3 = 0;
			foreach (T possibleObject2 in possibleObjects)
			{
				num3 += possibleObject2.Weight;
				if (num3 >= num2)
				{
					chosenObject = possibleObject2;
					return true;
				}
			}
			chosenObject = default(T);
			return false;
		}
	}
}
