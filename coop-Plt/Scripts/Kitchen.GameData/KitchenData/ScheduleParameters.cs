using System;
using Unity.Collections;

namespace KitchenData
{
	[Serializable]
	public struct ScheduleParameters
	{
		public bool IsPracticeMode;

		public int Day;

		public int Players;

		public KitchenParameters Parameters;

		public float CustomersPerHour;

		public float CustomersPerHourIncrease;

		public DataObjectList Status;

		public FixedListInt128 TypeValues;

		public FixedListFloat128 TypeProbabilities;

		public int MaxTableSize;

		public override int GetHashCode()
		{
			return (((((((((((((((((Day * 397) ^ IsPracticeMode.GetHashCode()) * 397) ^ Players) * 397) ^ Parameters.GetHashCode()) * 397) ^ CustomersPerHour.GetHashCode()) * 397) ^ CustomersPerHourIncrease.GetHashCode()) * 397) ^ Status.GetHashCode()) * 397) ^ TypeValues.GetHashCode()) * 397) ^ TypeProbabilities.GetHashCode()) * 397) ^ MaxTableSize.GetHashCode();
		}

		public bool HasStatus(RestaurantStatus status)
		{
			return Status.Contains((int)status);
		}
	}
}
