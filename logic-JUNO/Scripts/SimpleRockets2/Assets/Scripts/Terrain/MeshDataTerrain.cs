using System;
using System.Runtime.InteropServices;
using Assets.Scripts.Terrain.Pooling;
using ModApi.Planet;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Terrain
{
	public class MeshDataTerrain
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct TerrainVertex
		{
			[FieldOffset(24)]
			public half4 Color;

			[FieldOffset(12)]
			public float3 Normal;

			[FieldOffset(0)]
			public float3 Position;

			[FieldOffset(32)]
			public float4 Uv1;

			[FieldOffset(48)]
			public Color32 Uv2;

			[FieldOffset(52)]
			public Color32 Uv3;

			[FieldOffset(56)]
			public Color32 Uv4;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct TerrainVertexBasic
		{
			[FieldOffset(24)]
			public half4 Color;

			[FieldOffset(12)]
			public float3 Normal;

			[FieldOffset(0)]
			public float3 Position;
		}

		public Bounds Bounds;

		public Type VertexType;

		public TerrainVertex[] Vertices;

		public TerrainVertexBasic[] VerticesBasic;

		public MeshDataTerrain(int vertexCount, QuadMeshDataFlags requiredData)
		{
			Vertices = new TerrainVertex[vertexCount];
			VertexType = QuadMeshPool.GetMeshVertexType(QuadMeshPoolType.Terrain, requiredData);
			if (VertexType == typeof(TerrainVertexBasic))
			{
				VerticesBasic = new TerrainVertexBasic[vertexCount];
			}
		}
	}
}
