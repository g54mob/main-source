using System;

namespace CTS
{
	[Serializable]
	public struct MaeveSaveData
	{
		public int[] buyed;

		public int[] daysBeforeReuse;

		public int maeveProtectionPastDay;

		public float discountMultiplier;
	}
}
