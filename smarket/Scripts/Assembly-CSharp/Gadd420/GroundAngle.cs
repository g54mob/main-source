using UnityEngine;

namespace Gadd420
{
	public class GroundAngle : MonoBehaviour
	{
		[Header("Script Not Used If Safe Wheelies Is Turned Off")]
		public LayerMask layerMask;

		private RB_Controller rbScript;

		private AutoLeveling autoLeveler;

		public GameObject frontRayPos;

		public GameObject rearRayPos;

		private bool upHill;

		[HideInInspector]
		public float forwardY;

		[HideInInspector]
		public float surfaceAngle;

		[HideInInspector]
		public float actualAngle;

		[HideInInspector]
		public float wheelieAngleMinusSurfaceAngle;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void SetRayPositionsAndRotations()
		{
		}

		private void RayCastsAndUphillCheck()
		{
		}

		private void CalculateForwardY()
		{
		}
	}
}
