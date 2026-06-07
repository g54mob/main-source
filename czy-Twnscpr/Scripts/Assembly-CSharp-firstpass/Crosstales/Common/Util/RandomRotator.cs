using UnityEngine;

namespace Crosstales.Common.Util
{
	[DisallowMultipleComponent]
	public class RandomRotator : MonoBehaviour
	{
		public bool UseInterval;

		public Vector2 ChangeInterval;

		public Vector3 SpeedMin;

		public Vector3 SpeedMax;

		public bool RandomRotationAtStart;

		public bool RandomChangeIntervalPerAxis;

		private Transform tf;

		private Vector3 speed;

		private float elapsedTime;

		private float changeTime;

		private Vector3 elapsedTimeAxis;

		private Vector3 changeTimeAxis;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
