using System;
using System.Collections.Generic;
using ModApi.Planet;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Terrain.Pooling
{
	public class QuadMeshPool : QuadSpherePool<Mesh>
	{
		private static Dictionary<int, List<Color>> _emptyColorLists;

		private static Dictionary<int, List<Vector2>> _emptyVector2Lists;

		private static Dictionary<int, List<Vector3>> _emptyVector3Lists;

		private static Dictionary<int, List<Vector4>> _emptyVector4Lists;

		public string MeshName { get; private set; }

		public Type MeshVertexType { get; private set; }

		public QuadMeshPoolType PoolType { get; private set; }

		public QuadMeshDataFlags RequiredData { get; private set; }

		public int VertexCount { get; private set; }

		public QuadMeshPool(QuadMeshPoolType type, int vertexCount, QuadMeshDataFlags requiredData, int initialSize)
			: base(initialSize)
		{
			PoolType = type;
			VertexCount = vertexCount;
			RequiredData = requiredData;
			MeshName = type.ToString() + "QuadMesh_" + vertexCount;
		}

		public static Type GetMeshVertexType(QuadMeshPoolType poolType, QuadMeshDataFlags requiredData)
		{
			switch (poolType)
			{
			case QuadMeshPoolType.Physics:
				return typeof(MeshDataPhysics.PhysicsVertex);
			case QuadMeshPoolType.Terrain:
				if (requiredData.HasFlag(QuadMeshDataFlags.UV) || requiredData.HasFlag(QuadMeshDataFlags.UV2) || requiredData.HasFlag(QuadMeshDataFlags.UV3) || requiredData.HasFlag(QuadMeshDataFlags.UV4))
				{
					return typeof(MeshDataTerrain.TerrainVertex);
				}
				return typeof(MeshDataTerrain.TerrainVertexBasic);
			case QuadMeshPoolType.Water:
				return typeof(MeshDataWater.WaterVertex);
			default:
				return null;
			}
		}

		public void Initialize(int vertexCount, QuadMeshDataFlags requiredData)
		{
			int vertexCount2 = VertexCount;
			_ = RequiredData;
			Type meshVertexType = MeshVertexType;
			VertexCount = vertexCount;
			RequiredData = requiredData;
			MeshVertexType = GetMeshVertexType(PoolType, requiredData);
			if (VertexCount != vertexCount2 || MeshVertexType != meshVertexType)
			{
				Shrink(base.Size);
			}
			MeshName = PoolType.ToString() + "QuadMesh_" + vertexCount;
		}

		protected override Mesh CreateItem(int id)
		{
			Mesh mesh = new Mesh();
			mesh.name = MeshName;
			InitializeMesh(mesh);
			return mesh;
		}

		protected override void Destroy(Mesh item)
		{
			UnityEngine.Object.Destroy(item);
		}

		protected virtual void InitializeMesh(Mesh mesh)
		{
			int vertexCount = VertexCount;
			if (PoolType == QuadMeshPoolType.Physics)
			{
				mesh.SetVertexBufferParams(vertexCount, new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0));
				NativeArray<MeshDataPhysics.PhysicsVertex> data = new NativeArray<MeshDataPhysics.PhysicsVertex>(vertexCount, Allocator.Temp);
				mesh.SetVertexBufferData(data, 0, 0, vertexCount);
				mesh.triangles = QuadSpherePoolManager.Instance.GetQuadMeshTriangles(vertexCount, skipEdgeVertices: true);
				data.Dispose();
			}
			else if (MeshVertexType == typeof(MeshDataTerrain.TerrainVertex))
			{
				mesh.SetVertexBufferParams(vertexCount, new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0), new VertexAttributeDescriptor(VertexAttribute.Normal), new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.Float16, 4), new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 4), new VertexAttributeDescriptor(VertexAttribute.TexCoord1, VertexAttributeFormat.UNorm8, 4), new VertexAttributeDescriptor(VertexAttribute.TexCoord2, VertexAttributeFormat.UNorm8, 4), new VertexAttributeDescriptor(VertexAttribute.TexCoord3, VertexAttributeFormat.UNorm8, 4));
				NativeArray<MeshDataTerrain.TerrainVertex> data2 = new NativeArray<MeshDataTerrain.TerrainVertex>(vertexCount, Allocator.Temp);
				mesh.SetVertexBufferData(data2, 0, 0, vertexCount);
				mesh.triangles = QuadSpherePoolManager.Instance.GetQuadMeshTriangles(vertexCount);
				data2.Dispose();
			}
			else if (MeshVertexType == typeof(MeshDataTerrain.TerrainVertexBasic))
			{
				mesh.SetVertexBufferParams(vertexCount, new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0), new VertexAttributeDescriptor(VertexAttribute.Normal), new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.Float16, 4));
				NativeArray<MeshDataTerrain.TerrainVertexBasic> data3 = new NativeArray<MeshDataTerrain.TerrainVertexBasic>(vertexCount, Allocator.Temp);
				mesh.SetVertexBufferData(data3, 0, 0, vertexCount);
				mesh.triangles = QuadSpherePoolManager.Instance.GetQuadMeshTriangles(vertexCount);
				data3.Dispose();
			}
			else if (MeshVertexType == typeof(MeshDataWater.WaterVertex))
			{
				mesh.SetVertexBufferParams(vertexCount, new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0), new VertexAttributeDescriptor(VertexAttribute.Normal), new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.Float16, 4), new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 4), new VertexAttributeDescriptor(VertexAttribute.TexCoord1, VertexAttributeFormat.UNorm8, 4), new VertexAttributeDescriptor(VertexAttribute.TexCoord2, VertexAttributeFormat.UNorm8, 4));
				NativeArray<MeshDataWater.WaterVertex> data4 = new NativeArray<MeshDataWater.WaterVertex>(vertexCount, Allocator.Temp);
				mesh.SetVertexBufferData(data4, 0, 0, vertexCount);
				mesh.triangles = QuadSpherePoolManager.Instance.GetQuadMeshTriangles(vertexCount);
				data4.Dispose();
			}
			else
			{
				Debug.LogError($"Unsupported mesh type '{MeshVertexType}' for pool '{PoolType}'");
			}
		}

		private static List<Color> GetEmptyColorList(int vertexCount)
		{
			if (_emptyColorLists == null)
			{
				_emptyColorLists = new Dictionary<int, List<Color>>();
			}
			if (!_emptyColorLists.TryGetValue(vertexCount, out var value))
			{
				value = new List<Color>(vertexCount);
				value.AddRange(new Color[vertexCount]);
				_emptyColorLists.Add(vertexCount, value);
			}
			return value;
		}

		private static List<Vector2> GetEmptyVector2List(int vertexCount)
		{
			if (_emptyVector2Lists == null)
			{
				_emptyVector2Lists = new Dictionary<int, List<Vector2>>();
			}
			if (!_emptyVector2Lists.TryGetValue(vertexCount, out var value))
			{
				value = new List<Vector2>(vertexCount);
				value.AddRange(new Vector2[vertexCount]);
				_emptyVector2Lists.Add(vertexCount, value);
			}
			return value;
		}

		private static List<Vector3> GetEmptyVector3List(int vertexCount)
		{
			if (_emptyVector3Lists == null)
			{
				_emptyVector3Lists = new Dictionary<int, List<Vector3>>();
			}
			if (!_emptyVector3Lists.TryGetValue(vertexCount, out var value))
			{
				value = new List<Vector3>(vertexCount);
				value.AddRange(new Vector3[vertexCount]);
				_emptyVector3Lists.Add(vertexCount, value);
			}
			return value;
		}

		private static List<Vector4> GetEmptyVector4List(int vertexCount)
		{
			if (_emptyVector4Lists == null)
			{
				_emptyVector4Lists = new Dictionary<int, List<Vector4>>();
			}
			if (!_emptyVector4Lists.TryGetValue(vertexCount, out var value))
			{
				value = new List<Vector4>(vertexCount);
				value.AddRange(new Vector4[vertexCount]);
				_emptyVector4Lists.Add(vertexCount, value);
			}
			return value;
		}
	}
}
