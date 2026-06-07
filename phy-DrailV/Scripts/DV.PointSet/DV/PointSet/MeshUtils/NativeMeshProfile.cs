using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace DV.PointSet.MeshUtils
{
	[NativeContainer]
	public struct NativeMeshProfile : IDisposable
	{
		public struct ProfileVertex
		{
			public float2 pos;

			public float3 normal;

			public float2 uv;
		}

		public enum UVDirection
		{
			X = 0,
			Y = 1
		}

		private Allocator m_AllocatorLabel;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<ProfileVertex> vertices;

		public UVDirection uvDirection;

		public NativeMeshProfile(Allocator allocator)
		{
			m_AllocatorLabel = allocator;
			vertices = new NativeList<ProfileVertex>(8, allocator);
			uvDirection = UVDirection.X;
		}

		public void Clear()
		{
			vertices.Clear();
		}

		public void Dispose()
		{
			vertices.Dispose();
		}
	}
}
