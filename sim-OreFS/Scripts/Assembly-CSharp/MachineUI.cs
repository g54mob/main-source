using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MachineUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private RecipeListUI recipeListUI;

	[SerializeField]
	private GameObject uiPanel;

	[SerializeField]
	private TextMeshProUGUI machineNameText;

	[Header("Recipe Detail Panel")]
	[SerializeField]
	private GameObject recipeDetailPanelContainer;

	[SerializeField]
	private TextMeshProUGUI selectedRecipeNameText;

	[SerializeField]
	private TextMeshProUGUI selectedRecipeDescriptionText;

	[SerializeField]
	private TextMeshProUGUI selectedRecipeTimeText;

	[SerializeField]
	private Image combineIcon;

	[SerializeField]
	private Image ingredient1Icon;

	[SerializeField]
	private TextMeshProUGUI ingredient1CountText;

	[SerializeField]
	private Image ingredient2Icon;

	[SerializeField]
	private TextMeshProUGUI ingredient2CountText;

	[SerializeField]
	private GameObject ingredient2Container;

	[SerializeField]
	private Image productIcon;

	[SerializeField]
	private TextMeshProUGUI productCountText;

	[Header("Requirements Panel")]
	[SerializeField]
	private GameObject requirementsPanelContainer;

	[SerializeField]
	private Image requirement1Icon;

	[SerializeField]
	private TextMeshProUGUI requirement1Text;

	[SerializeField]
	private TextMeshProUGUI requirement1NameText;

	[SerializeField]
	private Image requirement2Icon;

	[SerializeField]
	private TextMeshProUGUI requirement2Text;

	[SerializeField]
	private TextMeshProUGUI requirement2NameText;

	[SerializeField]
	private GameObject requirement2Container;

	[Header("Production Control")]
	[SerializeField]
	private TextMeshProUGUI activeRecipeText;

	[SerializeField]
	private Button startStopButton;

	[SerializeField]
	private GameObject playIconObject;

	[SerializeField]
	private GameObject pauseIconObject;

	[SerializeField]
	private Image productionFillBar;

	[Header("Storage Panel")]
	[SerializeField]
	private TextMeshProUGUI storageCapacityText;

	[SerializeField]
	private Transform storageItemListParent;

	[SerializeField]
	private GameObject storageItemPrefab;

	[SerializeField]
	private Button clearStorageButton;

	[Header("Production Amount Control")]
	[SerializeField]
	private TMP_InputField amountInputField;

	[SerializeField]
	private Button increaseAmountButton;

	[SerializeField]
	private Button decreaseAmountButton;

	[SerializeField]
	private Button maxAmountButton;

	[SerializeField]
	private Button infiniteToggleButton;

	[SerializeField]
	private Button infiniteDisableButton;

	[SerializeField]
	private GameObject infiniteActiveIndicator;

	[Header("Infinite Mode Events")]
	public UnityEvent OnInfiniteModeEnabled;

	public UnityEvent OnInfiniteModeDisabled;

	private T_Machine currentMachine;

	private List<StorageItemUI> storageItemUIs = new List<StorageItemUI>();

	private int previewRecipeIndex = -1;

	private bool isUpdatingAmountFromCode;

	private void Start()
	{
		if (startStopButton != null)
		{
			startStopButton.onClick.RemoveAllListeners();
			startStopButton.onClick.AddListener(OnStartStopButtonClicked);
		}
		if (clearStorageButton != null)
		{
			clearStorageButton.onClick.RemoveAllListeners();
			clearStorageButton.onClick.AddListener(OnClearStorageButtonClicked);
			clearStorageButton.interactable = true;
		}
		if (increaseAmountButton != null)
		{
			increaseAmountButton.onClick.RemoveAllListeners();
			increaseAmountButton.onClick.AddListener(OnIncreaseAmountClicked);
		}
		if (decreaseAmountButton != null)
		{
			decreaseAmountButton.onClick.RemoveAllListeners();
			decreaseAmountButton.onClick.AddListener(OnDecreaseAmountClicked);
		}
		if (maxAmountButton != null)
		{
			maxAmountButton.onClick.RemoveAllListeners();
			maxAmountButton.onClick.AddListener(OnMaxAmountClicked);
		}
		if (infiniteToggleButton != null)
		{
			infiniteToggleButton.onClick.RemoveAllListeners();
			infiniteToggleButton.onClick.AddListener(OnInfiniteToggleClicked);
		}
		if (infiniteDisableButton != null)
		{
			infiniteDisableButton.onClick.RemoveAllListeners();
			infiniteDisableButton.onClick.AddListener(OnInfiniteDisableClicked);
		}
		if (amountInputField != null)
		{
			amountInputField.contentType = TMP_InputField.ContentType.IntegerNumber;
			amountInputField.onValueChanged.AddListener(OnAmountInputFieldValueChanged);
		}
		if (productionFillBar != null)
		{
			productionFillBar.fillAmount = 0f;
		}
		if (uiPanel != null)
		{
			uiPanel.SetActive(value: false);
		}
	}

	private void OnEnable()
	{
		if (currentMachine != null)
		{
			currentMachine.OnRecipeSelected += OnMachineRecipeSelected;
			currentMachine.OnProductionStateChangedEvent += OnMachineProductionStateChanged;
			currentMachine.OnStorageChanged += OnMachineStorageChanged;
			currentMachine.OnProductionAmountChangedEvent += OnMachineAmountChanged;
			currentMachine.OnInfiniteModeChangedEvent += OnMachineInfiniteModeChanged;
		}
	}

	private void OnDisable()
	{
		if (currentMachine != null)
		{
			currentMachine.OnRecipeSelected -= OnMachineRecipeSelected;
			currentMachine.OnProductionStateChangedEvent -= OnMachineProductionStateChanged;
			currentMachine.OnStorageChanged -= OnMachineStorageChanged;
			currentMachine.OnProductionAmountChangedEvent -= OnMachineAmountChanged;
			currentMachine.OnInfiniteModeChangedEvent -= OnMachineInfiniteModeChanged;
		}
	}

	private void Update()
	{
		if (currentMachine != null && uiPanel != null && uiPanel.activeSelf && currentMachine.IsProducing)
		{
			UpdateFillBar(currentMachine.ProductionProgress);
		}
	}

	private void OnMachineRecipeSelected(int recipeIndex)
	{
		if (recipeListUI != null)
		{
			recipeListUI.UpdateSelectedRecipe(recipeIndex);
		}
		UpdateUI();
	}

	private void OnMachineProductionStateChanged(bool isProducing)
	{
		if (uiPanel != null && uiPanel.activeSelf)
		{
			if (!isProducing)
			{
				UpdateFillBar(0f);
			}
			UpdateUI();
		}
	}

	private void OnMachineStorageChanged()
	{
		if (uiPanel != null && uiPanel.activeSelf)
		{
			UpdateUI();
		}
	}

	private void OnMachineAmountChanged(int newAmount)
	{
		if (uiPanel != null && uiPanel.activeSelf)
		{
			UpdateAmountControl();
		}
	}

	private void OnMachineInfiniteModeChanged(bool isInfinite)
	{
		if (uiPanel != null && uiPanel.activeSelf)
		{
			TriggerInfiniteModeEvent(isInfinite);
			UpdateAmountControl();
		}
	}

	private void TriggerInfiniteModeEvent(bool isInfinite)
	{
		if (isInfinite)
		{
			Debug.Log("[MachineUI] OnInfiniteModeEnabled invoke ediliyor");
			OnInfiniteModeEnabled?.Invoke();
		}
		else
		{
			Debug.Log("[MachineUI] OnInfiniteModeDisabled invoke ediliyor");
			OnInfiniteModeDisabled?.Invoke();
		}
	}

	public void OpenUIPanel(T_Machine machine)
	{
		if (machine == null)
		{
			Debug.LogWarning("[MachineUI] Machine null, UI açılamadı");
			return;
		}
		if (currentMachine != null)
		{
			currentMachine.OnRecipeSelected -= OnMachineRecipeSelected;
			currentMachine.OnProductionStateChangedEvent -= OnMachineProductionStateChanged;
			currentMachine.OnStorageChanged -= OnMachineStorageChanged;
			currentMachine.OnProductionAmountChangedEvent -= OnMachineAmountChanged;
			currentMachine.OnInfiniteModeChangedEvent -= OnMachineInfiniteModeChanged;
		}
		currentMachine = machine;
		if (currentMachine != null)
		{
			currentMachine.OnRecipeSelected += OnMachineRecipeSelected;
			currentMachine.OnProductionStateChangedEvent += OnMachineProductionStateChanged;
			currentMachine.OnStorageChanged += OnMachineStorageChanged;
			currentMachine.OnProductionAmountChangedEvent += OnMachineAmountChanged;
			currentMachine.OnInfiniteModeChangedEvent += OnMachineInfiniteModeChanged;
		}
		if (recipeListUI != null)
		{
			recipeListUI.UpdateRecipeList(machine, this);
		}
		UpdateMachineName();
		if (uiPanel != null)
		{
			uiPanel.SetActive(value: true);
		}
		UpdateFillBar(currentMachine.IsProducing ? currentMachine.ProductionProgress : 0f);
		UpdateUI();
		TriggerInfiniteModeEvent(currentMachine.IsInfiniteMode);
	}

	public void CloseUIPanel()
	{
		if (currentMachine != null)
		{
			currentMachine.TriggerOnUIClosed();
		}
		if (currentMachine != null)
		{
			currentMachine.OnRecipeSelected -= OnMachineRecipeSelected;
			currentMachine.OnProductionStateChangedEvent -= OnMachineProductionStateChanged;
			currentMachine.OnStorageChanged -= OnMachineStorageChanged;
			currentMachine.OnProductionAmountChangedEvent -= OnMachineAmountChanged;
			currentMachine.OnInfiniteModeChangedEvent -= OnMachineInfiniteModeChanged;
		}
		UpdateFillBar(0f);
		currentMachine = null;
		if (uiPanel != null)
		{
			uiPanel.SetActive(value: false);
		}
	}

	[Obsolete("OpenMachineUI yerine OpenUIPanel kullanın")]
	public void OpenMachineUI(T_Machine machine)
	{
		OpenUIPanel(machine);
	}

	[Obsolete("CloseMachineUI yerine CloseUIPanel kullanın")]
	public void CloseMachineUI()
	{
		CloseUIPanel();
	}

	private void UpdateUI()
	{
		if (!(currentMachine == null))
		{
			UpdateRecipeDetail();
			UpdateRequirements();
			UpdateProductionControl();
			UpdateStorage();
			UpdateAmountControl();
		}
	}

	private void UpdateMachineName()
	{
		if (machineNameText == null || currentMachine == null)
		{
			return;
		}
		string text = "";
		if (currentMachine.BuildingSO != null && !string.IsNullOrEmpty(currentMachine.BuildingSO.Name))
		{
			text = currentMachine.BuildingSO.Name;
			string translation = LocalizationManager.GetTranslation(text);
			if (!string.IsNullOrEmpty(translation))
			{
				text = translation;
			}
		}
		else
		{
			text = currentMachine.name;
			string translation2 = LocalizationManager.GetTranslation(text);
			if (!string.IsNullOrEmpty(translation2))
			{
				text = translation2;
			}
		}
		machineNameText.text = text;
	}

	private void UpdateRecipeDetail()
	{
		int num = ((previewRecipeIndex >= 0) ? previewRecipeIndex : currentMachine.SelectedRecipeIndex);
		bool flag = currentMachine.AcceptedRecipes != null && currentMachine.AcceptedRecipes.Count > 0 && num >= 0 && num < currentMachine.AcceptedRecipes.Count;
		if (recipeDetailPanelContainer != null)
		{
			recipeDetailPanelContainer.SetActive(flag);
		}
		if (requirementsPanelContainer != null)
		{
			requirementsPanelContainer.SetActive(flag);
		}
		if (!flag || num < 0 || num >= currentMachine.AcceptedRecipes.Count)
		{
			return;
		}
		T_ItemSO t_ItemSO = currentMachine.AcceptedRecipes[num];
		if (t_ItemSO == null)
		{
			return;
		}
		if (selectedRecipeNameText != null)
		{
			string translation = LocalizationManager.GetTranslation(t_ItemSO.Name);
			if (string.IsNullOrEmpty(translation))
			{
				translation = t_ItemSO.Name;
			}
			selectedRecipeNameText.text = translation;
		}
		if (selectedRecipeDescriptionText != null)
		{
			string text = t_ItemSO.Description;
			if (!string.IsNullOrEmpty(text))
			{
				string translation2 = LocalizationManager.GetTranslation(text);
				if (!string.IsNullOrEmpty(translation2))
				{
					text = translation2;
				}
			}
			selectedRecipeDescriptionText.text = text ?? "";
		}
		if (selectedRecipeTimeText != null)
		{
			selectedRecipeTimeText.text = t_ItemSO.productionTime + "s";
		}
		bool active = false;
		if (t_ItemSO.Type == PickupType.Product && t_ItemSO.RecipeList != null && t_ItemSO.RecipeList.Count > 1)
		{
			active = true;
		}
		if (combineIcon != null)
		{
			combineIcon.gameObject.SetActive(active);
		}
		if (t_ItemSO.Type == PickupType.Resource)
		{
			if (t_ItemSO.ore != null)
			{
				if (ingredient1Icon != null)
				{
					ingredient1Icon.sprite = t_ItemSO.ore.Icon;
					ingredient1Icon.gameObject.SetActive(value: true);
				}
				if (ingredient1CountText != null)
				{
					if (previewRecipeIndex < 0)
					{
						int itemCount = currentMachine.GetItemCount(t_ItemSO.ore.GetItemID());
						int oreCount = t_ItemSO.oreCount;
						ingredient1CountText.text = $"{itemCount}/{oreCount}";
					}
					else
					{
						ingredient1CountText.text = t_ItemSO.oreCount.ToString();
					}
					ingredient1CountText.gameObject.SetActive(value: true);
				}
			}
			if (ingredient2Container != null)
			{
				ingredient2Container.SetActive(value: false);
			}
			if (productIcon != null)
			{
				productIcon.sprite = t_ItemSO.Icon;
				productIcon.gameObject.SetActive(value: true);
			}
			if (productCountText != null)
			{
				if (previewRecipeIndex < 0)
				{
					int num2 = currentMachine.GetItemCount(t_ItemSO.ore.GetItemID()) / t_ItemSO.oreCount;
					productCountText.text = num2.ToString();
				}
				else
				{
					productCountText.text = "1";
				}
				productCountText.gameObject.SetActive(value: true);
			}
		}
		else
		{
			if (t_ItemSO.Type != PickupType.Product)
			{
				return;
			}
			if (t_ItemSO.RecipeList != null && t_ItemSO.RecipeList.Count > 0)
			{
				if (t_ItemSO.RecipeList.Count > 0 && t_ItemSO.RecipeList[0].Item != null)
				{
					T_ItemSO.RecipeIngredient recipeIngredient = t_ItemSO.RecipeList[0];
					if (ingredient1Icon != null)
					{
						ingredient1Icon.sprite = recipeIngredient.Item.Icon;
						ingredient1Icon.gameObject.SetActive(value: true);
					}
					if (ingredient1CountText != null)
					{
						if (previewRecipeIndex < 0)
						{
							int itemCount2 = currentMachine.GetItemCount(recipeIngredient.Item.GetItemID());
							int count = recipeIngredient.Count;
							ingredient1CountText.text = $"{itemCount2}/{count}";
						}
						else
						{
							ingredient1CountText.text = $"{recipeIngredient.Count}";
						}
						ingredient1CountText.gameObject.SetActive(value: true);
					}
				}
				if (t_ItemSO.RecipeList.Count > 1 && t_ItemSO.RecipeList[1].Item != null)
				{
					T_ItemSO.RecipeIngredient recipeIngredient2 = t_ItemSO.RecipeList[1];
					if (ingredient2Container != null)
					{
						ingredient2Container.SetActive(value: true);
					}
					if (ingredient2Icon != null)
					{
						ingredient2Icon.sprite = recipeIngredient2.Item.Icon;
						ingredient2Icon.gameObject.SetActive(value: true);
					}
					if (ingredient2CountText != null)
					{
						if (previewRecipeIndex < 0)
						{
							int itemCount3 = currentMachine.GetItemCount(recipeIngredient2.Item.GetItemID());
							int count2 = recipeIngredient2.Count;
							ingredient2CountText.text = $"{itemCount3}/{count2}";
						}
						else
						{
							ingredient2CountText.text = $"{recipeIngredient2.Count}";
						}
						ingredient2CountText.gameObject.SetActive(value: true);
					}
				}
				else if (ingredient2Container != null)
				{
					ingredient2Container.SetActive(value: false);
				}
			}
			if (productIcon != null)
			{
				productIcon.sprite = t_ItemSO.Icon;
				productIcon.gameObject.SetActive(value: true);
			}
			if (!(productCountText != null))
			{
				return;
			}
			if (previewRecipeIndex < 0)
			{
				int num3 = int.MaxValue;
				foreach (T_ItemSO.RecipeIngredient recipe in t_ItemSO.RecipeList)
				{
					if (!(recipe.Item == null))
					{
						int b = currentMachine.GetItemCount(recipe.Item.GetItemID()) / recipe.Count;
						num3 = Mathf.Min(num3, b);
					}
				}
				if (num3 == int.MaxValue)
				{
					num3 = 0;
				}
				productCountText.text = num3.ToString();
			}
			else
			{
				productCountText.text = "1";
			}
			productCountText.gameObject.SetActive(value: true);
		}
	}

	private void UpdateRequirements()
	{
		int num = ((previewRecipeIndex >= 0) ? previewRecipeIndex : currentMachine.SelectedRecipeIndex);
		if (num < 0 || num >= currentMachine.AcceptedRecipes.Count)
		{
			if (requirement1Icon != null)
			{
				requirement1Icon.gameObject.SetActive(value: false);
			}
			if (requirement1Text != null)
			{
				requirement1Text.gameObject.SetActive(value: false);
			}
			if (requirement1NameText != null)
			{
				requirement1NameText.gameObject.SetActive(value: false);
			}
			if (requirement2Container != null)
			{
				requirement2Container.SetActive(value: false);
			}
			return;
		}
		T_ItemSO t_ItemSO = currentMachine.AcceptedRecipes[num];
		if (t_ItemSO == null)
		{
			return;
		}
		if (t_ItemSO.Type == PickupType.Resource)
		{
			if (t_ItemSO.ore != null)
			{
				if (requirement1Icon != null)
				{
					requirement1Icon.sprite = t_ItemSO.ore.Icon;
					requirement1Icon.gameObject.SetActive(value: true);
				}
				if (requirement1Text != null)
				{
					requirement1Text.text = $"{t_ItemSO.oreCount}x";
					requirement1Text.gameObject.SetActive(value: true);
				}
				if (requirement1NameText != null)
				{
					string translation = LocalizationManager.GetTranslation(t_ItemSO.ore.Name);
					if (string.IsNullOrEmpty(translation))
					{
						translation = t_ItemSO.ore.Name;
					}
					requirement1NameText.text = translation;
					requirement1NameText.gameObject.SetActive(value: true);
				}
			}
			if (requirement2Container != null)
			{
				requirement2Container.SetActive(value: false);
			}
		}
		else
		{
			if (t_ItemSO.Type != PickupType.Product || t_ItemSO.RecipeList == null || t_ItemSO.RecipeList.Count <= 0)
			{
				return;
			}
			if (t_ItemSO.RecipeList.Count > 0 && t_ItemSO.RecipeList[0].Item != null)
			{
				T_ItemSO.RecipeIngredient recipeIngredient = t_ItemSO.RecipeList[0];
				if (requirement1Icon != null)
				{
					requirement1Icon.sprite = recipeIngredient.Item.Icon;
					requirement1Icon.gameObject.SetActive(value: true);
				}
				if (requirement1Text != null)
				{
					requirement1Text.text = $"{recipeIngredient.Count}x";
					requirement1Text.gameObject.SetActive(value: true);
				}
				if (requirement1NameText != null)
				{
					string translation2 = LocalizationManager.GetTranslation(recipeIngredient.Item.Name);
					if (string.IsNullOrEmpty(translation2))
					{
						translation2 = recipeIngredient.Item.Name;
					}
					requirement1NameText.text = translation2;
					requirement1NameText.gameObject.SetActive(value: true);
				}
			}
			if (t_ItemSO.RecipeList.Count > 1 && t_ItemSO.RecipeList[1].Item != null)
			{
				T_ItemSO.RecipeIngredient recipeIngredient2 = t_ItemSO.RecipeList[1];
				if (requirement2Container != null)
				{
					requirement2Container.SetActive(value: true);
				}
				if (requirement2Icon != null)
				{
					requirement2Icon.sprite = recipeIngredient2.Item.Icon;
					requirement2Icon.gameObject.SetActive(value: true);
				}
				if (requirement2Text != null)
				{
					requirement2Text.text = $"{recipeIngredient2.Count}x";
					requirement2Text.gameObject.SetActive(value: true);
				}
				if (requirement2NameText != null)
				{
					string translation3 = LocalizationManager.GetTranslation(recipeIngredient2.Item.Name);
					if (string.IsNullOrEmpty(translation3))
					{
						translation3 = recipeIngredient2.Item.Name;
					}
					requirement2NameText.text = translation3;
					requirement2NameText.gameObject.SetActive(value: true);
				}
			}
			else if (requirement2Container != null)
			{
				requirement2Container.SetActive(value: false);
			}
		}
	}

	private void UpdateProductionControl()
	{
		if (activeRecipeText != null)
		{
			if (currentMachine.SelectedRecipeIndex >= 0 && currentMachine.SelectedRecipeIndex < currentMachine.AcceptedRecipes.Count)
			{
				T_ItemSO t_ItemSO = currentMachine.AcceptedRecipes[currentMachine.SelectedRecipeIndex];
				if (t_ItemSO != null)
				{
					string translation = LocalizationManager.GetTranslation(t_ItemSO.Name);
					if (string.IsNullOrEmpty(translation))
					{
						translation = t_ItemSO.Name;
					}
					activeRecipeText.text = translation;
				}
				else
				{
					string text = LocalizationManager.GetTranslation("No Recipe Selected");
					if (string.IsNullOrEmpty(text))
					{
						text = "NL/ No Recipe";
					}
					activeRecipeText.text = text;
				}
			}
			else
			{
				string text2 = LocalizationManager.GetTranslation("No Recipe Selected");
				if (string.IsNullOrEmpty(text2))
				{
					text2 = "NL/ No Recipe";
				}
				activeRecipeText.text = text2;
			}
		}
		if (!currentMachine.IsProductionPaused)
		{
			if (pauseIconObject != null)
			{
				pauseIconObject.SetActive(value: true);
			}
			if (playIconObject != null)
			{
				playIconObject.SetActive(value: false);
			}
		}
		else
		{
			if (playIconObject != null)
			{
				playIconObject.SetActive(value: true);
			}
			if (pauseIconObject != null)
			{
				pauseIconObject.SetActive(value: false);
			}
		}
	}

	private void UpdateStorage()
	{
		if (storageCapacityText != null)
		{
			Dictionary<string, int> storedItemCounts = currentMachine.GetStoredItemCounts();
			int num = 0;
			foreach (KeyValuePair<string, int> item in storedItemCounts)
			{
				num += item.Value;
			}
			int num2 = ((GameManager.Instance != null) ? GameManager.Instance.machineMaxItemCount : 2000);
			storageCapacityText.text = $"{num}/{num2}";
		}
		UpdateStorageItemList();
	}

	private void UpdateStorageItemList()
	{
		if (storageItemListParent == null || storageItemPrefab == null)
		{
			return;
		}
		Dictionary<string, int> storedItemCounts = currentMachine.GetStoredItemCounts();
		foreach (StorageItemUI storageItemUI2 in storageItemUIs)
		{
			if (storageItemUI2 != null && storageItemUI2.gameObject != null)
			{
				UnityEngine.Object.Destroy(storageItemUI2.gameObject);
			}
		}
		storageItemUIs.Clear();
		foreach (KeyValuePair<string, int> item in storedItemCounts)
		{
			T_ItemSO t_ItemSO = ItemSOManager.Instance?.GetItemSOById(item.Key);
			if (!(t_ItemSO == null))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(storageItemPrefab, storageItemListParent);
				StorageItemUI storageItemUI = gameObject.GetComponent<StorageItemUI>();
				if (storageItemUI == null)
				{
					storageItemUI = gameObject.AddComponent<StorageItemUI>();
				}
				storageItemUI.Initialize(t_ItemSO, item.Value);
				storageItemUIs.Add(storageItemUI);
			}
		}
	}

	private void OnStartStopButtonClicked()
	{
		if (!(currentMachine == null))
		{
			if (!currentMachine.IsProductionPaused)
			{
				currentMachine.RequestStopProduction();
			}
			else
			{
				currentMachine.RequestStartProduction();
			}
		}
	}

	public void OnRecipeHoverEnter(int recipeIndex)
	{
		if (!(currentMachine == null) && recipeIndex >= 0 && recipeIndex < currentMachine.AcceptedRecipes.Count)
		{
			previewRecipeIndex = recipeIndex;
			UpdateRecipeDetail();
			UpdateRequirements();
		}
	}

	public void OnRecipeHoverExit()
	{
		previewRecipeIndex = -1;
		UpdateRecipeDetail();
		UpdateRequirements();
	}

	private void OnClearStorageButtonClicked()
	{
		if (currentMachine == null)
		{
			Debug.LogWarning("[MachineUI] Machine null, item'lar gönderilemedi");
			return;
		}
		currentMachine.SendAllItemsToStorage();
		Debug.Log("[MachineUI] Tüm item'lar StorageManager'a gönderildi");
	}

	private void OnIncreaseAmountClicked()
	{
		if (!(currentMachine == null))
		{
			currentMachine.IncreaseAmount();
			UpdateAmountControl();
		}
	}

	private void OnDecreaseAmountClicked()
	{
		if (!(currentMachine == null))
		{
			currentMachine.DecreaseAmount();
			UpdateAmountControl();
		}
	}

	private void OnMaxAmountClicked()
	{
		if (!(currentMachine == null))
		{
			currentMachine.SetMaxAmount();
			UpdateAmountControl();
		}
	}

	private void OnInfiniteToggleClicked()
	{
		if (!(currentMachine == null))
		{
			bool isInfiniteMode = currentMachine.IsInfiniteMode;
			currentMachine.ToggleInfiniteMode();
			StartCoroutine(TriggerInfiniteModeEventDelayed(!isInfiniteMode));
		}
	}

	private void OnInfiniteDisableClicked()
	{
		if (!(currentMachine == null) && currentMachine.IsInfiniteMode)
		{
			currentMachine.DisableInfiniteMode();
			StartCoroutine(TriggerInfiniteModeEventDelayed(enabled: false));
		}
	}

	private IEnumerator TriggerInfiniteModeEventDelayed(bool enabled)
	{
		yield return null;
		if (enabled)
		{
			Debug.Log("[MachineUI] OnInfiniteModeEnabled invoke ediliyor");
			OnInfiniteModeEnabled?.Invoke();
		}
		else
		{
			Debug.Log("[MachineUI] OnInfiniteModeDisabled invoke ediliyor");
			OnInfiniteModeDisabled?.Invoke();
		}
		UpdateAmountControl();
	}

	private void UpdateAmountControl()
	{
		if (!(currentMachine == null) && amountInputField != null && !amountInputField.isFocused)
		{
			isUpdatingAmountFromCode = true;
			amountInputField.text = currentMachine.ProductionAmount.ToString();
			isUpdatingAmountFromCode = false;
		}
	}

	private void OnAmountInputFieldValueChanged(string value)
	{
		if (!isUpdatingAmountFromCode && !(currentMachine == null) && !string.IsNullOrEmpty(value) && int.TryParse(value, out var result))
		{
			if (result < 0)
			{
				result = 0;
			}
			int productionAmount = currentMachine.ProductionAmount;
			int num = result - productionAmount;
			if (num > 0)
			{
				currentMachine.IncreaseAmount(num);
			}
			else if (num < 0)
			{
				currentMachine.DecreaseAmount(-num);
			}
		}
	}

	private void UpdateFillBar(float progress)
	{
		if (productionFillBar != null)
		{
			productionFillBar.fillAmount = Mathf.Clamp01(progress);
		}
	}
}
