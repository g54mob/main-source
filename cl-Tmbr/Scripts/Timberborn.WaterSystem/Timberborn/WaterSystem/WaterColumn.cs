using System;

namespace Timberborn.WaterSystem
{
	internal struct WaterColumn
	{
		public byte Floor;

		public byte Ceiling;

		public float WaterDepth;

		public float OldWaterDepth;

		public float Contamination;

		public float Overflow;

		public WaterColumn(int floor, int ceiling)
		{
			Floor = Convert.ToByte(floor);
			Ceiling = Convert.ToByte(ceiling);
			WaterDepth = 0f;
			OldWaterDepth = 0f;
			Contamination = 0f;
			Overflow = 0f;
		}

		public void Reset()
		{
			WaterDepth = 0f;
			OldWaterDepth = 0f;
			Contamination = 0f;
			Overflow = 0f;
		}
	}
}
