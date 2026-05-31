using UnityEngine;

namespace Examples.Scenes.TouchpadCamera
{
	public class RotationConstraint : MonoBehaviour
	{
		public float Min;

		public float Max;

		private Transform _transformCache;

		private Quaternion _minQuaternion;

		private Quaternion _maxQuaternion;

		private Vector3 _rotateAround;

		private float _range;

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
