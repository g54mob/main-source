using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public static class BBTCollections
	{
		public static bool TryGetNearest<TCollection, T>(this TCollection collection, RoomObject roomObject, out T outBest, out float outBestDistance) where TCollection : IEnumerable<T> where T : class, IBBTObject
		{
			outBest = BBTCollections<T>.GetNearest(roomObject, collection, out outBestDistance);
			return outBest != null;
		}
	}
	public static class BBTCollections<T> where T : class, IBBTObject
	{
		private static float _differentRoomWeight = 3f;

		private static float _differentFloorWeight = 10f;

		public static bool TryGetNearest<TCollection>(RoomObject roomData, TCollection collection, out T outBest, out float outBestDistance) where TCollection : IEnumerable<T>
		{
			outBest = GetNearest(roomData, collection, out outBestDistance);
			return outBest != null;
		}

		public static T GetNearest<TCollection>(RoomObject roomData, TCollection collection, out float outBestDistance) where TCollection : IEnumerable<T>
		{
			Vector3 position = roomData.transform.position;
			RoomBuilding currentRoom = roomData.CurrentRoom;
			T result = null;
			outBestDistance = float.MaxValue;
			foreach (T item in collection)
			{
				Vector3 vector = item.Transform.position - position;
				RoomObject roomObject = item.RoomObject;
				if (roomObject.CurrentRoom != currentRoom)
				{
					vector *= _differentRoomWeight;
				}
				if (roomObject.CurrentFloor != currentRoom.Container)
				{
					vector *= _differentFloorWeight;
				}
				float num = Vector3.SqrMagnitude(vector);
				if (num < outBestDistance)
				{
					outBestDistance = num;
					result = item;
				}
			}
			return result;
		}
	}
}
