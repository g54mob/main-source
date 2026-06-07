using System;

[Serializable]
public class Tutorial
{
	public TutorialConfigType currentConfigType;

	public bool isActive;

	public TutorialStepType currentStep;

	public TutorialSubStepType currentSubStep;

	public bool isCompleted;

	public TutorialStepType lastStep;

	public TutorialConfig tutorialConfig;
}
