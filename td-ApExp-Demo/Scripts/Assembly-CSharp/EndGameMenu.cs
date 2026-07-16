using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

public class EndGameMenu : Menu
{
	[SerializeField]
	private Button backToMenuButton;

	[SerializeField]
	private Button previousButton;

	[SerializeField]
	private Button startNewJourneyButtonUnlocks;

	[SerializeField]
	private Button nextButton;

	[SerializeField]
	private TextMeshProUGUI numberOfUnlocksTxt;

	[SerializeField]
	private GameObject newUnlockPrefab;

	[SerializeField]
	private GameObject contentHolder;

	[SerializeField]
	private Button continueButton;

	[SerializeField]
	private TextMeshProUGUI continueButtonText;

	[SerializeField]
	private GameObject gameOverUI;

	[SerializeField]
	private GameObject newUnlocksUI;

	[SerializeField]
	private Button startNewJourneyButton;

	[SerializeField]
	private GameObject containerPrefab;

	[Header("Localized Strings")]
	[SerializeField]
	private LocalizedString continueLocalized;

	[SerializeField]
	private LocalizedString menuLocalized;

	private int currentPage;

	private int itemsPerPage = 3;

	private int totalPages;

	private int numberOfUnlocks;

	private Rarity highestRarity;

	private List<CardContainer> currentUnlocksOnScreen;

	private bool firstShowcaseShown;

	public override void Init()
	{
		base.Init();
		backToMenuButton.onClick.AddListener(delegate
		{
			GameManager.Instance.QuitRun();
		});
		nextButton.onClick.AddListener(delegate
		{
			NextPage();
		});
		previousButton.onClick.AddListener(delegate
		{
			PreviousPage();
		});
		startNewJourneyButton.onClick.AddListener(delegate
		{
			GameManager.Instance.StartNewGame();
		});
		startNewJourneyButtonUnlocks.onClick.AddListener(delegate
		{
			GameManager.Instance.StartNewGame();
		});
		currentUnlocksOnScreen = new List<CardContainer>();
	}

	protected override void OnOpen()
	{
		base.OnOpen();
		if (MilestoneManager.Instance.currentRunUnlocks.Count == 0 || MilestoneManager.Instance.currentRunUnlocks == null)
		{
			continueButtonText.text = menuLocalized.GetLocalizedString();
			continueButton.onClick.AddListener(delegate
			{
				GameManager.Instance.QuitRun();
			});
			startNewJourneyButton.gameObject.SetActive(value: true);
			return;
		}
		continueButtonText.text = continueLocalized.GetLocalizedString();
		continueButton.onClick.AddListener(delegate
		{
			gameOverUI.SetActive(value: false);
		});
		continueButton.onClick.AddListener(delegate
		{
			newUnlocksUI.SetActive(value: true);
		});
		continueButton.onClick.AddListener(delegate
		{
			ShowUnlocks();
		});
	}

	public void ShowUnlocks()
	{
		numberOfUnlocks = MilestoneManager.Instance.currentRunUnlocks.Count;
		currentPage = 0;
		totalPages = Mathf.CeilToInt((float)numberOfUnlocks / (float)itemsPerPage);
		UpdateDisplay();
		UpdateButtonStates();
	}

	private void UpdateDisplay()
	{
		currentUnlocksOnScreen.Clear();
		foreach (Transform item in contentHolder.transform)
		{
			Object.Destroy(item.gameObject);
		}
		StartCoroutine(ShowcaseCoroutine());
	}

	private IEnumerator ShowcaseCoroutine()
	{
		int num = currentPage * itemsPerPage;
		int endIndex = Mathf.Min(num + itemsPerPage, numberOfUnlocks);
		for (int i = num; i < endIndex; i++)
		{
			GameObject obj = Object.Instantiate(containerPrefab, contentHolder.GetComponent<RectTransform>());
			obj.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
			CardContainer component = obj.GetComponent<CardContainer>();
			component.Card.Initialize(MilestoneManager.Instance.currentRunUnlocks[i].Unlock, 0, 0, isDiscounted: false, sold: false, isClickable: false);
			Canvas.ForceUpdateCanvases();
			LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)obj.transform);
			component.Card.GetComponent<Button>().interactable = false;
			currentUnlocksOnScreen.Add(component);
			if (i == endIndex - 1)
			{
				component.OnContainerOpened += ContainerOpened;
			}
			yield return new WaitForSecondsRealtime(0.15f);
		}
		highestRarity = Rarity.Common;
		foreach (CardContainer item in currentUnlocksOnScreen)
		{
			if (item.Card.en.Rarity > highestRarity)
			{
				highestRarity = item.Card.en.Rarity;
			}
		}
		numberOfUnlocksTxt.text = endIndex + "/" + numberOfUnlocks;
		if (!firstShowcaseShown)
		{
			firstShowcaseShown = true;
			EventSystem.current.SetSelectedGameObject(startNewJourneyButton.gameObject);
			StickySelection.Instance.SetLastValid(startNewJourneyButton.gameObject);
		}
	}

	private void ContainerOpened(CargoContainer container)
	{
		foreach (CardContainer item in currentUnlocksOnScreen)
		{
			_ = item;
			container.Card.GetComponent<Button>().interactable = false;
		}
		container.gameObject.GetComponent<CardContainer>().PlayBackgroundSFX(highestRarity);
	}

	private void ClearContainers()
	{
		foreach (CardContainer item in currentUnlocksOnScreen)
		{
			item.OnContainerOpened -= ContainerOpened;
		}
	}

	private void NextPage()
	{
		ClearContainers();
		if (currentPage < totalPages - 1)
		{
			currentPage++;
			UpdateDisplay();
			UpdateButtonStates();
		}
	}

	private void PreviousPage()
	{
		ClearContainers();
		if (currentPage > 0)
		{
			currentPage--;
			UpdateDisplay();
			UpdateButtonStates();
		}
	}

	private void UpdateButtonStates()
	{
		nextButton.interactable = currentPage < totalPages - 1;
		nextButton.GetComponent<Image>().enabled = currentPage < totalPages - 1;
		nextButton.GetComponentInChildren<TextMeshProUGUI>().enabled = currentPage < totalPages - 1;
		previousButton.interactable = currentPage > 0;
		previousButton.GetComponent<Image>().enabled = currentPage > 0;
		TextMeshProUGUI componentInChildren = previousButton.GetComponentInChildren<TextMeshProUGUI>();
		bool flag = (base.enabled = currentPage > 0);
		componentInChildren.enabled = flag;
	}
}
