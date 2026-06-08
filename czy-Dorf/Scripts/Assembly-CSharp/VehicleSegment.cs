using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;

[RequireComponent(typeof(ElementGroupSegment))]
public class VehicleSegment : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<PathPointData, bool> _003C_003E9__15_0;

		internal bool _003CReadPaths_003Eb__15_0(PathPointData x)
		{
			return x.type == VehiclePathPointType.entrance;
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public Space space;

		public int entranceEdge;

		internal bool _003CGetPathAtEntrance_003Eb__0(VehiclePathData x)
		{
			return ((space == Space.World) ? x.EntranceWorldEdge : x.entranceLocalEdge) == entranceEdge;
		}

		internal bool _003CGetPathAtEntrance_003Eb__1(VehiclePathData x)
		{
			if (((space == Space.World) ? x.EntranceWorldEdge : x.entranceLocalEdge) == entranceEdge && !x.ExitBlocked)
			{
				return x.Priority == 0;
			}
			return false;
		}

		internal bool _003CGetPathAtEntrance_003Eb__2(VehiclePathData x)
		{
			if (((space == Space.World) ? x.EntranceWorldEdge : x.entranceLocalEdge) == entranceEdge && !x.ExitBlocked)
			{
				return x.Priority > 0;
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public int exitEdge;

		internal bool _003CGetPathTowardsExit_003Eb__0(VehiclePathData x)
		{
			return x.exitLocalEdge == exitEdge;
		}

		internal bool _003CGetPathTowardsExit_003Eb__1(VehiclePathData x)
		{
			return x.ExitWorldEdge == exitEdge;
		}
	}

	[SerializeField]
	private bool blockedByDefault;

	[SerializeField]
	private bool createEmergencyPaths;

	[SerializeField]
	private List<AffectingAdaptiveSegment> affectingAdaptiveSegments;

	public List<VehicleSegmentPath> paths;

	[SerializeField]
	private VehicleSegmentPath vehiclePathPrefab;

	[SerializeField]
	private VehiclePathPoint vehiclePathPointPrefab;

	[SerializeField]
	private List<VehiclePathData> pathData;

	[SerializeField]
	private List<PathPointData> pathPointData;

	[SerializeField]
	private List<PathPointData> entrancePathPoints;

	private ElementGroupSegment segment;

	private int _debugCounter;

	public Tile Tile => segment.Tile;

	private void Awake()
	{
		segment = GetComponent<ElementGroupSegment>();
		foreach (AffectingAdaptiveSegment affectingAdaptiveSegment in affectingAdaptiveSegments)
		{
			affectingAdaptiveSegment.adaptiveSegment.OnNeighborStateChanged += UpdateNeighborState;
		}
	}

	private void UpdateNeighborState(int worldDirectionIndex, SegmentNeighborType neighborState)
	{
		bool flag = false;
		foreach (AffectingAdaptiveSegment affectingAdaptiveSegment in affectingAdaptiveSegments)
		{
			SegmentNeighborType neighborType = affectingAdaptiveSegment.adaptiveSegment.GetNeighborType(worldDirectionIndex, Space.World);
			flag |= affectingAdaptiveSegment.blockingStates.Contains(neighborType);
		}
		BlockEntrance(worldDirectionIndex, flag);
	}

	private void ReadPaths()
	{
		if (!segment)
		{
			segment = GetComponent<ElementGroupSegment>();
		}
		_debugCounter = 0;
		foreach (VehicleSegmentPath path in paths)
		{
			if ((bool)path)
			{
				UnityEngine.Object.DestroyImmediate(path.gameObject);
			}
		}
		paths.Clear();
		List<VehiclePathPoint> list = new List<VehiclePathPoint>(GetComponentsInChildren<VehiclePathPoint>());
		if (list.Count > 0)
		{
			pathPointData.Clear();
			foreach (VehiclePathPoint item in list)
			{
				pathPointData.Add(new PathPointData(item, list));
			}
		}
		entrancePathPoints = Enumerable.ToList(Enumerable.Where(pathPointData, (PathPointData x) => x.type == VehiclePathPointType.entrance));
		pathData = new List<VehiclePathData>();
		foreach (PathPointData entrancePathPoint in entrancePathPoints)
		{
			pathData.AddRange(CreateAllPossiblePathDataFromEntrancePoint(entrancePathPoint));
		}
		if (createEmergencyPaths)
		{
			foreach (PathPointData entrancePathPoint2 in entrancePathPoints)
			{
				pathData.Add(new VehiclePathData(new List<PathPointData>
				{
					entrancePathPoint2,
					GetConnectedPathPoints(entrancePathPoint2)[0],
					entrancePathPoint2
				}, 1));
			}
		}
		if (!blockedByDefault)
		{
			return;
		}
		foreach (VehiclePathData pathDatum in pathData)
		{
			pathDatum.BlockEdge(-1, newBlocked: true);
		}
	}

	private void CreatePathPointObjectsBasedOnData()
	{
		if (pathPointData.Count == 0)
		{
			Debug.LogError(base.name + " has no path point data!");
		}
		else if (GetComponentsInChildren<VehiclePathPoint>().Length != 0)
		{
			Debug.LogError(base.name + " already has path points!");
		}
	}

	private List<VehiclePathData> CreateAllPossiblePathDataFromEntrancePoint(PathPointData entrancePoint)
	{
		List<VehiclePathData> list = new List<VehiclePathData>();
		List<List<PathPointData>> list2 = new List<List<PathPointData>>
		{
			new List<PathPointData> { entrancePoint }
		};
		RecursivelySearchPathsInNeighborPathPoints(list2);
		foreach (List<PathPointData> item in list2)
		{
			list.Add(new VehiclePathData(item, 0));
		}
		return list;
	}

	private void RecursivelySearchPathsInNeighborPathPoints(List<List<PathPointData>> incompletePaths)
	{
		_debugCounter++;
		if (_debugCounter > 50)
		{
			Debug.LogError("Endless Loop");
			return;
		}
		List<List<PathPointData>> list = new List<List<PathPointData>>(incompletePaths);
		int num = 0;
		foreach (List<PathPointData> item in list)
		{
			if (_003CRecursivelySearchPathsInNeighborPathPoints_003Eg__IsCompleted_007C18_0(item))
			{
				continue;
			}
			bool flag = false;
			List<PathPointData> list2 = new List<PathPointData>(item);
			foreach (PathPointData connectedPathPoint in GetConnectedPathPoints(list2[list2.Count - 1]))
			{
				if (list2.Count >= 2 && connectedPathPoint == list2[list2.Count - 2])
				{
					continue;
				}
				if (flag)
				{
					List<PathPointData> list3 = new List<PathPointData>(list2);
					list3.Add(connectedPathPoint);
					if (!_003CRecursivelySearchPathsInNeighborPathPoints_003Eg__IsCompleted_007C18_0(list3))
					{
						num++;
					}
					incompletePaths.Add(list3);
				}
				else
				{
					item.Add(connectedPathPoint);
					flag = true;
					if (!_003CRecursivelySearchPathsInNeighborPathPoints_003Eg__IsCompleted_007C18_0(item))
					{
						num++;
					}
				}
			}
		}
		if (num > 0)
		{
			RecursivelySearchPathsInNeighborPathPoints(incompletePaths);
		}
	}

	private List<PathPointData> GetConnectedPathPoints(PathPointData pathPoint)
	{
		List<PathPointData> list = new List<PathPointData>();
		foreach (int connectedPathPoint in pathPoint.connectedPathPoints)
		{
			list.Add(pathPointData[connectedPathPoint]);
		}
		return list;
	}

	public void PlacementInitialization()
	{
		foreach (VehiclePathData pathDatum in pathData)
		{
			pathDatum.ApplyRotation(segment);
		}
	}

	public void BlockEntrance(int worldDirectionIndex, bool newBlocked)
	{
		int localEdge = (worldDirectionIndex - segment.RotationIndex - segment.Tile.RotationIndex + 12) % 6;
		foreach (VehiclePathData pathDatum in pathData)
		{
			pathDatum.BlockEdge(localEdge, newBlocked);
		}
	}

	public VehicleSegment GetNextSegment(int worldEdge, out bool traversable)
	{
		ElementGroupSegment neighborSegment = segment.GetNeighborSegment(worldEdge);
		if ((bool)neighborSegment && neighborSegment.Tile.State == TileState.placed)
		{
			VehicleSegment component = neighborSegment.GetComponent<VehicleSegment>();
			if ((bool)component)
			{
				traversable = component.GetPathAtEntrance((worldEdge + 3) % 6, Space.World) != null;
				return component;
			}
		}
		traversable = false;
		return null;
	}

	public VehiclePathData GetPathAtEntrance(int entranceEdge, Space space)
	{
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals8.space = space;
		CS_0024_003C_003E8__locals8.entranceEdge = entranceEdge;
		if (Enumerable.Count(pathData, (VehiclePathData x) => ((CS_0024_003C_003E8__locals8.space == Space.World) ? x.EntranceWorldEdge : x.entranceLocalEdge) == CS_0024_003C_003E8__locals8.entranceEdge) == 0)
		{
			return null;
		}
		List<VehiclePathData> list = Enumerable.ToList(Enumerable.Where(pathData, (VehiclePathData x) => ((CS_0024_003C_003E8__locals8.space == Space.World) ? x.EntranceWorldEdge : x.entranceLocalEdge) == CS_0024_003C_003E8__locals8.entranceEdge && !x.ExitBlocked && x.Priority == 0));
		if (list.Count == 0)
		{
			list = Enumerable.ToList(Enumerable.Where(pathData, (VehiclePathData x) => ((CS_0024_003C_003E8__locals8.space == Space.World) ? x.EntranceWorldEdge : x.entranceLocalEdge) == CS_0024_003C_003E8__locals8.entranceEdge && !x.ExitBlocked && x.Priority > 0));
		}
		if (list.Count == 0)
		{
			Debug.LogError("no possible paths!");
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	private void OnDestroy()
	{
		foreach (AffectingAdaptiveSegment affectingAdaptiveSegment in affectingAdaptiveSegments)
		{
			affectingAdaptiveSegment.adaptiveSegment.OnNeighborStateChanged += UpdateNeighborState;
		}
	}

	public void SetupFromReference(VehicleSegment referenceVehicleSegment)
	{
		pathData = new List<VehiclePathData>(referenceVehicleSegment.pathData);
	}

	public VehiclePathData GetPathTowardsExit(int exitEdge, Space space)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals3.exitEdge = exitEdge;
		if (space == Space.Self)
		{
			return Enumerable.First(pathData, (VehiclePathData x) => x.exitLocalEdge == CS_0024_003C_003E8__locals3.exitEdge);
		}
		return Enumerable.First(pathData, (VehiclePathData x) => x.ExitWorldEdge == CS_0024_003C_003E8__locals3.exitEdge);
	}

	internal static bool _003CRecursivelySearchPathsInNeighborPathPoints_003Eg__IsCompleted_007C18_0(List<PathPointData> path)
	{
		if (path.Count > 1)
		{
			return Enumerable.Last(path).type == VehiclePathPointType.entrance;
		}
		return false;
	}
}
