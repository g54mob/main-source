using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Encounter", menuName = "Encounter/Specialist")]
public class EncounterSpecialist : Encounter
{
	[SerializeField]
	private float maxAmountOfChoices;

	[SerializeField]
	private List<Stats> modulesToAvoid;

	private List<Module> chosenModules = new List<Module>();

	[SerializeField]
	private GameObject containerPrefab;

	private List<CardContainer> containers = new List<CardContainer>();

	[SerializeField]
	private float lootCountEasy;

	[SerializeField]
	private float lootCountMedium;

	[SerializeField]
	private float lootCountHard;

	private int lootCount;

	private Rarity highestRarity;

	public override bool EncounterRequirementsMet()
	{
		if (LootUtils.ViableModuleUpgrades().Count == 0)
		{
			return false;
		}
		return true;
	}

	public override void StartEncounter()
	{
		base.StartEncounter();
		base.EncounterNameTextUI = mysteryLocationUI.specialistNameText;
		base.EncounterTextUI = mysteryLocationUI.specialistDescriptionText;
		base.EncounterPortraitUI = mysteryLocationUI.specialistPortraitImg;
		base.Option1ButtonUI = mysteryLocationUI.specialistOption1Button;
		base.Option2ButtonUI = mysteryLocationUI.specialistOption2Button;
		base.Option3ButtonUI = mysteryLocationUI.specialistOption3Button;
		base.Option1TextUI = mysteryLocationUI.specialistOption1Text;
		base.Option2TextUI = mysteryLocationUI.specialistOption2Text;
		base.Option3TextUI = mysteryLocationUI.specialistOption3Text;
		base.EncounterNameTextUI.text = base.EncounterName.GetLocalizedString();
		base.EncounterTextUI.text = base.EncounterDescription.GetLocalizedString();
		base.EncounterPortraitUI.sprite = base.EncounterPortrait;
		if (base.Option1ButtonUI != null)
		{
			base.Option1ButtonUI.onClick.RemoveAllListeners();
			base.Option2ButtonUI.onClick.RemoveAllListeners();
			base.Option3ButtonUI.onClick.RemoveAllListeners();
		}
		base.Option1ButtonUI.onClick.AddListener(Option1Chosen);
		base.Option2ButtonUI.onClick.AddListener(Option2Chosen);
		base.Option3ButtonUI.onClick.AddListener(Option3Chosen);
		SelectFirstOption();
		base.FirstWindow.SetActive(value: false);
		mysteryLocationUI.specialistFirstWindow.SetActive(value: true);
		chosenModules.Clear();
		for (int i = 0; i < 3; i++)
		{
			List<Module> list = Train.Instance.Modules.Where((Module module) => (bool)module && !modulesToAvoid.Contains(module.StatsSO) && !chosenModules.Contains(module) && LootUtils.ViableUpgrades(module).Count != 0).ToList();
			if (list.Count != 0)
			{
				int index = DRNG.Instance.NextInt(0, list.Count);
				chosenModules.Add(list[index]);
				switch (LevelManager.Instance.CurrentLevel.Difficulty.Name)
				{
				case "Easy":
					lootCount = 2;
					break;
				case "Medium":
					lootCount = 3;
					break;
				case "Hard":
					lootCount = 4;
					break;
				default:
					Debug.Log("Invalid Difficulty set.");
					break;
				}
			}
		}
		containers.Clear();
		if (chosenModules.Count == 2)
		{
			base.Option1.Arguments = new object[1] { chosenModules[0].Name };
			base.Option2.Arguments = new object[1] { chosenModules[1].Name };
			base.Option3ButtonUI.gameObject.SetActive(value: false);
			SetOptionText(base.Option1TextUI, base.Option1.GetLocalizedString());
			SetOptionText(base.Option2TextUI, base.Option2.GetLocalizedString());
		}
		else if (chosenModules.Count == 1)
		{
			base.Option1.Arguments = new object[1] { chosenModules[0].Name };
			base.Option3ButtonUI.gameObject.SetActive(value: false);
			base.Option2ButtonUI.gameObject.SetActive(value: false);
			SetOptionText(base.Option1TextUI, base.Option1.GetLocalizedString());
		}
		else
		{
			base.Option1.Arguments = new object[1] { chosenModules[0].Name };
			base.Option2.Arguments = new object[1] { chosenModules[1].Name };
			base.Option3.Arguments = new object[1] { chosenModules[2].Name };
			SetOptionText(base.Option1TextUI, base.Option1.GetLocalizedString());
			SetOptionText(base.Option2TextUI, base.Option2.GetLocalizedString());
			SetOptionText(base.Option3TextUI, base.Option3.GetLocalizedString());
		}
	}

	public override void EndEncounter()
	{
		mysteryLocationUI.Opened -= DisplayOnOpen;
		mysteryLocationUI.Closed -= HideOnClose;
		mysteryLocationUI.specialistWindow.SetActive(value: false);
		if (mysteryLocationUI.specialistContainerHolder.childCount > 0)
		{
			for (int num = mysteryLocationUI.specialistContainerHolder.childCount - 1; num >= 0; num--)
			{
				mysteryLocationUI.specialistContainerHolder.GetChild(num).gameObject.GetComponent<CardContainer>().Card.GetComponent<Button>().onClick.RemoveAllListeners();
				Object.Destroy(mysteryLocationUI.specialistContainerHolder.GetChild(num).gameObject);
			}
		}
		base.EndEncounter();
	}

	protected override void OnOptionChosen()
	{
		mysteryLocationUI.specialistFirstWindow.SetActive(value: false);
		mysteryLocationUI.specialistWindow.SetActive(value: true);
		SaveManager.Instance.ColectedLevelReward = true;
		SaveManager.Instance.SaveJourney();
	}

	public override void Option1Chosen()
	{
		GenerateLoot(chosenModules[0]);
		OnOptionChosen();
		base.Option1Chosen();
	}

	public override void Option2Chosen()
	{
		GenerateLoot(chosenModules[1]);
		OnOptionChosen();
		base.Option2Chosen();
	}

	public override void Option3Chosen()
	{
		GenerateLoot(chosenModules[2]);
		OnOptionChosen();
		base.Option3Chosen();
	}

	private void GenerateLoot(Module module)
	{
		mysteryLocationUI.StartCoroutineForCurrentEncounter(ShowcaseCoroutine(module));
		mysteryLocationUI.Opened += DisplayOnOpen;
		mysteryLocationUI.Closed += HideOnClose;
	}

	private IEnumerator ShowcaseCoroutine(Module module)
	{
		List<EnhancementUpgrade> blacklist = new List<EnhancementUpgrade>();
		int numberOfContainers = lootCount;
		if (LootUtils.ViableUpgrades().Count < lootCount)
		{
			numberOfContainers = LootUtils.ViableUpgrades(module).Count;
		}
		for (int i = 0; i < numberOfContainers; i++)
		{
			EnhancementUpgrade randomUpgrade = LootUtils.GetRandomUpgrade(module, autoAdd: false, blacklist);
			if (!(randomUpgrade == null))
			{
				blacklist.Add(randomUpgrade);
				Showcase(randomUpgrade);
				yield return new WaitForSecondsRealtime(0.1f);
			}
		}
	}

	private void Showcase(EnhancementUpgrade en)
	{
		GameObject gameObject = Object.Instantiate(containerPrefab, mysteryLocationUI.specialistContainerHolder);
		gameObject.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
		CardContainer container = gameObject.GetComponent<CardContainer>();
		container.Card.Initialize(en, 0);
		Canvas.ForceUpdateCanvases();
		LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)gameObject.transform);
		containers.Add(container);
		container.Card.GetComponent<Button>().interactable = false;
		highestRarity = Rarity.Common;
		foreach (CardContainer container2 in containers)
		{
			if (container2.Card.en.Rarity > highestRarity)
			{
				highestRarity = container2.Card.en.Rarity;
			}
		}
		container.OnContainerOpened += ContainerOpened;
		container.Card.GetComponent<Button>().onClick.AddListener(delegate
		{
			foreach (CardContainer container3 in containers)
			{
				container3.Card.GetComponent<Button>().interactable = false;
				if (container3 != container)
				{
					container3.Anim.Play("Raise");
					container3.OnContainerOpened -= ContainerOpened;
				}
			}
			container.Anim.Play("Chosen");
			container.OnContainerOpened -= ContainerOpened;
			container.Card.GetComponent<Button>().onClick.RemoveAllListeners();
			container.PlayChainBreakSound();
			mysteryLocationUI.StartCoroutineForCurrentEncounter(RemoveShowcase());
		});
	}

	private IEnumerator RemoveShowcase()
	{
		yield return new WaitForSecondsRealtime(1.5f);
		EndEncounter();
	}

	private void ContainerOpened(CargoContainer container)
	{
		container.Card.GetComponent<Button>().interactable = true;
		EventSystem.current.SetSelectedGameObject(containers[0].Card.gameObject);
		container.gameObject.GetComponent<CardContainer>().PlayBackgroundSFX(highestRarity);
		container.OnContainerOpened -= ContainerOpened;
	}

	private void DisplayOnOpen()
	{
		mysteryLocationUI.StartCoroutineForCurrentEncounter(DisplayCoroutine());
	}

	private IEnumerator DisplayCoroutine()
	{
		foreach (CardContainer container in containers)
		{
			container.gameObject.SetActive(value: true);
			yield return new WaitForSecondsRealtime(0.1f);
		}
	}

	private void HideOnClose()
	{
		foreach (CardContainer container in containers)
		{
			container.gameObject.SetActive(value: false);
		}
	}
}
