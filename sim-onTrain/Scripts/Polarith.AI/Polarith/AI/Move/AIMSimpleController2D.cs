using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Character/AIM Simple Controller 2D")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-simplecontroller.html")]
	[DisallowMultipleComponent]
	public sealed class AIMSimpleController2D : MonoBehaviour
	{
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
				base.transform.rotation = Quaternion.LookRotation(Vector3.forward, Context.DecidedDirection);
				if (ObjectiveAsSpeed >= 0 && ObjectiveAsSpeed < Context.DecidedValues.Count)
				{
					velocity = Context.DecidedValues[ObjectiveAsSpeed] * Speed;
					velocity = ((velocity > Speed) ? Speed : velocity);
				}
				else
				{
					velocity = Speed;
				}
				base.transform.Translate(Time.deltaTime * velocity * Vector3.up);
			}
		}
	}
}
