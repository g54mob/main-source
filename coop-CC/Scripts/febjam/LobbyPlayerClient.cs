using System;
using System.Runtime.InteropServices;
using Aggro.Core.Networking;
using Mirror;

public class LobbyPlayerClient : NetworkEntityBehaviourBase
{
	public struct Info : IEquatable<Info>
	{
		public int contractIndex;

		public int score;

		public bool Equals(Info other)
		{
			if (contractIndex == other.contractIndex)
			{
				return score == other.score;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Info other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(contractIndex, score);
		}
	}

	[SyncVar]
	private Info _syncInfo;

	private bool _init;

	public Info info => _syncInfo;

	public Info Network_syncInfo
	{
		get
		{
			return _syncInfo;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncInfo, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		Info syncInfo = _syncInfo;
		syncInfo.contractIndex = -2;
		Network_syncInfo = syncInfo;
	}

	public override void OnStartLocalPlayer()
	{
		_init = false;
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		int contractIndex = NetworkAggroManagerBase<LobbyManager>.instance.GetContractIndex();
		if (contractIndex != _syncInfo.contractIndex || !_init)
		{
			_init = true;
			Info syncInfo = _syncInfo;
			syncInfo.contractIndex = contractIndex;
			if (contractIndex >= 0)
			{
				ContractObject contract = NetworkAggroManagerBase<LobbyManager>.instance.GetContract();
				SaveManager.data.TryGetContractBellCount(contract, out syncInfo.score);
			}
			else
			{
				syncInfo.score = 0;
			}
			Network_syncInfo = syncInfo;
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_LobbyPlayerClient_002FInfo(writer, _syncInfo);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_LobbyPlayerClient_002FInfo(writer, _syncInfo);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncInfo, null, GeneratedNetworkCode._Read_LobbyPlayerClient_002FInfo(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncInfo, null, GeneratedNetworkCode._Read_LobbyPlayerClient_002FInfo(reader));
		}
	}
}
