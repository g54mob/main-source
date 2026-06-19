using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class CorridorWallsVisual : MustCallDestroy
	{
		private struct WallVisual
		{
			public Bounds Bounds;

			public Transform Transform;

			public Room Room;
		}

		private struct RemovedWall
		{
			public Vector3 Position;

			public Quaternion Rotation;

			public Mesh Mesh;
		}

		private readonly RoomWallDefinition _hospitalInteriorDefinition;

		private readonly RoomWallDefinition _corridorOverrideWallDefinition;

		private readonly Transform _container;

		private readonly List<WallVisual> _activeWalls;

		private readonly List<Transform> _inactiveWalls;

		private readonly List<Transform> _pillarObjects;

		private static readonly GridCoord[] CornerRoomOffsets = new GridCoord[4]
		{
			new GridCoord(-1, 1),
			new GridCoord(1, 1),
			new GridCoord(1, -1),
			new GridCoord(-1, -1)
		};

		public Transform Container => _container;

		public CorridorWallsVisual(RoomWallDefinition hospitalInteriorDefinition, RoomWallDefinition corridorOverrideWallDefinition, Transform parent)
		{
			_hospitalInteriorDefinition = hospitalInteriorDefinition;
			_corridorOverrideWallDefinition = corridorOverrideWallDefinition;
			_container = new GameObject().transform;
			_container.gameObject.name = "Corridor Walls";
			_container.SetParent(parent, worldPositionStays: true);
			_activeWalls = new List<WallVisual>();
			_inactiveWalls = new List<Transform>();
			_pillarObjects = new List<Transform>();
		}

		public override void Destroy()
		{
			foreach (WallVisual activeWall in _activeWalls)
			{
				Material[] materials = activeWall.Transform.GetComponent<MeshRenderer>().materials;
				for (int i = 0; i < materials.Length; i++)
				{
					Object.Destroy(materials[i]);
				}
			}
			DestroyMaterials(_inactiveWalls);
			DestroyMaterials(_pillarObjects);
			foreach (WallVisual activeWall2 in _activeWalls)
			{
				Object.Destroy(activeWall2.Transform.gameObject);
			}
			_activeWalls.Clear();
			_inactiveWalls.ClearAndDestroy();
			_pillarObjects.ClearAndDestroy();
			if ((bool)_container && (bool)_container.gameObject)
			{
				Object.Destroy(_container.gameObject);
			}
			base.Destroy();
		}

		private void DestroyMaterials(List<Transform> objects)
		{
			foreach (Transform @object in objects)
			{
				Material[] materials = @object.GetComponent<MeshRenderer>().materials;
				for (int i = 0; i < materials.Length; i++)
				{
					Object.Destroy(materials[i]);
				}
			}
		}

		public void CreateWallObjects(List<WallCoord> walls, GridCoord worldAnchor, GridBounds recalcBounds, WorldState worldState, bool animateWalls, Room roomWallsToAnimate, Vector3 animateOrigin)
		{
			List<Transform> list = new List<Transform>();
			List<RemovedWall> list2 = new List<RemovedWall>();
			List<GameObject> list3 = new List<GameObject>();
			GameObject piece = _hospitalInteriorDefinition.GetPiece(RoomWallDefinition.Type.Pillar);
			GameObject piece2 = _hospitalInteriorDefinition.GetPiece(RoomWallDefinition.Type.PillarCornerRight);
			foreach (WallVisual activeWall in _activeWalls)
			{
				GridCoord coord = activeWall.Transform.position.ToGridCoord() - worldAnchor;
				if (recalcBounds.IsInBounds(coord))
				{
					list.Add(activeWall.Transform);
					list2.Add(new RemovedWall
					{
						Position = activeWall.Transform.position,
						Rotation = activeWall.Transform.rotation,
						Mesh = activeWall.Transform.GetComponent<MeshFilter>().sharedMesh
					});
				}
			}
			foreach (Transform obj in list)
			{
				_activeWalls.RemoveAll((WallVisual v) => v.Transform == obj);
				_inactiveWalls.Add(obj);
				GameObjectUtils.SetActive(obj.gameObject, isActive: false);
			}
			for (int num = _inactiveWalls.Count; num < walls.Count; num++)
			{
				GameObject gameObject = MeshUtils.CreateStaticMeshObject();
				gameObject.name = "Corridor wall";
				gameObject.transform.parent = _container;
				_inactiveWalls.Add(gameObject.transform);
			}
			List<Transform> oldPillars = new List<Transform>();
			foreach (Transform pillarObject in _pillarObjects)
			{
				GridCoord coord2 = pillarObject.position.ToGridCoord() - worldAnchor;
				if (recalcBounds.IsInBounds(coord2))
				{
					oldPillars.Add(pillarObject);
					Object.Destroy(pillarObject.gameObject);
				}
			}
			_pillarObjects.RemoveAll((Transform p) => oldPillars.Contains(p));
			foreach (WallCoord wall in walls)
			{
				if (!recalcBounds.IsInBounds(wall._position))
				{
					continue;
				}
				GridCoord gridCoord = worldAnchor + wall._position;
				Room room;
				RoomWallDefinition wallDefinition = GetWallDefinition(worldState, wall, gridCoord, out room);
				if (wallDefinition == null)
				{
					continue;
				}
				Transform transform = _inactiveWalls[_inactiveWalls.Count - 1];
				Vector3 vector = GridCoord.GridCoordToWorldPosition(gridCoord);
				Vector3 vector2 = new Vector3(0f, wall._rotation.YawRotation(), 0f);
				vector += wall._rotation.DirectionVector() * 2f * 0.5f;
				transform.position = vector;
				transform.localEulerAngles = vector2;
				bool isActive = MeshUtils.SetStaticMeshFromPrefab(transform.gameObject, wallDefinition.GetPiece(wall._type));
				GameObjectUtils.SetActive(transform.gameObject, isActive);
				if (transform.gameObject.activeSelf)
				{
					MeshRenderer component = transform.GetComponent<MeshRenderer>();
					component.shadowCastingMode = wallDefinition.WallShadowCastingMode;
					_activeWalls.Add(new WallVisual
					{
						Transform = transform,
						Bounds = component.bounds,
						Room = room
					});
					_inactiveWalls.RemoveAt(_inactiveWalls.Count - 1);
					if (animateWalls && room == roomWallsToAnimate)
					{
						bool flag = true;
						foreach (RemovedWall item in list2)
						{
							if (transform.position == item.Position && transform.rotation == item.Rotation && transform.GetComponent<MeshFilter>().sharedMesh == item.Mesh)
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							list3.Add(transform.gameObject);
						}
					}
				}
				if (room != null && !room.Definition.HasExteriorWalls())
				{
					continue;
				}
				GameObject gameObject2 = null;
				if (piece2 != null && wall._type == RoomWallDefinition.Type.CornerInner)
				{
					GridDirection direction = wall._rotation.RotateClockwise();
					GridCoord worldCoord = gridCoord + direction.DirectionCoord();
					Room roomAtWorldCoord = worldState.GetRoomAtWorldCoord(worldCoord, includeHospital: true, includeClosedPlots: true);
					if ((roomAtWorldCoord == null || roomAtWorldCoord.Definition.HasExteriorWalls()) && ((roomAtWorldCoord == null && wallDefinition != _hospitalInteriorDefinition) || (roomAtWorldCoord != null && AreWallDefinitionsDifferent(roomAtWorldCoord, wallDefinition))))
					{
						gameObject2 = AddPillarObject(piece2, vector, vector2);
						GameObjectUtils.SetActive(transform.gameObject, isActive: false);
					}
				}
				else if (piece != null && (wall.IsWall() || wall.IsDoor() || wall.IsWindow()))
				{
					GridDirection direction2 = wall._rotation.RotateClockwise();
					GridCoord gridCoord2 = gridCoord + direction2.DirectionCoord() + wall._rotation.DirectionCoord();
					Room roomAtWorldCoord2 = worldState.GetRoomAtWorldCoord(gridCoord2, includeHospital: true, includeClosedPlots: true);
					if (roomAtWorldCoord2 == null || roomAtWorldCoord2.Definition.HasExteriorWalls())
					{
						if (roomAtWorldCoord2 == null && wallDefinition != _hospitalInteriorDefinition)
						{
							gridCoord2 = gridCoord + direction2.DirectionCoord();
							if (worldState.GetRoomAtWorldCoord(gridCoord2, includeHospital: true, includeClosedPlots: true) != null)
							{
								gameObject2 = AddPillarObject(piece, vector, vector2);
							}
						}
						else if (roomAtWorldCoord2 != null && AreWallDefinitionsDifferent(roomAtWorldCoord2, wallDefinition))
						{
							GridDirection gridDirection = wall._rotation.Rotate180();
							List<WallCoord> walls2 = roomAtWorldCoord2.FloorPlan.Walls;
							if (walls2 != null)
							{
								GridCoord gridCoord3 = gridCoord2 - roomAtWorldCoord2.FloorPlan.Anchor;
								foreach (WallCoord item2 in walls2)
								{
									if (!item2.IsCorner() && item2._position == gridCoord3 && gameObject2 == null && gridDirection == item2._rotation)
									{
										gameObject2 = AddPillarObject(piece, vector, vector2);
									}
								}
							}
						}
					}
				}
				if (!animateWalls || !(gameObject2 != null))
				{
					continue;
				}
				bool flag2 = false;
				foreach (Transform item3 in oldPillars)
				{
					if (item3.transform.position == gameObject2.transform.position)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					list3.Add(gameObject2);
				}
			}
			if (!animateWalls)
			{
				return;
			}
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetVector("_Origin", animateOrigin);
			materialPropertyBlock.SetFloat("_StartTime", VisualManager.ElapsedTime);
			foreach (GameObject item4 in list3)
			{
				MeshRenderer component2 = item4.GetComponent<MeshRenderer>();
				if ((bool)component2)
				{
					component2.SetPropertyBlock(materialPropertyBlock);
					component2.gameObject.GetOrAddComponent<RendererClearPropertyBlock>().Setup(component2, 2f);
				}
			}
		}

		public void UpdateWallDoorClipBounds(Room room, GridCoord worldAnchor)
		{
			RoomItem door = room.FloorPlan.Door;
			if (door == null || !door.TryGetClipBounds(out var clipBounds))
			{
				return;
			}
			GridBounds gridBounds = room.FloorPlan.WorldBounds - worldAnchor;
			gridBounds.Min -= new GridCoord(1, 1);
			gridBounds.Max += new GridCoord(1, 1);
			Bounds bounds = clipBounds.Transform(door.WorldPosition, Quaternion.Euler(0f, door.Rotation, 0f));
			List<MeshRenderer> list = new List<MeshRenderer>(8);
			foreach (WallVisual activeWall in _activeWalls)
			{
				if (activeWall.Room != room || !bounds.Intersects(activeWall.Bounds))
				{
					continue;
				}
				activeWall.Transform.GetComponentsInChildren(list);
				foreach (MeshRenderer item in list)
				{
					Material[] sharedMaterials = item.sharedMaterials;
					for (int i = 0; i < sharedMaterials.Length; i++)
					{
						if (!sharedMaterials[i].name.Contains("M_Wall_Top"))
						{
							Material material = new Material(sharedMaterials[i]);
							material.EnableKeyword("_AACLIPBOX_ON");
							material.SetVector("_AAClipBoxPos", bounds.center);
							material.SetVector("_AAClipBoxExtents", bounds.extents);
							sharedMaterials[i] = material;
						}
					}
					item.sharedMaterials = sharedMaterials;
				}
			}
		}

		private bool AreWallDefinitionsDifferent(Room otherRoom, RoomWallDefinition wallDefinition)
		{
			if (otherRoom.Definition.IsHospitalOrBay)
			{
				return otherRoom.Definition._wallsInterior != wallDefinition;
			}
			return GetRoomExteriorWallDefinition(otherRoom) != wallDefinition;
		}

		private GameObject AddPillarObject(GameObject pillarPrefab, Vector3 worldPos, Vector3 worldRot)
		{
			GameObject gameObject = MeshUtils.CreateStaticMeshObject();
			Transform transform = gameObject.transform;
			gameObject.name = "Pillar";
			transform.parent = _container;
			transform.position = worldPos;
			transform.localEulerAngles = worldRot;
			MeshUtils.SetStaticMeshFromPrefab(gameObject, pillarPrefab);
			_pillarObjects.Add(transform);
			return gameObject;
		}

		private RoomWallDefinition GetWallDefinition(WorldState worldState, WallCoord wall, GridCoord worldGridPos, out Room room)
		{
			GridCoord gridCoord = ((wall._type == RoomWallDefinition.Type.CornerOuter) ? CornerRoomOffsets[(int)wall._rotation] : wall._rotation.DirectionCoord());
			room = worldState.GetRoomAtWorldCoord(worldGridPos + gridCoord, includeHospital: false, includeClosedPlots: true);
			if (room == null)
			{
				return _hospitalInteriorDefinition;
			}
			return GetRoomExteriorWallDefinition(room);
		}

		private RoomWallDefinition GetRoomExteriorWallDefinition(Room room)
		{
			if (_corridorOverrideWallDefinition == null)
			{
				return room.Definition._wallsExterior;
			}
			return _corridorOverrideWallDefinition;
		}
	}
}
