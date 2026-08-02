using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class FpEquipmentSync : NetworkBehaviour
{
	public Transform fpEquipment;

	[SyncVar]
	private Vector3 syncedPosition;

	[SyncVar]
	private Quaternion syncedRotation;

	private float syncRate = 15f;

	private float lastSyncTime;

	private float positionThreshold = 0.01f;

	private float rotationThreshold = 1f;

	public Vector3 FpEquipmentPosition => syncedPosition;

	public Quaternion FpEquipmentRotation => syncedRotation;

	public Vector3 NetworksyncedPosition
	{
		get
		{
			return syncedPosition;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncedPosition, 1uL, null);
		}
	}

	public Quaternion NetworksyncedRotation
	{
		get
		{
			return syncedRotation;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncedRotation, 2uL, null);
		}
	}

	private void Update()
	{
		if (base.isLocalPlayer)
		{
			if (!(fpEquipment == null) && !(Time.time - lastSyncTime < 1f / syncRate))
			{
				Vector3 position = fpEquipment.position;
				Quaternion rotation = fpEquipment.rotation;
				Debug.Log($"[FpEquipSync LOCAL] pos: {position}");
				if (Vector3.Distance(position, syncedPosition) > positionThreshold || Quaternion.Angle(rotation, syncedRotation) > rotationThreshold)
				{
					CmdSyncPosition(position, rotation);
					lastSyncTime = Time.time;
				}
			}
		}
		else
		{
			Debug.Log($"[FpEquipSync REMOTE] synced pos: {syncedPosition}");
		}
	}

	[Command(channel = 1)]
	private void CmdSyncPosition(Vector3 pos, Quaternion rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		SendCommandInternal("System.Void FpEquipmentSync::CmdSyncPosition(UnityEngine.Vector3,UnityEngine.Quaternion)", -210303364, writer, 1);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSyncPosition__Vector3__Quaternion(Vector3 pos, Quaternion rot)
	{
		NetworksyncedPosition = pos;
		NetworksyncedRotation = rot;
	}

	protected static void InvokeUserCode_CmdSyncPosition__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSyncPosition called on client.");
		}
		else
		{
			((FpEquipmentSync)obj).UserCode_CmdSyncPosition__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	static FpEquipmentSync()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(FpEquipmentSync), "System.Void FpEquipmentSync::CmdSyncPosition(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CmdSyncPosition__Vector3__Quaternion, requiresAuthority: true);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVector3(syncedPosition);
			writer.WriteQuaternion(syncedRotation);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVector3(syncedPosition);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteQuaternion(syncedRotation);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref syncedPosition, null, reader.ReadVector3());
			GeneratedSyncVarDeserialize(ref syncedRotation, null, reader.ReadQuaternion());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncedPosition, null, reader.ReadVector3());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncedRotation, null, reader.ReadQuaternion());
		}
	}
}
