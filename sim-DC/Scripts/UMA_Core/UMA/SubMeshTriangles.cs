using System;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine;

namespace UMA
{
	[Serializable]
	[StructLayout((LayoutKind)0, Pack = 1, Size = 24)]
	public struct SubMeshTriangles
	{
		[SerializeField]
		private int[] triangles;

		public NativeArray<int> nativeTriangles;

		public int[] getBaseTriangles()
		{
			return null;
		}

		public void SetTriangles(int[] tris)
		{
		}

		public NativeArray<int> GetTriangles()
		{
			return default(NativeArray<int>);
		}
	}
}
