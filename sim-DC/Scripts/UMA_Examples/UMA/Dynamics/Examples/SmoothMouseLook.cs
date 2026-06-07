using System.Collections.Generic;
using UnityEngine;

namespace UMA.Dynamics.Examples
{
	[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
	public class SmoothMouseLook : MonoBehaviour
	{
		public enum RotationAxes
		{
			MouseXAndY = 0,
			MouseX = 1,
			MouseY = 2
		}

		public RotationAxes axes;

		public float sensitivityX;

		public float sensitivityY;

		public float minimumX;

		public float maximumX;

		public float minimumY;

		public float maximumY;

		private float rotationX;

		private float rotationY;

		private List<float> rotArrayX;

		private float rotAverageX;

		private List<float> rotArrayY;

		private float rotAverageY;

		public float frameCounter;

		private Quaternion originalRotation;

		private Quaternion parentRotation;

		private void Update()
		{
		}

		private void Start()
		{
		}

		public static float ClampAngle(float angle, float min, float max)
		{
			return 0f;
		}
	}
}
