using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Encounter", menuName = "Encounter/Gambler")]
public class EncounterGambler : Encounter
{
	[Header("Option 1")]
	private float startingScrapCost;

	[SerializeField]
	private float startingScrapCostEasy;

	[SerializeField]
	private float startingScrapCostMedium;

	[SerializeField]
	private float startingScrapCostHard;

	private float scrapCost;

	[SerializeField]
	private float startingProbability;

	private float probability;

	[SerializeField]
	private float scrapCostIncrease;

	[SerializeField]
	private float probabilityIncrease;

	[SerializeField]
	private GameObject containerPrefab;

	private CardContainer currentContainer;

	private Button claimButton;

	private Button declineButton;

	private Action containerOpenedHandler;

	private bool startedRemovingUpgrade;

	public override bool EncounterRequirementsMet()
	{
		switch (LevelManager.Instance.CurrentLevel.Difficulty.Name)
		{
		case "Easy":
			startingScrapCost = startingScrapCostEasy;
			break;
		case "Medium":
			startingScrapCost = startingScrapCostMedium;
			break;
		case "Hard":
			startingScrapCost = startingScrapCostHard;
			break;
		default:
			Debug.Log("Invalid Difficulty set.");
			break;
		}
		if (LootUtils.ViableUpgrades().Count == 0)
		{
			return false;
		}
		if (ResourceManager.Instance.Scrap.Value < startingScrapCost)
		{
			return false;
		}
		return true;
	}

	public override void StartEncounter()
	{
		base.StartEncounter();
		base.FirstWindow.SetActive(value: false);
		mysteryLocationUI.gamblerWindow.SetActive(value: true);
		mysteryLocationUI.gamblerText.text = base.EncounterDescription.GetLocalizedString();
		base.Option1TextUI = mysteryLocationUI.gamblerGambleText;
		base.Option2TextUI = mysteryLocationUI.gamblerDeclineText;
		base.Option3TextUI = mysteryLocationUI.gamblerClaimText;
		SetAllOptionsText();
		mysteryLocationUI.gamblerPortraitImg.sprite = base.EncounterPortrait;
		mysteryLocationUI.gamblerNameText.text = base.EncounterName.GetLocalizedString();
		base.Option1ButtonUI = mysteryLocationUI.gamblerGambleButton;
		base.Option2ButtonUI = mysteryLocationUI.gamblerDeclineButton;
		base.Option3TextUI.text = "1. " + base.Option3.GetLocalizedString();
		probability = startingProbability;
		scrapCost = startingScrapCost;
		base.Option1ButtonUI.onClick.AddListener(Option1Chosen);
		base.Option2ButtonUI.onClick.AddListener(Option2Chosen);
		claimButton = mysteryLocationUI.gamblerClaimButton;
		declineButton = base.Option2ButtonUI;
		declineButton.interactable = false;
		containerOpenedHandler = delegate
		{
			claimButton.interactable = true;
			EventSystem.current.SetSelectedGameObject(claimButton.gameObject);
		};
		base.Option1.Arguments = new object[1] { startingScrapCost };
		SetOptionText(base.Option1TextUI, base.Option1.GetLocalizedString());
		mysteryLocationUI.gamblerClaimButton.gameObject.SetActive(value: false);
		base.Option1ButtonUI.gameObject.SetActive(value: true);
		mysteryLocationUI.Closed += Cleanup;
		SelectFirstOption();
	}

	public override void EndEncounter()
	{
		claimButton.onClick.RemoveAllListeners();
		declineButton.onClick.RemoveAllListeners();
		if (mysteryLocationUI.gamblerContainerHolder.childCount > 0)
		{
			mysteryLocationUI.gamblerContainerHolder.GetChild(0).gameObject.GetComponent<CargoContainer>().OnContainerOpened -= ContainerOpened;
			UnityEngine.Object.Destroy(mysteryLocationUI.gamblerContainerHolder.GetChild(0).gameObject);
		}
		mysteryLocationUI.gamblerWindow.SetActive(value: false);
		SaveManager.Instance.ColectedLevelReward = true;
		SaveManager.Instance.SaveJourney();
		base.Option1ButtonUI.interactable = true;
		declineButton.interactable = false;
		if (currentContainer != null)
		{
			UnityEngine.Object.Destroy(mysteryLocationUI.gamblerContainerHolder.GetChild(0).gameObject);
			if (ResourceManager.Instance.Scrap.Value >= scrapCost)
			{
				base.Option1ButtonUI.interactable = true;
			}
		}
		mysteryLocationUI.Closed -= Cleanup;
		base.EndEncounter();
	}

	protected override void OnOptionChosen()
	{
	}

	public override void Option1Chosen()
	{
		ResourceManager.Instance.Scrap.TrySpend(scrapCost);
		scrapCost += scrapCostIncrease;
		if (ResourceManager.Instance.Scrap.Value < scrapCost)
		{
			base.Option1ButtonUI.interactable = false;
		}
		base.Option1.Arguments[0] = scrapCost;
		SetOptionText(base.Option1TextUI, base.Option1.GetLocalizedString());
		if (ProbUtils.CheckWithDRNGLuck(probability))
		{
			EnhancementUpgrade randomUpgrade = LootUtils.GetRandomUpgrade(null, autoAdd: false);
			Showcase(randomUpgrade);
			base.Option1ButtonUI.interactable = false;
			probability = startingProbability;
		}
		else
		{
			probability += probabilityIncrease;
		}
	}

	public override void Option2Chosen()
	{
		mysteryLocationUI.StartCoroutineForCurrentEncounter(DeclineUpgrade());
		claimButton.onClick.RemoveAllListeners();
		currentContainer.PlayChainBreakSound();
		declineButton.interactable = false;
		claimButton.gameObject.SetActive(value: false);
		base.Option1ButtonUI.gameObject.SetActive(value: true);
		currentContainer.OnContainerOpened -= ContainerOpened;
	}

	private void Showcase(EnhancementUpgrade en)
	{
		claimButton.gameObject.SetActive(value: true);
		claimButton.interactable = false;
		base.Option1ButtonUI.gameObject.SetActive(value: false);
		GameObject gameObject = UnityEngine.Object.Instantiate(containerPrefab, mysteryLocationUI.gamblerContainerHolder);
		gameObject.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
		CardContainer component = gameObject.GetComponent<CardContainer>();
		component.Card.Initialize(en, 0, 0, isDiscounted: false, sold: false, isClickable: false);
		Canvas.ForceUpdateCanvases();
		LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)gameObject.transform);
		currentContainer = component;
		currentContainer.OnContainerOpened += ContainerOpened;
		component.Card.GetComponent<Button>().interactable = false;
		claimButton.onClick.AddListener(delegate
		{
			UpgradeManager.Instance.AddUpgrade(en);
			mysteryLocationUI.StartCoroutineForCurrentEncounter(ClaimUpgrade());
			claimButton.onClick.RemoveAllListeners();
			declineButton.interactable = false;
			claimButton.gameObject.SetActive(value: false);
			base.Option1ButtonUI.gameObject.SetActive(value: true);
			currentContainer.OnContainerOpened -= ContainerOpened;
		});
	}

	private IEnumerator ClaimUpgrade()
	{
		startedRemovingUpgrade = true;
		currentContainer.Anim.Play("Chosen");
		yield return new WaitForSecondsRealtime(1.5f);
		startedRemovingUpgrade = false;
		UnityEngine.Object.Destroy(mysteryLocationUI.gamblerContainerHolder.GetChild(0).gameObject);
		if (ResourceManager.Instance.Scrap.Value >= scrapCost)
		{
			base.Option1ButtonUI.interactable = true;
		}
		EventSystem.current.SetSelectedGameObject(base.Option1ButtonUI.gameObject);
	}

	private IEnumerator DeclineUpgrade()
	{
		startedRemovingUpgrade = true;
		currentContainer.Anim.Play("Raise");
		yield return new WaitForSecondsRealtime(1.5f);
		startedRemovingUpgrade = false;
		UnityEngine.Object.Destroy(mysteryLocationUI.gamblerContainerHolder.GetChild(0).gameObject);
		if (ResourceManager.Instance.Scrap.Value >= scrapCost)
		{
			base.Option1ButtonUI.interactable = true;
		}
		EventSystem.current.SetSelectedGameObject(base.Option1ButtonUI.gameObject);
	}

	private void ContainerOpened(CargoContainer container)
	{
		container.Card.gameObject.GetComponent<Button>().interactable = false;
		claimButton.interactable = true;
		declineButton.interactable = true;
		EventSystem.current.SetSelectedGameObject(claimButton.gameObject);
		container.gameObject.GetComponent<CardContainer>().PlayBackgroundSFX(container.Card.en.Rarity);
		container.OnContainerOpened -= ContainerOpened;
	}

	private void Cleanup()
	{
		if (startedRemovingUpgrade)
		{
			startedRemovingUpgrade = false;
			UnityEngine.Object.Destroy(mysteryLocationUI.gamblerContainerHolder.GetChild(0).gameObject);
			if (ResourceManager.Instance.Scrap.Value >= scrapCost)
			{
				base.Option1ButtonUI.interactable = true;
			}
			EventSystem.current.SetSelectedGameObject(base.Option1ButtonUI.gameObject);
		}
	}
}
