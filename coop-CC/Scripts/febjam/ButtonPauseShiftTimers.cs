using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class ButtonPauseShiftTimers : EntityBehaviourBase, IWarehouseButton
{
	[Min(0f)]
	public float pauseDuration = 10f;

	public WarehouseButtonState ServerGetButtonState()
	{
		if (NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() == ShiftPhase.Shift && !NetworkAggroManagerBase<ShiftManager>.instance.serverHasShiftPaused)
		{
			return WarehouseButtonState.Unpressed;
		}
		return WarehouseButtonState.Pressed;
	}

	public void ServerButtonPressed(NetworkConnectionToClient conn)
	{
		NetworkAggroManagerBase<ShiftManager>.instance.ServerPauseTimers(pauseDuration, setShiftPaused: true);
	}

	public void ClientButtonPressed()
	{
	}
}
