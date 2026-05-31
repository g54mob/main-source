using System;
using UnityEngine;

namespace TinyGiantStudio.Layout
{
	[Serializable]
	public class MeshLayout
	{
		public Mesh mesh;

		public Vector3 position;

		public Quaternion rotation;

		public float xOffset;

		public float yOffset;

		public float zOffset;

		public float width;

		public float height;

		public float depth;

		public bool lineBreak;

		public bool space;

		public MeshLayout(Mesh newMesh)
		{
		}

		public MeshLayout()
		{
		}
	}
}
