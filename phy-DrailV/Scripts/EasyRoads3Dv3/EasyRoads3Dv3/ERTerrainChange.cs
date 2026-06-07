using System;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERTerrainChange
	{
		public int index;

		public int value;

		public ERTerrainChange(int v_index, int v_value)
		{
			index = v_index;
			value = v_value;
		}
	}
}
