using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	[CreateAssetMenu(fileName = "Simple Landmark Generator", menuName = "Flotsam/Procedural Generation/Landmarks/Simple Generator", order = 4)]
	public class SimpleLandmarkGenerator : LandmarkGeneratorBase
	{
		public class Tile
		{
			public Rect Bounds;

			public int Overlap;

			public int DistanceFromBorder;

			public bool IntersectsWithRoad;

			public Tile(Rect bounds, int overlap, bool intersectsWithRoad)
			{
				Bounds = bounds;
				Overlap = overlap;
				DistanceFromBorder = 32;
				IntersectsWithRoad = intersectsWithRoad;
			}
		}

		public class Cluster : ILandmarkCluster
		{
			public Tile CenterTile;

			public ClusterLandmarkProvider LandmarkProvider;

			public Vector2 Position => CenterTile.Bounds.center;

			public int Count { get; private set; }

			public Cluster(Tile centerTile)
			{
				CenterTile = centerTile;
			}

			public void Reset()
			{
				Count = 0;
			}

			public void Add(ILandmarkBehaviourProvider landmark, Vector2 position)
			{
				Count++;
			}
		}

		private float BORDER_OVERLAP_THRESHOLD = 100f;

		[Header("Cluster Placement")]
		[SerializeField]
		private int _tilesPerCluster = 25;

		[SerializeField]
		private float _clusterRadius = 250f;

		[SerializeField]
		private Vector2 _sectorSize = new Vector2(100f, 100f);

		[Header("Clusters Spawning")]
		[SerializeField]
		private LandmarkClusterGeneratorBase _clusterGenerator;

		private Tile[,] _grid;

		private int _gridWidth;

		private int _gridHeight;

		private Rect _gridBounds;

		private Vector2 _tileSize;

		private int _spawnTileCount;

		private int _maximumDistanceFromBorder;

		private ILandmarkEditor _landmarkEditor;

		private bool _showGrid;

		private static List<Tile> _tiles = new List<Tile>();

		private static List<Cluster> _clusters = new List<Cluster>();

		private static List<Landmark> _landmarks = new List<Landmark>();

		public override List<Landmark> GeneratedLandmarks => _landmarks;

		public override void Run(IRegion region)
		{
		}

		public override bool IsValidPosition(Vector2 position)
		{
			if (_grid == null || !_gridBounds.Contains(position))
			{
				return false;
			}
			Vector2 vector = position - _gridBounds.position;
			int num = Mathf.FloorToInt(vector.x / _tileSize.x);
			int num2 = Mathf.FloorToInt(vector.y / _tileSize.y);
			return 0 < _grid[num, num2].DistanceFromBorder;
		}

		public override void AddLandmark(ILandmarkBehaviourProvider landmarkBehaviourProvider, Vector2 position)
		{
			_landmarkEditor?.AddLandmark(landmarkBehaviourProvider, position);
		}

		private void GenerateGrid(VoronoiData data, IRegion region)
		{
			_gridWidth = Mathf.RoundToInt(region.Bounds.width / _sectorSize.x);
			_gridHeight = Mathf.RoundToInt(region.Bounds.height / _sectorSize.y);
			_gridBounds = region.Bounds;
			_tileSize = new Vector2(region.Bounds.width / (float)_gridWidth, region.Bounds.height / (float)_gridHeight);
			float num = _tileSize.x * _tileSize.y;
			_grid = new Tile[_gridWidth, _gridHeight];
			Vector2 position = default(Vector2);
			for (int i = 0; i < _gridHeight; i++)
			{
				for (int j = 0; j < _gridWidth; j++)
				{
					position.x = region.Bounds.position.x + (float)j * _tileSize.x;
					position.y = region.Bounds.position.y + (float)i * _tileSize.y;
					Rect rect = new Rect(position, _tileSize);
					Polygon2DBase tempPolygon = rect.GetTempPolygon();
					float num2 = region.ReturnOverlap(tempPolygon);
					Tile tile = new Tile(rect, Mathf.RoundToInt(Mathf.Clamp01(num2 / num) * 100f), num2 != 0f && data.IntersectsWithRoad(tempPolygon, 75f));
					_grid[j, i] = tile;
				}
			}
			for (int k = 0; k < _gridHeight; k++)
			{
				for (int l = 0; l < _gridWidth; l++)
				{
					Tile tile = _grid[l, k];
					if (tile.Overlap <= 0)
					{
						tile.DistanceFromBorder = -1;
					}
					else if ((float)tile.Overlap < BORDER_OVERLAP_THRESHOLD)
					{
						tile.DistanceFromBorder = 0;
					}
					else
					{
						tile.DistanceFromBorder = ReturnNeighborDistanceFromBorder(l, k) + 1;
					}
				}
			}
			_maximumDistanceFromBorder = 0;
			_spawnTileCount = 0;
			int gridHeight = _gridHeight;
			while (0 < gridHeight--)
			{
				int gridWidth = _gridWidth;
				while (0 < gridWidth--)
				{
					Tile tile = _grid[gridWidth, gridHeight];
					if (BORDER_OVERLAP_THRESHOLD <= (float)tile.Overlap)
					{
						tile.DistanceFromBorder = Mathf.Min(ReturnNeighborDistanceFromBorder(gridWidth, gridHeight) + 1, tile.DistanceFromBorder);
						if (_maximumDistanceFromBorder < tile.DistanceFromBorder)
						{
							_maximumDistanceFromBorder = tile.DistanceFromBorder;
						}
						if (!tile.IntersectsWithRoad)
						{
							_spawnTileCount++;
						}
					}
				}
			}
			Debug.Log($"{_spawnTileCount} tiles with maximum distance from border: {_maximumDistanceFromBorder}");
			_showGrid = true;
		}

		private void GenerateClusters()
		{
			int num = Mathf.RoundToInt(_spawnTileCount / _tilesPerCluster);
			int maximumDistanceFromBorder = _maximumDistanceFromBorder;
			_ = _clusterRadius;
			_clusters.Clear();
			while (_clusters.Count < num && 0 < maximumDistanceFromBorder)
			{
				List<Tile> list = ReturnTiles(maximumDistanceFromBorder--);
				while (_clusters.Count < num && list.Count > 0)
				{
					int index = Random.Range(0, list.Count);
					Tile tile = list[index];
					if (CanTileBeClusterCenterTile(tile))
					{
						_clusters.Add(new Cluster(tile));
					}
					list.RemoveAt(index);
				}
			}
			_showGrid = true;
		}

		private void GenerateLandmarks(ILandmarkEditor landmarkEditor, IRegion region)
		{
			if (_clusters.Count == 0)
			{
				return;
			}
			foreach (Cluster cluster in _clusters)
			{
				cluster.Reset();
			}
			_landmarkEditor = landmarkEditor;
			_landmarkEditor.RemoveLandmarksInRegion(region);
			_clusterGenerator.Initialize(this);
			_clusterGenerator.Run(region, _clusters);
			_showGrid = false;
		}

		private int ReturnNeighborDistanceFromBorder(int x, int y)
		{
			int num = x + 1;
			int num2 = y + 1;
			int num3 = 32;
			for (int i = y - 1; i <= num2; i++)
			{
				for (int j = x - 1; j <= num; j++)
				{
					if (j != x || i != y)
					{
						int num4 = ReturnDistanceFromBorder(j, i);
						if (num4 < num3)
						{
							num3 = num4;
						}
					}
				}
			}
			return num3;
		}

		private int ReturnDistanceFromBorder(int x, int y)
		{
			if (x < 0 || _gridWidth <= x || y < 0 || _gridHeight <= y)
			{
				return -1;
			}
			return _grid[x, y].DistanceFromBorder;
		}

		private List<Tile> ReturnTiles(int distanceFromBorder)
		{
			_tiles.Clear();
			int gridHeight = _gridHeight;
			while (0 < gridHeight--)
			{
				int gridWidth = _gridWidth;
				while (0 < gridWidth--)
				{
					Tile tile = _grid[gridWidth, gridHeight];
					if (tile.DistanceFromBorder == distanceFromBorder)
					{
						_tiles.Add(tile);
					}
				}
			}
			return _tiles;
		}

		private bool CanTileBeClusterCenterTile(Tile tile)
		{
			float num = _clusterRadius * 2f;
			if (tile.IntersectsWithRoad)
			{
				return false;
			}
			foreach (Cluster cluster in _clusters)
			{
				if (Vector2.Distance(tile.Bounds.center, cluster.CenterTile.Bounds.center) < num)
				{
					return false;
				}
			}
			return true;
		}

		private bool IsClusterCenterTile(Tile tile)
		{
			foreach (Cluster cluster in _clusters)
			{
				if (cluster.CenterTile == tile)
				{
					return true;
				}
			}
			return false;
		}
	}
}
