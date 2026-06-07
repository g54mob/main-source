using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class MeshAnimatorPersistentData
{
	public AnimatorState AnimatorState;

	public int ShortNameHash;

	public float NormalizedTime;

	public MeshAnimatorPersistentData(Agent agent)
	{
		MeshAnimator componentInChildren = agent.GetComponentInChildren<MeshAnimator>();
		AnimatorState = componentInChildren.ReturnAnimatorState();
		AnimatorStateInfo animatorStateInfo = componentInChildren.ReturnCurrentAnimatorStateInfo();
		ShortNameHash = animatorStateInfo.shortNameHash;
		NormalizedTime = animatorStateInfo.normalizedTime;
	}

	public void Restore(Agent agent)
	{
		agent.StartCoroutine(RestoreCoroutine(agent));
	}

	private IEnumerator RestoreCoroutine(Agent agent)
	{
		yield return new WaitForEndOfFrame();
		agent.GetComponentInChildren<MeshAnimator>().RestoreAnimatorState(AnimatorState, ShortNameHash, NormalizedTime);
	}
}
