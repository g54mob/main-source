using UnityEngine;

namespace TH20
{
	public static class AnimationUtils
	{
		public static void Pause(this Animator animator)
		{
			if (animator != null)
			{
				animator.speed = 0f;
			}
		}

		public static void Resume(this Animator animator)
		{
			if (animator != null)
			{
				animator.speed = 1f;
			}
		}

		public static bool HasParameter(this Animator animator, string paramName)
		{
			if (animator.runtimeAnimatorController != null)
			{
				for (int i = 0; i < animator.parameterCount; i++)
				{
					if (animator.GetParameter(i).name == paramName)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static void SetParameter(this Animator animator, string paramName, bool value)
		{
			if (animator != null && animator.runtimeAnimatorController != null && animator.HasParameter(paramName))
			{
				animator.SetBool(paramName, value);
			}
		}

		public static void SetParameter(this Animator animator, string paramName, int value)
		{
			if (animator != null && animator.runtimeAnimatorController != null && animator.HasParameter(paramName))
			{
				animator.SetInteger(paramName, value);
			}
		}

		public static void SetParameter(this Animator animator, string paramName, float value)
		{
			if (animator != null && animator.runtimeAnimatorController != null && animator.HasParameter(paramName))
			{
				animator.SetFloat(paramName, value);
			}
		}

		public static void SetParameter(this Animator animator, string paramName)
		{
			if (animator != null && animator.runtimeAnimatorController != null)
			{
				animator.SetTrigger(paramName);
			}
		}

		public static bool IsInState(this Animator animator, string stateName, int layer = 0)
		{
			if (animator.runtimeAnimatorController != null)
			{
				return animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName);
			}
			return false;
		}
	}
}
