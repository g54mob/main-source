using UnityEngine;

namespace Photon.Pun.Demo.SlotRacer.Utils
{
	[ExecuteInEditMode]
	public class SplineWalker : MonoBehaviour
	{
		public BezierSpline spline;

		public float Speed;

		public bool lookForward;

		public bool reverse;

		private float progress;

		public float currentDistance;

		public float currentClampedDistance;

		public void SetPositionOnSpline(float position)
		{
		}

		private void Update()
		{
		}

		public void ExecutePositioning()
		{
		}
	}
}
