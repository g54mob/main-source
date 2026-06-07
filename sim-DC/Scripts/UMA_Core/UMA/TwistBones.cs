using UnityEngine;

namespace UMA
{
	public class TwistBones : MonoBehaviour
	{
		public float twistValue;

		public Transform[] twistBone;

		public Transform[] refBone;

		private float[] originalRefRotation;

		public float[] twistRotation;

		private Vector3 rotated;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
