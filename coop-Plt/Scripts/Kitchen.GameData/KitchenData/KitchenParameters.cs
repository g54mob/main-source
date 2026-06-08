using System;
using UnityEngine;

namespace KitchenData
{
	[Serializable]
	public struct KitchenParameters
	{
		public float CustomersPerHour;

		public float CustomersPerHourReduction;

		public int MinimumGroupSize;

		public int MaximumGroupSize;

		public int CurrentCourses;

		public static KitchenParameters Defaults => new KitchenParameters
		{
			CustomersPerHour = 1f,
			CustomersPerHourReduction = 0f,
			MaximumGroupSize = 2,
			MinimumGroupSize = 1,
			CurrentCourses = 1
		};

		public KitchenParameters Add(KitchenParameters other)
		{
			KitchenParameters result = new KitchenParameters
			{
				CustomersPerHour = CustomersPerHour + other.CustomersPerHour,
				CustomersPerHourReduction = CustomersPerHourReduction + other.CustomersPerHourReduction,
				MinimumGroupSize = MinimumGroupSize + other.MinimumGroupSize,
				MaximumGroupSize = MaximumGroupSize + other.MaximumGroupSize,
				CurrentCourses = Mathf.Max(CurrentCourses, other.CurrentCourses)
			};
			result.MinimumGroupSize = Mathf.Max(1, result.MinimumGroupSize);
			result.MaximumGroupSize = Mathf.Max(result.MaximumGroupSize, result.MinimumGroupSize);
			return result;
		}

		public override int GetHashCode()
		{
			return (((((((CustomersPerHour.GetHashCode() * 397) ^ CustomersPerHourReduction.GetHashCode()) * 397) ^ MinimumGroupSize.GetHashCode()) * 397) ^ MaximumGroupSize.GetHashCode()) * 397) ^ CurrentCourses.GetHashCode();
		}
	}
}
