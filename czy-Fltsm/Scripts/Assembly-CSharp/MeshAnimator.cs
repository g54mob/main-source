using System.Collections;
using PajamaLlama.Debugs;
using UnityEngine;

public class MeshAnimator : MonoBehaviour
{
	public Animator Animator;

	[Header("Components")]
	[HideInInspector]
	public GameObject ParticlePlaying;

	[HideInInspector]
	public bool ParticleAlreadyPlayed;

	[HideInInspector]
	public bool RandomAnimationEnabled = true;

	[HideInInspector]
	public int LastStateHash;

	[HideInInspector]
	public bool PortraitAnimator;

	private GameObject _backpack;

	private AnimationTools _animationTools;

	private Agent _agent;

	private AnimatorState _lastAnimatorState;

	public void Initialize()
	{
		_agent = GetComponentInParent<Agent>();
		_animationTools = GetComponentInChildren<AnimationTools>();
		_animationTools.Initialize(_agent);
	}

	public void UpdateAnimator(bool triggerActivity = false, int loopBlock = -1)
	{
		if (!_lastAnimatorState.Equals(_agent, triggerActivity, loopBlock))
		{
			SetAnimatorState(new AnimatorState(_agent, triggerActivity, loopBlock));
		}
	}

	private void SetAnimatorState(AnimatorState state)
	{
		Animator.SetBool("Alive", state.Alive);
		Animator.SetInteger("Floor", (int)state.Terrain);
		Animator.SetInteger("Boat", state.BoatID);
		Animator.SetInteger("Activity", (int)state.Activity);
		if (state.TriggerActivity)
		{
			Animator.SetTrigger("Activity Trigger");
		}
		Animator.SetInteger("Attribute", state.AttributeVariation);
		if (state.LoopBlocked != -1)
		{
			Animator.SetInteger("LoopBlocker", state.LoopBlocked);
		}
		ParticleAlreadyPlayed = false;
		_lastAnimatorState = state;
		_animationTools.CheckForBackpack();
	}

	public void StartAnimationCounter(float secondsToWait)
	{
		StartCoroutine(RandomAnimationCounter(secondsToWait));
	}

	public IEnumerator RandomAnimationCounter(float secondsToWait)
	{
		RandomAnimationEnabled = false;
		yield return new WaitForSeconds(secondsToWait);
		RandomAnimationEnabled = true;
	}

	public void SetFloat(string name, float value)
	{
		Animator.SetFloat(name, value);
	}

	public void UpdatePortraitAnimator(Agent agent, Activity activity)
	{
		UpdatePortraitAnimator(activity, agent.Descriptor.Name, agent.DrifterRig.AttributeVariation);
	}

	public void UpdatePortraitAnimator(AgentDescriptor descriptor, Activity activity)
	{
		UpdatePortraitAnimator(activity, descriptor.Name, descriptor.AttributesVariation);
	}

	private void UpdatePortraitAnimator(Activity activity, string agentName, int attributeVariation)
	{
		AnimatorState animatorState = new AnimatorState
		{
			Activity = activity,
			AgentName = agentName + " Portrait character",
			Alive = true,
			BoatID = -1,
			Terrain = Navigator.TerrainType.Construction,
			AttributeVariation = attributeVariation
		};
		SetAnimatorState(animatorState);
		PortraitAnimator = true;
	}

	private void PrintAnimatorState(AnimatorState animatorState)
	{
		Debugger.Log(string.Format("Agent Name: {0}\nMale: {1}\nAlive: {2}\nCondition: {3}\nTerrain: {4}\nBoat ID: {5}\nActivity: {6}\nTransition ID: {7}", "Attribute: {8}", animatorState.AgentName, animatorState.Alive, animatorState.Terrain, animatorState.BoatID, animatorState.Activity, animatorState.AttributeVariation));
	}

	public void RestoreAnimatorState(AnimatorState animatorState, int shortNameHash, float normalizedTime)
	{
		SetAnimatorState(animatorState);
		Animator.Play(shortNameHash, 0, normalizedTime);
	}

	public AnimatorState ReturnAnimatorState()
	{
		return new AnimatorState
		{
			AgentName = _agent.Descriptor.Name,
			Alive = Animator.GetBool("Alive"),
			Terrain = (Navigator.TerrainType)Animator.GetInteger("Floor"),
			BoatID = Animator.GetInteger("Boat"),
			Activity = (Activity)Animator.GetInteger("Activity"),
			LoopBlocked = Animator.GetInteger("LoopBlocker"),
			AttributeVariation = Animator.GetInteger("Attribute")
		};
	}

	public AnimatorStateInfo ReturnCurrentAnimatorStateInfo(int layerIndex = 0)
	{
		return Animator.GetCurrentAnimatorStateInfo(layerIndex);
	}
}
