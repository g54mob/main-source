using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class ButtonLockIn : EntityBehaviourBase, IWarehouseButton
{
	[Min(0f)]
	public float lockInDuration = 10f;

	public WarehouseButtonState ServerGetButtonState()
	{
		ShiftPhase shiftPhase = NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase();
		if (!NetworkAggroManagerBase<ShiftManager>.instance.serverHasShiftPaused && (shiftPhase == ShiftPhase.BreakRoom || shiftPhase == ShiftPhase.Organizational || shiftPhase == ShiftPhase.Shift))
		{
			return WarehouseButtonState.Unpressed;
		}
		return WarehouseButtonState.Pressed;
	}

	public void ServerButtonPressed(NetworkConnectionToClient conn)
	{
		NetworkAggroManagerBase<ShiftManager>.instance.ServerLockIn(lockInDuration);
	}

	public void ClientButtonPressed()
	{
	}
}
