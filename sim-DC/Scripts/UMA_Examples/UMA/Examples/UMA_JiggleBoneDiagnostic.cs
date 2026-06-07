using UnityEngine;

namespace UMA.Examples
{
	public class UMA_JiggleBoneDiagnostic : MonoBehaviour
	{
		public bool debugMode;

		private Vector3 dynamicPos;

		public Vector3 boneAxis;

		public Vector3 upDirection;

		public Vector3 extraRotation;

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
