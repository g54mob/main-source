using UnityEngine;

namespace GRP
{
	public class SphereShape : SimShape, ICameraAttach
	{
		public float radius;

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

		public void CameraAttach(OrbitCameraController camera, WorldPointerScan target, Vector3 relativePosition)
		{
		}
	}
}
