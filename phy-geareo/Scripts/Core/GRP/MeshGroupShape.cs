using UnityEngine;

namespace GRP
{
	public class MeshGroupShape : SimShape
	{
		public float volume;

		public Mesh[] meshes;

		public Vector3 center;

		public override Collider GetShapeCollider()
		{
			return null;
		}

		public override float GetVolume()
		{
			return 0f;
		}

		public override Vector3 GetCenter()
		{
			return default(Vector3);
		}
	}
}
