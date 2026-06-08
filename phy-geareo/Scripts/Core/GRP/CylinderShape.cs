using UnityEngine;

namespace GRP
{
	public class CylinderShape : SimShape, ICameraAttach
	{
		public int segments;

		public float radius;

		public float height;

		public override Collider GetShapeCollider()
		{
			return null;
		}

		private void OnDrawGizmosSelected()
		{
		}

		public static void DrawCircle(Vector3 position, Quaternion rotation, float radius, int segments = 30)
		{
		}

		public override float GetVolume()
		{
			return 0f;
		}

		public void CameraAttach(OrbitCameraController camera, WorldPointerScan target, Vector3 relativePosition)
		{
		}

		public static void DoCameraAttach(OrbitCameraController camera, WorldPointerScan target, Vector3 relativePosition)
		{
		}
	}
}
