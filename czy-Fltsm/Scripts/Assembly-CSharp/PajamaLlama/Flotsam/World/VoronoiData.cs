using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Procedural;
using PajamaLlama.Utilities;
using PajamaLlama.YieldInstructions;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	[CreateAssetMenu(fileName = "Voronoi Data", menuName = "Flotsam/Procedural/Voronoi/Voronoi Data")]
	public class VoronoiData : TileGeneratorBase
	{
		public enum GenerationMethod
		{
			Random = 0,
			PoissonDisk = 1
		}

		[SerializeField]
		[EditorInspectorGUIField("Voronoi", 0, null)]
		private bool _randomSeed;

		[SerializeField]
		[EditorInspectorGUIField("Voronoi", 0, null)]
		private int _seed;

		[SerializeField]
		[EditorInspectorGUIField("Voronoi", 0, null)]
		private GenerationMethod _generationMethod;

		[SerializeField]
		[EditorInspectorGUIField("Voronoi", 0, null)]
		[ConditionalEnumHide("_generationMethod", 0, false, HideInInspector = true)]
		private int _randomSiteCount;

		[SerializeField]
		[EditorInspectorGUIField("Voronoi", 0, null)]
		[ConditionalEnumHide("_generationMethod", 0, false, HideInInspector = true)]
		private int _randomSiteEdgePadding = 250;

		[SerializeField]
		[EditorInspectorGUIField("Voronoi", 0, null)]
		[ConditionalEnumHide("_generationMethod", 1, false, HideInInspector = true)]
		private PoissonDiskSamplerWithBounds _poissonDiskSiteGenerator;

		[SerializeField]
		[EditorInspectorGUIField("Voronoi", 0, "Bounds")]
		private Rect _voronoiBounds = new Rect(-4000f, -4000f, 8000f, 8000f);

		[SerializeField]
		private List<VoronoiRegion> _regions;

		[SerializeField]
		private Texture _worldMapTexture;

		[SerializeField]
		private Vector3 _worldMapNormal = Vector3.up;

		[Header("Editor")]
		[SerializeField]
		private Material[] _regionMaterials;

		[SerializeField]
		private HandmadeTileGenerator.Townheart _townheart;

		[SerializeField]
		private List<HandmadeTileGenerator.Landmark> _landmarks;

		[SerializeField]
		private List<HandmadeTileGenerator.PointOfInterest> _pointsOfInterest;

		[SerializeField]
		private List<HandmadeTileGenerator.Road> _roads;

		[Header("Narrative")]
		[SerializeField]
		private bool _isEndTile;

		private List<Vector2> _siteCache;

		private Mesh _cachedMesh;

		private static Rectangle _rectangle = new Rectangle();

		public bool RandomSeed => _randomSeed;

		public Rect VoronoiBounds => _voronoiBounds;

		public List<VoronoiRegion> Regions => _regions;

		public override Rect MinimumBounds => _voronoiBounds;

		public override float Scale
		{
			get
			{
				return 1f;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override bool IsEndTile => _isEndTile;

		public override void Initialize(bool isStartingTile)
		{
		}

		public override IEnumerator Generate(IWorldTile worldTile)
		{
			yield return GenerateRegionsAndRoads(worldTile);
			foreach (HandmadeTileGenerator.Landmark landmark in _landmarks)
			{
				LandmarkSpawner landmarkSpawner = new LandmarkSpawner(landmark.ReturnLandmarkBehaviour(), landmark.Position, landmark.Rotation);
				landmarkSpawner.SetScoutingState(landmark.ScoutingState);
				worldTile.AddLandmarkSpawner(landmarkSpawner);
			}
			yield return null;
			foreach (HandmadeTileGenerator.PointOfInterest item in _pointsOfInterest)
			{
				worldTile.AddPointOfInterestSpawner(new PointOfInterestSpawner(item.PointOfInterestProperties, item.Position));
			}
		}

		public override void Restore(IWorldTile worldTile)
		{
			CoroutineRunner.RunCoroutine(GenerateRegionsAndRoads(worldTile));
		}

		private IEnumerator GenerateRegionsAndRoads(IWorldTile worldTile)
		{
			VoronoiTask task = new VoronoiTask(GenerateSites(), _voronoiBounds);
			if (ThreadPoolManager.QueueTask(task))
			{
				yield return new WaitForThreadpoolManagerTask(task);
			}
			else
			{
				Voronoi.Generate(GenerateSites(), _voronoiBounds);
			}
			using ListPool<VoronoiWorldRegion>.List worldRegions = ListPool<VoronoiWorldRegion>.Get(_regions.Count);
			yield return PopulateRegions(worldRegions);
			yield return null;
			foreach (VoronoiWorldRegion item in worldRegions)
			{
				worldTile.AddRegion(item);
			}
			worldTile.PopulateRegionNeighbors();
			yield return null;
			foreach (HandmadeTileGenerator.Road road in _roads)
			{
				if (road.Nodes.Length == 0)
				{
					Debug.LogException(new Exception("A road with 0 nodes was encoutered during WorldTile generation"));
				}
				else
				{
					worldTile.AddRoadSpawner(new RoadSpawner(road));
				}
			}
			yield return null;
			_cachedMesh = GenerateMesh();
			yield return null;
		}

		private IEnumerator PopulateRegions(List<VoronoiWorldRegion> worldRegions)
		{
			foreach (VoronoiRegion region in _regions)
			{
				worldRegions.Add(new VoronoiWorldRegion(region, _voronoiBounds));
				yield return null;
			}
			foreach (VoronoiWorldRegion worldRegion in worldRegions)
			{
				worldRegion.PopulateNeighbors(worldRegions);
			}
		}

		public override bool TryReturnTownheartStartPosition(out Vector3 position)
		{
			if (_townheart != null)
			{
				position = _townheart.GetPosition();
				return true;
			}
			position = default(Vector3);
			return false;
		}

		public List<Vector2> GenerateSites()
		{
			if (_siteCache == null)
			{
				_siteCache = new List<Vector2>(1024);
			}
			else
			{
				_siteCache.Clear();
			}
			UnityEngine.Random.State state = UnityEngine.Random.state;
			UnityEngine.Random.InitState(_seed);
			switch (_generationMethod)
			{
			case GenerationMethod.Random:
			{
				Rect rect = new Rect(_voronoiBounds);
				rect.xMin += _randomSiteEdgePadding;
				rect.yMin += _randomSiteEdgePadding;
				rect.xMax -= _randomSiteEdgePadding;
				rect.yMax -= _randomSiteEdgePadding;
				for (int i = 0; i < _randomSiteCount; i++)
				{
					_siteCache.Add(rect.RandomPosition());
				}
				break;
			}
			case GenerationMethod.PoissonDisk:
				_poissonDiskSiteGenerator.GenerateSamples(_voronoiBounds);
				_siteCache.AddRange(_poissonDiskSiteGenerator.Samples);
				break;
			}
			UnityEngine.Random.state = state;
			return _siteCache;
		}

		public bool TryGetRegionMaterial(out Material material, WorldRegionType region)
		{
			material = null;
			if (_regionMaterials == null)
			{
				return false;
			}
			int num = (int)(region - 1);
			if (0 <= num && num < _regionMaterials.Length)
			{
				material = _regionMaterials[num];
				return true;
			}
			return material != null;
		}

		public Mesh GenerateMesh()
		{
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			List<Vector2> list3 = new List<Vector2>();
			foreach (VoronoiRegion region in _regions)
			{
				region.GenerateTriangles(list, list2, list3);
			}
			Vector3[] array = new Vector3[list.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _worldMapNormal;
			}
			return new Mesh
			{
				vertices = list.ToArray(),
				triangles = list2.ToArray(),
				uv = list3.ToArray(),
				normals = array
			};
		}

		public override bool TryReturnWorldMapRegionMeshAndBounds(out Mesh mesh, out Rect bounds)
		{
			if (_cachedMesh == null)
			{
				_cachedMesh = GenerateMesh();
			}
			mesh = _cachedMesh;
			bounds = _voronoiBounds;
			return mesh != null;
		}

		public bool IntersectsWithRoad(Polygon2DBase polygon, float width)
		{
			foreach (HandmadeTileGenerator.Road road in _roads)
			{
				if (road.Nodes.Length < 1)
				{
					continue;
				}
				Vector2 vector = road.Nodes[0];
				for (int i = 1; i < road.Nodes.Length; i++)
				{
					Vector2 vector2 = road.Nodes[i];
					_rectangle.Set(vector, vector2 - vector, width);
					if (polygon.IsOverlapping(_rectangle))
					{
						return true;
					}
					vector = vector2;
				}
			}
			return false;
		}

		public override bool HasRegionOfType(params WorldRegionType[] worldRegionTypes)
		{
			foreach (VoronoiRegion region in _regions)
			{
				if (worldRegionTypes.Contains(region.Type))
				{
					return true;
				}
			}
			return false;
		}
	}
}
