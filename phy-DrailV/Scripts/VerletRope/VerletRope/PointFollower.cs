using UnityEngine;

namespace VerletRope
{
	public class PointFollower : MonoBehaviour
	{
		public RopeBehaviour rope;

		public int pointIndex;

		public bool reverseForward;

		private bool wasWarningLogged;

		private void OnEnable()
		{
			wasWarningLogged = false;
		}

		protected virtual void LateUpdate()
		{
			if (rope == null || rope.rope == null || pointIndex < 0 || pointIndex >= rope.rope.points.Length)
			{
				if (!wasWarningLogged)
				{
					Debug.LogWarning(GetType().Name + " is in invalid state, following will not work", this);
					wasWarningLogged = true;
				}
				return;
			}
			Point point = rope.rope.points[pointIndex];
			Vector3 position = point.curPos;
			Vector3 vector = point.localForward;
			Vector3 vector2 = point.localUp;
			base.transform.position = rope.transform.TransformPoint(position);
			if (vector != vector2)
			{
				Vector3 forward = (reverseForward ? (vector * -1f) : vector);
				Quaternion quaternion2 = (base.transform.parent ? base.transform.parent.rotation : Quaternion.identity);
				base.transform.rotation = quaternion2 * Quaternion.LookRotation(forward, vector2);
			}
		}
	}
}
