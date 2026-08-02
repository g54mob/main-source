using UnityEngine;

namespace GRP
{
	public class BoxShape : SimShape
	{
		public Vector3 center;

		public Vector3 size;

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
