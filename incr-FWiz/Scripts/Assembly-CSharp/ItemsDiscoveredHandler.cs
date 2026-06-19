using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class ItemsDiscoveredHandler : MonoBehaviour
{
	public List<ItemType> ItemsDiscovered;

	private HashSet<ItemType> ItemsDiscoveredSet;

	private Dictionary<ItemType, Action> _callOnItemDiscoveredDict;

	public List<ItemType> BaseKnownItems;

	public EventReference ItemDiscoveredSound;

	public int ItemsKnown;

	public int MaxItemsKnown;

	public static ItemsDiscoveredHandler Instance { get; private set; }

	public event Action<ItemType> AnnounceItemDiscovered
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

	public void StartListening()
	{
	}

	private void OnDestroy()
	{
	}

	public bool IsItemDiscovered(ItemType itemType, bool includeBase = false)
	{
		return false;
	}

	public void OnItemCollected(ItemType itemType)
	{
	}

	private void DiscoverItem(ItemType itemType)
	{
	}

	public void CallOnItemDiscovered(ItemType itemType, Action callback)
	{
	}

	public void CancelCallOnItemDiscovered(ItemType itemType, Action callback)
	{
	}

	public void EvaluatedCompletedness()
	{
	}
}
