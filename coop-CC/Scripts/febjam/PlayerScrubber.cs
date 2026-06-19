using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class PlayerScrubber : NetworkEntityBehaviourBase
{
	[Range(-100f, 0f)]
	public int scrubbingVehicleSpeedPercentage = -50;

	private Entity _currentlyScrubbing;

	[SyncVar]
	private Entity _syncIsCurrentlyScrubbingWithBox;

	private Entity _serverCurrentScrubbing;

	private static Collider[] _colliders;

	public Entity Network_syncIsCurrentlyScrubbingWithBox
	{
		get
		{
			return _syncIsCurrentlyScrubbingWithBox;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncIsCurrentlyScrubbingWithBox, 1uL, null);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isLocalPlayer)
		{
			if (!AggroInputManager.input.Game.UseBox.IsPressed() || AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen)
			{
				Network_syncIsCurrentlyScrubbingWithBox = Entity.invalid;
				CheckStopScrubbing();
				return;
			}
			PlayerGrabber playerGrabber = base.entity.GetObject<PlayerGrabber>();
			if (playerGrabber.grabState != PlayerGrabState.Grabbed || playerGrabber.syncLiftRaised || !playerGrabber.localPlayerGrabTarget.TryGetObject<BoxScrubber>(out var obj) || obj.isAlwaysScrubbing)
			{
				Network_syncIsCurrentlyScrubbingWithBox = Entity.invalid;
				CheckStopScrubbing();
				return;
			}
			Network_syncIsCurrentlyScrubbingWithBox = playerGrabber.localPlayerGrabTarget;
			Entity invalid = Entity.invalid;
			Vector3 position = base.entity.transform.position;
			int num = Physics.OverlapSphereNonAlloc(position, obj.scrubRadius, _colliders, 131072);
			float num2 = float.MaxValue;
			for (int i = 0; i < num; i++)
			{
				if (_colliders[i].TryGetComponent<EntityCollider>(out var component) && component.entity.HasObject<Puddle>())
				{
					float num3 = math.distancesq(position, component.transform.position);
					if (num3 < num2)
					{
						num2 = num3;
						invalid = component.entity;
					}
				}
			}
			if (_currentlyScrubbing != invalid)
			{
				CheckStopScrubbing();
			}
			if (invalid != _currentlyScrubbing)
			{
				_currentlyScrubbing = invalid;
				CmdStartScrubbing(invalid);
			}
		}
		if (base.isServer && _syncIsCurrentlyScrubbingWithBox.TryGetObject<BoxScrubber>(out var obj2))
		{
			obj2.ServerSetScrubbing();
		}
	}

	private void CheckStopScrubbing()
	{
		if (_currentlyScrubbing != Entity.invalid)
		{
			CmdStopScrubbing();
			_currentlyScrubbing = Entity.invalid;
		}
	}

	public bool IsScrubbing(out int speedPercentage)
	{
		if (_currentlyScrubbing.Exists())
		{
			speedPercentage = scrubbingVehicleSpeedPercentage;
			return true;
		}
		speedPercentage = 0;
		return false;
	}

	[Command]
	private void CmdStartScrubbing(Entity target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(target);
		SendCommandInternal("System.Void PlayerScrubber::CmdStartScrubbing(Aggro.Core.Entity)", -821412103, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdStopScrubbing()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerScrubber::CmdStopScrubbing()", -459223025, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerStopScrubbing()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerScrubber::ServerStopScrubbing()' called when server was not active");
			return;
		}
		if (_serverCurrentScrubbing.TryGetObject<Puddle>(out var obj))
		{
			obj.ServerDecrementCleaning(base.entity.netIdentity.connectionToClient);
		}
		_serverCurrentScrubbing = Entity.invalid;
	}

	protected override void OnServerOwnerDisconnecting()
	{
		ServerStopScrubbing();
	}

	static PlayerScrubber()
	{
		_colliders = new Collider[8];
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerScrubber), "System.Void PlayerScrubber::CmdStartScrubbing(Aggro.Core.Entity)", InvokeUserCode_CmdStartScrubbing__Entity, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerScrubber), "System.Void PlayerScrubber::CmdStopScrubbing()", InvokeUserCode_CmdStopScrubbing, requiresAuthority: true);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdStartScrubbing__Entity(Entity target)
	{
		if (target.TryGetObject<Puddle>(out var obj))
		{
			_serverCurrentScrubbing = target;
			obj.ServerIncrementCleaning(base.entity.netIdentity.connectionToClient);
		}
	}

	protected static void InvokeUserCode_CmdStartScrubbing__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStartScrubbing called on client.");
		}
		else
		{
			((PlayerScrubber)obj).UserCode_CmdStartScrubbing__Entity(reader.ReadEntity());
		}
	}

	protected void UserCode_CmdStopScrubbing()
	{
		ServerStopScrubbing();
	}

	protected static void InvokeUserCode_CmdStopScrubbing(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStopScrubbing called on client.");
		}
		else
		{
			((PlayerScrubber)obj).UserCode_CmdStopScrubbing();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteEntity(_syncIsCurrentlyScrubbingWithBox);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteEntity(_syncIsCurrentlyScrubbingWithBox);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncIsCurrentlyScrubbingWithBox, null, reader.ReadEntity());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncIsCurrentlyScrubbingWithBox, null, reader.ReadEntity());
		}
	}
}
