using Aggro.Core;
using Mirror;

public class ButtonOutboundBay : EntityBehaviourBase, IWarehouseButton
{
	public WarehouseButtonState ServerGetButtonState()
	{
		if (base.entity.TryGetObject<OutboundBay>(out var obj) && obj.state == OutboundBay.BayState.Outbound)
		{
			return WarehouseButtonState.Unpressed;
		}
		return WarehouseButtonState.Pressed;
	}

	public void ServerButtonPressed(NetworkConnectionToClient conn)
	{
		base.entity.GetObject<OutboundBay>().ServerRequestSendOutbound(conn, forceCompleted: false);
	}

	public void ClientButtonPressed()
	{
	}
}
