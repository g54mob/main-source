using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeliveryPackage : MonoBehaviour
{
	[SerializeField]
	private int sizeX = 4;

	[SerializeField]
	private int sizeY = 2;

	[SerializeField]
	[Range(0.01f, 2f)]
	private float scale = 1f;

	[SerializeField]
	[Range(0.01f, 10f)]
	private float spacingX = 0.2f;

	[SerializeField]
	[Range(0.01f, 10f)]
	private float spacingY = 0.2f;

	[SerializeField]
	private GameObject packageSocketPrefab;

	[SerializeField]
	private List<ItemSocket> sockets = new List<ItemSocket>();

	private DeliveryDepotComponent assignedDepot;

	private void OnDrawGizmos()
	{
		for (int i = 0; i < sizeX; i++)
		{
			for (int j = 0; j < sizeY; j++)
			{
				float num = (float)sizeX * spacingX * scale;
				float num2 = (float)sizeY * spacingY * scale;
				Vector3 vector = new Vector3((float)i + spacingX / 2f, 0f, (float)j + spacingY / 2f) * scale;
				Vector3 vector2 = new Vector3(num / 2f, 0f, num2 / 2f);
				Gizmos.DrawSphere(base.transform.position + (vector - vector2), 0.1f);
			}
		}
	}

	public int GetPackageCapacity()
	{
		return sockets.Count;
	}

	[ContextMenu("GenerateSockets")]
	public void GenerateSockets()
	{
		for (int i = 0; i < sizeX; i++)
		{
			for (int j = 0; j < sizeY; j++)
			{
				float num = (float)sizeX * spacingX * scale;
				float num2 = (float)sizeY * spacingY * scale;
				Vector3 vector = new Vector3((float)i + spacingX / 2f, 0f, (float)j + spacingY / 2f) * scale;
				Vector3 vector2 = new Vector3(num / 2f, 0f, num2 / 2f);
				Vector3 position = base.transform.position + (vector - vector2);
				GameObject gameObject = Object.Instantiate(packageSocketPrefab, base.transform);
				gameObject.transform.position = position;
				sockets.Add(gameObject.GetComponent<ItemSocket>());
			}
		}
	}

	public bool IsFull()
	{
		bool result = true;
		for (int i = 0; i < sockets.Count; i++)
		{
			if (!sockets[i].IsHoldingItem())
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public bool IsEmpty()
	{
		return !sockets.Any((ItemSocket x) => x.IsHoldingItem());
	}

	public ItemSocket GetEmptySocket()
	{
		return sockets.First((ItemSocket x) => !x.IsHoldingItem());
	}

	public ItemSocket GetNextOccupiedSocket()
	{
		return sockets.FirstOrDefault((ItemSocket x) => x.IsHoldingItem());
	}

	public List<ItemSocket> GetSockets()
	{
		return sockets;
	}

	public void AssignDepot(DeliveryDepotComponent depot)
	{
		assignedDepot = depot;
	}

	public void TakeFromDepot()
	{
		if (!(assignedDepot == null))
		{
			assignedDepot.TakePackage(this);
			assignedDepot = null;
		}
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		if (!GetComponent<InteractableComponent>().InRange(character.transform.position))
		{
			return;
		}
		if (character.socket.IsHoldingItem() && !IsFull())
		{
			GetEmptySocket().PushItemWithScale(character.socket.GetItemComponent(), character.socket.GetItemComponent().minScale, character.socket.GetItemComponent().alternativeSocketRotation);
			character.socket.Clear();
		}
		else if (!character.socket.IsHoldingItem())
		{
			ItemSocket nextOccupiedSocket = GetNextOccupiedSocket();
			if (!(nextOccupiedSocket == null))
			{
				character.socket.PushItemWithScale(nextOccupiedSocket.GetItemComponent(), nextOccupiedSocket.GetItemComponent().minScale);
			}
		}
	}

	public bool SpawnItemInsidePackage(int itemId, int amount)
	{
		if (IsFull())
		{
			return false;
		}
		ItemSocket emptySocket = GetEmptySocket();
		if (emptySocket == null)
		{
			return false;
		}
		ItemComponent component = Object.Instantiate(InventorySystem.GetItemLibrary().itemInfos[itemId].prefab, base.transform).GetComponent<ItemComponent>();
		component.transform.position = base.transform.position;
		emptySocket.PushItemWithScale(component, component.minScale, component.alternativeSocketRotation);
		return true;
	}

	public void LoadItemsIntoSockets()
	{
		ItemComponent[] componentsInChildren = base.transform.GetComponentsInChildren<ItemComponent>();
		foreach (ItemComponent itemComponent in componentsInChildren)
		{
			if (itemComponent.socket == null && itemComponent != GetComponent<ItemComponent>())
			{
				GetEmptySocket().PushItemWithScale(itemComponent, itemComponent.minScale, itemComponent.alternativeSocketRotation);
			}
		}
	}
}
