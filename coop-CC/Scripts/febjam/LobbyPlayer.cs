using System.Runtime.InteropServices;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using UnityEngine;

public class LobbyPlayer : NetworkEntityBehaviourBase
{
	private static readonly int PlayerAssigned = Animator.StringToHash("playerAssigned");

	[Range(0f, 3f)]
	public int lobbyPlayerIndex;

	[SyncVar]
	private bool _syncHasPlayerAssigned;

	private bool _previouslyAssigned;

	public Animator animator;

	public EventReference joinSfx;

	public bool hasPlayerAssigned => _syncHasPlayerAssigned;

	public bool Network_syncHasPlayerAssigned
	{
		get
		{
			return _syncHasPlayerAssigned;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncHasPlayerAssigned, 1uL, null);
		}
	}

	protected override void OnUpdatePresentation()
	{
		animator.SetBool(PlayerAssigned, hasPlayerAssigned);
		if (hasPlayerAssigned && !_previouslyAssigned)
		{
			AudioManager.PlaySfx(joinSfx);
		}
		_previouslyAssigned = hasPlayerAssigned;
	}

	[Server]
	public void ServerPlayerAssigned()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void LobbyPlayer::ServerPlayerAssigned()' called when server was not active");
		}
		else
		{
			Network_syncHasPlayerAssigned = true;
		}
	}

	[Server]
	public void ServerPlayerUnassigned()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void LobbyPlayer::ServerPlayerUnassigned()' called when server was not active");
		}
		else
		{
			Network_syncHasPlayerAssigned = false;
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
			writer.WriteBool(_syncHasPlayerAssigned);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_syncHasPlayerAssigned);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncHasPlayerAssigned, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncHasPlayerAssigned, null, reader.ReadBool());
		}
	}
}
