using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

public class UI_MergePanel : MonoBehaviour
{
	[SerializeField]
	private RoomBuilding _roomA;

	[SerializeField]
	private RoomBuilding _roomB;

	private void Start()
	{
		_roomA = null;
		_roomB = null;
	}

	private void OnDestroy()
	{
	}

	private void RemoveRoomA()
	{
		_roomA = null;
	}

	private void RemoveRoomB()
	{
		_roomB = null;
	}

	[Button(null, EButtonEnableMode.Always)]
	private void MergeRoom()
	{
		if (MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentRoomManager.MergeRoom(_roomA.RoomIndex, _roomB.RoomIndex))
		{
			RemoveRoomA();
			RemoveRoomB();
			MonoSingleton<ConstructionSystem>.Instance.CurrentGrid?.Refresh();
		}
	}
}
