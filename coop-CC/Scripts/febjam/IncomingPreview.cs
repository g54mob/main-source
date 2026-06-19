using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class IncomingPreview : EntityBehaviourBase
{
	private List<OrderCount> _orderCounts = new List<OrderCount>();

	public int minCount = 12;

	public float speed = 1f;

	public float spacing = 2f;

	public float maxDistance = 15f;

	public Transform orderVisualContainer;

	private List<Transform> boxOrderVisualTransforms = new List<Transform>();

	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<EvInboundOrdersChanged>(OnInboundChanged);
	}

	protected override void OnEntityDestroyed()
	{
		base.eventManager.RemoveGlobalListener<EvInboundOrdersChanged>(OnInboundChanged);
	}

	private void OnInboundChanged(EvInboundOrdersChanged ev)
	{
		if (GameUtil.isTutorial)
		{
			return;
		}
		foreach (Transform boxOrderVisualTransform in boxOrderVisualTransforms)
		{
			Object.Destroy(boxOrderVisualTransform.gameObject);
		}
		boxOrderVisualTransforms.Clear();
		_orderCounts.Clear();
		NetworkAggroManagerBase<ShiftManager>.instance.GetInboundOrderCounts(_orderCounts);
		if (_orderCounts.Count == 0)
		{
			return;
		}
		while (boxOrderVisualTransforms.Count < minCount)
		{
			foreach (OrderCount orderCount in _orderCounts)
			{
				for (int i = 0; i < orderCount.count; i++)
				{
					GameObject gameObject = Object.Instantiate(orderCount.order.orderVisualPrefab, orderVisualContainer);
					boxOrderVisualTransforms.Add(gameObject.transform);
				}
			}
		}
		boxOrderVisualTransforms.Randomize(GameUtil.seed);
	}

	protected override void OnUpdatePresentation()
	{
		for (int i = 0; i < boxOrderVisualTransforms.Count; i++)
		{
			float value = ((float)i * spacing + speed * (float)NetworkTime.time) % (spacing * (float)boxOrderVisualTransforms.Count);
			value = Mathf.Clamp(value, 0f, maxDistance);
			Vector3 localPosition = new Vector3(0f, 0f, value);
			boxOrderVisualTransforms[i].localPosition = localPosition;
		}
	}
}
