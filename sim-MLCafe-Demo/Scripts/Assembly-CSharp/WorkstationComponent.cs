using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class WorkstationComponent
{
	[SerializeField]
	private string tag;

	[SerializeField]
	private bool isReady;

	[Header("Item")]
	[SerializeField]
	public bool useItemId;

	[SerializeField]
	private Item item;

	[SerializeField]
	public bool useItemType;

	[SerializeField]
	private ItemInfo.ItemType itemType;

	[Header("Dependency")]
	[SerializeField]
	private bool useWorkstationComponentDependency;

	[SerializeField]
	private string[] dependentComponents;

	[SerializeField]
	private bool useInteractionItemDependency;

	[SerializeField]
	private Item interactionItem;

	[Header("Socket")]
	[SerializeField]
	private ItemSocket socket;

	public UnityEvent<ItemComponent, string> OnProcessItemComponent = new UnityEvent<ItemComponent, string>();

	public UnityEvent OnReady = new UnityEvent();

	public string GetTag()
	{
		return tag;
	}

	public Item GetRequiredItem()
	{
		return item;
	}

	public ItemInfo.ItemType GetRequiredItemType()
	{
		return itemType;
	}

	public ItemSocket GetSocket()
	{
		return socket;
	}

	public bool IsRequiredItem(ItemComponent itemComponent)
	{
		bool result = true;
		if (useItemId && item.id != itemComponent.item.id)
		{
			result = false;
		}
		if (useItemType && itemComponent.GetInfo().itemType != itemType)
		{
			result = false;
		}
		if (useInteractionItemDependency && itemComponent.item.id != interactionItem.id)
		{
			return false;
		}
		return result;
	}

	public bool DependenciesReady(WorkstationComponent[] dependencies)
	{
		if (!useWorkstationComponentDependency)
		{
			return true;
		}
		bool result = true;
		string[] array = dependentComponents;
		foreach (string text in array)
		{
			for (int j = 0; j < dependencies.Length; j++)
			{
				if (!(dependencies[j].GetTag() != text))
				{
					if (dependencies[j].IsReady())
					{
						break;
					}
					return false;
				}
			}
		}
		return result;
	}

	public bool CheckInteractionDependency(ItemComponent itemComponent)
	{
		if (!useInteractionItemDependency)
		{
			return false;
		}
		if (useInteractionItemDependency && itemComponent.item.id != interactionItem.id)
		{
			return false;
		}
		return true;
	}

	public bool IsReady()
	{
		return isReady;
	}

	public void MarkReady()
	{
		isReady = true;
		OnReady.Invoke();
	}

	public void UnmarkReady()
	{
		isReady = false;
	}

	public virtual void Reset()
	{
		UnmarkReady();
	}
}
