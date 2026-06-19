using Aggro.Core.Networking;
using Mirror;

public class ButtonWarehouseSprinklers : NetworkEntityBehaviourBase, IWarehouseButton
{
	public WarehouseButtonState ServerGetButtonState()
	{
		if (NetworkAggroManagerBase<SprinklerManager>.instance.state == SprinklerManager.State.Inert && (NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() == ShiftPhase.Shift || NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() == ShiftPhase.Organizational))
		{
			return WarehouseButtonState.Unpressed;
		}
		return WarehouseButtonState.Pressed;
	}

	public void ServerButtonPressed(NetworkConnectionToClient conn)
	{
		NetworkAggroManagerBase<SprinklerManager>.instance.ServerTurnOn(conn);
	}

	public void ClientButtonPressed()
	{
	}

	public override bool Weaved()
	{
		return true;
	}
}
