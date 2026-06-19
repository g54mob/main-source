using System;
using System.Threading.Tasks;

public interface INetworkStateProvider
{
	bool HasNetworkConnection { get; }

	void HasNetworkConnectionWithCallback(Action<bool> callback);

	Task<bool> HasNetworkConnectionAsync();
}
