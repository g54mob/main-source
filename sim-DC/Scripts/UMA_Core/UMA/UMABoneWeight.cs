using System;
using System.Runtime.InteropServices;

namespace UMA
{
	[Serializable]
	[StructLayout((LayoutKind)0, Pack = 1, Size = 32)]
	public struct UMABoneWeight
	{
		public int boneIndex0;

		public int boneIndex1;

		public int boneIndex2;

		public int boneIndex3;

		public float weight0;

		public float weight1;

		public float weight2;

		public float weight3;
	}
}
