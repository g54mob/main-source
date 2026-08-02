using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Character/AIM Physics Controller 2D")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-physicscontroller.html")]
	[DisallowMultipleComponent]
	public sealed class AIMPhysicsController2D : MonoBehaviour
	{
		[Tooltip("Determines the base value of the applied force for rotating the character towards the decided direction. The default value of 0.05 is suitable for a rigidbody (2D) angular drag of 10, whereby the mass = 1 and a default 'PhysicsMaterial2D' should be used.")]
		public float Torque = 0.05f;

		[Tooltip("Determines the base value specifying how fast the character moves. This value is highly dependent on the 'Rigidbody2D.drag', 'Rigidbody2D.mass' and the 'PhysicsMaterial2D' used by the involved collider instances.\n\nFor the default value, you may use a 2D rigidbody configuration with mass = 1, drag = 5 and a default collider material.")]
		public float Speed = 10f;

		[Tooltip("If set equal to or greater than 0, the evaluated AI decision value is multiplied to the 'Speed'.")]
		[TargetObjective(true)]
		public int ObjectiveAsSpeed = -1;

		[Tooltip("The 'AIMContext' which provides the next movement direction that is applied to the rigidbody.")]
		public AIMContext Context;

		[Tooltip("The rigidbody which is manipulated by this controller.")]
		public Rigidbody2D Body2D;

		private Vector3 up;

		private Vector3 cross;

		private float angleDiff;

		private float velocity;

		private void OnEnable()
		{
			if (Body2D == null)
			{
				Body2D = base.gameObject.GetComponentInChildren<Rigidbody2D>();
			}
			if (Context == null)
			{
				Context = base.gameObject.GetComponentInChildren<AIMContext>();
			}
			if (Body2D == null || Context == null)
			{
				base.enabled = false;
			}
		}

		private void FixedUpdate()
		{
			up = base.transform.up;
			angleDiff = Vector3.Angle(up, Context.DecidedDirection);
			cross = Vector3.Cross(up, Context.DecidedDirection);
			if (!Mathf2.Approximately(Context.DecidedDirection.sqrMagnitude, 0f) && Mathf2.Approximately(cross.z, 0f))
			{
				cross.z = Mathf.Sign(Random.Range(-1f, 1f));
			}
			Body2D.AddTorque(cross.z * Torque * angleDiff);
			if (ObjectiveAsSpeed >= 0 && ObjectiveAsSpeed < Context.DecidedValues.Count)
			{
				velocity = Context.DecidedValues[ObjectiveAsSpeed] * Speed;
				velocity = ((velocity > Speed) ? Speed : velocity);
			}
			else
			{
				velocity = Speed;
			}
			Body2D.AddForce(velocity * up);
		}
	}
}
