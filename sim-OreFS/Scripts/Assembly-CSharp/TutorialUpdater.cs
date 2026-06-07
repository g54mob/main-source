using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialUpdater : MonoBehaviour
{
	public List<TutorialTrigger> tutorialTriggers = new List<TutorialTrigger>();

	public UnityEvent CompleteTutorialEvent;

	public UnityEvent CompleteTransitionEvent;

	public bool tutorialFinished;

	public void UpdateTutorials(TutorialSubStepType overrideSubStep = TutorialSubStepType.None, int[] completedSubStepsSnapshot = null)
	{
		foreach (TutorialTrigger tutorialTrigger in tutorialTriggers)
		{
			if (tutorialTrigger != null)
			{
				tutorialTrigger.CheckCurrentTutorial(tutorialFinished, overrideSubStep, completedSubStepsSnapshot);
			}
		}
	}

	public void NotifyTriggerCompleted(TutorialSubStepType subStepType)
	{
		foreach (TutorialTrigger tutorialTrigger in tutorialTriggers)
		{
			if (tutorialTrigger != null && tutorialTrigger.subStepType == subStepType)
			{
				tutorialTrigger.tutorialCompletedEvent?.Invoke();
			}
		}
	}

	public void CompleteTutorial(TutorialConfigType currentConfigType)
	{
		tutorialFinished = true;
		CompleteTutorialEvent.Invoke();
	}

	public void CompleteTransition()
	{
		CompleteTransitionEvent.Invoke();
	}

	public void EnableAllInteractables()
	{
		tutorialFinished = true;
		CompleteTutorialEvent?.Invoke();
		UpdateTutorials();
	}
}
