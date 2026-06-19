using Aggro.Core;
using UnityEngine;

public class IncomingNotifFloaterManagerUI : EntityBehaviourBase
{
	public GameObject incomingNotifFloaterPrefab;

	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<EvInboundArrived>(OnInboundArrived);
	}

	protected override void OnEntityDestroyed()
	{
		base.eventManager.RemoveGlobalListener<EvInboundArrived>(OnInboundArrived);
	}

	private void OnInboundArrived(EvInboundArrived ev)
	{
		Object.Instantiate(incomingNotifFloaterPrefab, base.transform).GetComponent<FloaterUI>().targetWorldPosition = ev.worldPosition;
		base.eventManager.QueueGlobalEvent(default(FloaterManagerUI.EvFloaterAddedOrRemoved));
	}
}
