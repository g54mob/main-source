using System;

public class NullReachability : IReachability
{
	public InternetConnectivity Connectivity => InternetConnectivity.Unknown;

	public bool CanConnectManually => false;

	public event Action<InternetConnectivity> ConnectivityChanged
	{
		add
		{
		}
		remove
		{
		}
	}

	public void OpenSilentConnection(IReachability.ConnectionOpened connectionOpened)
	{
		connectionOpened(new InternetConnectionHandle(this));
	}

	public void OpenManualConnection(IReachability.ConnectionOpened connectionOpened)
	{
		OpenSilentConnection(connectionOpened);
	}

	public void CloseConnection(InternetConnectionHandle handle)
	{
	}
}
