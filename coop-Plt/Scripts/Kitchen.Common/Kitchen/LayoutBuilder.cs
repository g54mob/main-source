using System.Collections.Generic;
using Kitchen.Layouts;
using Kitchen.Layouts.Features;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class LayoutBuilder
	{
		public LayoutBlueprint Blueprint;

		public Transform Parent;

		public LayoutPrefabSet Prefabs;

		public LayoutMaterialSet Materials;

		public List<Door> Doors = new List<Door>();

		public List<Wall> Walls = new List<Wall>();

		public LayoutBuilder(LayoutBlueprint blueprint, LayoutPrefabSet prefabs, Transform parent)
		{
			Blueprint = blueprint;
			Parent = parent;
			Prefabs = prefabs;
			Materials = new LayoutMaterialSet(prefabs.Materials);
			foreach (Room item in Blueprint.Rooms())
			{
				if (item.Type == RoomType.Kitchen)
				{
					Materials.Get(item, LayoutMaterialType.Floor).CopyPropertiesFromMaterial(Prefabs.KitchenFloor);
				}
			}
		}

		public void Dispose()
		{
			Materials?.Dispose();
		}

		public void SetOpenTime(bool is_open)
		{
			foreach (Door door in Doors)
			{
				if (door.MoveAtNight && door.DoorController != null)
				{
					door.DoorController.SetSpring(is_open);
				}
			}
		}

		public void SetIllusionWalls(List<(Vector3, Vector3)> illusion_walls)
		{
			foreach (Wall wall in Walls)
			{
				Vector3 vector = wall.Tile1.ToWorld();
				Vector3 vector2 = wall.Tile2.ToWorld();
				if (!wall.IsExternal)
				{
					wall.Collider.enabled = !illusion_walls.Contains((vector, vector2)) && !illusion_walls.Contains((vector2, vector));
				}
			}
			foreach (Door door in Doors)
			{
				if (!(door.DoorController == null))
				{
					Vector3 vector3 = door.Tile1.ToWorld();
					Vector3 vector4 = door.Tile2.ToWorld();
					door.DoorController.SetCollision(!illusion_walls.Contains((vector3, vector4)) && !illusion_walls.Contains((vector4, vector3)));
				}
			}
		}

		public void SetDoorRemoveSet(List<Vector3> removers)
		{
			foreach (Door door in Doors)
			{
				Vector3 item = door.Tile1.ToWorld();
				Vector3 item2 = door.Tile2.ToWorld();
				door.Update(!removers.Contains(item) && !removers.Contains(item2));
			}
		}

		public void Build()
		{
			BuildWalls();
			BuildFloors();
		}

		public void BuildFloors()
		{
			foreach (KeyValuePair<LayoutPosition, Room> tile in Blueprint.Tiles)
			{
				BuildFloor(tile.Key, tile.Value);
			}
		}

		public void BuildFloor(LayoutPosition pos, Room room)
		{
			if (!LayoutHelpers.IsInside(room))
			{
				return;
			}
			GameObject gameObject = Object.Instantiate((room.Type == RoomType.Kitchen) ? Prefabs.KitchenFloorPrefab : Prefabs.FloorPrefab);
			gameObject.transform.parent = Parent;
			gameObject.transform.localPosition = pos;
			gameObject.transform.localScale = Vector3.one;
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				Material[] sharedMaterials = meshRenderer.sharedMaterials;
				for (int j = 0; j < meshRenderer.sharedMaterials.Length; j++)
				{
					sharedMaterials[j] = Materials.Get(room, LayoutMaterialType.Floor);
				}
				meshRenderer.sharedMaterials = sharedMaterials;
			}
		}

		public void BuildWalls()
		{
			foreach (KeyValuePair<LayoutPosition, Room> tile in Blueprint.Tiles)
			{
				foreach (LayoutPosition internalWall in Blueprint.GetInternalWalls(tile.Key))
				{
					if ((tile.Key.x < internalWall.x || tile.Key.y < internalWall.y) && !Blueprint.HasFeature(tile.Key, internalWall))
					{
						BuildWallBetween(tile.Key, internalWall);
					}
				}
				foreach (LayoutPosition externalWall in Blueprint.GetExternalWalls(tile.Key))
				{
					if (tile.Value.Type != RoomType.NoRoom && !Blueprint.HasFeature(tile.Key, externalWall))
					{
						bool is_kitchen = tile.Value.Type == RoomType.Kitchen;
						bool is_window = false;
						bool is_fence = tile.Value.Type == RoomType.Garden;
						BuildWallBetween(tile.Key, externalWall, is_hatch: false, is_window, is_kitchen, is_fence);
					}
				}
				foreach (Feature feature in Blueprint.GetFeatures(tile.Key))
				{
					if (feature.Tile1 == tile.Key)
					{
						if (feature.Type == FeatureType.Hatch)
						{
							BuildWallBetween(tile.Key, feature.Tile2, is_hatch: true);
						}
						if (feature.Type.IsDoor())
						{
							bool is_external = !LayoutHelpers.IsInside(Blueprint[feature.Tile2].Type, allow_garden: true) || !LayoutHelpers.IsInside(tile.Value.Type, allow_garden: true);
							bool is_legal_door = Blueprint[feature.Tile1].Type == RoomType.Contracts || Blueprint[feature.Tile2].Type == RoomType.Contracts;
							bool is_trophy_door = Blueprint[feature.Tile1].Type == RoomType.Trophies || Blueprint[feature.Tile2].Type == RoomType.Trophies;
							bool is_office_door = (Blueprint[feature.Tile1].Type == RoomType.Office && Blueprint[feature.Tile2].Type == RoomType.Locations) || (Blueprint[feature.Tile2].Type == RoomType.Office && Blueprint[feature.Tile1].Type == RoomType.Locations);
							BuildDoorBetween(tile.Key, feature.Tile2, is_external, feature.Type == FeatureType.DoorReversed, is_legal_door, is_office_door, is_trophy_door, feature.Type == FeatureType.EmployeesOnlyDoor, feature.Type == FeatureType.LightDoor, feature.Type == FeatureType.MissingDoor);
						}
					}
				}
			}
		}

		public void BuildDoorBetween(Vector2 tile1, Vector2 tile2, bool is_external, bool is_reversed, bool is_legal_door, bool is_office_door, bool is_trophy_door, bool is_employees_only_door, bool is_light_door, bool is_missing_door)
		{
			Vector2 vector = (tile1 + tile2) * 0.5f;
			Vector3 localPosition = new Vector3(vector.x, 0f, vector.y);
			GameObject original = Prefabs.DoorPrefab;
			if (is_reversed && Prefabs.DoorPrefabReversed != null)
			{
				original = Prefabs.DoorPrefabReversed;
			}
			if (is_external)
			{
				original = Prefabs.ExternalDoorPrefab;
			}
			if (is_legal_door)
			{
				original = Prefabs.LegalDoorPrefab;
			}
			if (is_office_door)
			{
				original = Prefabs.OfficeDoorPrefab;
			}
			if (is_trophy_door)
			{
				original = Prefabs.TrophyDoorPrefab;
			}
			if (is_employees_only_door)
			{
				original = Prefabs.EmployeesOnlyDoorPrefab;
			}
			if (is_light_door)
			{
				original = Prefabs.LightDoorPrefab;
			}
			if (is_missing_door)
			{
				original = Prefabs.MissingDoorPrefab;
			}
			GameObject gameObject = Object.Instantiate(original);
			gameObject.transform.parent = Parent;
			gameObject.transform.localPosition = localPosition;
			gameObject.transform.localRotation = Quaternion.LookRotation(new Vector3(tile1.x - tile2.x, 0f, tile1.y - tile2.y), Vector3.up);
			gameObject.transform.localScale = Vector3.one;
			DoorController component;
			bool flag = gameObject.TryGetComponent<DoorController>(out component);
			Door item = new Door
			{
				Tile1 = tile1,
				Tile2 = tile2,
				DoorGameObject = gameObject,
				HatchGameObject = BuildWallBetween(tile1, tile2, is_hatch: true),
				DoorController = component,
				MoveAtNight = (is_external && flag)
			};
			item.Update(is_door: true, force: true);
			Doors.Add(item);
		}

		public GameObject BuildWallBetween(Vector2 tile1, Vector2 tile2, bool is_hatch = false, bool is_window = false, bool is_kitchen = false, bool is_fence = false)
		{
			Vector2 vector = (tile1 + tile2) * 0.5f;
			Vector3 localPosition = new Vector3(vector.x, 0f, vector.y);
			bool flag = false;
			if (!is_hatch)
			{
				if (tile1.x != tile2.x)
				{
					flag = ((!(localPosition.x > 0f)) ? (!LayoutHelpers.IsOutsidePlayable(Blueprint[(tile1.x < tile2.x) ? tile1 : tile2])) : (!LayoutHelpers.IsOutsidePlayable(Blueprint[(tile1.x > tile2.x) ? tile1 : tile2])));
				}
				else
				{
					Vector2 vector2 = ((tile1.y > tile2.y) ? tile1 : tile2);
					Vector2 vector3 = ((localPosition.x > 0f) ? new Vector2(1f, 0f) : new Vector2(-1f, 0f));
					flag = !LayoutHelpers.IsOutsidePlayable(Blueprint[vector2]) || !LayoutHelpers.IsOutsidePlayable(Blueprint[vector2 + vector3]);
				}
			}
			GameObject original = Prefabs.WallPrefab;
			if (is_fence)
			{
				original = Prefabs.FencePrefab;
			}
			else if (is_hatch)
			{
				original = Prefabs.HatchPrefab;
			}
			else if (flag)
			{
				original = Prefabs.ShortWallPrefab;
			}
			else if (is_window)
			{
				original = ((!is_kitchen) ? Prefabs.WindowPrefab : Prefabs.KitchenWindowPrefab);
			}
			GameObject gameObject = Object.Instantiate(original);
			gameObject.transform.parent = Parent;
			gameObject.transform.localPosition = localPosition;
			gameObject.transform.localRotation = Quaternion.LookRotation(new Vector3(tile1.x - tile2.x, 0f, tile1.y - tile2.y), Vector3.up);
			gameObject.transform.localScale = Vector3.one;
			Room room = Blueprint[tile1];
			Room room2 = Blueprint[tile2];
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				Material[] sharedMaterials = meshRenderer.sharedMaterials;
				for (int j = 0; j < meshRenderer.sharedMaterials.Length; j++)
				{
					Material obj = meshRenderer.sharedMaterials[j];
					if (obj.name == "Wall1")
					{
						sharedMaterials[j] = Materials.Get(room, LayoutMaterialType.Wallpaper);
					}
					if (obj.name == "Wall2")
					{
						sharedMaterials[j] = Materials.Get(room2, LayoutMaterialType.Wallpaper);
					}
				}
				meshRenderer.sharedMaterials = sharedMaterials;
			}
			Walls.Add(new Wall
			{
				Tile1 = tile1,
				Tile2 = tile2,
				Collider = gameObject.GetComponent<BoxCollider>(),
				IsExternal = (room.Type == RoomType.NoRoom || room2.Type == RoomType.NoRoom)
			});
			return gameObject;
		}
	}
}
