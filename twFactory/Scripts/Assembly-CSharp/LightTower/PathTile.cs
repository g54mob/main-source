using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LightTower
{
	public class PathTile : Tile
	{
		public enum EPathTileType
		{
			Straigth = 0,
			Curve = 1,
			Cross3 = 2
		}

		[Header("Path Tile")]
		[SerializeField]
		private EPathTileType pathTileType;

		[SerializeField]
		private List<Path> northPaths;

		[SerializeField]
		private List<Path> eastPaths;

		[SerializeField]
		private List<Path> southPaths;

		[SerializeField]
		private List<Path> westPaths;

		[SerializeField]
		private List<PathTile> nextPathTiles;

		private List<PathTile> previousPathTiles;

		private bool pathInitializated;

		private bool isVisible;

		private int tilesFromEnd;

		private List<Enemy> currentEnemies;

		public EPathTileType PathTileType => pathTileType;

		public bool IsVisible
		{
			get
			{
				return isVisible;
			}
			set
			{
				isVisible = value;
			}
		}

		public List<PathTile> PreviousPathTiles => previousPathTiles;

		public List<PathTile> NextPathTiles
		{
			get
			{
				return nextPathTiles;
			}
			private set
			{
				nextPathTiles = value;
			}
		}

		public int TilesFromEnd
		{
			get
			{
				return tilesFromEnd;
			}
			private set
			{
				tilesFromEnd = value;
			}
		}

		public List<Enemy> CurrentEnemies
		{
			get
			{
				return currentEnemies;
			}
			set
			{
				currentEnemies = value;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			CurrentEnemies = new List<Enemy>();
		}

		protected override void Start()
		{
			base.Start();
			InitPaths();
		}

		public void InitPaths()
		{
			if (pathInitializated)
			{
				return;
			}
			previousPathTiles = new List<PathTile>();
			if (NextPathTiles.Count > 0)
			{
				foreach (PathTile nextPathTile in NextPathTiles)
				{
					nextPathTile.InitPaths();
					nextPathTile.previousPathTiles.AddUnique(this);
					if (nextPathTile.TilesFromEnd > TilesFromEnd - 1)
					{
						TilesFromEnd = nextPathTile.TilesFromEnd + 1;
					}
				}
			}
			PathToWorldspace(northPaths);
			PathToWorldspace(eastPaths);
			PathToWorldspace(southPaths);
			PathToWorldspace(westPaths);
			DeleteInvalidPaths();
			CalculatePathsNextPositionDistances(northPaths);
			CalculatePathsNextPositionDistances(eastPaths);
			CalculatePathsNextPositionDistances(southPaths);
			CalculatePathsNextPositionDistances(westPaths);
			pathInitializated = true;
		}

		public bool IsPathSplitter()
		{
			return NextPathTiles.Count > 1;
		}

		public bool IsPathJoiner()
		{
			if (previousPathTiles.Count > 1)
			{
				return NextPathTiles.Count <= 1;
			}
			return false;
		}

		private void DeleteInvalidPaths()
		{
			if (NextPathTiles.Count == 0)
			{
				return;
			}
			List<Vector3> list = new List<Vector3>();
			foreach (PathTile nextPathTile in NextPathTiles)
			{
				foreach (Path allPath in nextPathTile.GetAllPaths())
				{
					list.Add(allPath.positions[0]);
				}
			}
			Vector3 auxPathFirstPosition;
			Vector3 auxPathLastPosition;
			for (int num = northPaths.Count - 1; num >= 0; num--)
			{
				auxPathFirstPosition = northPaths[num].positions[0];
				auxPathLastPosition = northPaths[num].positions[northPaths[num].positions.Length - 1];
				if (!list.Any((Vector3 x) => (x - auxPathLastPosition).sqrMagnitude < 0.01f) || list.Any((Vector3 x) => (x - auxPathFirstPosition).sqrMagnitude < 0.01f))
				{
					northPaths.RemoveAt(num);
				}
			}
			for (int num2 = eastPaths.Count - 1; num2 >= 0; num2--)
			{
				auxPathFirstPosition = eastPaths[num2].positions[0];
				auxPathLastPosition = eastPaths[num2].positions[eastPaths[num2].positions.Length - 1];
				if (!list.Any((Vector3 x) => (x - auxPathLastPosition).sqrMagnitude < 0.01f) || list.Any((Vector3 x) => (x - auxPathFirstPosition).sqrMagnitude < 0.01f))
				{
					eastPaths.RemoveAt(num2);
				}
			}
			for (int num3 = southPaths.Count - 1; num3 >= 0; num3--)
			{
				auxPathFirstPosition = southPaths[num3].positions[0];
				auxPathLastPosition = southPaths[num3].positions[southPaths[num3].positions.Length - 1];
				if (!list.Any((Vector3 x) => (x - auxPathLastPosition).sqrMagnitude < 0.01f) || list.Any((Vector3 x) => (x - auxPathFirstPosition).sqrMagnitude < 0.01f))
				{
					southPaths.RemoveAt(num3);
				}
			}
			for (int num4 = westPaths.Count - 1; num4 >= 0; num4--)
			{
				auxPathFirstPosition = westPaths[num4].positions[0];
				auxPathLastPosition = westPaths[num4].positions[westPaths[num4].positions.Length - 1];
				if (!list.Any((Vector3 x) => (x - auxPathLastPosition).sqrMagnitude < 0.01f) || list.Any((Vector3 x) => (x - auxPathFirstPosition).sqrMagnitude < 0.01f))
				{
					westPaths.RemoveAt(num4);
				}
			}
		}

		private void PathToWorldspace(List<Path> paths)
		{
			foreach (Path path in paths)
			{
				for (int i = 0; i < path.positions.Length; i++)
				{
					path.positions[i] = base.transform.TransformPoint(path.positions[i]);
				}
			}
		}

		private void CalculatePathsNextPositionDistances(List<Path> paths)
		{
			foreach (Path path in paths)
			{
				path.distanceToPosition = new float[path.positions.Length];
				path.distanceToPosition[0] = 0f;
				for (int i = 1; i < path.distanceToPosition.Length; i++)
				{
					path.distanceToPosition[i] = (path.positions[i] - path.positions[i - 1]).magnitude;
				}
			}
		}

		public Path GetPath(EOrientation orientation, int idx = -1)
		{
			List<Path> list = null;
			switch (LTFunctionLibrary.OrientationToLocalSpace(orientation, base.transform))
			{
			case EOrientation.North:
				list = northPaths;
				break;
			case EOrientation.East:
				list = eastPaths;
				break;
			case EOrientation.South:
				list = southPaths;
				break;
			case EOrientation.West:
				list = westPaths;
				break;
			}
			if (list == null || list.Count == 0)
			{
				return null;
			}
			if (idx == -1)
			{
				return list[Random.Range(0, list.Count)];
			}
			return list[idx];
		}

		public List<Path> GetAllPaths()
		{
			List<Path> list = new List<Path>();
			list.AddRange(northPaths);
			list.AddRange(eastPaths);
			list.AddRange(southPaths);
			list.AddRange(westPaths);
			return list;
		}

		public PathTile GetNextPathTile(Vector3 position)
		{
			float num = 9999999f;
			PathTile result = null;
			foreach (PathTile nextPathTile in NextPathTiles)
			{
				float sqrMagnitude = (nextPathTile.transform.position - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = nextPathTile;
				}
			}
			return result;
		}
	}
}
