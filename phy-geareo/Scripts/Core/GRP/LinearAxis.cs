using UnityEngine;

namespace GRP
{
	public class LinearAxis : Axis
	{
		public bool dynamicDirection;

		private Vector3 startPosition;

		private Vector3 startDirection;

		private bool down;

		private float distance;

		public override void OnDown(WorldPointerEvent evt)
		{
		}

		public override void OnDrag(WorldPointerEvent evt)
		{
		}

		public override void OnUp(WorldPointerEvent evt)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
