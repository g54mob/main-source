using System.Collections.Generic;
using Aggro.Core;
using UnityEngine;

public class OutboundTruckFloaterManagerUI : EntityBehaviourBase
{
	private List<TruckTimerFloaterUI> truckTimerFloaters = new List<TruckTimerFloaterUI>();

	private List<TruckOrderFloaterUI> truckOrderFloaters = new List<TruckOrderFloaterUI>();

	public GameObject truckTimerFloaterPrefab;

	public GameObject truckOrderFloaterPrefab;

	private ObjectQuery<OutboundBay> _bayQuery;

	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<EvShiftStart>(OnShiftStarted);
		_bayQuery = base.entityManager.CreateObjectQuery<OutboundBay>();
	}

	private void OnShiftStarted(EvShiftStart ev)
	{
		truckTimerFloaters.Clear();
		truckOrderFloaters.Clear();
		base.entity.GetObjects(truckTimerFloaters);
		base.entity.GetObjects(truckOrderFloaters);
		for (int i = 0; i < truckTimerFloaters.Count; i++)
		{
			Object.Destroy(truckTimerFloaters[i].gameObject);
		}
		for (int j = 0; j < truckOrderFloaters.Count; j++)
		{
			Object.Destroy(truckOrderFloaters[j].gameObject);
		}
		truckTimerFloaters.Clear();
		truckOrderFloaters.Clear();
		_bayQuery.Run();
		foreach (OutboundBay item in _bayQuery)
		{
			_ = item;
		}
		base.eventManager.QueueGlobalEvent(default(FloaterManagerUI.EvFloaterAddedOrRemoved));
	}
}
