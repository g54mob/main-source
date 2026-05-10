using UnityEngine;

namespace Animancer
{
	[AddComponentMenu("Animancer/Redirect Root Motion To Character Controller")]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/RedirectRootMotionToCharacterController")]
	public class RedirectRootMotionToCharacterController : RedirectRootMotion<CharacterController>
	{
		protected override void OnAnimatorMove()
		{
			if (base.ApplyRootMotion)
			{
				base.Target.Move(base.Animator.deltaPosition);
				base.Target.transform.rotation *= base.Animator.deltaRotation;
			}
		}
	}
}
