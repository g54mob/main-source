using System;
using UnityEngine;

public abstract class TutorialSequence : MonoBehaviour
{
	public TutorialID tutorialID;

	public bool validForCreativeCharacters;

	public float delayAfterConditionsMet = 60f;

	public virtual bool ReadyToRun()
	{
		return true;
	}

	public abstract bool HasBeenBypassed();

	public abstract void StartTutorialSequence(Action<bool> onFinished);

	public virtual void AbortTutorialSequence()
	{
		StopAllCoroutines();
	}
}
