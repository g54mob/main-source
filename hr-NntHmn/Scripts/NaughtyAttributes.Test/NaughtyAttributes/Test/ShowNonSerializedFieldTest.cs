using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ShowNonSerializedFieldTest : MonoBehaviour
	{
		[ShowNonSerializedField]
		private ushort myUShort;

		[ShowNonSerializedField]
		private short myShort;

		[ShowNonSerializedField]
		private uint myUInt;

		[ShowNonSerializedField]
		private int myInt;

		[ShowNonSerializedField]
		private ulong myULong;

		[ShowNonSerializedField]
		private long myLong;

		[ShowNonSerializedField]
		private const float PI = 3.14159f;

		[ShowNonSerializedField]
		private static readonly Vector3 CONST_VECTOR;
	}
}
