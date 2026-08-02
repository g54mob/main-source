using UnityEngine;

namespace GRP
{
	public class BoxGroupShape : SimShape
	{
		public Box[] boxes;

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
