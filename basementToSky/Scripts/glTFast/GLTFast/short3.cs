using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace GLTFast
{
	internal struct short3
	{
		public short x;

		public short y;

		public short z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short3(short x, short y, short z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 GltfToUnityFloat3()
		{
			return new float3(-x, y, z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 GltfNormalToUnityFloat3()
		{
			float3 float5 = new float3(x, y, z) / 32767f;
			float5 = math.max(float5, -1f);
			float5.x *= -1f;
			return math.normalize(float5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 GltfToUnityNormalizedFloat3()
		{
			float3 float5 = new float3(x, y, z) / 32767f;
			float5 = math.max(float5, -1f);
			float5.x *= -1f;
			return float5;
		}
	}
}
