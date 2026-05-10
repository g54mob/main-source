using UnityEngine;

namespace Animancer
{
	[AddComponentMenu("Animancer/Redirect Root Motion To Rigidbody")]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/RedirectRootMotionToRigidbody")]
	public class RedirectRootMotionToRigidbody : RedirectRootMotion<Rigidbody>
	{
		protected override void OnAnimatorMove()
		{
			if (base.ApplyRootMotion)
			{
				base.Target.MovePosition(base.Target.position + base.Animator.deltaPosition);
				base.Target.MoveRotation(base.Target.rotation * base.Animator.deltaRotation);
			}
		}
	}
}
