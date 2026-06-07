using UnityEngine;

[AddComponentMenu("Flotsam/Animation/Buildable Animator")]
[DisallowMultipleComponent]
public class BuildableAnimator : MonoBehaviour
{
	public Animator Animator { get; private set; }

	public void Initialize(Animator animator)
	{
		Animator = animator;
	}

	public void ResetAnimation(string defaultState)
	{
		if (Animator == null)
		{
			return;
		}
		Animator.Play(defaultState);
		for (int i = 0; i < Animator.parameters.Length; i++)
		{
			if (Animator.parameters[i].type == AnimatorControllerParameterType.Int)
			{
				Animator.SetInteger(Animator.parameters[i].name, Animator.parameters[i].defaultInt);
			}
		}
	}

	public void Play(string animationState)
	{
		Animator.Play(animationState);
	}

	public AnimatorStateInfo ReturnCurrentAnimatorClipInfo()
	{
		return Animator.GetCurrentAnimatorStateInfo(0);
	}

	public void RestoreAnimatorState(int shortNameHash, float normalizedTime)
	{
		Animator.Play(shortNameHash, 0, normalizedTime);
	}

	public bool HasParameter(string parameterName)
	{
		if (Animator == null)
		{
			return false;
		}
		AnimatorControllerParameter[] parameters = Animator.parameters;
		for (int i = 0; i < parameters.Length; i++)
		{
			if (parameters[i].name == parameterName)
			{
				return true;
			}
		}
		return false;
	}
}
