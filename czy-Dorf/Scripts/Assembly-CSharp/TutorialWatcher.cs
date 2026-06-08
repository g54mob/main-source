using System;
using UnityEngine;

public abstract class TutorialWatcher : MonoBehaviour
{
	protected TutorialManager tutorialManager;

	protected TutorialPhase tutorialPhase;

	public event Action OnConditionFulfilled;

	public void Setup(TutorialManager tutorialManager, TutorialPhase tutorialPhase)
	{
		this.tutorialManager = tutorialManager;
		this.tutorialPhase = tutorialPhase;
	}

	public abstract void StartWatching();

	protected void ConditionFulfilled()
	{
		this.OnConditionFulfilled?.Invoke();
	}
}
