using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Character/AIM Physics Controller")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-physicscontroller.html")]
	[DisallowMultipleComponent]
	public sealed class AIMPhysicsController : MonoBehaviour
	{
		[Tooltip("Determines the base value of the applied force for rotating the character towards the decided direction. This value is highly dependent on the 'Rigidbody.angularDrag', 'Rigidbody.mass' and the 'PhysicMaterial' used by the involved collider instances.\n\nFor the default value, you may use a rigidbody configuration with mass = 1, angular drag = 5 and a default collider material.")]
		public float Torque = 1f;

		[Tooltip("Determines the base value specifying how fast the character moves. This value is highly dependent on the 'Rigidbody.drag', 'Rigidbody.mass' and the 'PhysicMaterial' used by the involved collider instances.\n\nFor the default value, you may use a rigidbody configuration with mass = 1, drag = 1 and a default collider material.")]
		public float Speed = 15f;

		[Tooltip("If set equal to or greater than 0, the evaluated AI decision value is multiplied to the 'Speed'.")]
		[TargetObjective(true)]
		public int ObjectiveAsSpeed = -1;

		[Tooltip("The 'ForceMode' which is applied to the 'AddForce' method of the associated rigidbody.")]
		public ForceMode Mode = ForceMode.Acceleration;

		[Tooltip("The 'AIMContext' which provides the next movement direction that is applied to the rigidbody.")]
		public AIMContext Context;

		[Tooltip("The rigidbody which gets manipulated by this controller.")]
		public Rigidbody Body;

		private Vector3 forward;

		private Vector3 up;

		private Vector3 cross;

		private float angleDiff;

		private float velocity;

		private void OnEnable()
		{
			if (Body == null)
			{
				Body = base.gameObject.GetComponentInChildren<Rigidbody>();
			}
			if (Context == null)
			{
				Context = base.gameObject.GetComponentInChildren<AIMContext>();
			}
			if (Body == null || Context == null)
			{
				base.enabled = false;
			}
		}

		private void FixedUpdate()
		{
			if (Context.ObjectiveCount != 0 && Context.DecidedValues.Count > 0)
			{
				forward = base.transform.forward;
				up = base.transform.up;
				angleDiff = 0f;
				if (Context.DecidedDirection != Vector3.zero && Context.DecidedValues[0] > 0f)
				{
					angleDiff = Vector3.Angle(forward, Context.DecidedDirection);
				}
				cross = Vector3.Cross(up, forward);
				if (Vector3.Dot(cross, Context.DecidedDirection) < 0f)
				{
					angleDiff = 0f - angleDiff;
				}
				Body.AddTorque(up * Torque * angleDiff);
				if (ObjectiveAsSpeed >= 0 && ObjectiveAsSpeed < Context.DecidedValues.Count)
				{
					velocity = Context.DecidedValues[ObjectiveAsSpeed] * Speed;
					velocity = ((velocity > Speed) ? Speed : velocity);
				}
				else
				{
					velocity = Speed;
				}
				Body.AddForce(velocity * forward, Mode);
			}
		}
	}
}
