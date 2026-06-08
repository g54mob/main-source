using UnityEngine;

namespace GRP
{
	public class PlaneAxis : Axis
	{
		public Transform visual;

		private Transform helperTransform;

		private Vector3 startPosition;

		private Vector3 startDirection;

		private bool down;

		private void Start()
		{
		}

		public override void OnDown(WorldPointerEvent evt)
		{
		}

		public override void OnDrag(WorldPointerEvent evt)
		{
		}

		public override void OnUp(WorldPointerEvent evt)
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
