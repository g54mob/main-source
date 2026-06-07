using UnityEngine;

namespace KevinIglesias
{
	public class ThrowProp : MonoBehaviour
	{
		public Transform retargeter;

		public PropType propType;

		public Transform propToThrow;

		public Transform hand;

		public Transform targetPos;

		public float speed;

		public float arcHeight;

		public bool launched;

		public bool recoverProp;

		public bool propLanded;

		private Transform characterRoot;

		private Vector3 startPos;

		private Vector3 zeroPosition;

		private Quaternion zeroRotation;

		private Vector3 nextPos;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private static Quaternion LookAt2D(Vector3 forward)
		{
			return default(Quaternion);
		}

		public void Throw()
		{
		}

		public void RecoverProp()
		{
		}
	}
}
