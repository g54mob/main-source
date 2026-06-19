#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TH20
{
	public class NavMesh : MustCallDestroy
	{
		protected const int WalkableArea = 0;

		protected const int NotWalkableArea = 1;

		protected const int TestArea = 3;

		protected const float cellNavSourceBoxHeight = 0.125f;

		protected readonly Bounds _worldNavBounds;

		protected readonly NavMeshPath _canReachPath;

		private readonly List<NavMeshBuildSource> _indoorOrPathTileSources = new List<NavMeshBuildSource>();

		private readonly List<NavMeshBuildSource> _wallSources = new List<NavMeshBuildSource>();

		private readonly List<NavMeshBuildSource> _itemSources = new List<NavMeshBuildSource>();

		private readonly List<NavMeshBuildSource> _perimeterSources = new List<NavMeshBuildSource>();

		protected NavMeshBuildSettings _navMeshBuildSettings;

		protected readonly NavMeshData _navMeshData;

		private readonly NavMeshDataInstance _navMeshDataInstance;

		private NavMeshAreaLookup _areaLookup;

		private List<NavMeshBuildSource> _sources = new List<NavMeshBuildSource>();

		private static Vector3[] _cornersCache = new Vector3[64];

		public NavMeshAreaLookup AreaLookup => _areaLookup;

		public NavMesh(int worldWidthCells, int worldHeightCells, GridCoord worldAnchor, int agentTypeID)
		{
			Vector3 vector = new Vector3(((float)worldAnchor.X + (float)(worldWidthCells - 1) / 2f) * 2f, 0f, ((float)worldAnchor.Y + ((float)worldHeightCells - 1f) / 2f) * 2f);
			_worldNavBounds = new Bounds(vector, new Vector3((float)worldWidthCells * 2f, 1f, (float)worldHeightCells * 2f));
			Bounds localBounds = new Bounds(Vector3.zero, new Vector3((float)worldWidthCells * 2f, 1f, (float)worldHeightCells * 2f));
			_canReachPath = new NavMeshPath();
			UnityEngine.AI.NavMesh.pathfindingIterationsPerFrame = 500;
			_navMeshBuildSettings = UnityEngine.AI.NavMesh.CreateSettings();
			_navMeshBuildSettings.agentClimb = 0.1f;
			_navMeshBuildSettings.agentHeight = 1.5f;
			_navMeshBuildSettings.agentRadius = 0.25f;
			_navMeshBuildSettings.agentSlope = 10f;
			_navMeshBuildSettings.agentTypeID = agentTypeID;
			_navMeshBuildSettings.voxelSize = 0.125f;
			string[] array = _navMeshBuildSettings.ValidationReport(_worldNavBounds);
			if (array.Length != 0)
			{
				string[] array2 = array;
				foreach (string message in array2)
				{
					Logging.Warning(LogChannels.NavMesh, message);
				}
			}
			_sources.Clear();
			_sources.AddRange(_indoorOrPathTileSources);
			_navMeshData = NavMeshBuilder.BuildNavMeshData(_navMeshBuildSettings, _sources, localBounds, vector, Quaternion.identity);
			_navMeshDataInstance = UnityEngine.AI.NavMesh.AddNavMeshData(_navMeshData);
		}

		public override void Destroy()
		{
			UnityEngine.AI.NavMesh.RemoveNavMeshData(_navMeshDataInstance);
			base.Destroy();
		}

		public void UpdateFromRooms(List<Room> allRooms, GridCoord worldAnchor)
		{
			_wallSources.Clear();
			_itemSources.Clear();
			foreach (Room allRoom in allRooms)
			{
				if (!allRoom.FloorPlan.HospitalMap.Plot.Bought)
				{
					continue;
				}
				float wallThickness = allRoom.Definition.WallThickness;
				GridCoord roomWorldCoord = allRoom.FloorPlan.Anchor - worldAnchor;
				foreach (WallCoord wall in allRoom.FloorPlan.Walls)
				{
					AddWallToNavGraph(wall, wallThickness, roomWorldCoord, worldAnchor, _wallSources);
				}
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					AddItemToNavGraph(item, _itemSources);
				}
				foreach (LandscapeRoomItem landscapeItem in allRoom.FloorPlan.LandscapeItems)
				{
					AddItemToNavGraph(landscapeItem, _itemSources);
				}
			}
			_sources.Clear();
			_sources.AddRange(_perimeterSources);
			_sources.AddRange(_indoorOrPathTileSources);
			_sources.AddRange(_wallSources);
			_sources.AddRange(_itemSources);
			if (DebugVars.ShowNavMeshUpdateDebug.Value)
			{
				foreach (NavMeshBuildSource indoorOrPathTileSource in _indoorOrPathTileSources)
				{
					DebugDrawUtils.Bounds(indoorOrPathTileSource.size, indoorOrPathTileSource.transform, Color.blue, 1f);
				}
				foreach (NavMeshBuildSource wallSource in _wallSources)
				{
					DebugDrawUtils.Bounds(wallSource.size, wallSource.transform, Color.magenta, 1f);
				}
				foreach (NavMeshBuildSource itemSource in _itemSources)
				{
					DebugDrawUtils.Bounds(itemSource.size, itemSource.transform, Color.green, 1f);
				}
				foreach (NavMeshBuildSource perimeterSource in _perimeterSources)
				{
					DebugDrawUtils.Bounds(perimeterSource.size, perimeterSource.transform, Color.red, 1f);
				}
			}
			NavMeshBuilder.UpdateNavMeshData(_navMeshData, _navMeshBuildSettings, _sources, _worldNavBounds);
			UpdateNavmeshIslandIDs(0f);
		}

		internal void UpdateFromHospitalMap(GridCoord worldAnchor, HospitalMap hospitalMap)
		{
			bool bought = hospitalMap.Plot.Bought;
			int num = hospitalMap.FloorPlan.Width();
			int num2 = hospitalMap.FloorPlan.Height();
			bool[,] indoorState = hospitalMap.IndoorState;
			bool[,] indoorOrPathState = hospitalMap.IndoorOrPathState;
			Vector3 vector = new Vector3(2f, 0.125f, 2f);
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					bool num3;
					if (!bought)
					{
						if (!indoorOrPathState[j, i])
						{
							continue;
						}
						num3 = !indoorState[j, i];
					}
					else
					{
						num3 = indoorOrPathState[j, i];
					}
					if (num3)
					{
						_indoorOrPathTileSources.Add(new NavMeshBuildSource
						{
							area = 0,
							shape = NavMeshBuildSourceShape.Box,
							size = vector,
							transform = Matrix4x4.Translate(new Vector3((float)(j + worldAnchor.X) * 2f, -0.0625f, (float)(i + worldAnchor.Y) * 2f))
						});
					}
				}
			}
			_perimeterSources.Clear();
			if (!hospitalMap.Plot.Definition.IncludePerimiterInNavMesh)
			{
				return;
			}
			foreach (GameObject instance in hospitalMap.FootprintPerimeter.Instances)
			{
				GridCoord gridCoord = instance.transform.position.ToGridCoord();
				Vector3 vector2 = new Vector3((float)gridCoord.X * 2f, -0.0625f, (float)gridCoord.Y * 2f);
				NavMeshBuildSource item = new NavMeshBuildSource
				{
					area = 0,
					shape = NavMeshBuildSourceShape.Box,
					size = vector * 2f,
					transform = Matrix4x4.Translate(vector2)
				};
				_perimeterSources.Add(item);
			}
		}

		protected void AddWallToNavGraph(WallCoord wall, float thickness, GridCoord roomWorldCoord, GridCoord worldAnchor, List<NavMeshBuildSource> sources, float heightOffset = 0f)
		{
			if (!wall.IsCorner() && !wall.IsDoor())
			{
				Vector3 vector = (roomWorldCoord + wall._position + worldAnchor).ToWorldPosition();
				Vector3 size = new Vector3(2f, 1f, 0.125f + thickness);
				Matrix4x4 transform = Matrix4x4.identity;
				float num = 1f - thickness;
				vector.y += heightOffset;
				switch (wall._rotation)
				{
				case GridDirection.PosY:
					transform = Matrix4x4.Translate(vector + new Vector3(0f, 0f, num));
					break;
				case GridDirection.PosX:
					transform = Matrix4x4.TRS(vector + new Vector3(num, 0f, 0f), Quaternion.Euler(0f, 90f, 0f), Vector3.one);
					break;
				case GridDirection.NegY:
					transform = Matrix4x4.TRS(vector + new Vector3(0f, 0f, 0f - num), Quaternion.Euler(0f, 180f, 0f), Vector3.one);
					break;
				case GridDirection.NegX:
					transform = Matrix4x4.TRS(vector + new Vector3(0f - num, 0f, 0f), Quaternion.Euler(0f, 270f, 0f), Vector3.one);
					break;
				}
				sources.Add(new NavMeshBuildSource
				{
					area = 1,
					shape = NavMeshBuildSourceShape.Box,
					size = size,
					transform = transform
				});
			}
		}

		protected void AddItemToNavGraph(RoomItem item, List<NavMeshBuildSource> sources, float heightOffset = 0f)
		{
			if (!item.Definition.AffectsNavigation)
			{
				return;
			}
			Bounds[] localNavBounds = item.LocalNavBounds;
			Vector3 worldPosition = item.WorldPosition;
			Quaternion quaternion = Quaternion.Euler(0f, item.Rotation, 0f);
			Bounds[] array = localNavBounds;
			foreach (Bounds bounds in array)
			{
				AddBoundsToNavGraph(bounds, worldPosition, quaternion, sources, heightOffset);
			}
			if (item.Definition.ItemType == RoomItemDefinition.Type.Door)
			{
				float num = worldPosition.x / 2f;
				float num2 = worldPosition.z / 2f;
				if (Mathf.Abs(num - (float)(int)num) > 0f || Mathf.Abs(num2 - (float)(int)num2) > 0f)
				{
					Vector3 vector = worldPosition;
					Vector3 vector2 = item.GridRotation.DirectionVector();
					float num3 = ((item.OwningRoom != null) ? item.OwningRoom.Definition.WallThickness : 0f);
					Vector3 size = new Vector3(1f, 1f, 0.125f + num3);
					Vector3 pos = vector - new Vector3(vector2.z * 1.25f, heightOffset, vector2.x * 1.25f) + vector2;
					Vector3 pos2 = vector + new Vector3(vector2.z * 1.25f, heightOffset, vector2.x * 1.25f) + vector2;
					sources.Add(new NavMeshBuildSource
					{
						area = 1,
						component = null,
						shape = NavMeshBuildSourceShape.Box,
						size = size,
						transform = Matrix4x4.TRS(pos, quaternion, Vector3.one)
					});
					sources.Add(new NavMeshBuildSource
					{
						area = 1,
						component = null,
						shape = NavMeshBuildSourceShape.Box,
						size = size,
						transform = Matrix4x4.TRS(pos2, quaternion, Vector3.one)
					});
				}
			}
		}

		private void AddBoundsToNavGraph(Bounds bounds, Vector3 position, Quaternion quat, List<NavMeshBuildSource> sources, float heightOffset)
		{
			position.y += heightOffset;
			sources.Add(new NavMeshBuildSource
			{
				area = 1,
				component = null,
				shape = NavMeshBuildSourceShape.Box,
				size = bounds.size,
				transform = Matrix4x4.TRS(position + quat * bounds.center, quat, Vector3.one)
			});
			bounds.center = quat * bounds.center + position;
			bounds = bounds.Rotate(quat);
			if (DebugVars.ShowNavMeshUpdateDebug.Value)
			{
				DebugDrawUtils.Bounds(bounds.min, bounds.max, Color.red, 2f);
			}
		}

		protected void UpdateNavmeshIslandIDs(float planeHeight)
		{
			_areaLookup = NavMeshHelpers.BuildNavMeshAreaLookup(_worldNavBounds.center, planeHeight);
		}

		public int GetAreaIDAtPosition(Vector3 worldPosition, AllowDistanceOffNavMesh allowDistanceOffNavMesh = AllowDistanceOffNavMesh.Disallow)
		{
			if (AreaLookup == null)
			{
				return -1;
			}
			return AreaLookup.IslandIDAtPosition(worldPosition, allowDistanceOffNavMesh);
		}

		public int GetAreaIDAtGridCoord(GridCoord coord, AllowDistanceOffNavMesh allowDistanceOffNavMesh = AllowDistanceOffNavMesh.Disallow)
		{
			if (AreaLookup == null)
			{
				return -1;
			}
			return AreaLookup.IslandIDAtCoord(coord, allowDistanceOffNavMesh);
		}

		public virtual bool CanReach(Vector3 start, Vector3 end)
		{
			start.y = 0f;
			end.y = 0f;
			if (UnityEngine.AI.NavMesh.SamplePosition(start, out var hit, 0.25f, -1) && UnityEngine.AI.NavMesh.SamplePosition(end, out hit, 0.25f, -1))
			{
				UnityEngine.AI.NavMesh.CalculatePath(start, end, -1, _canReachPath);
				if (_canReachPath.status == NavMeshPathStatus.PathComplete)
				{
					if (DebugVars.ShowRoomNavMeshDebug.Value)
					{
						DebugDrawUtils.Marker(start, Color.green);
						for (int i = 0; i < _canReachPath.corners.Length - 1; i++)
						{
							Vector3 vector = _canReachPath.corners[i];
							DebugDrawUtils.Line(end: _canReachPath.corners[i + 1] + Vector3.up, start: vector + Vector3.up, color: Color.green);
						}
						DebugDrawUtils.Marker(end, Color.green);
					}
					return true;
				}
			}
			if (DebugVars.ShowRoomNavMeshDebug.Value)
			{
				DebugDrawUtils.Marker(start, Color.red);
				DebugDrawUtils.Line(start + Vector3.up * 0.5f, end + Vector3.up * 0.5f, Color.red);
				DebugDrawUtils.Marker(end, Color.red);
			}
			return false;
		}

		public float GetLastNavPathLength()
		{
			if (_canReachPath.status == NavMeshPathStatus.PathComplete)
			{
				int cornersNonAlloc = _canReachPath.GetCornersNonAlloc(_cornersCache);
				if (cornersNonAlloc != 0)
				{
					float num = 0f;
					for (int i = 0; i < cornersNonAlloc - 1; i++)
					{
						Vector3 a = _cornersCache[i];
						Vector3 b = _cornersCache[i + 1];
						num += Vector3.Distance(a, b);
					}
					return num;
				}
			}
			return float.MaxValue;
		}

		public bool IsValidLocation(Vector3 position, float distanceOffNavMesh = 0.25f)
		{
			if (UnityEngine.AI.NavMesh.SamplePosition(position, out var _, distanceOffNavMesh, -1))
			{
				return true;
			}
			return false;
		}
	}
}
