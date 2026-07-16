using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ReadyUpOptionChoice : ReadyUpOption
{
	[SerializeField]
	[Range(0f, 1f)]
	private float chanceForCommon;

	[SerializeField]
	[Range(0f, 1f)]
	private float chanceForRare;

	[SerializeField]
	[Range(0f, 1f)]
	private float chanceForEpic;

	[SerializeField]
	[Range(0f, 1f)]
	private float chanceForLegendary;

	[SerializeField]
	private GameObject containerPrefab;

	[SerializeField]
	private Button button;

	private Rarity highestRarity;

	private int containerIterator;

	private LocalizedString enhancementChosen;

	[field: SerializeField]
	public ReadyUpOptionsChoice ReadyUpOptionType { get; protected set; }

	protected new void Awake()
	{
		base.Awake();
		base.LocalizationString.Arguments = new object[1] { base.Value };
		base.DescriptionTxt.text = base.LocalizationString.GetLocalizedString();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (ReadyUpOptionType == ReadyUpOptionsChoice.Module && Train.Instance.currentTrain.trainType == TrainType.Cannon)
		{
			button.interactable = false;
		}
		else
		{
			button.interactable = true;
		}
	}

	public override void ApplyOption()
	{
		readyUpWindow.discardButton.onClick.AddListener(Discard);
		readyUpWindow.mainPanel.SetActive(value: false);
		readyUpWindow.choicePanel.SetActive(value: true);
		switch (ReadyUpOptionType)
		{
		case ReadyUpOptionsChoice.Module:
			GenerateLoot(LootType.Module);
			break;
		case ReadyUpOptionsChoice.Relic:
			GenerateLoot(LootType.Relic);
			break;
		}
	}

	private void GenerateLoot(LootType type)
	{
		List<Enhancement> blacklist = new List<Enhancement>();
		switch (type)
		{
		case LootType.Module:
			if (base.Value >= (float)(UpgradeManager.Instance.Modules.Count - UpgradeManager.Instance.ModulesInInventory.Count))
			{
				base.Value = UpgradeManager.Instance.Modules.Count - UpgradeManager.Instance.ModulesInInventory.Count;
			}
			break;
		case LootType.Relic:
			if (base.Value >= (float)(UpgradeManager.Instance.Relics.Count - UpgradeManager.Instance.RelicsInInventory.Length))
			{
				base.Value = UpgradeManager.Instance.Relics.Count - UpgradeManager.Instance.RelicsInInventory.Length;
			}
			break;
		}
		readyUpWindow.CouroutineStarter(ShowcaseCoroutine(type, blacklist));
	}

	private IEnumerator ShowcaseCoroutine(LootType type, List<Enhancement> blacklist)
	{
		containerIterator = 0;
		while ((float)containerIterator < base.Value)
		{
			Enhancement randomLoot = LootUtils.GetRandomLoot(type, LootUtils.GetRandomWeightedRarity(chanceForCommon, chanceForRare, chanceForEpic, chanceForLegendary), blacklist);
			if (!(randomLoot == null))
			{
				blacklist.Add(randomLoot);
				Showcase(randomLoot);
				yield return new WaitForSecondsRealtime(0.1f);
			}
			containerIterator++;
		}
		highestRarity = Rarity.Common;
		foreach (CardContainer container in readyUpWindow.containers)
		{
			if (container.Card.en.Rarity > highestRarity)
			{
				highestRarity = container.Card.en.Rarity;
			}
		}
	}

	private void Showcase(Enhancement en)
	{
		GameObject gameObject = Object.Instantiate(containerPrefab, readyUpWindow.choicePanel.transform);
		gameObject.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
		CardContainer container = gameObject.GetComponent<CardContainer>();
		container.Card.Initialize(en, 0);
		Canvas.ForceUpdateCanvases();
		LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)gameObject.transform);
		readyUpWindow.containers.Add(container);
		container.Card.GetComponent<Button>().interactable = false;
		if ((float)containerIterator == base.Value - 1f)
		{
			container.OnContainerOpened += ContainerOpened;
		}
		container.Card.GetComponent<Button>().onClick.AddListener(delegate
		{
			foreach (CardContainer container2 in readyUpWindow.containers)
			{
				container2.Card.GetComponent<Button>().interactable = false;
				if (container2 != container)
				{
					container2.Anim.Play("Raise");
					container2.OnContainerOpened -= ContainerOpened;
				}
				else
				{
					enhancementChosen = container2.Card.en.NameKey;
				}
			}
			container.Anim.Play("Chosen");
			container.OnContainerOpened -= ContainerOpened;
			container.Card.GetComponent<Button>().onClick.RemoveAllListeners();
			if (base.Value > 1f)
			{
				container.PlayChainBreakSound();
			}
			readyUpWindow.CouroutineStarter(RemoveShowcase());
		});
	}

	private IEnumerator RemoveShowcase()
	{
		yield return new WaitForSecondsRealtime(1.5f);
		End();
	}

	private void ContainerOpened(CargoContainer container)
	{
		foreach (CardContainer container2 in readyUpWindow.containers)
		{
			_ = container2;
			container.Card.GetComponent<Button>().interactable = true;
		}
		int index = Mathf.FloorToInt(readyUpWindow.containers.Count / 2);
		readyUpWindow.containers[index].Card.containerOutlineImage.gameObject.SetActive(value: true);
		EventSystem.current.SetSelectedGameObject(readyUpWindow.containers[index].Card.gameObject);
		readyUpWindow.discardButton.gameObject.SetActive(value: true);
		container.gameObject.GetComponent<CardContainer>().PlayBackgroundSFX(highestRarity);
	}

	private void End()
	{
		if (enhancementChosen != null)
		{
			switch (ReadyUpOptionType)
			{
			case ReadyUpOptionsChoice.Module:
				readyUpWindow.ModuleGainTxt.gameObject.SetActive(value: true);
				readyUpWindow.ModuleGainTxt.text = "+ Module " + enhancementChosen.GetLocalizedString();
				break;
			case ReadyUpOptionsChoice.Relic:
				readyUpWindow.RelicGainTxt.gameObject.SetActive(value: true);
				readyUpWindow.RelicGainTxt.text = "+ Relic " + enhancementChosen.GetLocalizedString();
				break;
			}
		}
		readyUpWindow.discardButton.gameObject.SetActive(value: false);
		readyUpWindow.choicePanel.SetActive(value: false);
		for (int num = readyUpWindow.choicePanel.transform.childCount - 1; num >= 0; num--)
		{
			if (!(readyUpWindow.choicePanel.transform.GetChild(num).gameObject.GetComponent<CardContainer>() == null))
			{
				readyUpWindow.choicePanel.transform.GetChild(num).gameObject.GetComponent<CardContainer>().Card.GetComponent<Button>().onClick.RemoveAllListeners();
				Object.Destroy(readyUpWindow.choicePanel.transform.GetChild(num).gameObject);
			}
		}
		readyUpWindow.discardButton.onClick.RemoveAllListeners();
		readyUpWindow.mainPanel.SetActive(value: true);
		readyUpWindow.containers.Clear();
		Object.Destroy(base.gameObject);
	}

	private void Discard()
	{
		foreach (CardContainer container in readyUpWindow.containers)
		{
			container.Card.GetComponent<Button>().interactable = false;
			container.Anim.Play("Raise");
			container.OnContainerOpened -= ContainerOpened;
			container.Card.GetComponent<Button>().onClick.RemoveAllListeners();
		}
		readyUpWindow.CouroutineStarter(RemoveShowcase());
	}
}
