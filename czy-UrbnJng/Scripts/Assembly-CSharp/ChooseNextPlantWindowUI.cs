using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChooseNextPlantWindowUI : MonoBehaviour
{
	public class OnNewPlantChosenEventArgs : EventArgs
	{
		public ObjectSO objectSo;

		public string GUID;
	}

	[SerializeField]
	private NewPlantButtonUI newPlantButtonUI;

	[SerializeField]
	private Transform nextPlantTemplate;

	[SerializeField]
	private Button confirmChoiceButton;

	[SerializeField]
	private Transform notEnoughButton;

	[SerializeField]
	private Transform skinNotUnlockedButton;

	[SerializeField]
	private TextMeshProUGUI confirmChoiceAmountText;

	[SerializeField]
	private TextMeshProUGUI rerollCostText;

	[SerializeField]
	private Button exitButton;

	[SerializeField]
	private Button rerollButton;

	[SerializeField]
	private TextMeshProUGUI priceText;

	private List<NextPlantUI> nextPlantUIList = new List<NextPlantUI>();

	private NextPlantUI firstNextPlantUI;

	private NextPlantUI secondNextPlantUI;

	private bool IsFirstPlantChosen = true;

	private PlayerInputActions playerInputActions;

	private int activePlantNumber;

	private int rerollCost = 1;

	private Sequence confirmButtonAnimation;

	private bool isButtonUnlocked;

	private bool confirmTrigger;

	private int previousRandomNumber = -1;

	public static ChooseNextPlantWindowUI Instance { get; private set; }

	public event EventHandler<OnNewPlantChosenEventArgs> OnNewPlantChosen;

	public event EventHandler OnShow;

	public event EventHandler OnExit;

	public event EventHandler OnFirstPlantChosen;

	public event EventHandler OnPlantCardClick;

	private void Awake()
	{
		Instance = this;
		playerInputActions = new PlayerInputActions();
		isButtonUnlocked = true;
	}

	private void Start()
	{
		InputManager.Instance.OnEscape += InputManager_OnEscape;
		newPlantButtonUI.OnSpawn += NewPlantUI_OnSpawn;
		rerollButton.onClick.AddListener(OnReroll);
		confirmChoiceButton.onClick.AddListener(ConfirmChoice);
		exitButton.onClick.AddListener(OnQuit);
		playerInputActions.ChoosePlant.LeftPlant.performed += OnLeftPlant;
		playerInputActions.ChoosePlant.RightPlant.performed += OnRightPlant;
		playerInputActions.ChoosePlant.SelectPlant.performed += OnSelectButton;
		playerInputActions.ChoosePlant.Quit.performed += OnExitButton;
		playerInputActions.ChoosePlant.BuySkin.performed += OnBuySkinButton;
		playerInputActions.ChoosePlant.ConfirmChoice.performed += OnConfirmChoiceButton;
		nextPlantTemplate.gameObject.SetActive(value: false);
		UpdateButtonText();
		Hide();
	}

	private void OnEnable()
	{
		playerInputActions.Enable();
	}

	private void OnDisable()
	{
		playerInputActions.Disable();
	}

	private void OnSelectButton(InputAction.CallbackContext obj)
	{
		nextPlantUIList[activePlantNumber].PlantChosenFromGamepad(isSkinClick: false);
	}

	private void OnBuySkinButton(InputAction.CallbackContext obj)
	{
		nextPlantUIList[activePlantNumber].TryToBuySkin();
	}

	private void InputManager_OnEscape(object sender, EventArgs e)
	{
		OnQuit();
	}

	private void OnExitButton(InputAction.CallbackContext obj)
	{
		OnQuit();
	}

	private void OnConfirmChoiceButton(InputAction.CallbackContext obj)
	{
		confirmChoiceButton.onClick.Invoke();
	}

	private void NewPlantUI_OnSpawn(object sender, EventArgs e)
	{
		Show();
		this.OnShow?.Invoke(this, EventArgs.Empty);
		if (!confirmTrigger)
		{
			SpawnButtons();
		}
	}

	private void OnReroll()
	{
		if (AllServices.Container.Single<IPersistentProgressService>().Progress.Coins < rerollCost)
		{
			CoinCounterUI.Instance.CoinsNotEnough();
			return;
		}
		AllServices.Container.Single<ICoinService>().SubtractCoin(rerollCost);
		ClearPlantSelection();
		CollectionManager.Instance.CalculateNewChances();
		SpawnButtons();
		rerollCost++;
		rerollCostText.text = rerollCost.ToString();
	}

	private void OnRightPlant(InputAction.CallbackContext obj)
	{
		if (activePlantNumber + 1 <= nextPlantUIList.Count - 1)
		{
			activePlantNumber++;
			PlantCardVisualUpdate();
		}
	}

	private void OnLeftPlant(InputAction.CallbackContext obj)
	{
		if (activePlantNumber - 1 >= 0)
		{
			activePlantNumber--;
			PlantCardVisualUpdate();
		}
	}

	public void DeactivateAllChooses(NextPlantUI plantUI)
	{
		for (int i = 0; i < nextPlantUIList.Count; i++)
		{
			if (nextPlantUIList[i] == plantUI)
			{
				activePlantNumber = i;
			}
			nextPlantUIList[i].DeactivateChoose();
		}
	}

	private void OnDestroy()
	{
		InputManager.Instance.OnEscape -= InputManager_OnEscape;
		newPlantButtonUI.OnSpawn -= NewPlantUI_OnSpawn;
		confirmChoiceButton.onClick.RemoveAllListeners();
		exitButton.onClick.RemoveAllListeners();
		rerollButton.onClick.RemoveAllListeners();
		confirmButtonAnimation.Kill();
		playerInputActions.ChoosePlant.LeftPlant.performed -= OnLeftPlant;
		playerInputActions.ChoosePlant.RightPlant.performed -= OnRightPlant;
		playerInputActions.ChoosePlant.SelectPlant.performed -= OnSelectButton;
		playerInputActions.ChoosePlant.Quit.performed -= OnExitButton;
		playerInputActions.ChoosePlant.BuySkin.performed -= OnBuySkinButton;
		playerInputActions.ChoosePlant.ConfirmChoice.performed -= OnConfirmChoiceButton;
	}

	private void UpdateButtonText()
	{
		confirmButtonAnimation.Kill();
		notEnoughButton.gameObject.SetActive(value: true);
		confirmChoiceButton.gameObject.SetActive(value: false);
		if (firstNextPlantUI == null && secondNextPlantUI == null)
		{
			confirmChoiceAmountText.text = "0/2";
		}
		else if (firstNextPlantUI == null || secondNextPlantUI == null)
		{
			confirmChoiceAmountText.text = "1/2";
		}
		else if (firstNextPlantUI != null && secondNextPlantUI != null)
		{
			priceText.text = (firstNextPlantUI.GetPrice() + secondNextPlantUI.GetPrice()).ToString();
			notEnoughButton.gameObject.SetActive(value: false);
			confirmChoiceButton.gameObject.SetActive(value: true);
			if (isButtonUnlocked)
			{
				ConfirmButtonActivation();
			}
		}
	}

	public void UpdateButtonOnSkinChange()
	{
		isButtonUnlocked = true;
		if (firstNextPlantUI != null && !firstNextPlantUI.IsChosenSkinUnlocked())
		{
			isButtonUnlocked = false;
		}
		if (secondNextPlantUI != null && !secondNextPlantUI.IsChosenSkinUnlocked())
		{
			isButtonUnlocked = false;
		}
		if (isButtonUnlocked)
		{
			skinNotUnlockedButton.gameObject.SetActive(value: false);
			if (firstNextPlantUI != null && secondNextPlantUI != null)
			{
				ConfirmButtonActivation();
			}
		}
		else
		{
			skinNotUnlockedButton.gameObject.SetActive(value: true);
		}
	}

	private void ConfirmButtonActivation()
	{
		confirmButtonAnimation = DOTween.Sequence();
		confirmButtonAnimation.Append(confirmChoiceButton.transform.DOScale(0.1f, 0.1f).SetEase(Ease.InOutSine)).Append(confirmChoiceButton.transform.DOScale(1.2f, 0.5f).SetEase(Ease.OutExpo)).Append(confirmChoiceButton.transform.DOScale(0.9f, 0.1f).SetEase(Ease.InOutSine))
			.Append(confirmChoiceButton.transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine))
			.Play();
	}

	private void Show()
	{
		base.gameObject.SetActive(value: true);
		if (nextPlantUIList.Count != 0)
		{
			foreach (NextPlantUI nextPlantUI in nextPlantUIList)
			{
				nextPlantUI.Hide();
			}
		}
		StartCoroutine(ShowButtonsOneByOne());
		UpdateButtonText();
	}

	private void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void SpawnButtons()
	{
		int num = int.MaxValue;
		bool flag = false;
		int num2 = 0;
		for (int i = 0; i < ProgressManager.Instance.GetObjectOnLevelListCount(); i++)
		{
			if (ProgressManager.Instance.IsUnlocked(i) && !ProgressManager.Instance.IsSpawned(i))
			{
				if (!flag)
				{
					num = ProgressManager.Instance.GetScoreToUnlock(i);
					flag = true;
				}
				if (num < int.MaxValue && ProgressManager.Instance.GetScoreToUnlock(i) == num)
				{
					ObjectSO objectSO = ProgressManager.Instance.GetObjectSO(i);
					int item = CollectionManager.Instance.GetRandomSkin(objectSO, randomPlant: false, num2).Item1;
					SpawnNewPlantButton(objectSO, i, item);
				}
				num2++;
			}
		}
		if (num2 == 0)
		{
			int randomNumberWithNoRepeat = GetRandomNumberWithNoRepeat(4, 6);
			for (int j = 0; j < randomNumberWithNoRepeat; j++)
			{
				ObjectSO randomPlant = CollectionManager.Instance.GetRandomPlant();
				(int, ObjectSO) randomSkin = CollectionManager.Instance.GetRandomSkin(randomPlant, randomPlant: true, j);
				SpawnNewPlantButton(randomSkin.Item2, -1, randomSkin.Item1);
			}
		}
		activePlantNumber = 0;
		PlantCardVisualUpdate();
		StartCoroutine(ShowButtonsOneByOne());
	}

	private IEnumerator ShowButtonsOneByOne()
	{
		foreach (NextPlantUI nextPlantUI in nextPlantUIList)
		{
			SoundManager.Instance.OnCardDraw();
			nextPlantUI.AppearAnimation();
			yield return new WaitForSeconds(0.1f);
		}
	}

	private int GetRandomNumberWithNoRepeat(int min, int max)
	{
		int num;
		do
		{
			num = UnityEngine.Random.Range(min, max);
		}
		while (num == previousRandomNumber);
		previousRandomNumber = num;
		return num;
	}

	private void SpawnNewPlantButton(ObjectSO objSO, int index, int variantNumber)
	{
		NextPlantUI item = NextPlantUI.Create(nextPlantTemplate, objSO, index, variantNumber);
		nextPlantUIList.Add(item);
	}

	private void ConfirmChoice()
	{
		if (firstNextPlantUI == null || secondNextPlantUI == null || !firstNextPlantUI.IsChosenSkinUnlocked() || !secondNextPlantUI.IsChosenSkinUnlocked())
		{
			return;
		}
		if (firstNextPlantUI.GetPrice() + secondNextPlantUI.GetPrice() > AllServices.Container.Single<IPersistentProgressService>().Progress.Coins)
		{
			CoinCounterUI.Instance.CoinsNotEnough();
			return;
		}
		if (IsFirstPlantChosen)
		{
			IsFirstPlantChosen = false;
			this.OnFirstPlantChosen?.Invoke(this, EventArgs.Empty);
		}
		this.OnNewPlantChosen?.Invoke(this, new OnNewPlantChosenEventArgs
		{
			objectSo = firstNextPlantUI.GetSO(),
			GUID = firstNextPlantUI.GetGUID()
		});
		this.OnNewPlantChosen?.Invoke(this, new OnNewPlantChosenEventArgs
		{
			objectSo = secondNextPlantUI.GetSO(),
			GUID = secondNextPlantUI.GetGUID()
		});
		AllServices.Container.Single<ICoinService>().SubtractCoin(firstNextPlantUI.GetPrice());
		AllServices.Container.Single<ICoinService>().SubtractCoin(secondNextPlantUI.GetPrice());
		CollectionManager.Instance.AddItemToPlayerCollection(firstNextPlantUI.GetVariantGUID(), firstNextPlantUI.GetSO().GUID);
		CollectionManager.Instance.AddItemToPlayerCollection(secondNextPlantUI.GetVariantGUID(), secondNextPlantUI.GetSO().GUID);
		for (int i = 0; i < ProgressManager.Instance.GetObjectOnLevelListCount(); i++)
		{
			if (ProgressManager.Instance.IsUnlocked(i) && !ProgressManager.Instance.IsSpawned(i) && (ProgressManager.Instance.GetScoreToUnlock(firstNextPlantUI.GetIndex()) == ProgressManager.Instance.GetScoreToUnlock(i) || ProgressManager.Instance.GetScoreToUnlock(secondNextPlantUI.GetIndex()) == ProgressManager.Instance.GetScoreToUnlock(i)))
			{
				ProgressManager.Instance.SetIsSpawned(i, value: true);
			}
		}
		rerollCost = 1;
		rerollCostText.text = rerollCost.ToString();
		confirmTrigger = false;
		CollectionManager.Instance.CalculateNewChances();
		ClearPlantSelection();
		Hide();
	}

	private void OnQuit()
	{
		if (base.gameObject.activeInHierarchy)
		{
			ProgressManager.Instance.PlusPlantButtonCounter();
			if (base.gameObject.activeInHierarchy)
			{
				confirmTrigger = true;
				this.OnExit?.Invoke(this, EventArgs.Empty);
				Hide();
			}
		}
	}

	public void PlantChosen(NextPlantUI nextPlantUI)
	{
		this.OnPlantCardClick?.Invoke(this, EventArgs.Empty);
		if (nextPlantUI == firstNextPlantUI)
		{
			firstNextPlantUI.ToggleChosen(value: false);
			firstNextPlantUI = secondNextPlantUI;
			secondNextPlantUI = null;
			UpdateButtonText();
			return;
		}
		if (nextPlantUI == secondNextPlantUI)
		{
			secondNextPlantUI.ToggleChosen(value: false);
			secondNextPlantUI = null;
			UpdateButtonText();
			return;
		}
		if (firstNextPlantUI == null)
		{
			firstNextPlantUI = nextPlantUI;
			firstNextPlantUI.ToggleChosen(value: true);
		}
		else if (secondNextPlantUI == null)
		{
			secondNextPlantUI = nextPlantUI;
			secondNextPlantUI.ToggleChosen(value: true);
		}
		else
		{
			firstNextPlantUI.ToggleChosen(value: false);
			firstNextPlantUI = secondNextPlantUI;
			secondNextPlantUI = nextPlantUI;
			secondNextPlantUI.ToggleChosen(value: true);
		}
		UpdateButtonText();
	}

	public void DeselectSkin(NextPlantUI nextPlantUI)
	{
		if (nextPlantUI == firstNextPlantUI)
		{
			firstNextPlantUI.ToggleChosen(value: false);
			firstNextPlantUI = secondNextPlantUI;
			secondNextPlantUI = null;
			UpdateButtonText();
		}
		else if (nextPlantUI == secondNextPlantUI)
		{
			secondNextPlantUI.ToggleChosen(value: false);
			secondNextPlantUI = null;
			UpdateButtonText();
		}
	}

	public bool IsPlantSelected(NextPlantUI nextPlantUI)
	{
		if (nextPlantUI == firstNextPlantUI || nextPlantUI == secondNextPlantUI)
		{
			return true;
		}
		return false;
	}

	private void ClearPlantSelection()
	{
		foreach (NextPlantUI nextPlantUI in nextPlantUIList)
		{
			nextPlantUI.DestroySelf();
		}
		nextPlantUIList.Clear();
		firstNextPlantUI = null;
		secondNextPlantUI = null;
	}

	private void PlantCardVisualUpdate()
	{
		foreach (NextPlantUI nextPlantUI in nextPlantUIList)
		{
			nextPlantUI.DeactivateChoose();
		}
		nextPlantUIList[activePlantNumber].ActivateChoose();
	}
}
