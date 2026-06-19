using System;

public class DummyStreamIntegrationManager : IStreamIntegrationManager
{
	public void ConnectToRoom(string code, bool save, Action<bool> onConnect)
	{
	}

	public void Disconnect()
	{
	}

	public bool TriedToConnectAtStartup(out bool result)
	{
		result = false;
		return false;
	}

	public bool IsConnecting()
	{
		return false;
	}

	public bool IsConnected()
	{
		return false;
	}

	public void CancelConnect()
	{
	}

	public bool IsRoomConnected()
	{
		return false;
	}

	public bool Init()
	{
		return true;
	}

	public void Update()
	{
	}
}
