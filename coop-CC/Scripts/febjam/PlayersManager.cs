using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class PlayersManager : NetworkAggroManagerBase<PlayersManager>
{
	public struct PlayerProceed
	{
		public Entity player;

		public bool isProceeding;
	}

	public struct PlayerVote
	{
		public Entity player;

		public VoteOption vote;
	}

	public enum VoteOption : byte
	{
		None = 0,
		A = 1,
		B = 2
	}

	[CompilerGenerated]
	private sealed class _003CServerPlayerProceedReadyCo_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayersManager _003C_003E4__this;

		public bool useTimer;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CServerPlayerProceedReadyCo_003Ed__32(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			PlayersManager playersManager = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				if (playersManager.ServerProcessProceed())
				{
					return false;
				}
			}
			else
			{
				_003C_003E1__state = -1;
				playersManager.ServerStartProceed(useTimer);
			}
			_003C_003E2__current = new WaitForFixedUpdate();
			_003C_003E1__state = 1;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CServerPlayerVoteCo_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayersManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CServerPlayerVoteCo_003Ed__33(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			PlayersManager playersManager = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				if (playersManager.ServerProcessVote())
				{
					return false;
				}
			}
			else
			{
				_003C_003E1__state = -1;
				playersManager.ServerStartVote();
			}
			_003C_003E2__current = new WaitForFixedUpdate();
			_003C_003E1__state = 1;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[Min(0f)]
	public float proceedDuration = 2f;

	private readonly SyncList<NetworkIdentity> _syncAllPlayers = new SyncList<NetworkIdentity>();

	private readonly SyncHashSet<NetworkIdentity> _syncPlayersProceeding = new SyncHashSet<NetworkIdentity>();

	private readonly SyncDictionary<NetworkIdentity, VoteOption> _syncPlayersVoting = new SyncDictionary<NetworkIdentity, VoteOption>();

	private Timer _serverProceedTimer;

	private bool _serverProceedUseTimer;

	private Timer _serverVoteTimer;

	private VoteOption _serverCurrentVote;

	private static List<NetworkIdentity> _identities;

	private static List<VoteOption> _votes;

	private static HashSet<NetworkIdentity> _set;

	[SyncVar]
	private float _syncNormalizedProceedValue;

	[SyncVar]
	private float _syncNormalizedVoteValue;

	public bool serverSuppressProceed { get; set; }

	public bool proceededLastTimer => _syncNormalizedProceedValue >= 1f;

	public int playerCount => _syncAllPlayers.Count;

	public float Network_syncNormalizedProceedValue
	{
		get
		{
			return _syncNormalizedProceedValue;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncNormalizedProceedValue, 1uL, null);
		}
	}

	public float Network_syncNormalizedVoteValue
	{
		get
		{
			return _syncNormalizedVoteValue;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncNormalizedVoteValue, 2uL, null);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		if (_syncPlayersProceeding.Count > 0)
		{
			bool flag = false;
			_identities.Clear();
			foreach (NetworkIdentity item in _syncPlayersProceeding)
			{
				if (item != null)
				{
					_identities.Add(item);
				}
				else
				{
					flag = true;
				}
			}
			if (flag)
			{
				_syncPlayersProceeding.Clear();
				for (int i = 0; i < _identities.Count; i++)
				{
					_syncPlayersProceeding.Add(_identities[i]);
				}
			}
		}
		if (_syncPlayersVoting.Count > 0)
		{
			bool flag2 = false;
			_identities.Clear();
			_votes.Clear();
			foreach (KeyValuePair<NetworkIdentity, VoteOption> item2 in _syncPlayersVoting)
			{
				if (item2.Key != null)
				{
					_identities.Add(item2.Key);
					_votes.Add(item2.Value);
				}
				else
				{
					flag2 = true;
				}
			}
			if (flag2)
			{
				_syncPlayersVoting.Clear();
				for (int j = 0; j < _identities.Count; j++)
				{
					_syncPlayersVoting[_identities[j]] = _votes[j];
				}
			}
		}
		bool flag3 = false;
		_set.Clear();
		for (int k = 0; k < _syncAllPlayers.Count; k++)
		{
			_set.Add(_syncAllPlayers[k]);
		}
		foreach (KeyValuePair<int, NetworkConnectionToClient> connection in NetworkServer.connections)
		{
			if (!_set.Remove(connection.Value.identity))
			{
				flag3 = true;
				break;
			}
		}
		if (!flag3 && _set.Count <= 0)
		{
			return;
		}
		_identities.Clear();
		foreach (KeyValuePair<int, NetworkConnectionToClient> connection2 in NetworkServer.connections)
		{
			if (connection2.Value.identity != null)
			{
				_identities.Add(connection2.Value.identity);
			}
		}
		_identities.Sort((NetworkIdentity x, NetworkIdentity y) => x.netId.CompareTo(y.netId));
		_syncAllPlayers.Clear();
		_syncAllPlayers.AddRange(_identities);
	}

	public int GetNumberPlayersProceeding()
	{
		return _syncPlayersProceeding.Count;
	}

	public void GetAllPlayerProceeds(List<PlayerProceed> playerProceeds)
	{
		for (int i = 0; i < _syncAllPlayers.Count; i++)
		{
			NetworkIdentity networkIdentity = _syncAllPlayers[i];
			if (networkIdentity != null && networkIdentity.TryGetEntity(out var player))
			{
				playerProceeds.Add(new PlayerProceed
				{
					player = player,
					isProceeding = _syncPlayersProceeding.Contains(networkIdentity)
				});
			}
		}
	}

	public void GetAllPlayerVotes(List<PlayerVote> playerVotes)
	{
		for (int i = 0; i < _syncAllPlayers.Count; i++)
		{
			NetworkIdentity networkIdentity = _syncAllPlayers[i];
			if (networkIdentity != null && networkIdentity.TryGetEntity(out var player))
			{
				PlayerVote item = new PlayerVote
				{
					player = player
				};
				if (!_syncPlayersVoting.TryGetValue(networkIdentity, out item.vote))
				{
					item.vote = VoteOption.None;
				}
				playerVotes.Add(item);
			}
		}
	}

	public bool GetAmIProceeding()
	{
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			return _syncPlayersProceeding.Contains(player.netIdentity);
		}
		return false;
	}

	public VoteOption GetMyVote()
	{
		if (GameUtil.TryGetLocalPlayer(out var player) && _syncPlayersVoting.TryGetValue(player.netIdentity, out var value))
		{
			return value;
		}
		return VoteOption.None;
	}

	public float GetNormalizedProceedValue()
	{
		return _syncNormalizedProceedValue;
	}

	public float GetNormalizedVoteValue()
	{
		return _syncNormalizedVoteValue;
	}

	[IteratorStateMachine(typeof(_003CServerPlayerProceedReadyCo_003Ed__32))]
	[Server]
	public IEnumerator ServerPlayerProceedReadyCo(bool useTimer)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator PlayersManager::ServerPlayerProceedReadyCo(System.Boolean)' called when server was not active");
			return null;
		}
		return new _003CServerPlayerProceedReadyCo_003Ed__32(0)
		{
			_003C_003E4__this = this,
			useTimer = useTimer
		};
	}

	[IteratorStateMachine(typeof(_003CServerPlayerVoteCo_003Ed__33))]
	[Server]
	public IEnumerator ServerPlayerVoteCo()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator PlayersManager::ServerPlayerVoteCo()' called when server was not active");
			return null;
		}
		return new _003CServerPlayerVoteCo_003Ed__33(0)
		{
			_003C_003E4__this = this
		};
	}

	[Server]
	public VoteOption ServerGetWinningVote()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'PlayersManager/VoteOption PlayersManager::ServerGetWinningVote()' called when server was not active");
			return default(VoteOption);
		}
		using (Dictionary<NetworkIdentity, VoteOption>.Enumerator enumerator = _syncPlayersVoting.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current.Value;
			}
		}
		return VoteOption.None;
	}

	[Server]
	public void ServerStartProceed(bool useTimer)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void PlayersManager::ServerStartProceed(System.Boolean)' called when server was not active");
			return;
		}
		_syncPlayersProceeding.Clear();
		_serverProceedUseTimer = useTimer;
		if (useTimer)
		{
			_serverProceedTimer.SetTimer(proceedDuration);
			Network_syncNormalizedProceedValue = 0f;
		}
		serverSuppressProceed = false;
	}

	[Server]
	public void ServerStartVote()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void PlayersManager::ServerStartVote()' called when server was not active");
			return;
		}
		_serverCurrentVote = VoteOption.None;
		_syncPlayersVoting.Clear();
		_serverVoteTimer.SetTimer(proceedDuration);
		Network_syncNormalizedVoteValue = 0f;
	}

	[Server]
	public bool ServerProcessProceed()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean PlayersManager::ServerProcessProceed()' called when server was not active");
			return default(bool);
		}
		if (ServerIsReadyToProceed())
		{
			if (!_serverProceedUseTimer)
			{
				return true;
			}
			_serverProceedTimer.DecrementTimer();
			Network_syncNormalizedProceedValue = 1f - math.saturate(_serverProceedTimer.GetSecondsRemaining() / proceedDuration);
			if (_serverProceedTimer.IsFinished())
			{
				Network_syncNormalizedProceedValue = 1f;
				return true;
			}
			return false;
		}
		if (_serverProceedUseTimer)
		{
			Network_syncNormalizedProceedValue = 0f;
			_serverProceedTimer.SetTimer(proceedDuration);
		}
		return false;
	}

	[Server]
	public bool ServerProcessVote()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean PlayersManager::ServerProcessVote()' called when server was not active");
			return default(bool);
		}
		if (ServerIsReadyToVote())
		{
			_serverVoteTimer.DecrementTimer();
			Network_syncNormalizedVoteValue = 1f - math.saturate(_serverVoteTimer.GetSecondsRemaining() / proceedDuration);
			if (_serverVoteTimer.IsFinished())
			{
				Network_syncNormalizedVoteValue = 1f;
				return true;
			}
			return false;
		}
		_serverCurrentVote = VoteOption.None;
		_serverVoteTimer.SetTimer(proceedDuration);
		return false;
	}

	[Server]
	public void ServerResetProceeding()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void PlayersManager::ServerResetProceeding()' called when server was not active");
			return;
		}
		_syncPlayersProceeding.Clear();
		if (_serverProceedUseTimer)
		{
			_serverProceedTimer.SetTimer(proceedDuration);
			Network_syncNormalizedProceedValue = 0f;
		}
	}

	[Server]
	public void ServerResetVote()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void PlayersManager::ServerResetVote()' called when server was not active");
			return;
		}
		_syncPlayersVoting.Clear();
		_serverVoteTimer.Clear();
	}

	[Server]
	public void ServerResetAll()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void PlayersManager::ServerResetAll()' called when server was not active");
			return;
		}
		_syncAllPlayers.Clear();
		ServerResetProceeding();
		ServerResetVote();
	}

	[Server]
	private bool ServerIsReadyToProceed()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean PlayersManager::ServerIsReadyToProceed()' called when server was not active");
			return default(bool);
		}
		if (serverSuppressProceed)
		{
			return false;
		}
		foreach (KeyValuePair<int, NetworkConnectionToClient> connection in NetworkServer.connections)
		{
			if (!_syncPlayersProceeding.Contains(connection.Value.identity))
			{
				return false;
			}
		}
		return true;
	}

	[Server]
	private bool ServerIsReadyToVote()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Boolean PlayersManager::ServerIsReadyToVote()' called when server was not active");
			return default(bool);
		}
		foreach (KeyValuePair<int, NetworkConnectionToClient> connection in NetworkServer.connections)
		{
			if (!_syncPlayersVoting.TryGetValue(connection.Value.identity, out var value))
			{
				return false;
			}
			if (_serverCurrentVote != VoteOption.None && _serverCurrentVote != value)
			{
				return false;
			}
			_serverCurrentVote = value;
		}
		return true;
	}

	public void RequestProceed()
	{
		CmdRequestProceedShift();
	}

	public void RequestCancel()
	{
		CmdRequestCancelProceedShift();
	}

	public void RequestVote(VoteOption option)
	{
		if (option != VoteOption.None)
		{
			CmdRequestVote(option);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestProceedShift(NetworkConnectionToClient conn = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayersManager::CmdRequestProceedShift(Mirror.NetworkConnectionToClient)", -388825346, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestCancelProceedShift(NetworkConnectionToClient conn = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayersManager::CmdRequestCancelProceedShift(Mirror.NetworkConnectionToClient)", -762859540, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestVote(VoteOption option, NetworkConnectionToClient conn = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PlayersManager_002FVoteOption(writer, option);
		SendCommandInternal("System.Void PlayersManager::CmdRequestVote(PlayersManager/VoteOption,Mirror.NetworkConnectionToClient)", 1144242315, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public PlayersManager()
	{
		InitSyncObject(_syncAllPlayers);
		InitSyncObject(_syncPlayersProceeding);
		InitSyncObject(_syncPlayersVoting);
	}

	static PlayersManager()
	{
		_identities = new List<NetworkIdentity>();
		_votes = new List<VoteOption>();
		_set = new HashSet<NetworkIdentity>();
		RemoteProcedureCalls.RegisterCommand(typeof(PlayersManager), "System.Void PlayersManager::CmdRequestProceedShift(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestProceedShift__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayersManager), "System.Void PlayersManager::CmdRequestCancelProceedShift(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestCancelProceedShift__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayersManager), "System.Void PlayersManager::CmdRequestVote(PlayersManager/VoteOption,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestVote__VoteOption__NetworkConnectionToClient, requiresAuthority: false);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestProceedShift__NetworkConnectionToClient(NetworkConnectionToClient conn)
	{
		_syncPlayersProceeding.Add(conn.identity);
	}

	protected static void InvokeUserCode_CmdRequestProceedShift__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestProceedShift called on client.");
		}
		else
		{
			((PlayersManager)obj).UserCode_CmdRequestProceedShift__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdRequestCancelProceedShift__NetworkConnectionToClient(NetworkConnectionToClient conn)
	{
		_syncPlayersProceeding.Remove(conn.identity);
	}

	protected static void InvokeUserCode_CmdRequestCancelProceedShift__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestCancelProceedShift called on client.");
		}
		else
		{
			((PlayersManager)obj).UserCode_CmdRequestCancelProceedShift__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdRequestVote__VoteOption__NetworkConnectionToClient(VoteOption option, NetworkConnectionToClient conn)
	{
		_syncPlayersVoting[conn.identity] = option;
	}

	protected static void InvokeUserCode_CmdRequestVote__VoteOption__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestVote called on client.");
		}
		else
		{
			((PlayersManager)obj).UserCode_CmdRequestVote__VoteOption__NetworkConnectionToClient(GeneratedNetworkCode._Read_PlayersManager_002FVoteOption(reader), senderConnection);
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(_syncNormalizedProceedValue);
			writer.WriteFloat(_syncNormalizedVoteValue);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(_syncNormalizedProceedValue);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(_syncNormalizedVoteValue);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedProceedValue, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncNormalizedVoteValue, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedProceedValue, null, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncNormalizedVoteValue, null, reader.ReadFloat());
		}
	}
}
