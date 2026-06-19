using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SteamSessionWrapper : IDisposable
{
	private IPlatformSessionManager _platformSessionManager;

	private int _maxPlayerCount;

	private CancellationTokenSource _connectSessionCancellation;

	private const float UPDATE_WAIT_SECONDS = 10f;

	private float _waitTime;

	private bool _inSession;

	public PlatformSession CurrentPlatformSession => _platformSessionManager?.CurrentPlatformSession;

	public void StartSessionInivitationFlow()
	{
	}

	public SteamSessionWrapper()
	{
		_platformSessionManager = new DummySessionManager();
	}

	private void UpdateSessionInfo()
	{
		UpdateSessionInfo(_maxPlayerCount);
	}

	public void UpdateSessionInfo(int maxPlayerCount)
	{
		_maxPlayerCount = maxPlayerCount;
		List<string> remotePlayerIds = (from x in Manager.main.allPlayers
			where x != null && x.platform == Platform.Microsoft && x.platformID.GetPlatformOnlineId() != Manager.platform.platformUserImpl.GetPlatformUserID().GetPlatformOnlineId()
			select x.platformID.GetPlatformOnlineId().ToString()).ToList();
		_platformSessionManager?.UpdateSessionInfo(CreatePlatformSessionParams(), remotePlayerIds);
	}

	public void Update()
	{
		_platformSessionManager.Update();
	}

	public void JoinSession(string connectId)
	{
		_connectSessionCancellation?.Dispose();
		_connectSessionCancellation = new CancellationTokenSource();
		WrapTaskExecution(async delegate
		{
			while (_maxPlayerCount == 0 && !(_connectSessionCancellation?.IsCancellationRequested ?? true))
			{
				Task.Delay(100);
			}
			if (!(_connectSessionCancellation?.IsCancellationRequested ?? true))
			{
				if (string.IsNullOrEmpty((await _platformSessionManager.JoinSessionAsync(connectId, _connectSessionCancellation.Token)).Item2))
				{
					UpdateSessionInfo();
					_inSession = true;
				}
				else
				{
					CreateSession();
				}
			}
		});
	}

	public void CreateSession()
	{
		_connectSessionCancellation?.Dispose();
		_connectSessionCancellation = new CancellationTokenSource();
		WrapTaskExecution(async delegate
		{
			if (string.IsNullOrEmpty((await _platformSessionManager.StartSessionAsync(CreatePlatformSessionParams(), _connectSessionCancellation.Token)).Item2))
			{
				_inSession = true;
			}
		});
	}

	public void StopSession()
	{
		WrapTaskExecution(async delegate
		{
			_connectSessionCancellation?.Cancel();
			_maxPlayerCount = 0;
			_inSession = false;
			if (_platformSessionManager != null)
			{
				await _platformSessionManager.EndSessionAsync();
			}
		});
	}

	private PlatformSessionParams CreatePlatformSessionParams()
	{
		if (Manager.networking.OfflineSession)
		{
			Debug.LogWarning("SteamSessionWrapper.CreatePlatformSessionParams: no need to create platform session parameters for an offline game.");
			return null;
		}
		if (string.IsNullOrEmpty(Manager.networking.CurrentSessionID))
		{
			Debug.Log("SteamSessionWrapper.CreatePlatformSessionParams: Not connected to any lobby.");
			return null;
		}
		WorldInfo worldInfo = Manager.saves.GetWorldInfo();
		if (worldInfo == null)
		{
			Debug.LogWarning("SteamSessionWrapper.CreatePlatformSessionParams: world info is null still.");
		}
		return new PlatformSessionParams
		{
			SessionId = Manager.networking.CurrentSession.IPPort,
			JoinString = Manager.networking.CurrentSessionID,
			WorldName = (worldInfo?.name ?? ""),
			MaxPlayers = (uint)_maxPlayerCount,
			IconIndex = (worldInfo?.iconIndex ?? 0),
			WorldMode = (worldInfo?.mode ?? WorldMode.Normal),
			IsHosting = false
		};
	}

	public void Dispose()
	{
		StopSession();
		_platformSessionManager = null;
		_connectSessionCancellation?.Dispose();
		_connectSessionCancellation = null;
	}

	private Task WrapTaskExecution(Func<Task> asyncTask, Action finallyCallback = null)
	{
		return Task.Run(async delegate
		{
			try
			{
				await asyncTask();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				finallyCallback?.Invoke();
			}
		});
	}
}
