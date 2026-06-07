using System;
using UnityEngine;

namespace FSG.MeshAnimator.Snapshot
{
	[Serializable]
	public class SnapshotMeshFrameData : MeshFrameDataBase
	{
		[HideInInspector]
		public Vector3[] normals;

		[NonSerialized]
		private Vector3[] decompressed;

		public Vector3[] verts => null;

		public void SetVerts(Vector3[] v)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
