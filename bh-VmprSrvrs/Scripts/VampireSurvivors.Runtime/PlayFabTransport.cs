using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Stats;
using Coherence.Transport;
using PlayFab.Party;

public class PlayFabTransport : ITransport
{
	private PlayFabMultiplayerManager _playFabMultiplayerManager;

	private List<PlayFabPlayer> host;

	private string hostId;

	private Logger _logger;

	private IStats _stats;

	private bool isClosing;

	private readonly Queue<byte[]> incomingPackets;

	public TransportState State { get; private set; }

	public bool IsReliable => false;

	public bool CanSend => false;

	public int HeaderSize { get; }

	public string Description => null;

	public event Action OnOpen
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

	public PlayFabTransport(Logger logger, IStats stats, string host, PlayFabMultiplayerManager manager)
	{
	}

	public void Open(EndpointData _, ConnectionSettings __)
	{
	}

	private void GameCoreOnResuming()
	{
	}

	private void OnRemotePlayerLeft(object sender, PlayFabPlayer player)
	{
	}

	private void OpenNetwork()
	{
	}

	private void OnPlayFabError(object sender, PlayFabMultiplayerManagerErrorArgs args)
	{
	}

	private void OnDataMessageNoCopyReceived(object sender, PlayFabPlayer from, IntPtr buffer, uint buffersize)
	{
	}

	public void Close()
	{
	}

	public void Send(IOutOctetStream data)
	{
	}

	public void Receive(List<(IInOctetStream, IPEndPoint)> buffer)
	{
	}

	public void PrepareDisconnect()
	{
	}
}
