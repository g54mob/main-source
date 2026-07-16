using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Encounter")]
public class Encounter : ScriptableObject
{
	protected MysteryLocationWindow mysteryLocationUI;

	private bool encounterInProgress;

	[field: SerializeField]
	public LocalizedString EncounterName { get; set; }

	[field: SerializeField]
	public EncounterType EncounterType { get; set; }

	[field: SerializeField]
	public Sprite EncounterPortrait { get; set; }

	[field: SerializeField]
	public LocalizedString EncounterDescription { get; private set; }

	[field: SerializeField]
	public LocalizedString Option1 { get; private set; }

	[field: SerializeField]
	public LocalizedString Option2 { get; private set; }

	[field: SerializeField]
	public LocalizedString Option3 { get; private set; }

	[field: SerializeField]
	public LocalizedString Resolution1 { get; set; }

	[field: SerializeField]
	public LocalizedString Resolution2 { get; set; }

	[field: SerializeField]
	public LocalizedString Resolution3 { get; set; }

	[field: SerializeField]
	public LocalizedString Reward1 { get; set; }

	[field: SerializeField]
	public LocalizedString Reward2 { get; set; }

	[field: SerializeField]
	public LocalizedString Reward3 { get; set; }

	protected TextMeshProUGUI EncounterTextUI { get; set; }

	protected Image EncounterPortraitUI { get; set; }

	protected TextMeshProUGUI EncounterNameTextUI { get; set; }

	protected TextMeshProUGUI EncounterNameText2UI { get; set; }

	protected Button Option1ButtonUI { get; set; }

	protected Button Option2ButtonUI { get; set; }

	protected Button Option3ButtonUI { get; set; }

	protected Button ContinueButtonUI { get; set; }

	protected TextMeshProUGUI Option1TextUI { get; set; }

	protected TextMeshProUGUI Option2TextUI { get; set; }

	protected TextMeshProUGUI Option3TextUI { get; set; }

	protected TextMeshProUGUI ResolutionTextUI { get; set; }

	protected TextMeshProUGUI RewardsTextUI { get; set; }

	protected GameObject FirstWindow { get; set; }

	protected GameObject SecondWindow { get; set; }

	public virtual bool EncounterRequirementsMet()
	{
		return true;
	}

	protected virtual void CheckRequirementsForEveryOption()
	{
	}

	public virtual void StartEncounter()
	{
		encounterInProgress = true;
		mysteryLocationUI = MysteryLocationWindow.Instance;
		EncounterTextUI = mysteryLocationUI.encounterText;
		EncounterPortraitUI = mysteryLocationUI.encounterPortraitImg;
		EncounterNameTextUI = mysteryLocationUI.encounterNameText;
		EncounterNameText2UI = mysteryLocationUI.encounterNameText2;
		Option1ButtonUI = mysteryLocationUI.option1Button;
		Option2ButtonUI = mysteryLocationUI.option2Button;
		Option3ButtonUI = mysteryLocationUI.option3Button;
		Option1TextUI = mysteryLocationUI.option1Text;
		Option2TextUI = mysteryLocationUI.option2Text;
		Option3TextUI = mysteryLocationUI.option3Text;
		ContinueButtonUI = mysteryLocationUI.continueButton;
		ResolutionTextUI = mysteryLocationUI.resolutionText;
		RewardsTextUI = mysteryLocationUI.rewardText;
		FirstWindow = mysteryLocationUI.firstWindow;
		SecondWindow = mysteryLocationUI.secondWindow;
		Option1ButtonUI.onClick.RemoveAllListeners();
		Option2ButtonUI.onClick.RemoveAllListeners();
		Option3ButtonUI.onClick.RemoveAllListeners();
		Option1ButtonUI.onClick.AddListener(Option1Chosen);
		Option2ButtonUI.onClick.AddListener(Option2Chosen);
		Option3ButtonUI.onClick.AddListener(Option3Chosen);
		EncounterTextUI.text = EncounterDescription.GetLocalizedString();
		EncounterPortraitUI.sprite = EncounterPortrait;
		EncounterNameTextUI.text = EncounterName.GetLocalizedString();
		EncounterNameText2UI.text = EncounterName.GetLocalizedString();
		SetAllOptionsText();
		Option1ButtonUI.interactable = true;
		Option2ButtonUI.interactable = true;
		Option3ButtonUI.interactable = true;
		Option1ButtonUI.gameObject.SetActive(value: true);
		Option2ButtonUI.gameObject.SetActive(value: true);
		Option3ButtonUI.gameObject.SetActive(value: true);
		FirstWindow.SetActive(value: true);
		SecondWindow.SetActive(value: false);
		CheckRequirementsForEveryOption();
		SelectFirstOption();
		SaveManager.Instance.SetEncounter(this);
	}

	public virtual void EndEncounter()
	{
		if (encounterInProgress)
		{
			LevelManager.Instance.CurrentLevel.IsLooted = true;
			MenuManager.Instance.CloseAllMenus();
			Option1ButtonUI.onClick.RemoveListener(Option1Chosen);
			Option2ButtonUI.onClick.RemoveListener(Option2Chosen);
			Option3ButtonUI.onClick.RemoveListener(Option3Chosen);
			encounterInProgress = false;
		}
	}

	protected virtual void OnOptionChosen()
	{
		SecondWindow.SetActive(value: true);
		FirstWindow.SetActive(value: false);
		mysteryLocationUI.StartCoroutineForCurrentEncounter(DebounceInput());
		SaveManager.Instance.ColectedLevelReward = true;
		SaveManager.Instance.SaveJourney();
	}

	public virtual void Option1Chosen()
	{
		OnOptionChosen();
		if (!Resolution1.IsEmpty)
		{
			ResolutionTextUI.text = Resolution1.GetLocalizedString();
			if (!Reward1.IsEmpty)
			{
				RewardsTextUI.text = Reward1.GetLocalizedString();
			}
		}
	}

	public virtual void Option2Chosen()
	{
		OnOptionChosen();
		if (!Resolution2.IsEmpty)
		{
			ResolutionTextUI.text = Resolution2.GetLocalizedString();
			if (!Reward2.IsEmpty)
			{
				RewardsTextUI.text = Reward2.GetLocalizedString();
			}
		}
	}

	public virtual void Option3Chosen()
	{
		OnOptionChosen();
		if (!Resolution3.IsEmpty)
		{
			ResolutionTextUI.text = Resolution3.GetLocalizedString();
			if (!Reward3.IsEmpty)
			{
				RewardsTextUI.text = Reward3.GetLocalizedString();
			}
		}
	}

	protected virtual void SetAllOptionsText()
	{
		Option1TextUI.text = "1. " + Option1.GetLocalizedString();
		Option2TextUI.text = "2. " + Option2.GetLocalizedString();
		if (!Option3.IsEmpty)
		{
			Option3TextUI.text = "3. " + Option3.GetLocalizedString();
		}
	}

	protected virtual void SetOptionText(TextMeshProUGUI UItext, string text)
	{
		if (UItext == Option1TextUI)
		{
			UItext.text = "1. " + text;
		}
		else if (UItext == Option2TextUI)
		{
			UItext.text = "2. " + text;
		}
		else if (UItext == Option3TextUI)
		{
			UItext.text = "3. " + text;
		}
		else
		{
			Debug.LogError("Wrong field set.");
		}
	}

	public virtual void SelectFirstOption()
	{
		Button[] array = new Button[3] { Option1ButtonUI, Option2ButtonUI, Option3ButtonUI };
		for (int i = 0; i < 3; i++)
		{
			if (array[i].interactable)
			{
				EventSystem.current.SetSelectedGameObject(array[i].gameObject);
				break;
			}
		}
	}

	private IEnumerator DebounceInput()
	{
		yield return new WaitForSecondsRealtime(0.01f);
		EventSystem.current.SetSelectedGameObject(ContinueButtonUI.gameObject);
	}
}
