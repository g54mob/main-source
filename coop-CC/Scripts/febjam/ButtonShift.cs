using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;

public class ButtonShift : EntityBehaviourBase, IWarehouseButton
{
	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<EvOrganizationPeriodStart>(OnOrganizationPeriodStart);
		base.eventManager.AddGlobalListener<EvShiftStart>(OnShiftStart);
	}

	protected override void OnEntityDestroyed()
	{
		base.eventManager.RemoveGlobalListener<EvOrganizationPeriodStart>(OnOrganizationPeriodStart);
		base.eventManager.RemoveGlobalListener<EvShiftStart>(OnShiftStart);
	}

	private void OnOrganizationPeriodStart(EvOrganizationPeriodStart ev)
	{
		base.entity.GetObject<FloaterPopulator>().AddFloater();
	}

	private void OnShiftStart(EvShiftStart ev)
	{
		base.entity.GetObject<FloaterPopulator>().HideAndRemoveFloater();
	}

	public WarehouseButtonState ServerGetButtonState()
	{
		if (NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() == ShiftPhase.Organizational)
		{
			return WarehouseButtonState.Unpressed;
		}
		return WarehouseButtonState.Pressed;
	}

	public void ServerButtonPressed(NetworkConnectionToClient conn)
	{
		if (NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() == ShiftPhase.Organizational)
		{
			NetworkAggroManagerBase<ShiftManager>.instance.ServerEndOrganizationalPeriod();
		}
	}

	public void ClientButtonPressed()
	{
	}
}
