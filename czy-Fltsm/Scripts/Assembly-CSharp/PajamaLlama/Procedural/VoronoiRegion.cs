using System;
using System.Collections.Generic;
using External.Zalgo2462.VoronoiLib.Structures;
using PajamaLlama.Flotsam.Narrative;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using UnityEngine;

namespace PajamaLlama.Procedural
{
	[Serializable]
	public class VoronoiRegion : IRegion
	{
		[SerializeField]
		[HideInInspector]
		private List<int> _siteIndices;

		[SerializeField]
		private WorldRegionType _region;

		[SerializeField]
		private PollutionLevels _pollutionLevel;

		[SerializeField]
		private QuestProperties _questProperties;

		[SerializeField]
		[ConditionalHide("_questProperties", true)]
		private QuestGiver _questGiver;

		[SerializeReference]
		[InstantiateSerializeReference]
		private ScenarioTriggerableBase[] _onEnterTriggerables;

		public List<int> SiteIndices => _siteIndices;

		public WorldRegionType Type => _region;

		public PollutionLevels PollutionLevel => _pollutionLevel;

		public QuestProperties QuestProperties => _questProperties;

		public QuestGiver QuestGiver => _questGiver;

		public List<VEdge> BorderEdges { get; private set; }

		public Rect Bounds => ReturnBounds();

		public ScenarioTriggerableBase[] EnterTriggerables => _onEnterTriggerables;

		public VoronoiRegion(IEnumerable<int> voronoiSiteCollection, WorldRegionType region)
		{
			_siteIndices = new List<int>(voronoiSiteCollection);
			_region = region;
			UpdateBorderEdges();
		}

		public void AddSites(IList<int> sitesToAdd)
		{
			if (SiteIndices.AddUniqueRange(sitesToAdd))
			{
				UpdateBorderEdges();
			}
		}

		public bool RemoveSite(int index)
		{
			if (SiteIndices.Remove(index))
			{
				UpdateBorderEdges();
				return true;
			}
			return false;
		}

		public void UpdateBorderEdges(bool sort = false)
		{
			if (BorderEdges == null)
			{
				BorderEdges = new List<VEdge>();
			}
			else
			{
				BorderEdges.Clear();
			}
			if (_siteIndices == null)
			{
				return;
			}
			foreach (int siteIndex in _siteIndices)
			{
				foreach (VEdge item in Voronoi.Sites[siteIndex].Cell)
				{
					if (!BorderEdges.Remove(item))
					{
						BorderEdges.Add(item);
					}
				}
			}
			if (sort)
			{
				SortBorderEdges();
			}
		}

		private void SortBorderEdges()
		{
			if (BorderEdges.IsNullOrEmpty())
			{
				return;
			}
			using PooledList<VEdge> pooledList = PooledList<VEdge>.Get();
			VEdge next = BorderEdges[0];
			VEdge vEdge = null;
			do
			{
				BorderEdges.Remove(next);
				pooledList.Add(next);
				vEdge = next;
			}
			while (TryGetNextEdge(out next, vEdge, BorderEdges));
			BorderEdges.Clear();
			BorderEdges.AddRange(pooledList);
		}

		private bool TryGetNextEdge(out VEdge next, VEdge previous, List<VEdge> edges)
		{
			for (int i = 0; i < edges.Count; i++)
			{
				next = edges[i];
				if (next.Start == previous.End)
				{
					return true;
				}
				if (next.End == previous.End)
				{
					next.Flip();
					return true;
				}
			}
			next = null;
			return false;
		}

		public void GenerateTriangles(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs)
		{
			Vector2 regionUVOffset = GetRegionUVOffset();
			foreach (int siteIndex in _siteIndices)
			{
				Voronoi.Sites[siteIndex].GenerateMeshTriangles(vertices, triangles, uvs, regionUVOffset);
			}
		}

		private Vector2 GetRegionUVOffset()
		{
			switch (Type)
			{
			case WorldRegionType.Forest:
				return new Vector2(0f, 0.75f);
			case WorldRegionType.Rural:
				return new Vector2(0.25f, 0.75f);
			case WorldRegionType.City:
				return new Vector2(0.5f, 0.75f);
			case WorldRegionType.PollutedWoods:
				return new Vector2(0.75f, 0.75f);
			case WorldRegionType.Farmland:
				return new Vector2(0f, 0.5f);
			case WorldRegionType.Shallow:
				return new Vector2(0.25f, 0.5f);
			case WorldRegionType.Industry:
				return new Vector2(0.75f, 0.5f);
			case WorldRegionType.Utopia:
				return new Vector2(0f, 0.25f);
			case WorldRegionType.PollutionBelt:
				return new Vector2(0.25f, 0.25f);
			default:
				Debug.LogError("Region type not supported!");
				return Vector2.zero;
			}
		}

		public bool ReturnContainsPosition(Vector2 position)
		{
			if (Voronoi.Sites.IsNullOrEmpty())
			{
				return false;
			}
			foreach (int siteIndex in _siteIndices)
			{
				VoronoiSite voronoiSite = Voronoi.Sites[siteIndex];
				if (voronoiSite.Polygon != null && voronoiSite.Polygon.Bounds.Contains(position) && voronoiSite.Polygon.ReturnPointIsOverlapping(position))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryReturnDistanceToBorder(Vector2 tilePosition, out float distance)
		{
			foreach (int siteIndex in _siteIndices)
			{
				VoronoiSite voronoiSite = Voronoi.Sites[siteIndex];
				if (voronoiSite.Polygon.ReturnPointIsOverlapping(tilePosition))
				{
					distance = ReturnDistanceToBorder(voronoiSite, tilePosition, out var _);
					return true;
				}
			}
			distance = float.MaxValue;
			return false;
		}

		private float ReturnDistanceToBorder(VoronoiSite site, Vector2 position, out Vector2 projection)
		{
			projection = Vector2.zero;
			if (BorderEdges == null)
			{
				return 0f;
			}
			float num = float.MaxValue;
			foreach (VEdge item in site.Cell)
			{
				if (BorderEdges.Contains(item))
				{
					Vector2 vector = new Polygon2DLine(item.Start.ToVector2(), item.End.ToVector2()).ReturnProjection(position);
					float num2 = position.DistanceToSquared(vector);
					if (num2 < num)
					{
						projection = vector;
						num = num2;
					}
				}
			}
			return Mathf.Sqrt(num);
		}

		public Rect ReturnBounds()
		{
			Vector2 vector = new Vector2(float.MaxValue, float.MaxValue);
			Vector2 vector2 = new Vector2(float.MinValue, float.MinValue);
			foreach (int siteIndex in SiteIndices)
			{
				VoronoiSite voronoiSite = Voronoi.Sites[siteIndex];
				vector = Vector2.Min(vector, voronoiSite.Polygon.Bounds.min);
				vector2 = Vector2.Max(vector2, voronoiSite.Polygon.Bounds.max);
			}
			return new Rect(vector, vector2 - vector);
		}

		public float ReturnSurface()
		{
			float num = 0f;
			foreach (int siteIndex in _siteIndices)
			{
				num += Voronoi.Sites[siteIndex].ComputeSurface();
			}
			return num;
		}

		public float ReturnOverlap(Polygon2DBase polygon)
		{
			float num = 0f;
			foreach (int siteIndex in _siteIndices)
			{
				if (Voronoi.Sites[siteIndex].Polygon.TryGetOverlap(polygon, out var overlap))
				{
					num += overlap;
				}
			}
			return num;
		}

		public Vector2 ReturnPositionInRegion()
		{
			return Voronoi.Sites[_siteIndices[UnityEngine.Random.Range(0, _siteIndices.Count)]].Position;
		}
	}
}
