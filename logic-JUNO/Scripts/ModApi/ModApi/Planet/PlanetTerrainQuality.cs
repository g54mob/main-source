using System;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetTerrainQuality : IPlanetTerrainQuality
	{
		public const int DefaultMaxSubdivisionLevel = 12;

		public const int DefaultMinSubdivisionLevel = 3;

		public const long DefaultQuadSphereActivationDistance = 0L;

		public const long DefaultQuadSphereTransitionDistance = 0L;

		public const int DefaultTerrainQuadEdgeVertexCount = 29;

		public const int DefaultWaterQuadEdgeVertexCount = 15;

		public const int MaxQuadEdgeVertexCount = 29;

		public const int MaxQuadSphereSubdivisionLevel = 20;

		public const int MaxWaterQuadEdgeVertexCount = 29;

		public const int MinQuadEdgeVertexCount = 13;

		public const int MinWaterQuadEdgeVertexCount = 13;

		public static readonly PlanetTerrainQuality Default = CreateDefault();

		[SerializeField]
		private int _maxSubdivisionLevel = 12;

		[SerializeField]
		private int _minSubdivisionLevel = 3;

		[SerializeField]
		private long _quadSphereActivationDistance;

		[SerializeField]
		private long _quadSphereTransitionDistance;

		[SerializeField]
		private int _terrainQuadEdgeVertexCount = 29;

		[SerializeField]
		private int _waterQuadEdgeVertexCount = 15;

		public int MaxSubdivisionLevel
		{
			get
			{
				return _maxSubdivisionLevel;
			}
			set
			{
				_maxSubdivisionLevel = value;
			}
		}

		public int MinSubdivisionLevel
		{
			get
			{
				return _minSubdivisionLevel;
			}
			set
			{
				_minSubdivisionLevel = value;
			}
		}

		public long QuadSphereActivationDistance
		{
			get
			{
				return _quadSphereActivationDistance;
			}
			set
			{
				_quadSphereActivationDistance = value;
			}
		}

		public long QuadSphereTransitionDistance
		{
			get
			{
				return _quadSphereTransitionDistance;
			}
			set
			{
				_quadSphereTransitionDistance = value;
			}
		}

		public int TerrainQuadEdgeVertexCount
		{
			get
			{
				return _terrainQuadEdgeVertexCount;
			}
			set
			{
				_terrainQuadEdgeVertexCount = value;
			}
		}

		public int WaterQuadEdgeVertexCount
		{
			get
			{
				return _waterQuadEdgeVertexCount;
			}
			set
			{
				_waterQuadEdgeVertexCount = value;
			}
		}

		public static PlanetTerrainQuality CreateFromXml(XElement xml, PlanetTerrainQuality defaults, int maxSubdivisionAdjustment)
		{
			PlanetTerrainQuality planetTerrainQuality = new PlanetTerrainQuality();
			planetTerrainQuality.TerrainQuadEdgeVertexCount = ((int?)xml.Attribute("terrainQuadEdgeVertexCount")) ?? defaults.TerrainQuadEdgeVertexCount;
			planetTerrainQuality.WaterQuadEdgeVertexCount = ((int?)xml.Attribute("waterQuadEdgeVertexCount")) ?? defaults.WaterQuadEdgeVertexCount;
			planetTerrainQuality.MinSubdivisionLevel = ((int?)xml.Attribute("minSubdivisionLevel")) ?? defaults.MinSubdivisionLevel;
			planetTerrainQuality.MaxSubdivisionLevel = ((int?)xml.Attribute("maxSubdivisionLevel")) ?? defaults.MaxSubdivisionLevel;
			planetTerrainQuality.QuadSphereActivationDistance = ((long?)xml.Attribute("quadSphereActivationDistance")).GetValueOrDefault();
			planetTerrainQuality.QuadSphereTransitionDistance = ((long?)xml.Attribute("quadSphereTransitionDistance")).GetValueOrDefault();
			if (xml.Attribute("maxSubdivisionLevel") != null)
			{
				planetTerrainQuality.MaxSubdivisionLevel += maxSubdivisionAdjustment;
			}
			return planetTerrainQuality;
		}

		public double GetEstimatedDistanceBetweenVertices(double radius)
		{
			return System.Math.PI * 2.0 * radius / 4.0 / (System.Math.Pow(2.0, MaxSubdivisionLevel) * (double)TerrainQuadEdgeVertexCount);
		}

		public XElement SaveXml(XElement xml, PlanetTerrainQuality defaults)
		{
			if (defaults == null || defaults.TerrainQuadEdgeVertexCount != TerrainQuadEdgeVertexCount)
			{
				xml.SetAttributeValue("terrainQuadEdgeVertexCount", TerrainQuadEdgeVertexCount);
			}
			if (defaults == null || defaults.WaterQuadEdgeVertexCount != WaterQuadEdgeVertexCount)
			{
				xml.SetAttributeValue("waterQuadEdgeVertexCount", WaterQuadEdgeVertexCount);
			}
			if (defaults == null || defaults.MinSubdivisionLevel != MinSubdivisionLevel)
			{
				xml.SetAttributeValue("minSubdivisionLevel", MinSubdivisionLevel);
			}
			if (defaults == null || defaults.MaxSubdivisionLevel != MaxSubdivisionLevel)
			{
				xml.SetAttributeValue("maxSubdivisionLevel", MaxSubdivisionLevel);
			}
			if (defaults == null || defaults.QuadSphereActivationDistance != QuadSphereActivationDistance)
			{
				xml.SetAttributeValue("quadSphereActivationDistance", QuadSphereActivationDistance);
			}
			if (defaults == null || defaults.QuadSphereTransitionDistance != QuadSphereTransitionDistance)
			{
				xml.SetAttributeValue("quadSphereTransitionDistance", QuadSphereTransitionDistance);
			}
			return xml;
		}

		private static PlanetTerrainQuality CreateDefault()
		{
			return new PlanetTerrainQuality
			{
				MaxSubdivisionLevel = 12,
				MinSubdivisionLevel = 3,
				TerrainQuadEdgeVertexCount = 29,
				WaterQuadEdgeVertexCount = 15,
				QuadSphereActivationDistance = 0L,
				QuadSphereTransitionDistance = 0L
			};
		}
	}
}
