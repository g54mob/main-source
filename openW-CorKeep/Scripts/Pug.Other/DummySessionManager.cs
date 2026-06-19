using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class DummySessionManager : IPlatformSessionManager
{
	public PlatformSession CurrentPlatformSession { get; private set; }

	public Task<(PlatformSession Session, string error)> StartSessionAsync(PlatformSessionParams sessionParams, CancellationToken cancellationToken)
	{
		CurrentPlatformSession = new PlatformSession
		{
			SessionId = sessionParams.SessionId,
			JoinString = sessionParams.SessionId
		};
		return Task.FromResult<(PlatformSession, string)>((CurrentPlatformSession, null));
	}

	public Task<(PlatformSession session, string error)> JoinSessionAsync(string sessionId, CancellationToken cancellationToken)
	{
		CurrentPlatformSession = new PlatformSession
		{
			SessionId = sessionId,
			JoinString = sessionId
		};
		return Task.FromResult<(PlatformSession, string)>((CurrentPlatformSession, null));
	}

	public void UpdateSessionInfo(PlatformSessionParams sessionParams, List<string> remotePlayerIds)
	{
		if (CurrentPlatformSession != null)
		{
			CurrentPlatformSession.SessionId = sessionParams.SessionId;
			CurrentPlatformSession.JoinString = sessionParams.JoinString;
		}
	}

	public Task<(PlatformSession session, string error)> EndSessionAsync()
	{
		PlatformSession currentPlatformSession = CurrentPlatformSession;
		CurrentPlatformSession = null;
		return Task.FromResult<(PlatformSession, string)>((currentPlatformSession, null));
	}

	public void Update()
	{
	}

	public void StartFriendInvitation()
	{
	}
}
