using UnityEngine;

namespace GRP
{
	public class RotateAxis : Axis
	{
		public bool useX;

		private Vector3 anchorPosition;

		private Vector3 anchorNormal;

		private Vector3 startPosition;

		private Plane plane;

		private bool hasBegin;

		private float lastAngle;

		private float offset;

		public override void OnDown(WorldPointerEvent evt)
		{
		}

		public override void OnDrag(WorldPointerEvent evt)
		{
		}

		public override void OnUp(WorldPointerEvent evt)
		{
		}
	}
}
