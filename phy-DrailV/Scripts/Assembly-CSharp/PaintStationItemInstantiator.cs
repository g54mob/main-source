using System.Collections;
using System.Linq;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

public class PaintStationItemInstantiator : MonoBehaviour
{
	[SerializeField]
	private ItemStaticParentPaintStation paintStationParent;

	[SerializeField]
	private GameObject itemPrefab;

	[SerializeField]
	private Transform paintStationItemAnchor;

	private ItemBase item;

	private Coroutine instantiateItemCoroutine;

	private void Awake()
	{
		if (paintStationParent == null || itemPrefab == null || paintStationItemAnchor == null)
		{
			Debug.LogError("PaintStationItemInstantiator: Required fields are not set.", this);
		}
		else
		{
			instantiateItemCoroutine = SingletonBehaviour<CoroutineManager>.Instance.Run(InstantiateItem());
		}
	}

	private void OnDestroy()
	{
		if (instantiateItemCoroutine != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.StopCoroutine(instantiateItemCoroutine);
		}
	}

	private IEnumerator InstantiateItem()
	{
		while (!SingletonBehaviour<StartingItemsController>.Instance.itemsLoaded)
		{
			yield return null;
		}
		if (SingletonBehaviour<StorageController>.Instance.GetAllStorageItems().FirstOrDefault((ItemBase t) => t.InventorySpecs.BelongsToPlayer && t.InventorySpecs.ItemPrefabName == itemPrefab.name) != null)
		{
			instantiateItemCoroutine = null;
			Object.Destroy(this);
			yield break;
		}
		GameObject gameObject = Object.Instantiate(itemPrefab, base.transform.position, base.transform.rotation);
		item = gameObject.GetComponent<ItemBase>();
		item.Grabbed += OnItemGrabbed;
		yield return null;
		ItemReparentingBase component = item.GetComponent<ItemReparentingBase>();
		if (paintStationParent.ValidParentFor(item))
		{
			item.transform.position = paintStationItemAnchor.position;
			item.transform.rotation = paintStationItemAnchor.rotation;
			item.ItemRigidbody.velocity = Vector3.zero;
			item.ItemRigidbody.angularVelocity = Vector3.zero;
			component.ParentItemExternal(paintStationParent.transform, null, paintStationParent);
		}
		else
		{
			Debug.LogError("PaintStationItemInstantiator: Paint station is not a valid parent for item " + item.name + ".", item);
		}
		instantiateItemCoroutine = null;
	}

	private void OnItemGrabbed(ControlImplBase _)
	{
		item.InventorySpecs.BelongsToPlayer = true;
		SingletonBehaviour<StorageController>.Instance.AddItemToWorldStorage(item.gameObject);
		RespawnOnDrop component = item.GetComponent<RespawnOnDrop>();
		if (component != null)
		{
			component.SetMaxDistance(200f);
		}
		item.Grabbed -= OnItemGrabbed;
		Object.Destroy(this);
	}
}
