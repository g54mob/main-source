using UnityEngine;

public static class AnimatorExtensions
{
	public static AnimatorStateInfo GetCurrentAnimatorStateInfo(this Animator animator, string layerName)
	{
		return default(AnimatorStateInfo);
	}

	public static AnimatorStateInfo GetNextAnimatorStateInfo(this Animator animator, string layerName)
	{
		return default(AnimatorStateInfo);
	}

	public static bool IsCurrentStateName(this Animator animator, string layerName, string stateName)
	{
		return false;
	}

	public static bool IsCurrentStateName(this Animator animator, int layerIndex, string stateName)
	{
		return false;
	}
}
