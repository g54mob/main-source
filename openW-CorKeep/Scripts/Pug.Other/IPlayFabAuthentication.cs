using System.Threading;
using System.Threading.Tasks;
using PlayFab.ClientModels;

public interface IPlayFabAuthentication
{
	bool IsAuthenticated { get; }

	string PlayFabTitleId { get; }

	EntityKey LocalPlayerEntityKey { get; }

	Task<AuthenticationVO> Login(CancellationToken cancellationToken);

	Task Logout();

	void Update();

	void Destroy();
}
