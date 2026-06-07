using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialStepUI : MonoBehaviour
{
	[Header("UI References")]
	public Transform subStepParent;

	[SerializeField]
	private TextMeshProUGUI stepTitleText;

	[SerializeField]
	private TextMeshProUGUI stepDescriptionText;

	[SerializeField]
	private Image stepImage;

	[Header("Prefab")]
	[SerializeField]
	private GameObject subStepPrefab;

	[Header("Step Objects")]
	public List<TutorialStepObject> tutorialStepObjects = new List<TutorialStepObject>();

	public GameObject controlsHeader;

	private Dictionary<TutorialSubStepType, GameObject> instantiatedSubSteps = new Dictionary<TutorialSubStepType, GameObject>();

	private TutorialStepType currentStepType;

	private TutorialConfigType currentConfigType;

	public void InitializeStep(TutorialStep step, TutorialConfigType configType)
	{
		currentStepType = step.stepType;
		currentConfigType = configType;
		UpdateStepObjects();
	}

	private void UpdateStepObjects()
	{
		if (tutorialStepObjects == null)
		{
			return;
		}
		foreach (TutorialStepObject tutorialStepObject in tutorialStepObjects)
		{
			if (tutorialStepObject.stepObject != null)
			{
				tutorialStepObject.stepObject.SetActive(value: false);
				controlsHeader.SetActive(value: false);
			}
		}
		foreach (TutorialStepObject tutorialStepObject2 in tutorialStepObjects)
		{
			if (tutorialStepObject2.stepObject != null)
			{
				bool flag = tutorialStepObject2.stepType == currentStepType && tutorialStepObject2.configType == currentConfigType;
				if (flag)
				{
					tutorialStepObject2.stepObject.SetActive(flag);
					controlsHeader.SetActive(value: true);
				}
			}
		}
	}

	public void ClearSubSteps()
	{
		if (subStepParent == null)
		{
			return;
		}
		foreach (Transform item in subStepParent)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void DisplayStepHeader(TutorialStep stepData)
	{
		Show();
		if (stepTitleText != null)
		{
			string translation = LocalizationManager.GetTranslation(stepData.stepTitle);
			stepTitleText.text = ((!string.IsNullOrEmpty(translation)) ? translation : stepData.stepTitle);
		}
		if (stepDescriptionText != null)
		{
			string translation2 = LocalizationManager.GetTranslation(stepData.stepDescription);
			stepDescriptionText.text = ((!string.IsNullOrEmpty(translation2)) ? translation2 : stepData.stepDescription);
		}
		if (stepImage != null)
		{
			if (stepData.stepImage != null)
			{
				stepImage.sprite = stepData.stepImage;
				stepImage.gameObject.SetActive(value: true);
			}
			else
			{
				stepImage.sprite = null;
				stepImage.gameObject.SetActive(value: false);
			}
		}
	}

	public void PopulateSubSteps(List<TutorialSubStep> subSteps, Func<TutorialSubStepType, bool> isCompleted, Func<TutorialSubStepType, int> getProgress, bool isHost = true)
	{
		if (subSteps == null)
		{
			return;
		}
		foreach (TutorialSubStep subStep in subSteps)
		{
			bool flag = isCompleted(subStep.subStepType);
			int num = getProgress(subStep.subStepType);
			if (instantiatedSubSteps.TryGetValue(subStep.subStepType, out var value) && value != null)
			{
				TutorialSubStepItemUI component = value.GetComponent<TutorialSubStepItemUI>();
				if (component != null)
				{
					if (flag)
					{
						component.SetCount(Mathf.Max(1, subStep.targetCount));
					}
					else if (num > 0)
					{
						component.SetCount(num);
					}
				}
			}
			else
			{
				if (subStepPrefab == null || subStepParent == null)
				{
					continue;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(subStepPrefab, subStepParent);
				instantiatedSubSteps[subStep.subStepType] = gameObject;
				TutorialSubStepItemUI component2 = gameObject.GetComponent<TutorialSubStepItemUI>();
				if (component2 != null)
				{
					string translation = LocalizationManager.GetTranslation(subStep.subStepDescription);
					component2.descriptionText.text = ((!string.IsNullOrEmpty(translation)) ? translation : subStep.subStepDescription);
					component2.Initialize(subStep.targetCount, subStep.canClientComplete, isHost);
					if (flag)
					{
						component2.SetCount(Mathf.Max(1, subStep.targetCount));
					}
					else if (num > 0)
					{
						component2.SetCount(num);
					}
				}
			}
		}
	}

	public void MarkSubStepCompleted(TutorialSubStepType subStepType, int targetCount)
	{
		if (instantiatedSubSteps.TryGetValue(subStepType, out var value) && value != null)
		{
			TutorialSubStepItemUI component = value.GetComponent<TutorialSubStepItemUI>();
			if (component != null)
			{
				component.SetCount(Mathf.Max(1, targetCount));
			}
		}
	}

	public void UpdateSubStepProgress(TutorialSubStepType subStepType, int currentCount)
	{
		if (instantiatedSubSteps.TryGetValue(subStepType, out var value) && value != null)
		{
			TutorialSubStepItemUI component = value.GetComponent<TutorialSubStepItemUI>();
			if (component != null)
			{
				component.SetCount(currentCount);
			}
		}
	}

	public void ClearSubStepInstances()
	{
		foreach (GameObject value in instantiatedSubSteps.Values)
		{
			if (value != null)
			{
				UnityEngine.Object.Destroy(value);
			}
		}
		instantiatedSubSteps.Clear();
	}
}
