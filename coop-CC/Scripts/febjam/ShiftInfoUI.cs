using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class ShiftInfoUI : EntityBehaviourBase, IShiftChanged
{
	public GameObject shiftInfoTruckUIPrefab;

	private List<ShiftInfoTruckUI> truckUIs = new List<ShiftInfoTruckUI>();

	private int numberOfOrdersTotal = 5;

	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<EvCorrectOrderSent>(OnCorrectOrderSent);
	}

	protected override void OnEntityDestroyed()
	{
		base.eventManager.RemoveGlobalListener<EvCorrectOrderSent>(OnCorrectOrderSent);
	}

	protected override void OnUpdatePresentation()
	{
		if (GameUtil.isLobby && truckUIs.Count > 0)
		{
			DestroyTruckUIs();
		}
		for (int i = 0; i < truckUIs.Count; i++)
		{
			truckUIs[i].checkMark.SetActive(i < NetworkAggroManagerBase<ShiftManager>.instance.GetTrucksCompleted());
			truckUIs[i].xMark.SetActive(value: false);
		}
	}

	public void SetUpShiftInfo()
	{
		numberOfOrdersTotal = NetworkAggroManagerBase<ShiftManager>.instance.GetOutboundsTotalThisShift();
		DestroyTruckUIs();
		for (int i = 0; i < numberOfOrdersTotal; i++)
		{
			Entity entity = Object.Instantiate(shiftInfoTruckUIPrefab, base.transform).GetEntity();
			truckUIs.Add(entity.GetObject<ShiftInfoTruckUI>());
		}
	}

	public void DestroyTruckUIs()
	{
		foreach (Transform item in base.transform)
		{
			Object.Destroy(item.gameObject);
		}
		truckUIs.Clear();
	}

	public void OnShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		if (phase == ShiftPhase.Organizational)
		{
			SetUpShiftInfo();
		}
		if (phase == ShiftPhase.BreakRoom || phase == ShiftPhase.Failed || phase == ShiftPhase.None)
		{
			DestroyTruckUIs();
		}
	}

	public void OnCorrectOrderSent(EvCorrectOrderSent ev)
	{
		if (!GameUtil.isTutorial)
		{
			StartCoroutine(truckUIs[ev.numberOfTrucksCompleted - 1].BlorbleCo());
		}
	}
}
