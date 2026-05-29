using CTS.Core;

namespace ES3Types
{
	public struct RoomSave
	{
		public int FloorIndex;

		public int RoomIndex;

		public RoomSave(RoomBuilding room)
		{
			RoomIndex = room.RoomIndex;
			FloorIndex = MonoSingleton<BuildingRoomsContainerManager>.Instance.GetContainerIndex(room.Container);
		}
	}
}
