using System.Diagnostics;

namespace Assets.Scripts.Terrain.Diagnostics
{
	public class QuadGenerationPerformanceTracker
	{
		private Stopwatch _allQuadData;

		private Stopwatch _boundingBox;

		private Stopwatch _normalsAndColor;

		private Stopwatch _skirtData;

		private Stopwatch _terrainMeshData;

		private Stopwatch _terrainPoints;

		private Stopwatch _terrainTangents;

		private Stopwatch _vertexColor;

		private Stopwatch _vertexData;

		private Stopwatch _waterMeshData;

		private Stopwatch _waterTangents;

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void AllQuadDataStart()
		{
			_allQuadData.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void AllQuadDataStop()
		{
			_allQuadData.Stop();
		}

		public double AllQuadDataTime()
		{
			return _allQuadData.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void BoundingBoxStart()
		{
			_boundingBox.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void BoundingBoxStop()
		{
			_boundingBox.Stop();
		}

		public double BoundingBoxTime()
		{
			return _boundingBox.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void NormalsAndColorStart()
		{
			_normalsAndColor.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void NormalsAndColorStop()
		{
			_normalsAndColor.Stop();
		}

		public double NormalsAndColorTime()
		{
			return _normalsAndColor.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void ResetAll()
		{
			_allQuadData.Reset();
			_boundingBox.Reset();
			_vertexData.Reset();
			_terrainPoints.Reset();
			_normalsAndColor.Reset();
			_vertexColor.Reset();
			_skirtData.Reset();
			_terrainMeshData.Reset();
			_waterMeshData.Reset();
			_terrainTangents.Reset();
			_waterTangents.Reset();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void SkirtDataStart()
		{
			_skirtData.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void SkirtDataStop()
		{
			_skirtData.Stop();
		}

		public double SkirtDataTime()
		{
			return _skirtData.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void TerrainMeshDataStart()
		{
			_terrainMeshData.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void TerrainMeshDataStop()
		{
			_terrainMeshData.Stop();
		}

		public double TerrainMeshDataTime()
		{
			return _terrainMeshData.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void TerrainPointsStart()
		{
			_terrainPoints.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void TerrainPointsStop()
		{
			_terrainPoints.Stop();
		}

		public double TerrainPointsTime()
		{
			return _terrainPoints.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void TerrainTangentsStart()
		{
			_terrainTangents.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void TerrainTangentsStop()
		{
			_terrainTangents.Stop();
		}

		public double TerrainTangentsTime()
		{
			return _terrainTangents.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void VertexColorStart()
		{
			_vertexColor.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void VertexColorStop()
		{
			_vertexColor.Stop();
		}

		public double VertexColorTime()
		{
			return _vertexColor.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void VertexDataStart()
		{
			_vertexData.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void VertexDataStop()
		{
			_vertexData.Stop();
		}

		public double VertexDataTime()
		{
			return _vertexData.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void WaterMeshDataStart()
		{
			_waterMeshData.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void WaterMeshDataStop()
		{
			_waterMeshData.Stop();
		}

		public double WaterMeshDataTime()
		{
			return _waterMeshData.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void WaterTangentsStart()
		{
			_waterTangents.Start();
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		public void WaterTangentsStop()
		{
			_waterTangents.Stop();
		}

		public double WaterTangentsTime()
		{
			return _waterTangents.Elapsed.TotalMilliseconds;
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		private void Initialize()
		{
			_allQuadData = new Stopwatch();
			_boundingBox = new Stopwatch();
			_vertexData = new Stopwatch();
			_terrainPoints = new Stopwatch();
			_normalsAndColor = new Stopwatch();
			_vertexColor = new Stopwatch();
			_skirtData = new Stopwatch();
			_terrainMeshData = new Stopwatch();
			_waterMeshData = new Stopwatch();
			_terrainTangents = new Stopwatch();
			_waterTangents = new Stopwatch();
		}
	}
}
