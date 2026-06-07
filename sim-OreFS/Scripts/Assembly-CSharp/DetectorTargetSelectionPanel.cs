using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetectorTargetSelectionPanel : MonoBehaviour
{
	[Header("Panel References")]
	[SerializeField]
	private GameObject panelRoot;

	[SerializeField]
	private Transform contentParent;

	[SerializeField]
	private GameObject itemEntryPrefab;

	[SerializeField]
	private Button closeButton;

	[Header("Active Target Display (Sağ taraf)")]
	[SerializeField]
	private Image activeTargetIcon;

	[SerializeField]
	private TextMeshProUGUI activeTargetNameText;

	[Header("Filter")]
	[SerializeField]
	private TextMeshProUGUI filterButtonText;

	[Header("State")]
	private T_ItemSO currentScanTarget;

	private List<DetectorScanTargetUI> spawnedEntries = new List<DetectorScanTargetUI>();

	private static readonly FilterType[] allowedFilterTypes = new FilterType[6]
	{
		FilterType.Ores,
		FilterType.Rocks,
		FilterType.BaseMetals,
		FilterType.Alloys,
		FilterType.RareMetals,
		FilterType.Gems
	};

	private int currentFilterIndex = -1;

	public static DetectorTargetSelectionPanel Instance { get; private set; }

	public T_ItemSO CurrentScanTarget => currentScanTarget;

	public bool IsOpen
	{
		get
		{
			if (panelRoot != null)
			{
				return panelRoot.activeSelf;
			}
			return false;
		}
	}

	public event Action<T_ItemSO> OnScanTargetChanged;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		if (closeButton != null)
		{
			closeButton.onClick.AddListener(ClosePanel);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void OpenPanel()
	{
		if (panelRoot != null)
		{
			panelRoot.SetActive(value: true);
		}
		ResetFilter();
		RefreshItemList();
	}

	public void ClosePanel()
	{
		if (panelRoot != null)
		{
			panelRoot.SetActive(value: false);
		}
	}

	public void RefreshItemList()
	{
		ClearEntries();
		if (itemEntryPrefab == null || contentParent == null || ComputerPropertyManager.Instance == null)
		{
			return;
		}
		List<T_ItemSO> activePropertyItems = ComputerPropertyManager.Instance.GetActivePropertyItems();
		HashSet<T_ItemSO> hashSet = new HashSet<T_ItemSO>();
		foreach (T_ItemSO item in activePropertyItems)
		{
			if (!(item == null) && !hashSet.Contains(item))
			{
				hashSet.Add(item);
				SpawnEntry(item);
			}
		}
		ApplyFilter();
	}

	private void SpawnEntry(T_ItemSO itemSO)
	{
		if (!(itemEntryPrefab == null) && !(contentParent == null))
		{
			DetectorScanTargetUI component = UnityEngine.Object.Instantiate(itemEntryPrefab, contentParent).GetComponent<DetectorScanTargetUI>();
			if (component != null)
			{
				component.Initialize(itemSO, OnItemSelected);
				spawnedEntries.Add(component);
			}
		}
	}

	private void ClearEntries()
	{
		foreach (DetectorScanTargetUI spawnedEntry in spawnedEntries)
		{
			if (spawnedEntry != null)
			{
				UnityEngine.Object.Destroy(spawnedEntry.gameObject);
			}
		}
		spawnedEntries.Clear();
	}

	private void OnItemSelected(T_ItemSO selectedItem)
	{
		currentScanTarget = selectedItem;
		UpdateActiveTargetDisplay();
		this.OnScanTargetChanged?.Invoke(selectedItem);
		Debug.Log("[DetectorTargetSelectionPanel] Scan target seçildi: " + selectedItem?.Name);
		ClosePanel();
	}

	private void UpdateActiveTargetDisplay()
	{
		if (activeTargetIcon != null)
		{
			if (currentScanTarget != null && currentScanTarget.Icon != null)
			{
				activeTargetIcon.sprite = currentScanTarget.Icon;
				activeTargetIcon.enabled = true;
			}
			else
			{
				activeTargetIcon.enabled = false;
			}
		}
		if (activeTargetNameText != null)
		{
			if (currentScanTarget != null)
			{
				string translation = LocalizationManager.GetTranslation(currentScanTarget.Name);
				activeTargetNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : currentScanTarget.Name);
			}
			else
			{
				activeTargetNameText.text = "";
			}
		}
	}

	public void SetScanTarget(T_ItemSO itemSO)
	{
		currentScanTarget = itemSO;
		UpdateActiveTargetDisplay();
		this.OnScanTargetChanged?.Invoke(itemSO);
	}

	public void ClearScanTarget()
	{
		currentScanTarget = null;
		UpdateActiveTargetDisplay();
		this.OnScanTargetChanged?.Invoke(null);
	}

	public void OnFilterButtonClicked()
	{
		currentFilterIndex++;
		if (currentFilterIndex >= allowedFilterTypes.Length)
		{
			currentFilterIndex = -1;
		}
		UpdateFilterButtonText();
		ApplyFilter();
	}

	private void UpdateFilterButtonText()
	{
		if (!(filterButtonText == null))
		{
			if (currentFilterIndex == -1)
			{
				string translation = LocalizationManager.GetTranslation("FilterType_All");
				filterButtonText.text = ((!string.IsNullOrEmpty(translation)) ? translation : "NL- All");
			}
			else
			{
				FilterType filterType = allowedFilterTypes[currentFilterIndex];
				string translation2 = LocalizationManager.GetTranslation("FilterType_" + filterType);
				filterButtonText.text = ((!string.IsNullOrEmpty(translation2)) ? translation2 : ("NL- " + filterType));
			}
		}
	}

	public void ApplyFilter()
	{
		foreach (DetectorScanTargetUI spawnedEntry in spawnedEntries)
		{
			if (spawnedEntry == null)
			{
				continue;
			}
			if (currentFilterIndex == -1)
			{
				spawnedEntry.gameObject.SetActive(value: true);
				continue;
			}
			FilterType item = allowedFilterTypes[currentFilterIndex];
			T_ItemSO itemSO = spawnedEntry.GetItemSO();
			if (itemSO != null && itemSO.FilterTypes != null)
			{
				spawnedEntry.gameObject.SetActive(itemSO.FilterTypes.Contains(item));
			}
			else
			{
				spawnedEntry.gameObject.SetActive(value: false);
			}
		}
	}

	public void ResetFilter()
	{
		currentFilterIndex = -1;
		UpdateFilterButtonText();
	}
}
