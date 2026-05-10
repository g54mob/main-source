using System.Collections.Generic;
using UnityEngine;

namespace TinyGiantStudio.Text.SampleScene
{
	public class MText_SampleScene_VRCam : MonoBehaviour
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

		private readonly List<float> rotArrayX;

		private float rotAverageX;

		private readonly List<float> rotArrayY;

		private float rotAverageY;

		public float frameCounter;

		private Quaternion originalRotation;

		private void Awake()
		{
		}

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
