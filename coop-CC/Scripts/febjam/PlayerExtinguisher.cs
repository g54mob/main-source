using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class PlayerExtinguisher : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float extinguishRadius;

	[Range(0f, 180f)]
	public float extinguishArcDegrees = 90f;

	[SyncVar]
	private bool _syncIsCurrentlyExtinguishing;

	[SyncVar]
	private Vector2 _syncExtinguishingPos;

	[SyncVar]
	private Vector2 _syncExtinguishingFwd;

	private const float EXTINGUISH_HEIGHT = 20f;

	private static Collider[] _colliders;

	public bool isCurrentlyExtinguishing => _syncIsCurrentlyExtinguishing;

	public bool Network_syncIsCurrentlyExtinguishing
	{
		get
		{
			return _syncIsCurrentlyExtinguishing;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncIsCurrentlyExtinguishing, 1uL, null);
		}
	}

	public Vector2 Network_syncExtinguishingPos
	{
		get
		{
			return _syncExtinguishingPos;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncExtinguishingPos, 2uL, null);
		}
	}

	public Vector2 Network_syncExtinguishingFwd
	{
		get
		{
			return _syncExtinguishingFwd;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncExtinguishingFwd, 4uL, null);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isLocalPlayer)
		{
			if (!AggroInputManager.input.Game.UseBox.IsPressed() || AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen)
			{
				Network_syncIsCurrentlyExtinguishing = false;
				return;
			}
			PlayerGrabber playerGrabber = base.entity.GetObject<PlayerGrabber>();
			if (playerGrabber.grabState != PlayerGrabState.Grabbed || !playerGrabber.localPlayerGrabTarget.HasObject<BoxExtinguisher>())
			{
				Network_syncIsCurrentlyExtinguishing = false;
				return;
			}
			Network_syncIsCurrentlyExtinguishing = true;
			Vector3 position = base.entity.transform.position;
			Vector3 forward = base.entity.transform.forward;
			Network_syncExtinguishingPos = new Vector2(position.x, position.z);
			Network_syncExtinguishingFwd = new Vector2(forward.x, forward.z);
		}
		if (!base.isServer || !_syncIsCurrentlyExtinguishing)
		{
			return;
		}
		Vector3 vector = new Vector3(_syncExtinguishingPos.x, 0f, _syncExtinguishingPos.y);
		Vector3 lhs = new Vector3(_syncExtinguishingFwd.x, 0f, _syncExtinguishingFwd.y);
		float num = math.cos(extinguishArcDegrees / 2f);
		int num2 = Physics.OverlapCapsuleNonAlloc(vector + Vector3.up * 10f, vector + Vector3.down * 10f, extinguishRadius, _colliders, 147464);
		int num3 = 0;
		for (int i = 0; i < num2; i++)
		{
			Entity entity = _colliders[i].GetEntity();
			Vector3 position2 = entity.transform.position;
			position2.y = 0f;
			Vector3 rhs = position2 - vector;
			if (Vector3.Dot(lhs, rhs) >= 0f && entity.TryGetObject<IFlammable>(out var obj) && obj.ServerFlammableCanBePutOut())
			{
				rhs.Normalize();
				if (Vector3.Dot(lhs, rhs) >= num)
				{
					obj.ServerFlammablePutOut();
					num3++;
				}
			}
		}
		if (num3 > 0)
		{
			RpcFiresExtinguished(base.entity.netIdentity.connectionToClient, (byte)num3);
		}
	}

	[TargetRpc]
	private void RpcFiresExtinguished(NetworkConnectionToClient conn, byte count)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, count);
		SendTargetRPCInternal(conn, "System.Void PlayerExtinguisher::RpcFiresExtinguished(Mirror.NetworkConnectionToClient,System.Byte)", -197096454, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	static PlayerExtinguisher()
	{
		_colliders = new Collider[128];
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerExtinguisher), "System.Void PlayerExtinguisher::RpcFiresExtinguished(Mirror.NetworkConnectionToClient,System.Byte)", InvokeUserCode_RpcFiresExtinguished__NetworkConnectionToClient__Byte);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcFiresExtinguished__NetworkConnectionToClient__Byte(NetworkConnectionToClient conn, byte count)
	{
		Platform.AddStat("stat_fires_extinguished", count);
	}

	protected static void InvokeUserCode_RpcFiresExtinguished__NetworkConnectionToClient__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcFiresExtinguished called on server.");
		}
		else
		{
			((PlayerExtinguisher)obj).UserCode_RpcFiresExtinguished__NetworkConnectionToClient__Byte(null, NetworkReaderExtensions.ReadByte(reader));
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(_syncIsCurrentlyExtinguishing);
			writer.WriteVector2(_syncExtinguishingPos);
			writer.WriteVector2(_syncExtinguishingFwd);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_syncIsCurrentlyExtinguishing);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVector2(_syncExtinguishingPos);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteVector2(_syncExtinguishingFwd);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncIsCurrentlyExtinguishing, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _syncExtinguishingPos, null, reader.ReadVector2());
			GeneratedSyncVarDeserialize(ref _syncExtinguishingFwd, null, reader.ReadVector2());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncIsCurrentlyExtinguishing, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncExtinguishingPos, null, reader.ReadVector2());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncExtinguishingFwd, null, reader.ReadVector2());
		}
	}
}
