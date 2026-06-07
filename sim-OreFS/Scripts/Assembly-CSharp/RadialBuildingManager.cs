using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RadialBuildingManager : MonoBehaviour
{
	[Header("State")]
	[SerializeField]
	private T_BuildingCategorySO activeCategory;

	[SerializeField]
	private int selectedIndex;

	[SerializeField]
	private BuildingModeSource currentSource;

	[Header("Events")]
	[Tooltip("Building mode başladığında tetiklenir")]
	public UnityEvent<T_BuildingItemSO> OnBuildingModeStarted;

	[Tooltip("Aktif building değiştiğinde tetiklenir (scroll ile)")]
	public UnityEvent<T_BuildingItemSO, int, int> OnBuildingChanged;

	[Tooltip("Building mode kapandığında tetiklenir")]
	public UnityEvent OnBuildingModeStopped;

	[Tooltip("Building yerleştirildiğinde tetiklenir")]
	public UnityEvent<T_BuildingItemSO> OnBuildingPlaced;

	public static RadialBuildingManager Instance { get; private set; }

	public IReadOnlyList<T_BuildingCategorySO> categories => ScriptableListManager.Instance.AllBuildingCategories;

	public T_BuildingCategorySO ActiveCategory => activeCategory;

	public int SelectedIndex => selectedIndex;

	public BuildingModeSource CurrentSource => currentSource;

	public bool IsInBuildingMode => currentSource != BuildingModeSource.None;

	public T_BuildingItemSO SelectedBuilding
	{
		get
		{
			if (activeCategory == null)
			{
				return null;
			}
			return activeCategory.GetBuilding(selectedIndex);
		}
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	public void StartBuildingFromCategory(T_BuildingCategorySO category)
	{
		if (category == null)
		{
			Debug.LogWarning("[RadialBuildingManager] StartBuildingFromCategory: category null!");
			return;
		}
		if (category.BuildingCount == 0)
		{
			Debug.LogWarning("[RadialBuildingManager] StartBuildingFromCategory: " + category.CategoryName + " kategorisinde building yok!");
			return;
		}
		if (IsInBuildingMode)
		{
			CancelBuilding();
		}
		activeCategory = category;
		selectedIndex = category.DefaultSelectedIndex;
		currentSource = BuildingModeSource.RadialMenu;
		T_BuildingItemSO selectedBuilding = SelectedBuilding;
		if (selectedBuilding == null)
		{
			Debug.LogError($"[RadialBuildingManager] StartBuildingFromCategory: selectedBuilding null! Category: {category.CategoryName}, Index: {selectedIndex}");
			CancelBuilding();
			return;
		}
		Debug.Log($"[RadialBuildingManager] Building mode başlatılıyor - Kategori: {category.CategoryName}, Building: {selectedBuilding.Name}, Index: {selectedIndex}/{category.BuildingCount}");
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameManager.Instance.localEquipments.StartBuildingModeFromRadialMenu(selectedBuilding);
			OnBuildingModeStarted?.Invoke(selectedBuilding);
			OnBuildingChanged?.Invoke(selectedBuilding, selectedIndex, category.BuildingCount);
		}
		else
		{
			Debug.LogError("[RadialBuildingManager] GameManager veya localEquipments null!");
			CancelBuilding();
		}
	}

	public void CycleBuilding(int direction)
	{
		if (currentSource != BuildingModeSource.RadialMenu || activeCategory == null || activeCategory.BuildingCount <= 1)
		{
			return;
		}
		int nextIndex = activeCategory.GetNextIndex(selectedIndex, direction);
		if (nextIndex == selectedIndex)
		{
			return;
		}
		selectedIndex = nextIndex;
		T_BuildingItemSO selectedBuilding = SelectedBuilding;
		if (selectedBuilding == null)
		{
			Debug.LogError($"[RadialBuildingManager] CycleBuilding: newBuilding null! Index: {selectedIndex}");
			return;
		}
		Debug.Log($"[RadialBuildingManager] Building değiştirildi - Building: {selectedBuilding.Name}, Index: {selectedIndex}/{activeCategory.BuildingCount}");
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameManager.Instance.localEquipments.ChangeBuildingInRadialMode(selectedBuilding);
		}
		OnBuildingChanged?.Invoke(selectedBuilding, selectedIndex, activeCategory.BuildingCount);
	}

	public void CancelBuilding()
	{
		if (currentSource != BuildingModeSource.None)
		{
			Debug.Log("[RadialBuildingManager] Building mode iptal ediliyor...");
			if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
			{
				GameManager.Instance.localEquipments.StopBuildingMode();
			}
			activeCategory = null;
			selectedIndex = 0;
			currentSource = BuildingModeSource.None;
			OnBuildingModeStopped?.Invoke();
		}
	}

	public void OnBuildingPlacedCallback(T_BuildingItemSO placedBuilding)
	{
		Debug.Log($"[RadialBuildingManager] OnBuildingPlacedCallback çağrıldı - currentSource: {currentSource}, placedBuilding: {placedBuilding?.Name}");
		if (currentSource != BuildingModeSource.RadialMenu)
		{
			Debug.LogWarning($"[RadialBuildingManager] OnBuildingPlacedCallback: currentSource Equipments değil! currentSource: {currentSource}");
			return;
		}
		Debug.Log("[RadialBuildingManager] Building yerleştirildi - Building: " + placedBuilding?.Name);
		OnBuildingPlaced?.Invoke(placedBuilding);
		Debug.Log(string.Format("[RadialBuildingManager] SelectedBuilding kontrolü - activeCategory: {0}, selectedIndex: {1}, SelectedBuilding: {2}", (activeCategory != null) ? activeCategory.CategoryName : "null", selectedIndex, (SelectedBuilding != null) ? SelectedBuilding.Name : "null"));
		if (SelectedBuilding != null)
		{
			Debug.Log("[RadialBuildingManager] Aynı building ile devam ediliyor - Building: " + SelectedBuilding.Name);
			if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
			{
				GameManager.Instance.localEquipments.ContinueBuildingInRadialMode(SelectedBuilding);
			}
			else
			{
				Debug.LogError("[RadialBuildingManager] GameManager veya localEquipments null!");
			}
		}
		else
		{
			Debug.LogWarning("[RadialBuildingManager] SelectedBuilding null! Yeni preview spawn edilemedi.");
		}
	}

	public bool CanAffordBuilding(T_BuildingItemSO building)
	{
		if (building == null)
		{
			return false;
		}
		if (building.Price <= 0)
		{
			return true;
		}
		if (GameManager.Instance != null && GameManager.Instance.factoryManager != null)
		{
			return GameManager.Instance.factoryManager.Money >= building.Price;
		}
		return false;
	}

	public T_BuildingCategorySO GetCategoryById(string categoryId)
	{
		if (string.IsNullOrEmpty(categoryId))
		{
			return null;
		}
		foreach (T_BuildingCategorySO category in categories)
		{
			if (category != null && category.CategoryId == categoryId)
			{
				return category;
			}
		}
		return null;
	}

	public void SetBuildingModeSource(BuildingModeSource source)
	{
		currentSource = source;
		if (source == BuildingModeSource.None)
		{
			activeCategory = null;
			selectedIndex = 0;
		}
	}
}
