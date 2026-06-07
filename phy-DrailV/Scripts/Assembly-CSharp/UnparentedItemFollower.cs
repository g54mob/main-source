using DV.Items;
using DV.Utils;
using UnityEngine;

[ExecutionOrder(10)]
public class UnparentedItemFollower : MonoBehaviour
{
	private Transform itemTransform;

	private ItemPositionHandler itemPositionHandler;

	private bool isInventory;

	private bool isHand;

	private void Awake()
	{
		itemTransform = base.transform.parent;
		if (itemTransform == null)
		{
			Debug.LogError("[UnparentedItemFollower]: No parent! UnparentedItemFollower should be the child of an item", this);
		}
		base.transform.SetParent(null);
	}

	private void Start()
	{
		itemPositionHandler = base.gameObject.AddComponent<ItemPositionHandler>();
		itemPositionHandler.Initialize(itemTransform.gameObject);
	}

	private void LateUpdate()
	{
		if (itemTransform == null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		if (itemPositionHandler.Initialized)
		{
			base.transform.position = itemPositionHandler.ItemPosition;
		}
		base.transform.rotation = Quaternion.identity;
	}
}
