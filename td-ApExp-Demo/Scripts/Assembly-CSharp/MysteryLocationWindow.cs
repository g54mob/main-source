using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MysteryLocationWindow : Menu
{
	public static MysteryLocationWindow Instance;

	[SerializeField]
	private List<Encounter> encounters;

	private Encounter currentEncounter;

	[Header("UI Elements")]
	[SerializeField]
	private List<SlidingUIElement> slidingWindows;

	[Header("First Window")]
	public TextMeshProUGUI encounterText;

	public Button option1Button;

	public Button option2Button;

	public Button option3Button;

	public TextMeshProUGUI option1Text;

	public TextMeshProUGUI option2Text;

	public TextMeshProUGUI option3Text;

	public TextMeshProUGUI encounterNameText;

	public Image encounterPortraitImg;

	[Header("Second Window")]
	public TextMeshProUGUI rewardText;

	public TextMeshProUGUI resolutionText;

	public TextMeshProUGUI encounterNameText2;

	public Button continueButton;

	[Header("Gambler Window")]
	public TextMeshProUGUI gamblerText;

	public Button gamblerGambleButton;

	public Button gamblerDeclineButton;

	public TextMeshProUGUI gamblerGambleText;

	public TextMeshProUGUI gamblerDeclineText;

	public RectTransform gamblerContainerHolder;

	public Button gamblerClaimButton;

	public TextMeshProUGUI gamblerClaimText;

	public TextMeshProUGUI gamblerNameText;

	public Image gamblerPortraitImg;

	[Header("Trader Window")]
	public TextMeshProUGUI traderResolutionText;

	public Button traderContinueButton;

	public RectTransform traderContainerHolder;

	public TextMeshProUGUI traderNameText;

	public Button traderDiscardButton;

	[Header("Specialist Window")]
	public RectTransform specialistContainerHolder;

	public TextMeshProUGUI specialistNameText;

	public Image specialistPortraitImg;

	public TextMeshProUGUI specialistDescriptionText;

	public Button specialistOption1Button;

	public Button specialistOption2Button;

	public Button specialistOption3Button;

	public TextMeshProUGUI specialistOption1Text;

	public TextMeshProUGUI specialistOption2Text;

	public TextMeshProUGUI specialistOption3Text;

	[Header("Windows")]
	public GameObject firstWindow;

	public GameObject secondWindow;

	public GameObject gamblerWindow;

	public GameObject traderWindow;

	public GameObject specialistWindow;

	public GameObject specialistFirstWindow;

	[Header("Misc")]
	[SerializeField]
	private GameObject reopenButtonGo;

	[SerializeField]
	private GameObject reopenGamepadInput;

	private Encounter previousEncounter;

	public event Action Opened;

	public event Action Closed;

	public override void Init()
	{
		base.Init();
		Instance = this;
		LevelManager.Instance.DestinationReached += HandleDestinationReached;
		LevelManager.Instance.NextLevelSelected += delegate
		{
			HandleNextLevelSelected();
		};
	}

	protected override void OnOpen()
	{
		base.OnOpen();
		this.Opened?.Invoke();
	}

	protected override void OnClose()
	{
		base.OnClose();
		this.Closed?.Invoke();
		firstWindow.gameObject.GetComponent<RectTransform>().localScale = Vector2.zero;
		gamblerWindow.gameObject.GetComponent<RectTransform>().localScale = Vector2.zero;
		specialistFirstWindow.gameObject.GetComponent<RectTransform>().localScale = Vector2.zero;
		gamblerContainerHolder.gameObject.SetActive(value: false);
	}

	private void HandleDestinationReached()
	{
		if ((!LevelManager.Instance.DestinationReachedOnLoad || !SaveManager.Instance.ColectedLevelReward) && LevelManager.Instance.CurrentLevel.LootType == LootType.MysteryLocation)
		{
			MenuManager.Instance.OpenMenu(MenuType.MysteryLocation);
			Encounter encounter = SaveManager.Instance.GetEncounter();
			if ((object)encounter != null)
			{
				SetEncounter(encounter);
			}
			else
			{
				GetRandomEncounter();
			}
			MenuManager.Instance.MenuClosed += HandleMenuClosed;
			MenuManager.Instance.MenuOpened += HandleMenuOpened;
		}
	}

	private void GetRandomEncounter()
	{
		List<Encounter> list = new List<Encounter>();
		foreach (Encounter encounter in encounters)
		{
			if (encounter.EncounterRequirementsMet())
			{
				list.Add(encounter);
			}
		}
		if (list.Count != 0)
		{
			int index = DRNG.Instance.NextInt(0, list.Count);
			currentEncounter = list[index];
			if (previousEncounter != null && currentEncounter == previousEncounter && list.Count > 1)
			{
				list.Remove(currentEncounter);
				index = DRNG.Instance.NextInt(0, list.Count);
				currentEncounter = list[index];
			}
			currentEncounter.StartEncounter();
			previousEncounter = currentEncounter;
		}
	}

	private void SetEncounter(Encounter encounter)
	{
		currentEncounter = encounter;
		if (currentEncounter.EncounterRequirementsMet())
		{
			currentEncounter.StartEncounter();
		}
		else
		{
			GetRandomEncounter();
		}
	}

	private void HandleNextLevelSelected()
	{
		EndCurrentEncounter();
		reopenButtonGo.gameObject.SetActive(value: false);
		reopenGamepadInput.gameObject.SetActive(value: false);
		MenuManager.Instance.MenuClosed -= HandleMenuClosed;
		MenuManager.Instance.MenuOpened -= HandleMenuOpened;
	}

	public void EndCurrentEncounter()
	{
		if (!(currentEncounter == null))
		{
			currentEncounter.EndEncounter();
			firstWindow.SetActive(value: false);
			secondWindow.SetActive(value: false);
			gamblerWindow.SetActive(value: false);
			traderWindow.SetActive(value: false);
			specialistWindow.SetActive(value: false);
			specialistFirstWindow.SetActive(value: false);
			SaveManager.Instance.SaveJourney();
		}
	}

	public void StartCoroutineForCurrentEncounter(IEnumerator coroutine)
	{
		if (base.gameObject.activeSelf)
		{
			StartCoroutine(coroutine);
		}
	}

	private void HandleMenuClosed(Menu menu)
	{
		InputManager.Instance.OnYPressed -= OnReopenPressed;
		LootType lootType = LevelManager.Instance.CurrentLevel.LootType;
		bool flag = LevelManager.Instance.IsAtDestination && !LevelManager.Instance.CurrentLevel.IsLooted && lootType == LootType.MysteryLocation && LevelManager.Instance.NextLevel == null;
		if (InputManager.Instance.IsLastInputGamepad)
		{
			reopenGamepadInput.SetActive(flag);
		}
		else
		{
			reopenButtonGo.SetActive(flag);
		}
		if (flag)
		{
			InputManager.Instance.OnYPressed += OnReopenPressed;
		}
	}

	private void HandleMenuOpened(Menu menu)
	{
		reopenButtonGo.SetActive(value: false);
		reopenGamepadInput.SetActive(value: false);
	}

	private void OnReopenPressed(int _, InputAction.CallbackContext __)
	{
		if (!base.gameObject.activeSelf && LevelManager.Instance.CurrentLevel.LootType == LootType.MysteryLocation)
		{
			MenuManager.Instance.OpenMenu(base.MenuType);
		}
	}

	public void GamblerHelper()
	{
		gamblerContainerHolder.gameObject.SetActive(value: true);
	}
}
