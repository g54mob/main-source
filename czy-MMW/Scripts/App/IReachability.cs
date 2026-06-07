using System;
using JetBrains.Annotations;

public interface IReachability
{
	public delegate void ConnectionOpened(InternetConnectionHandle handle);

	InternetConnectivity Connectivity { get; }

	bool CanConnectManually { get; }

	event Action<InternetConnectivity> ConnectivityChanged;

	void OpenSilentConnection([NotNull] ConnectionOpened connectionOpened);

	void OpenManualConnection([NotNull] ConnectionOpened connectionOpened);

	void CloseConnection([NotNull] InternetConnectionHandle handle);
}
