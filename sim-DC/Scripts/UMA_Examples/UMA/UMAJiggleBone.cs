using UnityEngine;

namespace UMA
{
	public class UMAJiggleBone : MonoBehaviour
	{
		private Vector3 dynamicPos;

		public Vector3 boneAxis;

		public float targetDistance;

		public float bStiffness;

		public float bMass;

		public float bDamping;

		public float bGravity;

		private Vector3 force;

		private Vector3 acc;

		private Vector3 vel;

		public bool SquashAndStretch;

		public float sideStretch;

		public float frontStretch;

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
