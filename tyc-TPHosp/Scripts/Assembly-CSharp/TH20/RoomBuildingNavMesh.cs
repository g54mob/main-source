using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TH20
{
	public class RoomBuildingNavMesh : NavMesh
	{
		private struct ConnectivityTest
		{
			public RoomItem Item;

			public int MinValid;

			public Vector3[] DoorPositions;

			public Vector3[] StartPositions;

			public string[] StartNames;
		}

		private const int MaxPerFrame = 20;

		private const float NavMeshHeightOffset = 0.5f;

		private bool _built;

		private bool _building;

		private FloorPlan _lastFloorPlan;

		private HospitalMap _hospitalMap;

		private readonly List<NavMeshBuildSource> _buildSources;

		private readonly List<RoomItem>[] _invalidItems = new List<RoomItem>[2];

		private readonly List<ConnectivityTest> _connectivityTests = new List<ConnectivityTest>(64);

		private readonly List<Vector3> _cacheDoorPositions = new List<Vector3>(8);

		private readonly List<Vector3> _cacheStartPositions = new List<Vector3>(8);

		private readonly List<string> _cacheStartNames = new List<string>(8);

		private readonly List<string> _cacheExcludeStarts = new List<string>(8);

		public List<RoomItem> InvalidItems => _invalidItems[0];

		public HospitalMap HospitalMap => _hospitalMap;

		public bool Built => _built;

		public RoomBuildingNavMesh(HospitalMap hospitalMap, GridCoord worldAnchor, int agentTypeID)
			: base(hospitalMap.FloorPlan.Width(), hospitalMap.FloorPlan.Height(), worldAnchor, agentTypeID)
		{
			_built = false;
			_hospitalMap = hospitalMap;
			_buildSources = new List<NavMeshBuildSource>();
			_invalidItems[0] = new List<RoomItem>();
			_invalidItems[1] = new List<RoomItem>();
		}

		public void Reset()
		{
			_invalidItems[0].Clear();
			_invalidItems[1].Clear();
			_connectivityTests.Clear();
		}

		public void RebuildFrom(FloorPlan floorPlan, BlueprintFloorPlan blueprintFloorPlan, GridCoord worldAnchor)
		{
			Process(floorPlan, blueprintFloorPlan, worldAnchor, rebuild: true);
		}

		public void UpdateFrom(FloorPlan floorPlan, BlueprintFloorPlan blueprintFloorPlan, GridCoord worldAnchor)
		{
			Process(floorPlan, blueprintFloorPlan, worldAnchor, rebuild: false);
		}

		private void Process(FloorPlan floorPlan, BlueprintFloorPlan blueprintFloorPlan, GridCoord worldAnchor, bool rebuild)
		{
			if (!rebuild && _building)
			{
				return;
			}
			if (floorPlan != _lastFloorPlan)
			{
				_lastFloorPlan = floorPlan;
				Reset();
			}
			if (!rebuild && _connectivityTests.Count != 0)
			{
				ValidateConnectivity();
				return;
			}
			_buildSources.Clear();
			AddFloorPlan(floorPlan, worldAnchor);
			SetupConnectivityTest(floorPlan);
			if (blueprintFloorPlan != null && blueprintFloorPlan != floorPlan)
			{
				AddFloorPlan(blueprintFloorPlan, worldAnchor);
			}
			_building = true;
			if (rebuild)
			{
				NavMeshBuilder.Cancel(_navMeshData);
				NavMeshBuilder.UpdateNavMeshData(_navMeshData, _navMeshBuildSettings, _buildSources, _worldNavBounds);
				OnCompleted(null);
			}
			else
			{
				NavMeshBuilder.UpdateNavMeshDataAsync(_navMeshData, _navMeshBuildSettings, _buildSources, _worldNavBounds).completed += OnCompleted;
			}
		}

		private void AddFloorPlan(FloorPlan floorPlan, GridCoord worldAnchor)
		{
			GridCoord roomWorldCoord = floorPlan.Anchor - worldAnchor;
			Vector3 size = new Vector3(2f, 0.125f, 2f);
			for (int i = 0; i < floorPlan.Height(); i++)
			{
				for (int j = 0; j < floorPlan.Width(); j++)
				{
					if (floorPlan[j, i])
					{
						_buildSources.Add(new NavMeshBuildSource
						{
							area = 3,
							shape = NavMeshBuildSourceShape.Box,
							size = size,
							transform = Matrix4x4.Translate(new Vector3((float)(j + floorPlan.Anchor.X) * 2f, 0.4375f, (float)(i + floorPlan.Anchor.Y) * 2f))
						});
					}
				}
			}
			foreach (WallCoord wall in floorPlan.Walls)
			{
				AddWallToNavGraph(wall, floorPlan.Definition.WallThickness, roomWorldCoord, worldAnchor, _buildSources, 0.5f);
			}
			foreach (RoomItem item in floorPlan.Items)
			{
				AddItemToNavGraph(item, _buildSources, 0.4f);
			}
		}

		private void OnCompleted(AsyncOperation asyncOperation)
		{
			_built = true;
			_building = false;
			UpdateNavmeshIslandIDs(0.5f);
		}

		private void SetupConnectivityTest(FloorPlan floorPlan)
		{
			_invalidItems[1].Clear();
			_connectivityTests.Clear();
			foreach (RoomItem item2 in floorPlan.Items)
			{
				if (item2.Interactions.Count == 0 || item2.Visual == null || item2.Definition.IgnoreValidation || item2.GetComponent<RoomItemSellInvalidComponent>() != null)
				{
					continue;
				}
				int num = item2.Definition.MinValidInteractions;
				_cacheDoorPositions.Clear();
				_cacheStartPositions.Clear();
				_cacheStartNames.Clear();
				_cacheExcludeStarts.Clear();
				foreach (RoomItem door in floorPlan.Doors)
				{
					if (item2 != door && door.IsValid)
					{
						Vector3 item = ((!floorPlan.Definition.IsHospitalOrBay) ? door.WorldPosition : RoomItemAlgorithms.CalculateDoorEnter(door));
						_cacheDoorPositions.Add(item);
					}
				}
				if (_cacheDoorPositions.Count == 0)
				{
					continue;
				}
				foreach (ObjectInteraction interaction in item2.Interactions)
				{
					if (interaction.Definition.IgnoreRoomCheck)
					{
						num--;
						_cacheExcludeStarts.Add(interaction.StartSocketName);
					}
				}
				foreach (KeyValuePair<string, Transform> startTransform in item2.Visual.StartTransforms)
				{
					if (!_cacheExcludeStarts.Contains(startTransform.Key))
					{
						_cacheStartPositions.Add(startTransform.Value.position);
						_cacheStartNames.Add(startTransform.Key);
					}
				}
				_connectivityTests.Add(new ConnectivityTest
				{
					Item = item2,
					MinValid = num,
					DoorPositions = _cacheDoorPositions.ToArray(),
					StartPositions = _cacheStartPositions.ToArray(),
					StartNames = _cacheStartNames.ToArray()
				});
			}
		}

		private void ValidateConnectivity()
		{
			int num = 0;
			while (_connectivityTests.Count != 0 && num < 20)
			{
				ConnectivityTest connectivityTest = _connectivityTests.Pop();
				RoomItem item = connectivityTest.Item;
				bool flag = false;
				bool hasMergedPlots = item.FloorPlan.HospitalMap.HasMergedPlots;
				Vector3[] doorPositions = connectivityTest.DoorPositions;
				foreach (Vector3 start in doorPositions)
				{
					int num2 = 0;
					for (int j = 0; j < connectivityTest.StartPositions.Length; j++)
					{
						Vector3 end = connectivityTest.StartPositions[j];
						if (CanReach(start, end))
						{
							num2++;
							if (num2 >= connectivityTest.MinValid)
							{
								break;
							}
						}
						else
						{
							item.UnreachableInteraction = connectivityTest.StartNames[j];
						}
					}
					if (hasMergedPlots)
					{
						if (num2 >= connectivityTest.MinValid)
						{
							flag = true;
							break;
						}
					}
					else if (num2 < connectivityTest.MinValid)
					{
						_invalidItems[1].Add(item);
						break;
					}
				}
				if (hasMergedPlots && !flag)
				{
					_invalidItems[1].Add(item);
				}
				num++;
			}
			if (_connectivityTests.Count == 0)
			{
				MathUtils.Swap(ref _invalidItems[0], ref _invalidItems[1]);
			}
		}

		public override bool CanReach(Vector3 start, Vector3 end)
		{
			start.y = 0.5f;
			end.y = 0.5f;
			if (UnityEngine.AI.NavMesh.SamplePosition(start, out var hit, 0.25f, 8) && UnityEngine.AI.NavMesh.SamplePosition(end, out hit, 0.25f, 8))
			{
				UnityEngine.AI.NavMesh.CalculatePath(start, end, 8, _canReachPath);
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

		public bool ValidPosition(Vector3 position, float distanceOffNavMeshToAllow)
		{
			if (!_built)
			{
				return true;
			}
			position.y += 0.5f;
			NavMeshHit hit;
			return UnityEngine.AI.NavMesh.SamplePosition(position, out hit, distanceOffNavMeshToAllow, 8);
		}
	}
}
