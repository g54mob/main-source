using System;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public struct TerrainSourceRule
	{
		public bool UseTerrainSourceID1;

		public bool UseTerrainSourceID2;

		public bool UseTerrainSourceID3;

		public bool UseTerrainSourceID4;

		public bool UseTerrainSourceID5;

		public bool UseTerrainSourceID6;

		public bool UseTerrainSourceID7;

		public bool UseTerrainSourceID8;

		public bool this[int index]
		{
			get
			{
				return UseTerrainSource(index);
			}
			set
			{
				SetUseTerrainSource(index, value);
			}
		}

		public void SetUseTerrainSource(int index, bool value)
		{
			switch (index)
			{
			case 0:
				UseTerrainSourceID1 = value;
				break;
			case 1:
				UseTerrainSourceID2 = value;
				break;
			case 2:
				UseTerrainSourceID3 = value;
				break;
			case 3:
				UseTerrainSourceID4 = value;
				break;
			case 4:
				UseTerrainSourceID5 = value;
				break;
			case 5:
				UseTerrainSourceID6 = value;
				break;
			case 6:
				UseTerrainSourceID7 = value;
				break;
			case 7:
				UseTerrainSourceID8 = value;
				break;
			}
		}

		public bool UseTerrainSource(int index)
		{
			switch (index)
			{
			case 0:
				return UseTerrainSourceID1;
			case 1:
				return UseTerrainSourceID2;
			case 2:
				return UseTerrainSourceID3;
			case 3:
				return UseTerrainSourceID4;
			case 4:
				return UseTerrainSourceID5;
			case 5:
				return UseTerrainSourceID6;
			case 6:
				return UseTerrainSourceID7;
			case 7:
				return UseTerrainSourceID8;
			default:
				return false;
			}
		}
	}
}
