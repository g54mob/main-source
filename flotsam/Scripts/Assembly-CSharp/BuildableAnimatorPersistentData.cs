using System;
using UnityEngine;

[Serializable]
public class BuildableAnimatorPersistentData
{
	public int shortNameHash;

	public float normalizedTime;

	private BuildableAnimatorPersistentData(Buildable buildable)
	{
		AnimatorStateInfo animatorStateInfo = buildable.BuildableAnimator.ReturnCurrentAnimatorClipInfo();
		shortNameHash = animatorStateInfo.shortNameHash;
		normalizedTime = animatorStateInfo.normalizedTime;
	}

	public void Restore(Buildable buildable)
	{
		buildable.BuildableAnimator.RestoreAnimatorState(shortNameHash, normalizedTime);
	}

	public static BuildableAnimatorPersistentData Create(Buildable buildable)
	{
		if ((bool)buildable.BuildableAnimator)
		{
			return new BuildableAnimatorPersistentData(buildable);
		}
		return null;
	}
}
