using UnityEngine;

namespace GRP
{
	public class MeshShape : SimShape
	{
		public Mesh mesh;

		public Vector3 scale;

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
