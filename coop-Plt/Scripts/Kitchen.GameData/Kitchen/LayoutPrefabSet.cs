using System;
using System.Collections.Generic;
using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	[CreateAssetMenu(fileName = "LayoutPrefabSet", menuName = "Kitchen/Layout Prefab Set", order = 1)]
	public class LayoutPrefabSet : KitchenObject
	{
		[Serializable]
		public struct MaterialType
		{
			public RoomType Room;

			public LayoutMaterialType Type;
		}

		public GameObject WallPrefab;

		public GameObject ShortWallPrefab;

		public GameObject HatchPrefab;

		public GameObject FloorPrefab;

		public GameObject KitchenFloorPrefab;

		public GameObject OutsideFloorPrefab;

		public GameObject DoorPrefab;

		public GameObject DoorPrefabReversed;

		public GameObject ExternalDoorPrefab;

		public GameObject WindowPrefab;

		public GameObject KitchenWindowPrefab;

		public GameObject LegalDoorPrefab;

		public GameObject OfficeDoorPrefab;

		public GameObject TrophyDoorPrefab;

		public GameObject EmployeesOnlyDoorPrefab;

		public GameObject LightDoorPrefab;

		public GameObject MissingDoorPrefab;

		public GameObject FencePrefab;

		public Material DefaultWall;

		public Material DefaultFloor;

		public Material KitchenFloor;

		public Dictionary<MaterialType, Material> Materials;
	}
}
