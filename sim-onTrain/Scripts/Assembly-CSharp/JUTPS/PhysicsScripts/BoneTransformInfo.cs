using UnityEngine;

namespace JUTPS.PhysicsScripts
{
	public class BoneTransformInfo
	{
		public Transform Transform;

		public Vector3 StoredPosition;

		public Quaternion StoredRotation;

		public BoneTransformInfo(Transform t)
		{
			Transform = t;
		}
	}
}
