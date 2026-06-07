using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TutorialStep
{
	public string stepTitle;

	[TextArea]
	public string stepDescription;

	public TutorialStepType stepType;

	public Sprite stepImage;

	[Header("Step Settings")]
	[Tooltip("Bu step bir bilgilendirme paneli mi? true ise InfoUI acilir, StepUI olusturulmaz.")]
	public bool isInfoStep;

	[Tooltip("true ise step gecisinde bildirim bekleme suresi atlanir, direkt acilir.")]
	public bool skipTransitionDelay;

	public List<TutorialSubStep> subSteps;

	[HideInInspector]
	public bool editorIsStepCompleted;

	public bool IsStepCompleted
	{
		get
		{
			if (isInfoStep)
			{
				return false;
			}
			if (subSteps == null || subSteps.Count == 0)
			{
				return false;
			}
			return subSteps.TrueForAll((TutorialSubStep sub) => sub.isCompleted);
		}
	}
}
