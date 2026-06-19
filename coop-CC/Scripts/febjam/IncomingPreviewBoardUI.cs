using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class IncomingPreviewBoardUI : EntityBehaviourBase
{
	public GameObject incomingPreviewItemPrefab;

	public Transform itemContainer;

	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<EvInboundOrdersChanged>(OnEvInboundOrdersChanged);
		ClearItems();
	}

	protected override void OnEntityDestroyed()
	{
		base.eventManager.RemoveGlobalListener<EvInboundOrdersChanged>(OnEvInboundOrdersChanged);
	}

	private void ClearItems()
	{
		foreach (Transform item in itemContainer)
		{
			Object.Destroy(item.gameObject);
		}
	}

	private void OnEvInboundOrdersChanged(EvInboundOrdersChanged ev)
	{
		ClearItems();
		List<OrderCount> list = new List<OrderCount>();
		NetworkAggroManagerBase<ShiftManager>.instance.GetInboundOrderCounts(list);
		foreach (OrderCount item in list)
		{
			ShiftOrderObject order = item.order;
			GameObject obj = Object.Instantiate(incomingPreviewItemPrefab);
			obj.transform.SetParentAndReset(itemContainer);
			OrderRequestItemUI component = obj.GetComponent<OrderRequestItemUI>();
			component.amountText.text = item.count.ToString();
			NetworkAggroManagerBase<WarehouseManager>.instance.TryGetOrderObject(order.prefab, out var order2);
			component.icon.sprite = order2.UIImage;
		}
	}
}
