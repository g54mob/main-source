using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit.Relay;
using PartyCSharpSDK;
using PlayFab.Party;

public class PlayFabRelay : IRelay
{
	private PlayFabMultiplayerManager _playFabMultiplayerManager;

	private Dictionary<PlayFabPlayer, PlayFabRelayConnection> _connectionMap;

	private PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS _connectivityOptions;

	private Logger _logger;

	private string _caughtError;

	private bool _errorOccurred;

	public CoherenceRelayManager RelayManager { get; set; }

	public event Action<ConnectionException> OnError
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public PlayFabRelay(PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS connectivityOptions)
	{
	}

	public void Open()
	{
	}

	private void GameCoreOnResuming()
	{
	}

	private void OnDataMessageNoCopyReceived(object sender, PlayFabPlayer from, IntPtr buffer, uint buffersize)
	{
	}

	private void OnRemotePlayerLeft(object sender, PlayFabPlayer player)
	{
	}

	public void Close()
	{
	}

	public void Update()
	{
	}

	public void Flush()
	{
	}

	private void OnNetworkError(object sender, PlayFabMultiplayerManagerErrorArgs args)
	{
	}

	private void ProcessError(string error)
	{
	}
}
