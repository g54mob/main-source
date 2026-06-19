using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class ItemInputCollector<S, I> : MonoBehaviour where S : ItemInputGroup<I> where I : ItemInputStack
{
	[SerializeField]
	private List<DropCollector> _dropCollectors;

	public Transform RefundPoint;

	public ItemDispense ItemDispensePrefab;

	public ItemInputGroup<I> InputGroup { get; private set; }

	public bool Empty => false;

	public event Action AnnounceFulfilled
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Initiate(ItemInputGroup<I> inputGroup)
	{
	}

	public void AddDropCollector(DropCollector dropCollector)
	{
	}

	public void RemoveDropCollector(DropCollector dropCollector)
	{
	}

	public void OnFulfilled()
	{
	}

	public bool CanTakeItem(ItemType type)
	{
		return false;
	}

	public void TakeItem(ItemType type)
	{
	}

	public void RefundAll()
	{
	}

	public void Clear()
	{
	}
}
