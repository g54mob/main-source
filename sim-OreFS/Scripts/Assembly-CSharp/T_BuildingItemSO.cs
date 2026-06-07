using UnityEngine;

[CreateAssetMenu(fileName = "T_BuildingItemSO", menuName = "Game/T_BuildingItemSO")]
public class T_BuildingItemSO : ScriptableObject
{
	[Header("Identity")]
	public string Name;

	public string Description;

	public Sprite Icon;

	[Header("Market")]
	public int Price;

	[Header("Marketplace")]
	[Tooltip("Building kategorisi - Marketplace filtreleme için")]
	public BuildingCategory Category;

	[Tooltip("Bu ürün markette satılabilir mi?")]
	public bool canBeSoldInMarket = true;

	[Tooltip("Bu ürün markete geri satılabilir mi?")]
	public bool canBeSoldBackToMarket;

	[Tooltip("Paket içindeki adet (örn: 10x su koli için 10)")]
	public int packageQuantity = 1;

	[Header("Building")]
	[Tooltip("Building prefab referansı - Spawn edilecek building objesi (BuildingObject component'ine sahip)")]
	public GameObject Prefab;

	[Header("Hammer Settings")]
	[Tooltip("Bu building hammer ile resale edilebilir mi?")]
	public bool canBeResaledWithHammer = true;

	[Tooltip("Bu building hammer ile relocate edilebilir mi?")]
	public bool canBeRelocatedWithHammer = true;

	[Header("Spawn Settings")]
	[Tooltip("True ise bu building U tuşuyla rastgele kutu olarak spawn edilmez. Sadece Equipments'den erişilebilir. (Palet, Belt gibi öğeler için kullan)")]
	public bool excludeFromBoxSpawn;

	[Header("Tutorial Settings")]
	[Tooltip("Bu building bir pallet mi? (Tutorial için)")]
	public bool isPallet;

	[Tooltip("Bu building bir belt mi? (Tutorial için)")]
	public bool isBelt;

	[Tooltip("Bu item tutorialde beleş mi?")]
	public bool isTutorialFree;

	[Tooltip("Hangi Steplerde beleş? (Birden fazla seçilebilir)")]
	public TutorialSubStepType[] TutorialSubStepTypesForFreeBuy;

	[Header("Placement")]
	[Tooltip("Bu building'in surfaceLayer'a ek olarak yerleştirilebileceği layer'lar (örn: Warehouse layer). Boş bırakılırsa sadece surfaceLayer geçerlidir.")]
	public LayerMask additionalPlacementLayers;

	[Header("Level")]
	[Tooltip("Building seviyesi - Hangi seviyede unlock olacak")]
	public int Level = 1;

	[Header("Requirements")]
	public UpgradeType requiredUpgrade;

	[Tooltip("Gerekli upgrade seviyesi (bu seviyeye ulaşılınca açılır)")]
	public int requiredUpgradeLevel = 1;

	[Header("Version")]
	[Tooltip("True ise bu item sadece full version'da kullanılabilir (Demo'da kilitli)")]
	public bool fullVersionOnly;
}
