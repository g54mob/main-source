using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using OUSystems.Basics.DataStructures;
using UnityEngine;

[SerializeField]
public class CrafterFueler : MonoBehaviour
{
	[SerializeField]
	private CrafterFuelerViewUI _crafterFuelerViewUI;

	public FloatContainer ItemPortionSpent;

	[SerializeField]
	private int _capacity;

	[SerializeField]
	private List<DropCollector> _dropCollectors;

	public BoolContainer HasFuel;

	public TotemListener FuelTotemListener;

	public List<ItemType> SpecialItems;

	public bool BurningSpecialItem;

	[field: SerializeField]
	public List<ItemType> FuelItems { get; private set; }

	public ItemType CurrentFuelItem => null;

	public bool Empty => false;

	public event Action<ItemType> AnnounceSpendItem
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

	public event Action<ItemType> AnnounceAddItem
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

	public void Initiate()
	{
	}

	public void Clear()
	{
	}

	public bool CanAddItem(ItemType item)
	{
		return false;
	}

	public void AddCapacity(int capacity)
	{
	}

	public void AddItem(ItemType item)
	{
	}

	public bool SpendFuel(float timeDelta, float fuelEfficiency = 1f)
	{
		return false;
	}

	public void EvaluateSpecialitem()
	{
	}
}
