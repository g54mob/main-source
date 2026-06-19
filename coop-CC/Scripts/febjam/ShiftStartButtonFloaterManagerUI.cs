using Aggro.Core;
using UnityEngine;

public class ShiftStartButtonFloaterManagerUI : EntityBehaviourBase
{
	private ObjectQuery<ButtonShift> buttonShiftQuery;

	public GameObject buttonShiftFloaterPrefab;

	protected override void OnEntityCreated()
	{
		buttonShiftQuery = GameUtil.entityManager.CreateObjectQuery<ButtonShift>();
		base.eventManager.AddGlobalListener<EvOrganizationPeriodStart>(OnOrganizationStart);
	}

	private void OnOrganizationStart(EvOrganizationPeriodStart ev)
	{
		buttonShiftQuery.Run();
		foreach (ButtonShift item in buttonShiftQuery)
		{
			Object.Instantiate(buttonShiftFloaterPrefab, base.transform).GetComponent<FloaterUI>().targetWorldPosition = item.transform.position;
		}
		base.eventManager.QueueGlobalEvent(default(FloaterManagerUI.EvFloaterAddedOrRemoved));
	}
}
