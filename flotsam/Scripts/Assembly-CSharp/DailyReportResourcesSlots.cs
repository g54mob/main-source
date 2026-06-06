using System.Collections.Generic;
using UnityEngine;

public class DailyReportResourcesSlots : MonoBehaviour
{
	[SerializeField]
	private ChildBehaviourCache<InventoryPanelItemSlot> _prefab;

	public void UpdateItems(Dictionary<ItemProperties, int> items)
	{
		_prefab.Reset();
		foreach (KeyValuePair<ItemProperties, int> item in items)
		{
			_prefab.Get(active: true).Initialize(item.Key, item.Value);
		}
		_prefab.Trim();
	}
}
