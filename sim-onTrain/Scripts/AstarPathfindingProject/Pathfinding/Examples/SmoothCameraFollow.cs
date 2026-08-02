using UnityEngine;

namespace Pathfinding.Examples
{
	public class SmoothCameraFollow : VersionedMonoBehaviour
	{
		public Transform target;

		public float distance = 3f;

		public float height = 3f;

		public float damping = 5f;

		public bool enableRotation = true;

		public bool smoothRotation = true;

		public float rotationDamping = 10f;

		public bool staticOffset;

		private void LateUpdate()
		{
			Vector3 b = ((!staticOffset) ? target.TransformPoint(0f, height, 0f - distance) : (target.position + new Vector3(0f, height, distance)));
			base.transform.position = Vector3.Lerp(base.transform.position, b, Time.deltaTime * damping);
			if (enableRotation)
			{
				if (smoothRotation)
				{
					Quaternion b2 = Quaternion.LookRotation(target.position - base.transform.position, target.up);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, Time.deltaTime * rotationDamping);
				}
				else
				{
					base.transform.LookAt(target, target.up);
				}
			}
		}
	}
}
