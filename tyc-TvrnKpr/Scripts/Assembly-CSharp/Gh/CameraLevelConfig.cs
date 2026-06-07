using UnityEngine;

namespace Gh
{
	public class CameraLevelConfig : MonoBehaviour
	{
		public float zoomLevel;

		public float zoomInMax;

		public float zoomOutMax;

		public Vector3 panCenter;

		public Vector3 rigPosition;

		public float rotationDegree;

		public AnimationCurve panRangeCurve;

		public GameObject backgroundDissolveController;

		public GameObject levelEdgeDissolveController;
	}
}
