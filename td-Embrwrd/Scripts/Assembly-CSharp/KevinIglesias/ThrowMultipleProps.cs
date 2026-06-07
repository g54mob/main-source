using UnityEngine;

namespace KevinIglesias
{
	public class ThrowMultipleProps : MonoBehaviour
	{
		public Transform retargeter1;

		public Transform retargeter2;

		public Transform propToThrow1;

		public Transform propToThrow2;

		public Transform hand1;

		public Transform hand2;

		public Transform targetPos;

		public float speed;

		public float arcHeight;

		public bool launched1;

		public bool launched2;

		public bool recoverProp1;

		public bool recoverProp2;

		public bool propLanded1;

		public bool propLanded2;

		private Transform characterRoot;

		private Vector3 startPos1;

		private Vector3 startPos2;

		private Vector3 zeroPosition1;

		private Quaternion zeroRotation1;

		private Vector3 zeroPosition2;

		private Quaternion zeroRotation2;

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

		public void Throw1()
		{
		}

		public void Throw2()
		{
		}

		public void RecoverProp1()
		{
		}

		public void RecoverProp2()
		{
		}
	}
}
