using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace GLTFast
{
	internal struct sbyte4
	{
		public sbyte x;

		public sbyte y;

		public sbyte z;

		public sbyte w;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sbyte4(sbyte x, sbyte y, sbyte z, sbyte w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public quaternion GltfToUnityRotation()
		{
			return new quaternion(math.max((float)x / 127f, -1f), 0f - math.max((float)y / 127f, -1f), 0f - math.max((float)z / 127f, -1f), math.max((float)w / 127f, -1f));
		}
	}
}
