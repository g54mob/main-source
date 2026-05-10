using FluffyUnderware.Curvy.Controllers;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	[RequireComponent(typeof(Rigidbody))]
	public class E11_RigidBodySplineController : MonoBehaviour
	{
		public CurvySpline Spline;

		public SplineController CameraController;

		public float VSpeed;

		public float HSpeed;

		public float CenterDrag;

		public float JumpForce;

		private Rigidbody mRigidBody;

		private float mTF;

		private float velocity;

		[UsedImplicitly]
		private void Start()
		{
		}

		[UsedImplicitly]
		private void LateUpdate()
		{
		}

		[UsedImplicitly]
		private void FixedUpdate()
		{
		}
	}
}
