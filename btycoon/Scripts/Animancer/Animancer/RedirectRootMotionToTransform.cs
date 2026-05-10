using UnityEngine;

namespace Animancer
{
	[AddComponentMenu("Animancer/Redirect Root Motion To Transform")]
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer/RedirectRootMotionToTransform")]
	public class RedirectRootMotionToTransform : RedirectRootMotion<Transform>
	{
		protected override void OnAnimatorMove()
		{
			if (base.ApplyRootMotion)
			{
				base.Target.position += base.Animator.deltaPosition;
				base.Target.rotation *= base.Animator.deltaRotation;
			}
		}
	}
}
