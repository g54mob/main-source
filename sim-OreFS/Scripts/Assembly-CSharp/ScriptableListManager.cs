using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class ScriptableListManager : MonoBehaviour
{
	private static ScriptableListManager _instance;

	[Header("Items")]
	[Tooltip("Tüm T_ItemSO'ların listesi")]
	[SerializeField]
	private List<T_ItemSO> allItemSOs = new List<T_ItemSO>();

	[Header("Buildings")]
	[Tooltip("Tüm T_BuildingItemSO'ların listesi (index sırası network sync için kritiktir)")]
	[SerializeField]
	private List<T_BuildingItemSO> allBuildingItemSOs = new List<T_BuildingItemSO>();

	[Header("Building Categories")]
	[Tooltip("Tüm building kategorileri")]
	[SerializeField]
	private List<T_BuildingCategorySO> allBuildingCategories = new List<T_BuildingCategorySO>();

	[Header("Contracts")]
	[Tooltip("Tüm contract konfigürasyonları")]
	[SerializeField]
	private List<ContractSO> allContractConfigs = new List<ContractSO>();

	[Header("Properties")]
	[Tooltip("Tüm property (emlak) konfigürasyonları")]
	[SerializeField]
	private List<PropertyConfigSO> allPropertyConfigs = new List<PropertyConfigSO>();

	[Header("Level")]
	[Tooltip("Level konfigürasyonu")]
	[SerializeField]
	private LevelConfigSO levelConfig;

	[Header("Upgrades")]
	[Tooltip("Tum upgrade tab konfigurasyonlari")]
	[SerializeField]
	private List<UpgradeTabSO> allUpgradeTabs = new List<UpgradeTabSO>();

	[Tooltip("Tum upgrade group konfigurasyonlari")]
	[SerializeField]
	private List<UpgradeGroupSO> allUpgradeGroups = new List<UpgradeGroupSO>();

	[Header("Companies")]
	[Tooltip("Tüm şirket konfigürasyonları (stock sell sistemi için)")]
	[SerializeField]
	private List<CompanySO> allCompanies = new List<CompanySO>();

	[Header("Factory Identity")]
	[Tooltip("Fabrika kimlik konfigürasyonu (şirket isimleri ve logolar)")]
	[SerializeField]
	private FactoryIdentityConfigSO factoryIdentityConfig;

	public static ScriptableListManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindFirstObjectByType<ScriptableListManager>();
				if (_instance == null)
				{
					Debug.LogError("[ScriptableListManager] Sahnede ScriptableListManager bulunamadı!");
				}
			}
			return _instance;
		}
	}

	public IReadOnlyList<T_ItemSO> AllItemSOs => allItemSOs;

	public IReadOnlyList<T_BuildingItemSO> AllBuildingItemSOs => allBuildingItemSOs;

	public IReadOnlyList<T_BuildingCategorySO> AllBuildingCategories => allBuildingCategories;

	public IReadOnlyList<ContractSO> AllContractConfigs => allContractConfigs;

	public IReadOnlyList<PropertyConfigSO> AllPropertyConfigs => allPropertyConfigs;

	public LevelConfigSO LevelConfig => levelConfig;

	public IReadOnlyList<UpgradeTabSO> AllUpgradeTabs => allUpgradeTabs;

	public IReadOnlyList<UpgradeGroupSO> AllUpgradeGroups => allUpgradeGroups;

	public IReadOnlyList<CompanySO> AllCompanies => allCompanies;

	public FactoryIdentityConfigSO FactoryIdentityConfig => factoryIdentityConfig;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Debug.LogWarning("[ScriptableListManager] Birden fazla instance bulundu! Yeni instance destroy ediliyor.");
			Object.Destroy(base.gameObject);
		}
		else
		{
			_instance = this;
		}
	}
}
