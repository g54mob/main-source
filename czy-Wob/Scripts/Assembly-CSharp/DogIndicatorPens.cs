using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DogIndicatorPens : WorldSpaceBillboard
{
	public GameObject locationCircle;

	public TextMeshProUGUI dogNameText;

	public TextMeshProUGUI dogAgeText;

	public Color defaultDogNameColor = Color.white;

	public Color selectedDogNameColor;

	public GameObject uiGroupA;

	public GameObject mainGUIHolder;

	public GameObject thoughtBubble;

	public Image thoughtBubbleIcon;

	public CoreButtonUnityGUI bubbleButton;

	public Sprite cocoonIcon;

	public Sprite hungerIcon;

	public Sprite energyIcon;

	public Sprite fearIcon;

	public Sprite ghostGoneIcon;

	public GameObject reinforcementHolder;

	public TextMeshProUGUI reinforcementPropertyText;

	public List<InchwormBounce> negativeReinforcementPips;

	public List<InchwormBounce> positiveReinforcementPips;

	public GameObject currentActionUI;

	public InchwormBounce actionUIBouncer;

	public TextMeshProUGUI currentActionText;

	private Coroutine currentReinforcementRoutine;

	private List<ReinforcementRequest> reinforcementRequests = new List<ReinforcementRequest>();

	private string cocoonIconSound = "cocoon_bubble_icon";

	private bool uiLocked;

	private bool dogNameRequested;

	private bool actionStatusRequested;

	private bool thoughtBubbleRequested;

	private bool thoughtBubbleHiddenTemporarily;

	private Vector3 locationOffset = new Vector3(0f, 0.01f, 0f);

	private float indicatorTimer = 3f;

	private float currentIndicatorTimer;

	private string lastLanguage;

	private Canvas canvasRef;

	private DoggyBrain brainRef;

	private Inchworm inchwormRef;

	private ObjectIndicatorManager indicatorManagerRef;

	protected override void AwakeBehavior()
	{
		base.AwakeBehavior();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		inchwormRef = registrationScript.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		indicatorManagerRef = registrationScript.GetGlobalComponent<ObjectIndicatorManager>(GlobalObject.OBJECT_INDICATOR_MANAGER);
		canvasRef = holderTransform.GetComponent<Canvas>();
		locationCircle.SetActive(value: false);
		HideThoughtBubble();
		HideActionUI();
	}

	private void Update()
	{
		if (PauseController.IsUIEnabled())
		{
			if (!canvasRef.enabled)
			{
				canvasRef.enabled = true;
			}
			if (LocalizationManager.CurrentLanguage != lastLanguage)
			{
				OnLanguageUpdated();
			}
			UpdateIndicator();
			UpdateThoughtBubble();
			ShowAppropriateUI();
		}
		else
		{
			canvasRef.enabled = false;
		}
	}

	public void OnPropertyReinforced(string property, float oldPercentage, float newPercentage)
	{
		if (property == null || property.Length < 1)
		{
			return;
		}
		if (currentReinforcementRoutine != null)
		{
			reinforcementRequests.Add(new ReinforcementRequest(property, oldPercentage, newPercentage));
			return;
		}
		currentReinforcementRoutine = StartCoroutine(ReinforcementDisplayRoutine(property, oldPercentage, newPercentage));
		if (oldPercentage < 1f && newPercentage >= 1f)
		{
			GoalsController.ReportGoalEvent(GoalCondition.MAX_POSITIVE_REINFORCEMENT);
		}
		else if (oldPercentage > 0f && newPercentage <= 0f)
		{
			GoalsController.ReportGoalEvent(GoalCondition.MAX_NEGATIVE_REINFORCEMENT);
		}
	}

	private IEnumerator ReinforcementDisplayRoutine(string property, float oldPercentage, float newPercentage)
	{
		if (currentIndicatorTimer > 0f)
		{
			currentIndicatorTimer = 0f;
			HideActionUI();
		}
		float holdTime = 2f;
		float seconds = 0.5f;
		float pipWaitTime = 0.1f;
		reinforcementHolder.SetActive(value: true);
		reinforcementPropertyText.text = property;
		int num = negativeReinforcementPips.Count * 2;
		int newlyActivePositivePips = 0;
		int newlyActiveNegativePips = 0;
		int previouslyActivePositivePips = 0;
		int previouslyActiveNegativePips = 0;
		if (oldPercentage > 0.5f)
		{
			previouslyActivePositivePips = Mathf.FloorToInt((oldPercentage - 0.5f) / 0.5f * (float)num / 2f);
		}
		else if (oldPercentage < 0.5f)
		{
			previouslyActiveNegativePips = Mathf.FloorToInt((0.5f - oldPercentage) / 0.5f * (float)num / 2f);
		}
		if (newPercentage > 0.5f)
		{
			newlyActivePositivePips = Mathf.FloorToInt((newPercentage - 0.5f) / 0.5f * (float)num / 2f);
		}
		else if (newPercentage < 0.5f)
		{
			newlyActiveNegativePips = Mathf.FloorToInt((0.5f - newPercentage) / 0.5f * (float)num / 2f);
		}
		for (int i = 0; i < negativeReinforcementPips.Count; i++)
		{
			negativeReinforcementPips[i].transform.localScale = Vector3.one;
			negativeReinforcementPips[i].gameObject.SetActive(i < previouslyActiveNegativePips);
		}
		for (int j = 0; j < positiveReinforcementPips.Count; j++)
		{
			positiveReinforcementPips[j].transform.localScale = Vector3.one;
			positiveReinforcementPips[j].gameObject.SetActive(j < previouslyActivePositivePips);
		}
		yield return new WaitForSeconds(seconds);
		WaitForSeconds pipWait = new WaitForSeconds(pipWaitTime);
		for (int i2 = previouslyActivePositivePips - 1; i2 >= newlyActivePositivePips; i2--)
		{
			inchwormRef.RequestEaseToScale(positiveReinforcementPips[i2].gameObject, Vector3.zero, 0.5f, Inchworm.EaseStyle.Sin);
			yield return pipWait;
		}
		for (int i2 = previouslyActiveNegativePips - 1; i2 >= newlyActiveNegativePips; i2--)
		{
			inchwormRef.RequestEaseToScale(negativeReinforcementPips[i2].gameObject, Vector3.zero, 0.5f, Inchworm.EaseStyle.Sin);
			yield return pipWait;
		}
		for (int i2 = previouslyActivePositivePips; i2 < newlyActivePositivePips; i2++)
		{
			positiveReinforcementPips[i2].gameObject.SetActive(value: true);
			positiveReinforcementPips[i2].transform.localScale = Vector3.zero;
			inchwormRef.RequestEaseToScale(positiveReinforcementPips[i2].gameObject, Vector3.one, 0.5f, Inchworm.EaseStyle.Sin);
			yield return pipWait;
		}
		for (int i2 = previouslyActiveNegativePips; i2 < newlyActiveNegativePips; i2++)
		{
			negativeReinforcementPips[i2].gameObject.SetActive(value: true);
			negativeReinforcementPips[i2].transform.localScale = Vector3.zero;
			inchwormRef.RequestEaseToScale(negativeReinforcementPips[i2].gameObject, Vector3.one, 0.5f, Inchworm.EaseStyle.Sin);
			yield return pipWait;
		}
		yield return new WaitForSeconds(holdTime);
		reinforcementHolder.SetActive(value: false);
		currentReinforcementRoutine = null;
		OnReinforcementComplete();
	}

	private void OnReinforcementComplete()
	{
		if (reinforcementRequests.Count != 0)
		{
			ReinforcementRequest reinforcementRequest = reinforcementRequests[0];
			reinforcementRequests.RemoveAt(0);
			currentReinforcementRoutine = StartCoroutine(ReinforcementDisplayRoutine(reinforcementRequest._property, reinforcementRequest._oldPercentage, reinforcementRequest._newPercentage));
		}
	}

	public void OnDogSelected()
	{
		dogNameText.color = selectedDogNameColor;
	}

	public void OnDogDeselected()
	{
		dogNameText.color = defaultDogNameColor;
	}

	public void SetName(string dogName)
	{
		dogNameText.text = dogName;
		dogNameText.color = defaultDogNameColor;
	}

	public void UpdateDogAge(DoggyBrain newRef)
	{
		SetBrainRef(newRef);
	}

	public void SetBrainRef(DoggyBrain newRef)
	{
		brainRef = newRef;
		RefreshAgeText();
	}

	public void OnLanguageUpdated()
	{
		RefreshAgeText();
	}

	public void RefreshAgeText()
	{
		if (!(brainRef == null))
		{
			lastLanguage = LocalizationManager.CurrentLanguage;
			if (brainRef.IsGhost())
			{
				dogAgeText.text = ScriptLocalization.GUI.GUI_AGE_GHOST;
			}
			else
			{
				dogAgeText.text = DoggyBrain.GetReadableNameForDogAge(brainRef.GetCurrentDogAge());
			}
		}
	}

	public void LockUI()
	{
		uiLocked = true;
	}

	public void UnlockUI()
	{
		uiLocked = false;
	}

	private void ShowAppropriateUI()
	{
		bool active = false;
		bool active2 = false;
		bool active3 = false;
		if (!uiLocked && currentReinforcementRoutine == null)
		{
			if (actionStatusRequested)
			{
				active3 = true;
				if (dogNameRequested)
				{
					active2 = true;
				}
			}
			else if (thoughtBubbleRequested)
			{
				active = true;
			}
			else if (dogNameRequested)
			{
				active2 = true;
			}
		}
		if (currentActionUI != null)
		{
			currentActionUI.SetActive(active3);
		}
		if (mainGUIHolder != null)
		{
			mainGUIHolder.SetActive(active2);
		}
		if (thoughtBubble != null)
		{
			thoughtBubble.SetActive(active);
		}
		if (currentReinforcementRoutine == null)
		{
			reinforcementHolder.SetActive(value: false);
		}
	}

	private void UpdateIndicator()
	{
		if (currentActionUI.activeSelf)
		{
			currentIndicatorTimer -= Time.deltaTime;
			if (currentIndicatorTimer <= 0f)
			{
				currentIndicatorTimer = 0f;
				HideActionUI();
			}
		}
	}

	public void OnBehaviorFinished()
	{
		if (locationCircle != null)
		{
			locationCircle.SetActive(value: false);
		}
	}

	public void ShowActionSucceededUI(string actionSuccessText, Vector3? location = null)
	{
		actionStatusRequested = true;
		currentIndicatorTimer = indicatorTimer;
		currentActionText.text = actionSuccessText;
		actionUIBouncer.RequestBounce();
		if (location.HasValue)
		{
			locationCircle.SetActive(value: true);
			locationCircle.transform.position = location.Value + locationOffset;
		}
	}

	public void ShowActionFailedUI(string customString = "")
	{
		actionStatusRequested = true;
		currentIndicatorTimer = indicatorTimer;
		if (customString.Length > 0)
		{
			currentActionText.text = customString;
		}
		else
		{
			currentActionText.text = ScriptLocalization.BehaviorsAndCommands.CMND_FAIL;
		}
		actionUIBouncer.RequestBounce();
	}

	public void HideActionUI()
	{
		actionStatusRequested = false;
		locationCircle.SetActive(value: false);
	}

	public void ShowNameTag()
	{
		dogNameRequested = true;
	}

	public void HideNameTag()
	{
		dogNameRequested = false;
	}

	private void ShowThoughtBubble(Sprite icon, bool clickable = false)
	{
		if (!thoughtBubbleRequested && !thoughtBubbleHiddenTemporarily)
		{
			AudioController.Play(cocoonIconSound, brainRef.GetComponent<LegController>().bodyFront.transform.position);
		}
		thoughtBubbleRequested = true;
		thoughtBubbleIcon.sprite = icon;
		thoughtBubbleHiddenTemporarily = false;
		bubbleButton.enabled = clickable;
		bubbleButton.interactable = clickable;
	}

	public void HideThoughtBubble(bool temporary = false)
	{
		thoughtBubbleRequested = false;
		thoughtBubbleHiddenTemporarily = temporary;
	}

	public void OnCocoonThoughtBubbleClicked()
	{
		indicatorManagerRef.ReportClick(brainRef.gameObject);
	}

	private void UpdateThoughtBubble()
	{
		if (brainRef == null)
		{
			return;
		}
		if (brainRef.IsReadyForCocoon())
		{
			if (ObjectPlacementManager.IsInPlacementMode() || indicatorManagerRef.IsContextMenuActiveForObject(brainRef.gameObject))
			{
				HideThoughtBubble(temporary: true);
			}
			else
			{
				ShowThoughtBubble(cocoonIcon, clickable: true);
			}
		}
		else
		{
			HideThoughtBubble();
		}
	}
}
