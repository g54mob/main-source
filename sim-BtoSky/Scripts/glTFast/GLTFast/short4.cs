using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace GLTFast
{
	internal struct short4
	{
		public short x;

		public short y;

		public short z;

		public short w;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public quaternion GltfToUnityRotation()
		{
			return new quaternion(math.max((float)x / 32767f, -1f), 0f - math.max((float)y / 32767f, -1f), 0f - math.max((float)z / 32767f, -1f), math.max((float)w / 32767f, -1f));
		}
	}
}
