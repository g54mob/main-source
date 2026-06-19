using Mirror;

public interface IWarehouseButton
{
	WarehouseButtonState ServerGetButtonState();

	void ServerButtonPressed(NetworkConnectionToClient conn);

	void ClientButtonPressed();
}
