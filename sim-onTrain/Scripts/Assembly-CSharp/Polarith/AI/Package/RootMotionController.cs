using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Character/Root Motion Controller")]
	public class RootMotionController : MonoBehaviour
	{
		public Rigidbody rb;

		[Tooltip("The animation controller that holds and manages the different animation states. This is a mandatory reference since the decision of Polarith AI (see 'Context') is applied to this animation controller. If the reference is null, the component searches for an attached Animator OnEnable.")]
		public Animator Animator;

		[Tooltip("This component provides the results of the AI system. These results are then applied to the attached Animator. Thus, the reference to an AIMContext component is mandatory.The controller is + disabled if no Context instance can be found at OnEnable.")]
		public AIMContext Context;

		[Tooltip("The maximum value of the parameter passed to the 'Animator Parameter' that is assumed to somehow control the movement animation. Thus, it could be seen as a limit for movement speed")]
		public float MovementSpeed = 0.5f;

		[Tooltip("Controls how fast the character can rotate to a direction given by the Context. In radians per second. For example, a value of 3.141 means that the character can turn around in one second.")]
		public float RotationSpeed = 1f;

		[Tooltip("If set equal to or greater than 0, the evaluated AI decision value is multiplied to the 'Speed'.")]
		[TargetObjective(true)]
		public int ObjectiveAsSpeed = -1;

		private void OnEnable()
		{
			if (Animator == null)
			{
				Animator = GetComponent<Animator>();
			}
			if (Context == null)
			{
				Context = GetComponent<AIMContext>();
			}
			if (Context == null || Animator == null)
			{
				Debug.LogWarning("(" + typeof(RootMotionController).Name + ") " + base.name + ": deactivated because a reference to either an AIMContext or an Animator is missing.");
				base.enabled = false;
			}
		}

		private void Update()
		{
			Vector3 decidedDirection = Context.DecidedDirection;
			float maxRadiansDelta = RotationSpeed * Time.deltaTime;
			Vector3 forward = Vector3.RotateTowards(base.transform.forward, decidedDirection, maxRadiansDelta, 0f);
			base.transform.rotation = Quaternion.LookRotation(forward);
			float num = 1f;
			if (Vector3.Angle(decidedDirection, base.transform.forward) > 50f)
			{
				num = 0f;
			}
			if (ObjectiveAsSpeed >= 0 && ObjectiveAsSpeed < Context.DecidedValues.Count)
			{
				float num2 = Context.DecidedValues[ObjectiveAsSpeed] * MovementSpeed;
				num2 = ((num2 > MovementSpeed) ? MovementSpeed : num2);
				Animator.SetFloat(AnimationKeys.ZombieWalkSpeed, num2 * num);
				base.transform.position += decidedDirection * Time.deltaTime * num * num2;
			}
			else
			{
				base.transform.position += decidedDirection * Time.deltaTime * MovementSpeed;
				Animator.SetFloat(AnimationKeys.ZombieWalkSpeed, MovementSpeed * num);
			}
		}
	}
}
