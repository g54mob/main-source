using System.Runtime.InteropServices;
using ModApi.Planet;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Terrain
{
	public class MeshDataWater
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct WaterVertex
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
		}

		public Bounds Bounds;

		public WaterVertex[] Vertices;

		public MeshDataWater(int vertexCount, QuadMeshDataFlags requiredData)
		{
			Vertices = new WaterVertex[vertexCount];
		}
	}
}
