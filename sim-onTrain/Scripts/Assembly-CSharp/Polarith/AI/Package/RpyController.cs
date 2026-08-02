using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package
{
	public abstract class RpyController : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Rigidbody that is used by the physics component to move the agent.")]
		protected Rigidbody body;

		[SerializeField]
		[Tooltip("'AIM Context' component for providing decision information that will be transformed into roll, pitch and yaw.")]
		protected AIMContext context;

		[SerializeField]
		[Tooltip("If true, roll, pitch and yaw will be determined by a PID controller. Additionally, the PID parameters will be enabled.")]
		protected bool usePidController;

		protected Vector3 force;

		protected float pitch;

		protected float pitchLimit = 180f;

		protected float roll;

		protected float rollLimit = 180f;

		protected float yaw;

		protected float yawLimit = 180f;

		[SerializeField]
		protected PidController pitchController;

		[SerializeField]
		protected PidController rollController;

		[SerializeField]
		protected PidController yawController;

		public Rigidbody Body
		{
			get
			{
				return body;
			}
			set
			{
				body = value;
			}
		}

		public AIMContext Context
		{
			get
			{
				return context;
			}
			set
			{
				context = value;
			}
		}

		public bool UsePidController
		{
			get
			{
				return usePidController;
			}
			set
			{
				usePidController = value;
			}
		}

		public Vector3 Force => force;

		public float Pitch => pitch;

		public float Roll => roll;

		public float Yaw => yaw;

		private void FixedUpdate()
		{
			PreprocessData();
			CalculateRoll();
			CalculatePitch();
			CalculateYaw();
			CalculateForce();
			if (UsePidController)
			{
				ApplyPIDControl();
			}
			LimitControls();
		}

		private void ApplyPIDControl()
		{
			roll = rollController.GetOutput(roll);
			pitch = pitchController.GetOutput(pitch);
			yaw = yawController.GetOutput(yaw);
		}

		protected abstract void CalculateForce();

		protected abstract void CalculatePitch();

		protected abstract void CalculateRoll();

		protected abstract void CalculateYaw();

		protected virtual void LimitControls()
		{
		}

		protected virtual void PreprocessData()
		{
		}

		protected float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
		{
			float num = Vector3.Angle(from, to);
			Vector3 lhs = Vector3.Cross(axis, from);
			return num * Mathf.Sign(Vector3.Dot(lhs, to));
		}
	}
}
