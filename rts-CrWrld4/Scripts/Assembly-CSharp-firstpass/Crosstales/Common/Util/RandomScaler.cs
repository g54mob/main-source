using UnityEngine;

namespace Crosstales.Common.Util
{
	[DisallowMultipleComponent]
	public class RandomScaler : MonoBehaviour
	{
		public bool UseInterval;

		public Vector2 ChangeInterval;

		public Vector3 ScaleMin;

		public Vector3 ScaleMax;

		public bool Uniform;

		public bool RandomScaleAtStart;

		private Transform tf;

		private Vector3 startScale;

		private Vector3 endScale;

		private float elapsedTime;

		private float changeTime;

		private float lerpTime;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
