using UnityEngine;

namespace Obi
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Animator))]
	public class ObiAnimatorController : MonoBehaviour
	{
		private bool updatedThisStep;

		private Animator animator;

		public void Awake()
		{
			animator = GetComponent<Animator>();
		}

		public void UpdateAnimation()
		{
			if (animator != null && animator.enabled && !updatedThisStep)
			{
				animator.playableGraph.Stop();
				animator.Update(Time.fixedDeltaTime);
				updatedThisStep = true;
			}
		}

		public void ResetUpdateFlag()
		{
			updatedThisStep = false;
		}

		public void ResumeAutonomousUpdate()
		{
			if (animator != null && animator.enabled)
			{
				animator.playableGraph.Play();
			}
		}
	}
}
