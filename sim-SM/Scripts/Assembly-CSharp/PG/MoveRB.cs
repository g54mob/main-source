using UnityEngine;

namespace PG
{
	[RequireComponent(typeof(Rigidbody))]
	public class MoveRB : MonoBehaviour
	{
		public Vector3 StartPosition;

		public Vector3 EndPosition;

		public float Speed;

		public bool UseRBMovePosition;

		private Vector3 GlobalStartPosition;

		private Vector3 GlobalEndPosition;

		private Vector3 TargetPosition;

		private Rigidbody RB;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}
	}
}
