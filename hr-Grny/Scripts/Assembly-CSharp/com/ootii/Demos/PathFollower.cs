using UnityEngine;
using com.ootii.Geometry;

namespace com.ootii.Demos
{
	public class PathFollower : MonoBehaviour
	{
		public BezierSpline Path;

		public float Speed;

		public float SpeedMultiplier;

		public Quaternion RotateForward;

		public float DistanceTraveled;

		private float mPathLength;

		private Vector3 mLastPosition;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
