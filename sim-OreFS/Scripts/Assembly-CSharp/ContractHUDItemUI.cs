using System.Collections.Generic;
using Enviro;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContractHUDItemUI : MonoBehaviour
{
	[Header("UI Elements")]
	[Tooltip("Contract numarası text'i (Contract #123 formatında)")]
	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private GameObject expandedArrow;

	[SerializeField]
	private GameObject collapsedArrow;

	[Header("First Item Only")]
	[Tooltip("Sadece ilk contract item'ında görünecek objeler (diğerlerinde gizlenir)")]
	[SerializeField]
	private List<GameObject> firstItemOnlyObjects = new List<GameObject>();

	[Tooltip("ContractHUDMaterialUI prefab'ı")]
	[SerializeField]
	private GameObject materialItemPrefab;

	[Tooltip("Material item'larının parent'ı (daraltıldığında gizlenecek)")]
	[SerializeField]
	private Transform materialListContent;

	[Header("Delivery Deadline")]
	[Tooltip("Kalan gün bilgisini içeren obje (expand/collapse ile açılıp kapanır)")]
	[SerializeField]
	private GameObject remainingDaysObject;

	[Tooltip("Kalan gün sayısını gösteren text")]
	[SerializeField]
	private TextMeshProUGUI remainingDaysText;

	[Header("Active Delivery Indicator")]
	[Tooltip("Bu contract aktif delivery olduğunda gösterilecek obje")]
	[SerializeField]
	private GameObject activeDeliveryIndicator;

	private List<ContractHUDMaterialUI> _spawnedMaterialItems = new List<ContractHUDMaterialUI>();

	private ActiveContractData _contractData;

	private bool _isDetailsExpanded = true;

	public string ActiveId => _contractData.activeId;

	public ActiveContractData ContractData => _contractData;

	public bool IsDetailsExpanded => _isDetailsExpanded;

	public void SetFirstItemOnly(bool isFirstItem)
	{
		foreach (GameObject firstItemOnlyObject in firstItemOnlyObjects)
		{
			if (firstItemOnlyObject != null)
			{
				firstItemOnlyObject.SetActive(isFirstItem);
			}
		}
	}

	public void Initialize(ActiveContractData contract)
	{
		_contractData = contract;
		UpdateUI();
		UpdateActiveDeliveryIndicator();
		UpdateRemainingDaysText();
	}

	public void UpdateContractData(ActiveContractData contract)
	{
		_contractData = contract;
		UpdateUI();
		UpdateActiveDeliveryIndicator();
		UpdateRemainingDaysText();
	}

	private void UpdateUI()
	{
		if (_contractData.IsValid)
		{
			if (nameText != null)
			{
				string translation = LocalizationManager.GetTranslation("Contract");
				nameText.text = $"{translation} #{_contractData.contractNumber:D3}";
			}
			UpdateMaterialList();
		}
	}

	private void UpdateMaterialList()
	{
		int materialCount = _contractData.MaterialCount;
		while (_spawnedMaterialItems.Count < materialCount)
		{
			CreateMaterialItem();
		}
		for (int i = 0; i < _spawnedMaterialItems.Count; i++)
		{
			bool active = i < materialCount && _isDetailsExpanded;
			_spawnedMaterialItems[i].gameObject.SetActive(active);
			if (i < materialCount && i < _contractData.materialIds.Length)
			{
				string itemId = _contractData.materialIds[i];
				int requiredCount = _contractData.materialCounts[i];
				int warehouseCount = ((T_Warehouse.Instance != null) ? T_Warehouse.Instance.GetItemCount(itemId) : 0);
				int deliveredCount = 0;
				if (T_DeliveryZone.Instance != null && T_DeliveryZone.Instance.CurrentContractId == _contractData.activeId)
				{
					deliveredCount = T_DeliveryZone.Instance.GetItemCount(itemId);
				}
				_spawnedMaterialItems[i].Initialize(itemId, requiredCount, deliveredCount, warehouseCount);
			}
		}
	}

	private void CreateMaterialItem()
	{
		if (!(materialItemPrefab == null) && !(materialListContent == null))
		{
			GameObject gameObject = Object.Instantiate(materialItemPrefab, materialListContent);
			ContractHUDMaterialUI component = gameObject.GetComponent<ContractHUDMaterialUI>();
			if (component != null)
			{
				_spawnedMaterialItems.Add(component);
				return;
			}
			Debug.LogWarning("[ContractHUDItemUI] ContractHUDMaterialUI component bulunamadı!");
			Object.Destroy(gameObject);
		}
	}

	public void ToggleDetails()
	{
		SetDetailsExpanded(!_isDetailsExpanded);
	}

	public void SetDetailsExpanded(bool expanded)
	{
		_isDetailsExpanded = expanded;
		if (expandedArrow != null)
		{
			expandedArrow.SetActive(expanded);
		}
		if (collapsedArrow != null)
		{
			collapsedArrow.SetActive(!expanded);
		}
		int materialCount = _contractData.MaterialCount;
		for (int i = 0; i < _spawnedMaterialItems.Count; i++)
		{
			if (_spawnedMaterialItems[i] != null)
			{
				bool active = i < materialCount && _isDetailsExpanded;
				_spawnedMaterialItems[i].gameObject.SetActive(active);
			}
		}
		if (remainingDaysObject != null)
		{
			remainingDaysObject.SetActive(expanded);
		}
		ForceRebuildLayout();
	}

	private void ForceRebuildLayout()
	{
		RectTransform component = GetComponent<RectTransform>();
		if (component != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(component);
		}
		if (materialListContent != null)
		{
			RectTransform component2 = materialListContent.GetComponent<RectTransform>();
			if (component2 != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(component2);
			}
		}
		RectTransform rectTransform = base.transform.parent?.GetComponent<RectTransform>();
		if (rectTransform != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
		}
	}

	public void ExpandDetails()
	{
		SetDetailsExpanded(expanded: true);
	}

	public void CollapseDetails()
	{
		SetDetailsExpanded(expanded: false);
	}

	private void UpdateRemainingDaysText()
	{
		if (remainingDaysText == null)
		{
			return;
		}
		if (!_contractData.IsValid)
		{
			remainingDaysText.gameObject.SetActive(value: false);
			return;
		}
		int remainingDays = _contractData.RemainingDays;
		if (remainingDays <= 0)
		{
			string text = LocalizationManager.GetTranslation("Last Day");
			if (string.IsNullOrEmpty(text))
			{
				text = "Last Day";
			}
			remainingDaysText.text = text;
		}
		else
		{
			string text2 = LocalizationManager.GetTranslation("Day");
			if (string.IsNullOrEmpty(text2))
			{
				text2 = "Day";
			}
			remainingDaysText.text = $"{remainingDays} {text2}";
		}
		remainingDaysText.gameObject.SetActive(value: true);
	}

	private void OnDayStartedForDeadline()
	{
		UpdateRemainingDaysText();
	}

	public void ClearMaterialItems()
	{
		foreach (ContractHUDMaterialUI spawnedMaterialItem in _spawnedMaterialItems)
		{
			if (spawnedMaterialItem != null)
			{
				Object.Destroy(spawnedMaterialItem.gameObject);
			}
		}
		_spawnedMaterialItems.Clear();
	}

	private void OnEnable()
	{
		if (T_Warehouse.Instance != null)
		{
			T_Warehouse.Instance.OnInventoryChanged.AddListener(OnInventoryChanged);
		}
		if (T_DeliveryZone.Instance != null)
		{
			T_DeliveryZone.Instance.OnItemsChanged.AddListener(OnInventoryChanged);
		}
		if (ComputerContractManager.Instance != null)
		{
			ComputerContractManager.Instance.onDeliveryContractChanged.AddListener(OnDeliveryContractChanged);
		}
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted += OnDayStartedForDeadline;
		}
		UpdateActiveDeliveryIndicator();
		UpdateRemainingDaysText();
	}

	private void OnDisable()
	{
		if (T_Warehouse.Instance != null)
		{
			T_Warehouse.Instance.OnInventoryChanged.RemoveListener(OnInventoryChanged);
		}
		if (T_DeliveryZone.Instance != null)
		{
			T_DeliveryZone.Instance.OnItemsChanged.RemoveListener(OnInventoryChanged);
		}
		if (ComputerContractManager.Instance != null)
		{
			ComputerContractManager.Instance.onDeliveryContractChanged.RemoveListener(OnDeliveryContractChanged);
		}
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted -= OnDayStartedForDeadline;
		}
	}

	private void OnInventoryChanged()
	{
		UpdateMaterialList();
	}

	private void OnDeliveryContractChanged(string newActiveContractId)
	{
		UpdateActiveDeliveryIndicator();
	}

	private void UpdateActiveDeliveryIndicator()
	{
		if (!(activeDeliveryIndicator == null))
		{
			bool active = false;
			if (_contractData.IsValid && ComputerContractManager.Instance != null)
			{
				active = ComputerContractManager.Instance.DeliveryRequestedContractId == _contractData.activeId;
			}
			activeDeliveryIndicator.SetActive(active);
		}
	}

	private void OnDestroy()
	{
		ClearMaterialItems();
	}
}
