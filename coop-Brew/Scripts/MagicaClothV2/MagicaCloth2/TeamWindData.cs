using Unity.Collections;

namespace MagicaCloth2
{
	public struct TeamWindData
	{
		public FixedList128Bytes<TeamWindInfo> windZoneList;

		public TeamWindInfo movingWind;

		public int ZoneCount => 0;

		public int IndexOf(int windId)
		{
			return 0;
		}

		public void ClearZoneList()
		{
		}

		public void AddOrReplaceWindZone(TeamWindInfo windInfo, in TeamWindData oldWindData)
		{
		}

		public void RemoveWindZone(int windId)
		{
		}

		public void CopyFrom(in TeamWindData wdata)
		{
		}
	}
}
