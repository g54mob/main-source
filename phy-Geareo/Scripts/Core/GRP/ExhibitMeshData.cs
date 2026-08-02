using System;
using UnityEngine;

namespace GRP
{
	[Serializable]
	public class ExhibitMeshData
	{
		public float[] vx;

		public float[] vy;

		public float[] vz;

		public int[][] tris;

		public static ExhibitMeshData FromMesh(Mesh mesh)
		{
			return null;
		}

		public Mesh CreateMesh()
		{
			return null;
		}
	}
}
