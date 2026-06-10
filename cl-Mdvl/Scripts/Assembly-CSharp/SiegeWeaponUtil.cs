using System.Collections.Generic;
using NSMedieval.BuildingComponents;
using UnityEngine;

public static class SiegeWeaponUtil
{
	public static bool IsTargetTooClose(float minRange, Vector3 siegeWeaponPosition, Vector3 targetPosition)
	{
		return Vector3.Distance(targetPosition, siegeWeaponPosition) < minRange;
	}

	public static bool IsTargetTooFar(float maxRange, Vector3 siegeWeaponPosition, Vector3 targetPosition)
	{
		return Vector3.Distance(targetPosition, siegeWeaponPosition) > maxRange;
	}

	public static bool IsTargetInRange(float minRange, float maxRange, Vector3 siegeWeaponPosition, Vector3 targetPosition)
	{
		float num = Vector3.Distance(targetPosition, siegeWeaponPosition);
		if (num >= minRange)
		{
			return num <= maxRange;
		}
		return false;
	}

	public static bool HasAmmunition(BaseBuildingInstance building)
	{
		return building.GetComponentInstance<SiegeWeaponComponentInstance>()?.HasAmmunition() ?? true;
	}

	public static KeyValuePair<float[], float[]> GetMinMaxRanges(SiegeWeaponComponentBlueprint blueprint)
	{
		int count = blueprint.RangePerLayer.Dictionary.Count;
		float[] array = new float[count];
		float[] array2 = new float[count];
		float num = blueprint.MinRangeRadius;
		float num2 = blueprint.MaxRangeRadius;
		for (int i = 1; i <= count; i++)
		{
			if (blueprint.RangePerLayer.Dictionary.TryGetValue(i, out var value))
			{
				num = (array[i - 1] = num * value);
				num2 = (array2[i - 1] = num2 * value);
			}
		}
		return new KeyValuePair<float[], float[]>(array, array2);
	}
}
