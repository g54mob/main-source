using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Level Room List", order = 1115)]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LevelRoomList : BaseScriptableObject
	{
		[SerializeField]
		private SharedInstance<RoomDefinition>[] m_rooms;

		public SharedInstance<RoomDefinition>[] RoomList => m_rooms;

		public bool ContainsRoom(RoomDefinition room)
		{
			SharedInstance<RoomDefinition>[] roomList = RoomList;
			for (int i = 0; i < roomList.Length; i++)
			{
				if (roomList[i].Instance == room)
				{
					return true;
				}
			}
			return false;
		}
	}
}
