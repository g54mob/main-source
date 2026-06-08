using System.Collections.Generic;
using UnityEngine;

public class TowManager : MonoBehaviour
{
	public static TowManager Instance;

	public List<ITowItem> knownTowableItems;

	private void Awake()
	{
		Instance = this;
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public void RegisterTowableItem(ITowItem item)
	{
		if (knownTowableItems == null)
		{
			knownTowableItems = new List<ITowItem>();
		}
		knownTowableItems.Add(item);
	}
}
