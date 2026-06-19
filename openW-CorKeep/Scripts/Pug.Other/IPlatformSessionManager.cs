using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IPlatformSessionManager
{
	PlatformSession CurrentPlatformSession { get; }

	Task<(PlatformSession Session, string error)> StartSessionAsync(PlatformSessionParams sessionParams, CancellationToken cancellationToken);

	Task<(PlatformSession session, string error)> JoinSessionAsync(string joinString, CancellationToken cancellationToken);

	void UpdateSessionInfo(PlatformSessionParams sessionParams, List<string> remotePlayerIds);

	Task<(PlatformSession session, string error)> EndSessionAsync();

	void Update();

	void StartFriendInvitation();
}
