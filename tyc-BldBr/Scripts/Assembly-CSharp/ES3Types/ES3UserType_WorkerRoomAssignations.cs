using System.Collections.Generic;
using CTS;
using CTS.Core;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_WorkerRoomAssignations : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerRoomAssignations()
			: base(typeof(RoomAssignations))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			RoomAssignations obj2 = (RoomAssignations)obj;
			List<int> list = new List<int>();
			foreach (RoomBuilding assignedRoom in obj2.AssignedRooms)
			{
				list.Add(assignedRoom.RoomIndex);
			}
			writer.WriteProperty("AssignedRooms", list);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			RoomAssignations objectContainingField = (RoomAssignations)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "AssignedRooms")
				{
					List<int> list = reader.Read<List<int>>();
					HashSet<RoomBuilding> hashSet = new HashSet<RoomBuilding>();
					foreach (int item in list)
					{
						hashSet.Add(MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers[0].GetRoomByIndex(item));
					}
					reader.SetPrivateField("_assignedRooms", hashSet, objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
