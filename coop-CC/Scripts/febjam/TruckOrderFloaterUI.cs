using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class TruckOrderFloaterUI : EntityBehaviourBase
{
	public FloaterUI floaterUI;

	public OutboundBay assignedOutboundBay;

	private uint previousTruckBayVersion;

	public List<GameObject> orderRequestItemUIs = new List<GameObject>();

	public List<OutboundBay.Order> orderItems = new List<OutboundBay.Order>();

	public GameObject orderRequestItemUITemplate;

	public Transform orderRequestItemContainer;

	public GameObject[] orderBubbles;

	public Sprite wrongBoxSprite;

	protected override void OnUpdatePresentationEarly()
	{
		if (assignedOutboundBay.state == OutboundBay.BayState.Outbound)
		{
			floaterUI.SetVisibleThisFrame();
		}
		if (assignedOutboundBay.version != previousTruckBayVersion)
		{
			UpdateOrderRequestItemUI();
		}
		previousTruckBayVersion = assignedOutboundBay.version;
	}

	private void UpdateOrderRequestItemUI()
	{
		foreach (GameObject orderRequestItemUI in orderRequestItemUIs)
		{
			Object.Destroy(orderRequestItemUI);
		}
		orderRequestItemUIs.Clear();
		orderItems.Clear();
		assignedOutboundBay.GetOutboundOrder(orderItems);
		foreach (OutboundBay.Order orderItem in orderItems)
		{
			GameObject gameObject = Object.Instantiate(orderRequestItemUITemplate);
			gameObject.transform.SetParentAndReset(orderRequestItemContainer);
			orderRequestItemUIs.Add(gameObject);
			OrderRequestItemUI component = gameObject.GetComponent<OrderRequestItemUI>();
			if (assignedOutboundBay.hasWildCard)
			{
				component.amountText.text = "?/" + orderItem.total;
			}
			else
			{
				component.amountText.text = orderItem.current + "/" + orderItem.total;
			}
			if (!NetworkAggroManagerBase<WarehouseManager>.instance.TryGetOrderObject(orderItem.prefab, out var order))
			{
				Debug.LogError("Prefab missing an order shift object? " + orderItem.prefab.name, orderItem.prefab);
				return;
			}
			component.icon.sprite = order.UIImage;
		}
		int incorrectBoxCount = assignedOutboundBay.GetIncorrectBoxCount();
		if (incorrectBoxCount > 0)
		{
			GameObject gameObject2 = Object.Instantiate(orderRequestItemUITemplate);
			gameObject2.transform.SetParentAndReset(orderRequestItemContainer);
			orderRequestItemUIs.Add(gameObject2);
			OrderRequestItemUI component2 = gameObject2.GetComponent<OrderRequestItemUI>();
			component2.icon.sprite = wrongBoxSprite;
			component2.amountText.text = incorrectBoxCount + "/" + 0;
		}
		for (int i = 0; i < orderBubbles.Length; i++)
		{
			int num = orderItems.Count - 1;
			if (assignedOutboundBay.GetIncorrectBoxCount() > 0)
			{
				num++;
			}
			orderBubbles[i].SetActive(i == num);
		}
	}
}
