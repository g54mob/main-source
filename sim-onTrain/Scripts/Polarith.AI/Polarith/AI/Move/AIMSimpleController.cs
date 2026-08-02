using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Character/AIM Simple Controller")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-simplecontroller.html")]
	[DisallowMultipleComponent]
	public sealed class AIMSimpleController : MonoBehaviour
	{
		[Tooltip("The direction which is used to rotate the forward direction according to the decision made by the 'Context'.\n\nThis vector needs to be perpendicular to an agent's forward direction, e.g., if the agent moves in the x/z-plane, this vector needs always to be (0, 1, 0).")]
		public Vector3 Up = Vector3.up;

		[Tooltip("Determines the base value specifying how fast the character moves.")]
		public float Speed = 1f;

		[Tooltip("If set equal to or greater than 0, the evaluated AI decision value is multiplied to the 'Speed'.")]
		[TargetObjective(true)]
		public int ObjectiveAsSpeed = -1;

		[Tooltip("The AIMContext which provides the next movement direction that is applied to the agent's transform.")]
		public AIMContext Context;

		private float velocity;

		private void OnEnable()
		{
			if (Context == null)
			{
				Context = GetComponentInChildren<AIMContext>();
			}
			if (Context == null)
			{
				base.enabled = false;
			}
		}

		private void Update()
		{
			if (!Mathf2.Approximately(Context.DecidedDirection.sqrMagnitude, 0f))
			{
				base.transform.rotation = Quaternion.LookRotation(Context.DecidedDirection, Up);
				if (ObjectiveAsSpeed >= 0)
				{
					velocity = Context.DecidedValues[ObjectiveAsSpeed] * Speed;
					velocity = ((velocity > Speed) ? Speed : velocity);
				}
				else
				{
					velocity = Speed;
				}
				base.transform.position += Time.deltaTime * velocity * Context.DecidedDirection;
			}
		}
	}
}
