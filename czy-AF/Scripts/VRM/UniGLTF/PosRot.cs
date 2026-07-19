using UnityEngine;

namespace UniGLTF
{
	public struct PosRot
	{
		public Vector3 Position;

		public Quaternion Rotation;

		public static PosRot FromGlobalTransform(Transform t)
		{
			return new PosRot
			{
				Position = t.position,
				Rotation = t.rotation
			};
		}
	}
}
