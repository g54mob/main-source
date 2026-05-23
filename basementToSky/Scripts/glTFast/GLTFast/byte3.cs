using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace GLTFast
{
	internal struct byte3
	{
		public byte x;

		public byte y;

		public byte z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte3(byte x, byte y, byte z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 GltfToUnityFloat3()
		{
			return new float3(-x, (int)y, (int)z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 GltfToUnityNormalizedFloat3()
		{
			return new float3(0f - (float)(int)x / 255f, (float)(int)y / 255f, (float)(int)z / 255f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3 GltfToUnityTriangleIndies()
		{
			return new int3(x, z, y);
		}
	}
}
