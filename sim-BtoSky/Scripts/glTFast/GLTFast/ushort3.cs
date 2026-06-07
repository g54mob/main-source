using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace GLTFast
{
	internal struct ushort3
	{
		public ushort x;

		public ushort y;

		public ushort z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 GltfToUnityFloat3()
		{
			return new float3(-x, (int)y, (int)z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 GltfToUnityNormalizedFloat3()
		{
			return new float3(0f - (float)(int)x / 65535f, (float)(int)y / 65535f, (float)(int)z / 65535f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3 GltfToUnityTriangleIndies()
		{
			return new int3(x, z, y);
		}
	}
}
