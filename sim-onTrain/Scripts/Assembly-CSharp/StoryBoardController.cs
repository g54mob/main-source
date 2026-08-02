using System.Collections.Generic;
using UnityEngine;

public class StoryBoardController : MonoBehaviour, IInteractable
{
	private bool isActive = true;

	private bool isInteracting;

	private TSPlayerController player;

	private bool isPaperActive;

	private GameObject paper;

	private bool canPlace;

	private List<Material> originalMats = new List<Material>();

	[SerializeField]
	private Transform interactionParent;

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
		}
	}

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (!isInteracting)
		{
			InventoryItem inventoryItem = playerInventory.GetComponent<EastUpPlayerItemManager>().lastSelectedSlot.InventoryItem;
			if (inventoryItem != null && inventoryItem.collectableItemData != null)
			{
				CollectableItemData collectableItemData = inventoryItem.collectableItemData;
				if (collectableItemData.itemType == ItemType.StoryPaper)
				{
					isPaperActive = true;
					paper = Object.Instantiate(collectableItemData.itemPrefab, base.transform);
					paper.transform.position = hitPoint;
					paper.transform.localRotation = Quaternion.identity;
					StoreOriginalMaterials();
					player = playerInventory.GetComponent<TSPlayerController>();
					isInteracting = true;
				}
			}
		}
		else
		{
			if (!isPaperActive || !(paper != null))
			{
				return;
			}
			paper.transform.position = hitPoint;
			paper.transform.localRotation = Quaternion.identity;
			CheckPlaceArea();
			ChangeMaterialAccordingToPlaceable(canPlace);
			if (Input.GetMouseButtonDown(0) && canPlace)
			{
				int inventoryID = playerInventory.GetComponent<EastUpPlayerItemManager>().lastSelectedSlot.inventoryID;
				if (playerInventory.RemoveItemOnSlot(inventoryID, 1))
				{
					ReturnOriginalMaterials();
					isPaperActive = false;
					isInteracting = false;
					player.GetComponent<Interactor>().lastInteractable = null;
				}
			}
		}
	}

	private void StoreOriginalMaterials()
	{
		originalMats.Clear();
		if (!(paper != null))
		{
			return;
		}
		Renderer[] componentsInChildren = paper.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Material[] materials = componentsInChildren[i].materials;
			foreach (Material item in materials)
			{
				originalMats.Add(item);
			}
		}
	}

	private bool CheckPlaceArea()
	{
		if (paper == null)
		{
			canPlace = false;
			return false;
		}
		Collider component = paper.GetComponent<Collider>();
		if (component == null)
		{
			canPlace = false;
			return false;
		}
		Collider[] array = Physics.OverlapBox(component.bounds.center, component.bounds.size / 2f);
		foreach (Collider collider in array)
		{
			if (collider.gameObject != paper && collider.GetComponent<StoryPaper>() != null)
			{
				canPlace = false;
				return false;
			}
		}
		canPlace = true;
		return true;
	}

	private void ChangeMaterialAccordingToPlaceable(bool placeable)
	{
		if (paper == null)
		{
			return;
		}
		Renderer[] componentsInChildren = paper.GetComponentsInChildren<Renderer>();
		Material material = ((!placeable) ? Singleton<MaterialManager>.Instance.objectUnReplaceableMaterial : Singleton<MaterialManager>.Instance.objectReplaceableMaterial);
		Renderer[] array = componentsInChildren;
		foreach (Renderer renderer in array)
		{
			Material[] array2 = new Material[renderer.materials.Length];
			for (int j = 0; j < renderer.materials.Length; j++)
			{
				array2[j] = material;
			}
			renderer.materials = array2;
		}
	}

	private void ReturnOriginalMaterials()
	{
		if (paper == null || originalMats.Count == 0)
		{
			return;
		}
		Renderer[] componentsInChildren = paper.GetComponentsInChildren<Renderer>();
		int num = 0;
		Renderer[] array = componentsInChildren;
		foreach (Renderer renderer in array)
		{
			Material[] array2 = new Material[renderer.materials.Length];
			for (int j = 0; j < renderer.materials.Length; j++)
			{
				if (num < originalMats.Count)
				{
					array2[j] = originalMats[num];
					num++;
				}
			}
			renderer.materials = array2;
		}
	}

	public void StopInteract()
	{
		isInteracting = false;
		if (paper != null && isPaperActive)
		{
			Object.Destroy(paper);
			isPaperActive = false;
		}
		if (player != null)
		{
			player.GetComponent<Interactor>().lastInteractable = null;
		}
		originalMats.Clear();
	}
}
