using UnityEngine;

namespace GRP
{
	public class TaperedCylinderShape : SimShape
	{
		public float height;

		public float topRadius;

		public float bottomRadius;

		public override Collider GetShapeCollider()
		{
			return null;
		}

		public override float GetVolume()
		{
			return 0f;
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
