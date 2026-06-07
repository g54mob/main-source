using UnityEngine;

namespace UMA
{
	public class MeshDetails
	{
		public Vector3[] vertices;

		public Vector3[] normals;

		public Vector4[] tangents;

		public Color32[] colors32;

		public Vector2[] uv;

		public Vector2[] uv2;

		public Vector2[] uv3;

		public Vector2[] uv4;

		public bool verticesModified;

		public bool normalsModified;

		public bool tangentsModified;

		public bool colors32Modified;

		public bool uvModified;

		public bool uv2Modified;

		public bool uv3Modified;

		public bool uv4Modified;

		public MeshDetails ShallowCopy()
		{
			return null;
		}
	}
}
