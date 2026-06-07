using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialTrigger : MonoBehaviour
{
	[Header("Tutorial Config")]
	public TutorialConfigType tutorialType;

	public TutorialStepType stepType;

	public TutorialSubStepType subStepType;

	public bool checkMatch;

	[Header("Auto Register")]
	[Tooltip("True ise Awake'de TutorialUpdater listesine otomatik eklenir")]
	public bool autoRegisterToUpdater;

	[Header("Trigger & POI Config")]
	public bool hasTrigger;

	public bool hasPOI;

	public string triggerTag = "Player";

	[Header("References")]
	public GameObject POI;

	public Collider tutorialTrigger;

	[Header("Events")]
	public UnityEvent thisActiveEvent;

	public UnityEvent thisFalseEvent;

	public UnityEvent tutorialCompletedEvent;

	private void Awake()
	{
		if (autoRegisterToUpdater)
		{
			RegisterToUpdater();
		}
	}

	private void OnDisable()
	{
		if (autoRegisterToUpdater)
		{
			UnregisterFromUpdater();
		}
	}

	private void RegisterToUpdater()
	{
		if (!(TutorialManager.Instance == null) && !(TutorialManager.Instance.tutorialUpdater == null))
		{
			List<TutorialTrigger> tutorialTriggers = TutorialManager.Instance.tutorialUpdater.tutorialTriggers;
			if (!tutorialTriggers.Contains(this))
			{
				tutorialTriggers.Add(this);
			}
		}
	}

	private void UnregisterFromUpdater()
	{
		if (!(TutorialManager.Instance == null) && !(TutorialManager.Instance.tutorialUpdater == null))
		{
			List<TutorialTrigger> tutorialTriggers = TutorialManager.Instance.tutorialUpdater.tutorialTriggers;
			tutorialTriggers.Remove(this);
			tutorialTriggers.RemoveAll((TutorialTrigger t) => t == null);
		}
	}

	public void CheckCurrentTutorial(bool isFinished, TutorialSubStepType overrideSubStep = TutorialSubStepType.None, int[] completedSubStepsSnapshot = null)
	{
		if (TutorialManager.Instance == null)
		{
			return;
		}
		if (((overrideSubStep != TutorialSubStepType.None) ? overrideSubStep : TutorialManager.Instance.CurrentSubStep) == subStepType && !isFinished)
		{
			thisActiveEvent.Invoke();
			if (hasPOI && POI != null)
			{
				POI.SetActive(value: true);
			}
			if (hasTrigger && tutorialTrigger != null)
			{
				tutorialTrigger.enabled = true;
			}
			return;
		}
		if (!((completedSubStepsSnapshot != null) ? (Array.IndexOf(completedSubStepsSnapshot, (int)subStepType) >= 0) : TutorialManager.Instance.IsSubStepCompleted(subStepType)) && !isFinished)
		{
			thisFalseEvent.Invoke();
		}
		if (hasPOI && POI != null)
		{
			POI.SetActive(value: false);
		}
		if (hasTrigger && tutorialTrigger != null)
		{
			tutorialTrigger.enabled = false;
		}
	}

	public void UpdateTutorial()
	{
		if (TutorialManager.Instance == null || TutorialManager.Instance.GetActiveConfig() != tutorialType)
		{
			return;
		}
		if (checkMatch)
		{
			if (TutorialManager.Instance.CurrentStep == stepType)
			{
				TutorialManager.Instance.CompleteSubStep(tutorialType, stepType, subStepType);
				CheckCurrentTutorial(isFinished: true);
			}
			else
			{
				thisFalseEvent.Invoke();
			}
		}
		else if (!TutorialManager.Instance.IsSubStepCompleted(subStepType))
		{
			TutorialManager.Instance.CompleteSubStep(tutorialType, stepType, subStepType);
			CheckCurrentTutorial(isFinished: true);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag(triggerTag) && hasTrigger)
		{
			UpdateTutorial();
		}
	}
}
