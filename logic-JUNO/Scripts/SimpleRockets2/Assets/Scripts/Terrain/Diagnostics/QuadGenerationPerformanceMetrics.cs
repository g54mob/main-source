using System;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts.Terrain.Diagnostics
{
	[Serializable]
	public class QuadGenerationPerformanceMetrics
	{
		private readonly object _lock = new object();

		[SerializeField]
		private QuadGenerationPerformanceMetric _allQuadData;

		[SerializeField]
		private QuadGenerationPerformanceMetric _boundingBox;

		[SerializeField]
		private QuadGenerationPerformanceMetric _normalsAndColor;

		[SerializeField]
		private QuadGenerationPerformanceMetric _skirtData;

		[SerializeField]
		private QuadGenerationPerformanceMetric _terrainMeshData;

		[SerializeField]
		private QuadGenerationPerformanceMetric _terrainPoints;

		[SerializeField]
		private QuadGenerationPerformanceMetric _terrainTangents;

		[SerializeField]
		private QuadGenerationPerformanceMetric _vertexColor;

		[SerializeField]
		private QuadGenerationPerformanceMetric _vertexData;

		private bool _warmup = true;

		[SerializeField]
		private QuadGenerationPerformanceMetric _waterMeshData;

		[SerializeField]
		private QuadGenerationPerformanceMetric _waterTangents;

		public QuadGenerationPerformanceMetric AllQuadData => _allQuadData;

		public QuadGenerationPerformanceMetric BoundingBox => _boundingBox;

		public QuadGenerationPerformanceMetric NormalsAndColor => _normalsAndColor;

		public QuadGenerationPerformanceMetric SkirtData => _skirtData;

		public QuadGenerationPerformanceMetric TerrainMeshData => _terrainMeshData;

		public QuadGenerationPerformanceMetric TerrainPoints => _terrainPoints;

		public QuadGenerationPerformanceMetric TerrainTangents => _terrainTangents;

		public QuadGenerationPerformanceMetric VertexColor => _vertexColor;

		public QuadGenerationPerformanceMetric VertexData => _vertexData;

		public QuadGenerationPerformanceMetric WaterMeshData => _waterMeshData;

		public QuadGenerationPerformanceMetric WaterTangents => _waterTangents;

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void Update(QuadGenerationPerformanceTracker performanceTracker)
		{
			lock (_lock)
			{
				if (_warmup)
				{
					_warmup = false;
					return;
				}
				double num = performanceTracker.AllQuadDataTime();
				double totalTime = AllQuadData.TotalTime + num;
				_allQuadData.Update(num, totalTime);
				_boundingBox.Update(performanceTracker.BoundingBoxTime(), totalTime);
				_vertexData.Update(performanceTracker.VertexDataTime(), totalTime);
				_terrainPoints.Update(performanceTracker.TerrainPointsTime(), totalTime);
				_normalsAndColor.Update(performanceTracker.NormalsAndColorTime(), totalTime);
				_vertexColor.Update(performanceTracker.VertexColorTime(), totalTime);
				_skirtData.Update(performanceTracker.SkirtDataTime(), totalTime);
				_terrainMeshData.Update(performanceTracker.TerrainMeshDataTime(), totalTime);
				_waterMeshData.Update(performanceTracker.WaterMeshDataTime(), totalTime);
				_terrainTangents.Update(performanceTracker.TerrainTangentsTime(), totalTime);
				_waterTangents.Update(performanceTracker.WaterTangentsTime(), totalTime);
			}
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		private void Initialize()
		{
			_allQuadData = new QuadGenerationPerformanceMetric();
			_boundingBox = new QuadGenerationPerformanceMetric();
			_vertexData = new QuadGenerationPerformanceMetric();
			_terrainPoints = new QuadGenerationPerformanceMetric();
			_normalsAndColor = new QuadGenerationPerformanceMetric();
			_vertexColor = new QuadGenerationPerformanceMetric();
			_skirtData = new QuadGenerationPerformanceMetric();
			_terrainMeshData = new QuadGenerationPerformanceMetric();
			_waterMeshData = new QuadGenerationPerformanceMetric();
			_terrainTangents = new QuadGenerationPerformanceMetric();
			_waterTangents = new QuadGenerationPerformanceMetric();
		}
	}
}
