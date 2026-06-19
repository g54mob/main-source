using System.Runtime.InteropServices;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class GlobalAction : NetworkEntityBehaviourBase
{
	public bool preventCrashOut;

	[SyncVar]
	[SerializeField]
	private bool _hasChargesLeft;

	public bool hasChargesLeft => _hasChargesLeft;

	public bool Network_hasChargesLeft
	{
		get
		{
			return _hasChargesLeft;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _hasChargesLeft, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		Network_hasChargesLeft = true;
	}

	public bool TryRequestConsumeCharge()
	{
		if (_hasChargesLeft)
		{
			CmdConsumeCharge();
			return true;
		}
		return false;
	}

	[Command(requiresAuthority = false)]
	private void CmdConsumeCharge()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void GlobalAction::CmdConsumeCharge()", -722693376, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerConsumeCharge()
	{
		BoxHealth obj;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void GlobalAction::ServerConsumeCharge()' called when server was not active");
		}
		else if (base.entity.TryGetObject<BoxHealth>(out obj))
		{
			obj.RequestTakeDamage(DamageType.Damaged);
			Network_hasChargesLeft = !obj.isDamaged;
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdConsumeCharge()
	{
		ServerConsumeCharge();
	}

	protected static void InvokeUserCode_CmdConsumeCharge(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdConsumeCharge called on client.");
		}
		else
		{
			((GlobalAction)obj).UserCode_CmdConsumeCharge();
		}
	}

	static GlobalAction()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(GlobalAction), "System.Void GlobalAction::CmdConsumeCharge()", InvokeUserCode_CmdConsumeCharge, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(_hasChargesLeft);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_hasChargesLeft);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _hasChargesLeft, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _hasChargesLeft, null, reader.ReadBool());
		}
	}
}
