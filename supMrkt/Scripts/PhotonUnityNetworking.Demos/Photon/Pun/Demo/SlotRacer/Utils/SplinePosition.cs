using UnityEngine;

namespace Photon.Pun.Demo.SlotRacer.Utils
{
	[ExecuteInEditMode]
	public class SplinePosition : MonoBehaviour
	{
		public BezierSpline Spline;

		public bool reverse;

		public bool lookForward;

		public float currentDistance;

		public float currentClampedDistance;

		private float LastDistance;

		public void SetPositionOnSpline(float position)
		{
		}

		private void Update()
		{
		}

		private void ExecutePositioning()
		{
		}
	}
}
