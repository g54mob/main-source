using Mirror;

namespace Mirage.NetworkProfiler
{
	public interface INetworkInfoProvider
	{
		uint? GetNetId(NetworkDiagnostics.MessageInfo info);

		NetworkIdentity GetNetworkIdentity(uint? netId);

		string GetRpcName(NetworkDiagnostics.MessageInfo info);
	}
}
