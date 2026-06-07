using UnityEngine;

namespace Assets.Scripts.Flight.MapView.MapDebug
{
	internal class DebugScript : MonoBehaviour
	{
		public Transform PlaneToProjectOnto;

		public Transform TransformToProject;

		public Transform Result;

		public void Update()
		{
			Vector3d vector3d = ConvertWorldToOrbit(TransformToProject.position, PlaneToProjectOnto.up, PlaneToProjectOnto.forward);
			Result.position = (Vector3)vector3d;
		}

		private Vector3d ConvertWorldToOrbit(Vector3d worldPosition, Vector3d planeNormal, Vector3d planeForward)
		{
			return Quaternion.FromToRotation((Vector3)planeNormal, Vector3.up) * (Vector3)worldPosition;
		}
	}
}
