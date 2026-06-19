using System;

public interface IStreamIntegrationManager
{
	void ConnectToRoom(string code, bool save, Action<bool> onConnect);

	void Disconnect();

	bool TriedToConnectAtStartup(out bool result);

	bool IsConnecting();

	bool IsConnected();

	void CancelConnect();

	bool IsRoomConnected();

	bool Init();

	void Update();
}
