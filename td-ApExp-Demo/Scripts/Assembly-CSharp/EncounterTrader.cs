using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Encounter", menuName = "Encounter/Trader")]
public class EncounterTrader : Encounter
{
	[Header("Option 1")]
	private float amountOfUpgradesGained1;

	[SerializeField]
	private float amountOfUpgradesGained1Easy;

	[SerializeField]
	private float amountOfUpgradesGained1Medium;

	[SerializeField]
	private float amountOfUpgradesGained1Hard;

	private Rarity rarity1;

	[SerializeField]
	private Rarity rarity1Easy;

	[SerializeField]
	private Rarity rarity1Medium;

	[SerializeField]
	private Rarity rarity1Hard;

	[Header("Option 2")]
	[SerializeField]
	private float ammoOffered1;

	private float amountOfUpgradesGained2;

	[SerializeField]
	private float amountOfUpgradesGained2Easy;

	[SerializeField]
	private float amountOfUpgradesGained2Medium;

	[SerializeField]
	private float amountOfUpgradesGained2Hard;

	private Rarity rarity2;

	[SerializeField]
	private Rarity rarity2Easy;

	[SerializeField]
	private Rarity rarity2Medium;

	[SerializeField]
	private Rarity rarity2Hard;

	[Header("Option 3")]
	[SerializeField]
	private float ammoOffered2;

	[SerializeField]
	private float hullPercentOffered;

	private float amountOfUpgradesGained3;

	[SerializeField]
	private float amountOfUpgradesGained3Easy;

	[SerializeField]
	private float amountOfUpgradesGained3Medium;

	[SerializeField]
	private float amountOfUpgradesGained3Hard;

	private Rarity rarity3;

	[SerializeField]
	private Rarity rarity3Easy;

	[SerializeField]
	private Rarity rarity3Medium;

	[SerializeField]
	private Rarity rarity3Hard;

	[SerializeField]
	private GameObject containerPrefab;

	private Action containerOpenedHandler;

	private List<EnhancementUpgrade> blacklist;

	private Rarity highestRarity;

	private int iterator;

	private bool isLastContainer;

	private List<CardContainer> containers = new List<CardContainer>();

	private bool startedRemovingContainer;

	public override bool EncounterRequirementsMet()
	{
		if (LootUtils.ViableUpgrades().Count == 0)
		{
			return false;
		}
		return true;
	}

	public override void StartEncounter()
	{
		blacklist = new List<EnhancementUpgrade>();
		containers = new List<CardContainer>();
		switch (LevelManager.Instance.CurrentLevel.Difficulty.Name)
		{
		case "Easy":
			amountOfUpgradesGained1 = amountOfUpgradesGained1Easy;
			rarity1 = rarity1Easy;
			amountOfUpgradesGained2 = amountOfUpgradesGained2Easy;
			rarity2 = rarity2Easy;
			amountOfUpgradesGained3 = amountOfUpgradesGained3Easy;
			rarity3 = rarity3Easy;
			break;
		case "Medium":
			amountOfUpgradesGained1 = amountOfUpgradesGained1Medium;
			rarity1 = rarity1Medium;
			amountOfUpgradesGained2 = amountOfUpgradesGained2Medium;
			rarity2 = rarity2Medium;
			amountOfUpgradesGained3 = amountOfUpgradesGained3Medium;
			rarity3 = rarity3Medium;
			break;
		case "Hard":
			amountOfUpgradesGained1 = amountOfUpgradesGained1Hard;
			rarity1 = rarity1Hard;
			amountOfUpgradesGained2 = amountOfUpgradesGained2Hard;
			rarity2 = rarity2Hard;
			amountOfUpgradesGained3 = amountOfUpgradesGained3Hard;
			rarity3 = rarity3Hard;
			break;
		default:
			Debug.Log("Invalid Difficulty set.");
			break;
		}
		base.Option2.Arguments = new object[1] { ammoOffered1 };
		base.Option3.Arguments = new object[1] { ammoOffered2 };
		base.StartEncounter();
		if (ResourceManager.Instance.Ammo.Value < ammoOffered1)
		{
			base.Option2ButtonUI.interactable = false;
		}
		if (ResourceManager.Instance.Ammo.Value < ammoOffered1 || Train.Instance.HealthComponent.HealthCurrent <= Train.Instance.HealthComponent.HealthMax * hullPercentOffered / 100f)
		{
			base.Option3ButtonUI.interactable = false;
		}
		mysteryLocationUI.traderNameText.text = base.EncounterName.GetLocalizedString();
		mysteryLocationUI.traderContinueButton.onClick.RemoveAllListeners();
		containerOpenedHandler = delegate
		{
			mysteryLocationUI.traderContinueButton.interactable = true;
		};
		mysteryLocationUI.traderContinueButton.onClick.AddListener(delegate
		{
			mysteryLocationUI.StartCoroutineForCurrentEncounter(RemoveShowcase());
			mysteryLocationUI.traderContinueButton.interactable = false;
		});
		mysteryLocationUI.traderDiscardButton.onClick.AddListener(delegate
		{
			mysteryLocationUI.StartCoroutineForCurrentEncounter(RemoveShowcase());
			mysteryLocationUI.traderDiscardButton.interactable = false;
		});
	}

	protected override void OnOptionChosen()
	{
		mysteryLocationUI.traderWindow.SetActive(value: true);
		base.FirstWindow.SetActive(value: false);
		SaveManager.Instance.ColectedLevelReward = true;
		SaveManager.Instance.SaveJourney();
	}

	public override void EndEncounter()
	{
		mysteryLocationUI.traderDiscardButton.interactable = false;
		mysteryLocationUI.Opened -= DisplayOnOpen;
		mysteryLocationUI.Closed -= HideOnClose;
		mysteryLocationUI.traderWindow.SetActive(value: false);
		if (mysteryLocationUI.traderContainerHolder.childCount > 0)
		{
			for (int num = mysteryLocationUI.traderContainerHolder.childCount - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(mysteryLocationUI.traderContainerHolder.GetChild(num).gameObject);
			}
		}
		mysteryLocationUI.traderContinueButton.onClick.RemoveAllListeners();
		mysteryLocationUI.traderDiscardButton.onClick.RemoveAllListeners();
		base.EndEncounter();
	}

	public override void Option1Chosen()
	{
		containers.Clear();
		for (int i = 0; (float)i < amountOfUpgradesGained1; i++)
		{
			EnhancementUpgrade randomUpgrade = LootUtils.GetRandomUpgrade(rarity1, null, autoAdd: false, blacklist);
			if (randomUpgrade == null)
			{
				break;
			}
			isLastContainer = true;
			highestRarity = randomUpgrade.Rarity;
			blacklist.Add(randomUpgrade);
			Showcase(randomUpgrade);
		}
		mysteryLocationUI.traderResolutionText.text = base.Resolution1.GetLocalizedString();
		mysteryLocationUI.Opened += DisplayOnOpen;
		mysteryLocationUI.Closed += HideOnClose;
		base.Option1Chosen();
	}

	public override void Option2Chosen()
	{
		containers.Clear();
		ResourceManager.Instance.Ammo.TrySpend(ammoOffered1);
		highestRarity = Rarity.Common;
		iterator = 0;
		isLastContainer = false;
		mysteryLocationUI.StartCoroutineForCurrentEncounter(Option2Coroutine());
		mysteryLocationUI.traderResolutionText.text = base.Resolution2.GetLocalizedString();
		mysteryLocationUI.Opened += DisplayOnOpen;
		mysteryLocationUI.Closed += HideOnClose;
		base.Option2Chosen();
	}

	private IEnumerator Option2Coroutine()
	{
		for (int i = 0; (float)i < amountOfUpgradesGained2; i++)
		{
			EnhancementUpgrade randomUpgrade = LootUtils.GetRandomUpgrade(rarity2, null, autoAdd: false, blacklist);
			if (!(randomUpgrade == null))
			{
				if (randomUpgrade.Rarity > highestRarity)
				{
					highestRarity = randomUpgrade.Rarity;
				}
				iterator++;
				if ((float)iterator == amountOfUpgradesGained3)
				{
					isLastContainer = true;
				}
				blacklist.Add(randomUpgrade);
				Showcase(randomUpgrade);
				yield return new WaitForSecondsRealtime(0.1f);
				continue;
			}
			break;
		}
	}

	public override void Option3Chosen()
	{
		containers.Clear();
		ResourceManager.Instance.Ammo.TrySpend(ammoOffered1);
		Train.Instance.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(Train.Instance, Train.Instance.HealthComponent, 0f - hullPercentOffered, isPercent: true, null, canRes: false, ignoreArmor: true, ignoreImmunity: true, isBurn: false, ignoreGrace: true));
		highestRarity = Rarity.Common;
		iterator = 0;
		isLastContainer = false;
		mysteryLocationUI.traderResolutionText.text = base.Resolution3.GetLocalizedString();
		mysteryLocationUI.StartCoroutineForCurrentEncounter(Option3Coroutine());
		mysteryLocationUI.Opened += DisplayOnOpen;
		mysteryLocationUI.Closed += HideOnClose;
		base.Option3Chosen();
	}

	private IEnumerator Option3Coroutine()
	{
		for (int i = 0; (float)i < amountOfUpgradesGained3; i++)
		{
			EnhancementUpgrade randomUpgrade = LootUtils.GetRandomUpgrade(rarity3, null, autoAdd: false, blacklist);
			if (!(randomUpgrade == null))
			{
				if (randomUpgrade.Rarity > highestRarity)
				{
					highestRarity = randomUpgrade.Rarity;
				}
				iterator++;
				if ((float)iterator == amountOfUpgradesGained3)
				{
					isLastContainer = true;
				}
				blacklist.Add(randomUpgrade);
				Showcase(randomUpgrade);
				yield return new WaitForSecondsRealtime(0.1f);
				continue;
			}
			break;
		}
	}

	private void Showcase(EnhancementUpgrade en)
	{
		mysteryLocationUI.traderContinueButton.interactable = false;
		GameObject gameObject = UnityEngine.Object.Instantiate(containerPrefab, mysteryLocationUI.traderContainerHolder);
		gameObject.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
		CardContainer container = gameObject.GetComponent<CardContainer>();
		container.Card.Initialize(en, 0, 0, isDiscounted: false, sold: false, isClickable: false);
		Canvas.ForceUpdateCanvases();
		LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)gameObject.transform);
		containers.Add(container);
		container.OnContainerOpened += ContainerOpened;
		if (isLastContainer)
		{
			container.OnContainerOpened += LastContainerOpened;
		}
		container.Card.GetComponent<Button>().interactable = false;
		mysteryLocationUI.traderContinueButton.onClick.AddListener(delegate
		{
			UpgradeManager.Instance.AddUpgrade(en);
			container.Anim.Play("Chosen");
			container.OnContainerOpened -= ContainerOpened;
		});
	}

	private IEnumerator RemoveShowcase()
	{
		startedRemovingContainer = true;
		bool flag = false;
		foreach (CardContainer container in containers)
		{
			container.Anim.Play("Raise");
			if (!flag)
			{
				container.dropAudio.PlayOnChannel(1);
				flag = true;
			}
		}
		yield return new WaitForSecondsRealtime(1.5f);
		startedRemovingContainer = false;
		EndEncounter();
	}

	private void ContainerOpened(CargoContainer container)
	{
		container.Card.gameObject.GetComponent<Button>().interactable = false;
		mysteryLocationUI.traderContinueButton.interactable = true;
		EventSystem.current.SetSelectedGameObject(mysteryLocationUI.traderContinueButton.gameObject);
		container.OnContainerOpened -= LastContainerOpened;
		container.OnContainerOpened -= ContainerOpened;
	}

	private void LastContainerOpened(CargoContainer cont)
	{
		cont.gameObject.GetComponent<CardContainer>().PlayBackgroundSFX(highestRarity);
		mysteryLocationUI.traderDiscardButton.interactable = true;
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
		if (startedRemovingContainer)
		{
			startedRemovingContainer = false;
			EndEncounter();
		}
	}
}
