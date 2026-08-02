using UnityEngine;

namespace Rowlan.Yapp
{
	public class Geometry
	{
		private readonly Vector3 originalPosition;

		private readonly Quaternion originalRotation;

		public Geometry(Transform transform)
		{
			originalPosition = transform.position;
			originalRotation = transform.rotation;
		}

		public Vector3 getPosition()
		{
			return originalPosition;
		}

		public Quaternion getRotation()
		{
			return originalRotation;
		}
	}
}
