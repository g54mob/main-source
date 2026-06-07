using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ShowNativePropertyTest : MonoBehaviour
	{
		[ShowNativeProperty]
		private Transform Transform => null;

		[ShowNativeProperty]
		private Transform ParentTransform => null;

		[ShowNativeProperty]
		private ushort MyUShort => 0;

		[ShowNativeProperty]
		private short MyShort => 0;

		[ShowNativeProperty]
		private ulong MyULong => 0uL;

		[ShowNativeProperty]
		private long MyLong => 0L;

		[ShowNativeProperty]
		private uint MyUInt => 0u;

		[ShowNativeProperty]
		private int MyInt => 0;
	}
}
