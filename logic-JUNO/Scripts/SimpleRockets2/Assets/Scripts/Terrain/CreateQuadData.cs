using System.Diagnostics;
using Assets.Scripts.Terrain.CustomData;
using Assets.Scripts.Terrain.Diagnostics;
using Assets.Scripts.Terrain.Events;
using Assets.Scripts.Terrain.Pooling;
using UnityEngine;

namespace Assets.Scripts.Terrain
{
	public class CreateQuadData
	{
		public bool AboveSeaLevel;

		public QuadAxisAlignedBoundingBox AxisAlignedBoundingBox;

		public Quaterniond AxisAlignedBoundingBoxRotation;

		public bool BelowSeaLevel;

		public Vector3d[] BoundingBoxSamplePoints;

		public Vector3d Center;

		public CustomCreateQuadData[] CustomData;

		public bool HasTerrain;

		public bool HasWater;

		public Matrix4x4d Matrix;

		public QuadGenerationPerformanceTracker PerformanceTracker;

		public Vector3d Position;

		public Quaterniond Rotation;

		public double Scale;

		public int SubdivisionLevel;

		public Vector3[] Tangents1;

		public Vector3[] Tangents2;

		public QuadSpherePoolItem<MeshDataTerrain> TerrainMeshData;

		public TerrainPointSample[] TerrainPoints;

		public Vector2d UVCenter;

		public double UVSize;

		public QuadSpherePoolItem<MeshDataWater> WaterMeshData;

		public CreateQuadDataEventArgs EventArgs { get; }

		public Vector4d SphereNormal
		{
			get
			{
				Matrix4x4d matrix = Matrix;
				return new Vector4d(matrix.m03, matrix.m13, matrix.m23).normalized;
			}
		}

		public CreateQuadData(int terrainQuadVertexCount)
		{
			Matrix = new Matrix4x4d();
			TerrainPoints = new TerrainPointSample[terrainQuadVertexCount];
			BoundingBoxSamplePoints = new Vector3d[18];
			EventArgs = new CreateQuadDataEventArgs(this);
			CustomData = CustomCreateQuadData.Create(terrainQuadVertexCount);
		}

		[Conditional("PERFORMANCE_METRICS_QUAD_GENERATION")]
		private void InitializePerformanceTracker()
		{
			PerformanceTracker = new QuadGenerationPerformanceTracker();
		}
	}
}
