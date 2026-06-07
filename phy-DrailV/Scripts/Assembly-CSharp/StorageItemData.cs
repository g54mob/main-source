using Newtonsoft.Json.Linq;
using UnityEngine;

public class StorageItemData
{
	public string itemPrefabName;

	public float itemPositionX;

	public float itemPositionY;

	public float itemPositionZ;

	public float itemRotationX;

	public float itemRotationY;

	public float itemRotationZ;

	public float itemRotationW;

	public bool belongsToPlayer;

	public bool isGrabbed;

	public int inventorySlotIndex;

	public int containerSlotIndex;

	public bool inLockedSlot;

	public bool isDropped;

	public string carGuid;

	public string containerId;

	public JObject state;

	public Vector3 ItemPosition => new Vector3(itemPositionX, itemPositionY, itemPositionZ);

	public Quaternion ItemRotation => new Quaternion(itemRotationX, itemRotationY, itemRotationZ, itemRotationW);

	public StorageItemData(string itemPrefabName, Vector3 itemPosition, Quaternion itemRotation, bool belongsToPlayer, bool isGrabbed = false, string carGuid = null, JObject state = null, int inventorySlotIndex = -1, int containerSlotIndex = -1, bool inLockedSlot = false, bool isDropped = false, string containerId = null)
	{
		this.itemPrefabName = itemPrefabName;
		itemPositionX = itemPosition.x;
		itemPositionY = itemPosition.y;
		itemPositionZ = itemPosition.z;
		itemRotationX = itemRotation.x;
		itemRotationY = itemRotation.y;
		itemRotationZ = itemRotation.z;
		itemRotationW = itemRotation.w;
		this.belongsToPlayer = belongsToPlayer;
		this.isGrabbed = isGrabbed;
		this.carGuid = carGuid;
		this.containerId = containerId;
		this.state = state;
		this.inventorySlotIndex = inventorySlotIndex;
		this.containerSlotIndex = containerSlotIndex;
		this.inLockedSlot = inLockedSlot;
		this.isDropped = isDropped;
	}
}
