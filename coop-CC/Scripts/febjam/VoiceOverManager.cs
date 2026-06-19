using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class VoiceOverManager : NetworkAggroManagerBase<VoiceOverManager>
{
	private Deck<byte> _lobbyPlayerJoinedDeck;

	private Deck<byte> _breakRoomInitialDeck;

	private Deck<byte> _breakRoomDeck;

	private Deck<byte> _crashOutDeck;

	[Space]
	private Deck<byte> _shiftStartDeck;

	private Deck<byte> _organizationStartInitialDeck;

	private Deck<byte> _organizationStartDeck;

	private Deck<byte> _shiftWonDeck;

	private Deck<byte> _shiftLostDeck;

	private Deck<byte> _gameWonDeck;

	private Deck<byte> _incorrectOrderDeck;

	[Space]
	private Deck<byte> _timerWarningPhase1ADeck;

	private Deck<byte> _timerWarningPhase3ADeck;

	private Deck<byte> _timerWarningPhase4ADeck;

	private Deck<byte> _timerWarningPhase1BDeck;

	private Deck<byte> _timerWarningPhase3BDeck;

	private Deck<byte> _timerWarningPhase4BDeck;

	protected override void OnEntityCreated()
	{
		if (base.isServer)
		{
			Unity.Mathematics.Random random = MathUtil.GetRandom(GameUtil.seed, Hash.Calculate(GetType()));
			_lobbyPlayerJoinedDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.lobbyPlayerJoined, random.NextInt());
			_breakRoomInitialDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.breakRoomInitial, random.NextInt());
			_breakRoomDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.breakRoom, random.NextInt());
			_crashOutDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.crashOut, random.NextInt());
			_shiftStartDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.shiftStart, random.NextInt());
			_organizationStartInitialDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.organizationStart, random.NextInt());
			_organizationStartDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.organizationStart, random.NextInt());
			_shiftWonDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.shiftWon, random.NextInt());
			_shiftLostDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.shiftLost, random.NextInt());
			_gameWonDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.gameWon, random.NextInt());
			_incorrectOrderDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.incorrectOrder, random.NextInt());
			_timerWarningPhase1ADeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase1A, random.NextInt());
			_timerWarningPhase3ADeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase3A, random.NextInt());
			_timerWarningPhase4ADeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase4A, random.NextInt());
			_timerWarningPhase1BDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase1B, random.NextInt());
			_timerWarningPhase3BDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase3B, random.NextInt());
			_timerWarningPhase4BDeck = ServerBuildDeck(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase4B, random.NextInt());
		}
	}

	[Server]
	public void ServerPlayLobbyPlayerJoined()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerPlayLobbyPlayerJoined()' called when server was not active");
		}
		else
		{
			RpcPlayLobbyPlayerJoined(_lobbyPlayerJoinedDeck.DrawCard());
		}
	}

	[Server]
	public void ServerPlayInitialBreakRoom()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerPlayInitialBreakRoom()' called when server was not active");
		}
		else
		{
			RpcPlayBreakRoomInitial(_breakRoomInitialDeck.DrawCard());
		}
	}

	[Server]
	public void ServerPlayBreakRoom()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerPlayBreakRoom()' called when server was not active");
		}
		else
		{
			RpcPlayBreakRoom(_breakRoomDeck.DrawCard());
		}
	}

	public void RequestPlayCrashOut()
	{
		if (base.isServer)
		{
			ServerPlayCrashOut();
		}
		else
		{
			CmdPlayCrashOut();
		}
	}

	[Server]
	public void ServerPlayCrashOut()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerPlayCrashOut()' called when server was not active");
		}
		else if (!AudioManager.IsPlayingVO())
		{
			RpcPlayCrashOut(_crashOutDeck.DrawCard());
		}
	}

	[Server]
	public void ServerShiftStart()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerShiftStart()' called when server was not active");
		}
		else
		{
			RpcShiftStart(_shiftStartDeck.DrawCard());
		}
	}

	[Server]
	public void ServerOrganizationStartInitial()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerOrganizationStartInitial()' called when server was not active");
		}
		else
		{
			RpcOrganizationStartInitial(_organizationStartInitialDeck.DrawCard());
		}
	}

	[Server]
	public void ServerOrganizationStart()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerOrganizationStart()' called when server was not active");
		}
		else
		{
			RpcOrganizationStart(_organizationStartDeck.DrawCard());
		}
	}

	[Server]
	public void ServerShiftWon()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerShiftWon()' called when server was not active");
		}
		else
		{
			RpcShiftWon(_shiftWonDeck.DrawCard());
		}
	}

	[Server]
	public void ServerShiftLost()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerShiftLost()' called when server was not active");
		}
		else
		{
			RpcShiftLost(_shiftLostDeck.DrawCard());
		}
	}

	[Server]
	public void ServerGameWon()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerGameWon()' called when server was not active");
		}
		else
		{
			RpcGameWon(_gameWonDeck.DrawCard());
		}
	}

	[Server]
	public void ServerIncorrectOrder()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerIncorrectOrder()' called when server was not active");
		}
		else
		{
			RpcIncorrectOrder(_incorrectOrderDeck.DrawCard());
		}
	}

	[Server]
	public void ServerTimerWarningPhase(int phase, bool isA)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VoiceOverManager::ServerTimerWarningPhase(System.Int32,System.Boolean)' called when server was not active");
			return;
		}
		byte index;
		switch (phase)
		{
		case 0:
			index = ((!isA) ? _timerWarningPhase1BDeck.DrawCard() : _timerWarningPhase1ADeck.DrawCard());
			break;
		case 1:
			return;
		case 2:
			index = ((!isA) ? _timerWarningPhase3BDeck.DrawCard() : _timerWarningPhase3ADeck.DrawCard());
			break;
		case 3:
			index = ((!isA) ? _timerWarningPhase4BDeck.DrawCard() : _timerWarningPhase4ADeck.DrawCard());
			break;
		default:
			Debug.LogWarning($"Unknown warning phase! ({phase})");
			return;
		}
		RpcTimerWarningPhase((byte)phase, isA, index);
	}

	[Command(requiresAuthority = false)]
	private void CmdPlayCrashOut()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void VoiceOverManager::CmdPlayCrashOut()", 2038725629, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayLobbyPlayerJoined(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcPlayLobbyPlayerJoined(System.Byte)", -1182465402, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayBreakRoomInitial(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcPlayBreakRoomInitial(System.Byte)", -1637409534, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayBreakRoom(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcPlayBreakRoom(System.Byte)", -1744451002, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayCrashOut(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcPlayCrashOut(System.Byte)", -1449663891, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcShiftStart(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcShiftStart(System.Byte)", -2085948104, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOrganizationStartInitial(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcOrganizationStartInitial(System.Byte)", -1812037063, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOrganizationStart(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcOrganizationStart(System.Byte)", 739780047, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcShiftWon(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcShiftWon(System.Byte)", -1730796504, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcShiftLost(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcShiftLost(System.Byte)", -1808040310, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcGameWon(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcGameWon(System.Byte)", 191404642, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcIncorrectOrder(byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcIncorrectOrder(System.Byte)", 1450002931, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcTimerWarningPhase(byte phase, bool isA, byte index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, phase);
		writer.WriteBool(isA);
		NetworkWriterExtensions.WriteByte(writer, index);
		SendRPCInternal("System.Void VoiceOverManager::RpcTimerWarningPhase(System.Byte,System.Boolean,System.Byte)", 2144083204, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private Deck<byte> ServerBuildDeck(DeckCard<EventReference>[] cards, int seed)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'Aggro.Core.Deck`1<System.Byte> VoiceOverManager::ServerBuildDeck(Aggro.Core.DeckCard`1<FMODUnity.EventReference>[],System.Int32)' called when server was not active");
			return null;
		}
		Deck<byte> deck = new Deck<byte>(seed);
		for (int i = 0; i < cards.Length; i++)
		{
			DeckCard<EventReference> deckCard = cards[i];
			deck.AddCard((byte)i, deckCard.cardCount);
		}
		deck.Shuffle();
		return deck;
	}

	private void TryPlay(DeckCard<EventReference>[] cards, int index)
	{
		if (index >= cards.Length)
		{
			Debug.LogWarning("Unable to play VO, index higher than array entries!");
		}
		else
		{
			AudioManager.PlayVO(cards[index].item);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdPlayCrashOut()
	{
		ServerPlayCrashOut();
	}

	protected static void InvokeUserCode_CmdPlayCrashOut(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlayCrashOut called on client.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_CmdPlayCrashOut();
		}
	}

	protected void UserCode_RpcPlayLobbyPlayerJoined__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.lobbyPlayerJoined, index);
	}

	protected static void InvokeUserCode_RpcPlayLobbyPlayerJoined__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayLobbyPlayerJoined called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcPlayLobbyPlayerJoined__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcPlayBreakRoomInitial__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.breakRoomInitial, index);
	}

	protected static void InvokeUserCode_RpcPlayBreakRoomInitial__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayBreakRoomInitial called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcPlayBreakRoomInitial__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcPlayBreakRoom__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.breakRoom, index);
	}

	protected static void InvokeUserCode_RpcPlayBreakRoom__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayBreakRoom called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcPlayBreakRoom__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcPlayCrashOut__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.crashOut, index);
	}

	protected static void InvokeUserCode_RpcPlayCrashOut__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayCrashOut called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcPlayCrashOut__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcShiftStart__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.shiftStart, index);
	}

	protected static void InvokeUserCode_RpcShiftStart__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShiftStart called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcShiftStart__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcOrganizationStartInitial__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.organizationStartInitial, index);
	}

	protected static void InvokeUserCode_RpcOrganizationStartInitial__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOrganizationStartInitial called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcOrganizationStartInitial__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcOrganizationStart__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.organizationStart, index);
	}

	protected static void InvokeUserCode_RpcOrganizationStart__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOrganizationStart called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcOrganizationStart__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcShiftWon__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.shiftWon, index);
	}

	protected static void InvokeUserCode_RpcShiftWon__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShiftWon called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcShiftWon__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcShiftLost__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.shiftLost, index);
	}

	protected static void InvokeUserCode_RpcShiftLost__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShiftLost called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcShiftLost__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcGameWon__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.gameWon, index);
	}

	protected static void InvokeUserCode_RpcGameWon__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcGameWon called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcGameWon__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcIncorrectOrder__Byte(byte index)
	{
		TryPlay(GlobalScriptableObject<AudioObject>.instance.incorrectOrder, index);
	}

	protected static void InvokeUserCode_RpcIncorrectOrder__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcIncorrectOrder called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcIncorrectOrder__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcTimerWarningPhase__Byte__Boolean__Byte(byte phase, bool isA, byte index)
	{
		switch (phase)
		{
		case 0:
			if (isA)
			{
				TryPlay(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase1A, index);
			}
			else
			{
				TryPlay(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase1B, index);
			}
			break;
		case 2:
			if (isA)
			{
				TryPlay(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase3A, index);
			}
			else
			{
				TryPlay(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase3B, index);
			}
			break;
		case 3:
			if (isA)
			{
				TryPlay(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase4A, index);
			}
			else
			{
				TryPlay(GlobalScriptableObject<AudioObject>.instance.timerWarningPhase4B, index);
			}
			break;
		default:
			Debug.LogWarning($"Unknown warning phase! ({phase})");
			break;
		}
	}

	protected static void InvokeUserCode_RpcTimerWarningPhase__Byte__Boolean__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTimerWarningPhase called on server.");
		}
		else
		{
			((VoiceOverManager)obj).UserCode_RpcTimerWarningPhase__Byte__Boolean__Byte(NetworkReaderExtensions.ReadByte(reader), reader.ReadBool(), NetworkReaderExtensions.ReadByte(reader));
		}
	}

	static VoiceOverManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(VoiceOverManager), "System.Void VoiceOverManager::CmdPlayCrashOut()", InvokeUserCode_CmdPlayCrashOut, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcPlayLobbyPlayerJoined(System.Byte)", InvokeUserCode_RpcPlayLobbyPlayerJoined__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcPlayBreakRoomInitial(System.Byte)", InvokeUserCode_RpcPlayBreakRoomInitial__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcPlayBreakRoom(System.Byte)", InvokeUserCode_RpcPlayBreakRoom__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcPlayCrashOut(System.Byte)", InvokeUserCode_RpcPlayCrashOut__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcShiftStart(System.Byte)", InvokeUserCode_RpcShiftStart__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcOrganizationStartInitial(System.Byte)", InvokeUserCode_RpcOrganizationStartInitial__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcOrganizationStart(System.Byte)", InvokeUserCode_RpcOrganizationStart__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcShiftWon(System.Byte)", InvokeUserCode_RpcShiftWon__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcShiftLost(System.Byte)", InvokeUserCode_RpcShiftLost__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcGameWon(System.Byte)", InvokeUserCode_RpcGameWon__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcIncorrectOrder(System.Byte)", InvokeUserCode_RpcIncorrectOrder__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(VoiceOverManager), "System.Void VoiceOverManager::RpcTimerWarningPhase(System.Byte,System.Boolean,System.Byte)", InvokeUserCode_RpcTimerWarningPhase__Byte__Boolean__Byte);
	}
}
