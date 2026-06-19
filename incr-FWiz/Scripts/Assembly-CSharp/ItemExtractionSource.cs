using System.Collections.Generic;
using UnityEngine;

public class ItemExtractionSource : MonoBehaviour
{
	public static List<ItemExtractionSource> AllSources;

	public PickupSupplier PickupSupplier;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public ItemType PeekItem()
	{
		return null;
	}

	public ItemType PopItem()
	{
		return null;
	}
}
