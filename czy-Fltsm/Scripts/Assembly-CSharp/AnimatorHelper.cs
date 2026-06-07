using UnityEngine;
using UnityEngine.Events;

public static class AnimatorHelper
{
	public const string AGENT_PARAMETER_Activity = "Activity";

	public const string AGENT_PARAMETER_ActivityTrigger = "Activity Trigger";

	public const string AGENT_PARAMETER_Floor = "Floor";

	public const string AGENT_PARAMETER_TransitionTrigger = "Transition Trigger";

	public const string AGENT_PARAMETERS_SpeedMultiplier = "Speed Multiplier";

	public static float ReturnAnimationLength(Agent agent, string name)
	{
		if (TryReturnAnimator(agent, out var animator))
		{
			return ReturnAnimationLength(animator, name);
		}
		return 0f;
	}

	public static void SetTransitionTrigger(Agent agent)
	{
		if (TryReturnAnimator(agent, out var animator))
		{
			animator.SetTrigger("Transition Trigger");
		}
	}

	public static void SetInteger(Agent agent, string name, int value)
	{
		if (TryReturnAnimator(agent, out var animator))
		{
			animator.SetInteger(name, value);
		}
	}

	public static void SetFloat(Agent agent, string name, float value)
	{
		if (TryReturnAnimator(agent, out var animator))
		{
			animator.SetFloat(name, value);
		}
	}

	public static float ReturnCurrentAnimatorStateLength(Agent agent, int layerIndex = 0)
	{
		if (TryReturnAnimator(agent, out var animator))
		{
			AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
			return currentAnimatorStateInfo.length * currentAnimatorStateInfo.speedMultiplier;
		}
		return 0f;
	}

	public static void AddDirfterRigEventListener(Agent agent, UnityAction<DrifterRigItemEvent> listener)
	{
		if (TryReturnAnimationTools(agent, out var animationTools))
		{
			animationTools.DrifterRigEvent.AddListener(listener);
		}
	}

	public static void RemoveDirfterRigEventListener(Agent agent, UnityAction<DrifterRigItemEvent> listener)
	{
		if (TryReturnAnimationTools(agent, out var animationTools))
		{
			animationTools.DrifterRigEvent.RemoveListener(listener);
		}
	}

	public static void AddDrifterRigTypeEventListener(Agent agent, UnityAction<DrifterRigEventType> listener)
	{
		if (TryReturnAnimationTools(agent, out var animationTools))
		{
			animationTools.DrifterRigTypeEvent.AddListener(listener);
		}
	}

	public static void RemoveDrifterRigTypeEventListener(Agent agent, UnityAction<DrifterRigEventType> listener)
	{
		if (TryReturnAnimationTools(agent, out var animationTools))
		{
			animationTools.DrifterRigTypeEvent.RemoveListener(listener);
		}
	}

	private static bool TryReturnAnimator(Agent agent, out Animator animator)
	{
		animator = null;
		if (agent == null || agent.DrifterRig == null || agent.DrifterRig.MeshAnimator == null)
		{
			return false;
		}
		animator = agent.DrifterRig.MeshAnimator.Animator;
		return animator != null;
	}

	private static bool TryReturnAnimationTools(Agent agent, out AnimationTools animationTools)
	{
		animationTools = null;
		if (agent == null || agent.DrifterRig == null)
		{
			return false;
		}
		animationTools = agent.DrifterRig.AnimationTools;
		return animationTools != null;
	}

	public static float ReturnAnimationLength(this Buildable buildable, string name)
	{
		if (TryReturnAnimator(buildable, out var animator))
		{
			return ReturnAnimationLength(animator, name);
		}
		return 0f;
	}

	public static void SetAnimatorInteger(this Buildable buildable, string name, int value)
	{
		if (TryReturnAnimator(buildable, out var animator))
		{
			animator.SetInteger(name, value);
		}
	}

	private static bool TryReturnAnimator(Buildable buildable, out Animator animator)
	{
		animator = null;
		if (buildable == null || buildable.BuildableAnimator == null)
		{
			return false;
		}
		animator = buildable.BuildableAnimator.Animator;
		return animator != null;
	}

	private static float ReturnAnimationLength(Animator animator, string name)
	{
		if (animator.runtimeAnimatorController == null)
		{
			return 0f;
		}
		AnimationClip[] animationClips = animator.runtimeAnimatorController.animationClips;
		foreach (AnimationClip animationClip in animationClips)
		{
			if (animationClip.name == name)
			{
				return animationClip.length;
			}
		}
		return 0f;
	}
}
