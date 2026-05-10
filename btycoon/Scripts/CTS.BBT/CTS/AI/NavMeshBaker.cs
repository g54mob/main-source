using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.AI
{
	[DefaultExecutionOrder(-10)]
	public sealed class NavMeshBaker : MonoBehaviour
	{
		private List<NavMeshRoom> _rooms = new List<NavMeshRoom>();

		[SerializeField]
		private Transform _wallsAnchor;

		[SerializeField]
		private bool _debug;

		private static List<NavMeshRoom> Rooms;

		private void Awake()
		{
			_rooms = GetComponentsInChildren<NavMeshRoom>().ToList();
			Rooms = Object.FindObjectsOfType<NavMeshRoom>().ToList();
			RepaintAllDirtyRooms();
		}

		[Button(null, EButtonEnableMode.Always)]
		public static void RepaintAllNavmesh()
		{
			_ = Time.realtimeSinceStartupAsDouble;
			foreach (NavMeshRoom room in Rooms)
			{
				room.BakeSurface();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void RepaintAllDirtyRooms()
		{
			_ = Time.realtimeSinceStartupAsDouble;
			foreach (NavMeshRoom room in _rooms)
			{
				if (room.IsDirty)
				{
					RepaintRoom(room);
				}
			}
			_wallsAnchor.SetParent(null);
		}

		private void RepaintRoom(NavMeshRoom p_room)
		{
			_wallsAnchor.SetParent(p_room.transform);
			p_room.BakeSurface();
		}
	}
}
