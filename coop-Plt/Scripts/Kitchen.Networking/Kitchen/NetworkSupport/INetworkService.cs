using System.Threading.Tasks;
using Platforms;

namespace Kitchen.NetworkSupport
{
	public interface INetworkService
	{
		PlatformState State { get; }

		bool ShouldConnect { get; set; }

		string Name { get; }

		bool IsCrossplay { get; }

		bool CanAcceptJoinCode { get; }

		Task<Result<INetworkTarget>> GetTargetFromJoinCode(JoinCode invite);

		bool CanHandleTarget(INetworkTarget target);

		INetworkTransport GetNewTransport(JoinCode join_code);

		Task<Result<INetworkTarget>> CanHandleInvite(NetworkInviteData data);
	}
}
