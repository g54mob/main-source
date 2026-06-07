using System.Collections.Generic;
using UnityEngine;

public static class AkRoomAwareManager
{
	private static readonly HashSet<AkRoomAwareObject> m_RoomAwareObjects;

	private static readonly HashSet<AkRoomAwareObject> m_RoomAwareObjectToUpdate;

	public static void RegisterRoomAwareObject(AkRoomAwareObject roomAwareObject)
	{
	}

	public static void UnregisterRoomAwareObject(AkRoomAwareObject roomAwareObject)
	{
	}

	public static void RegisterRoomAwareObjectForUpdate(AkRoomAwareObject roomAwareObject)
	{
	}

	public static void ObjectEnteredRoom(Collider collider, AkRoom room)
	{
	}

	public static void ObjectEnteredRoom(AkRoomAwareObject roomAwareObject, AkRoom room)
	{
	}

	public static void ObjectExitedRoom(Collider collider, AkRoom room)
	{
	}

	public static void ObjectExitedRoom(AkRoomAwareObject roomAwareObject, AkRoom room)
	{
	}

	public static void UpdateRoomAwareObjects()
	{
	}
}
