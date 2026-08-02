using System.Collections.Generic;
using HQFPSTemplate;
using HQFPSTemplate.Equipment;
using HQFPSTemplate.Items;
using UnityEngine;

public class CollectableInventoryItem : MonoBehaviour
{
	public CollectableItemData collectableData;

	public bool multipleItemBehavior;

	public List<CollectableItemData> multipleItems = new List<CollectableItemData>();

	[HideInInspector]
	public ItemInfo item;

	[ReadOnly]
	public string itemDatabaseName;

	private Inventory hqInventory;

	public PlayerEquipmentController playerEquipmentController;

	public HQFPSTemplate.Player player;

	public ItemDatabase itemDatabase;

	public EquipmentHandler equipmentHandler;

	private Item m_ItemInstance;

	[SerializeField]
	[Tooltip("In what container of the Player will the picked up item go")]
	protected ItemContainerFlags m_TargetContainers = ItemContainerFlags.Storage;

	public int weaponIndex;

	private void Start()
	{
		itemDatabaseName = collectableData.itemFPSTemplateKey;
	}

	public void OnEnable()
	{
		TryGetComponent<EquipmentInventoryAdder>(out var _);
	}
}
