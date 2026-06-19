using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class Bonkable : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float bonkForce = 10f;

	[Min(0f)]
	public float bonkRadius = 10f;

	[Range(0f, 90f)]
	public float bonkUpwardsModifierDegrees = 5f;

	private static List<GrabbableHolder> _holders;

	private static List<Entity> _entities;

	public void RequestBonk()
	{
		if (base.isServer)
		{
			ServerBonk();
		}
		else
		{
			CmdBonk();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdBonk()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Bonkable::CmdBonk()", 863226511, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerBonk()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Bonkable::ServerBonk()' called when server was not active");
			return;
		}
		_holders.Clear();
		base.entity.GetObjects(_holders);
		Vector3 position = base.entity.transform.position;
		for (int i = 0; i < _holders.Count; i++)
		{
			GrabbableHolder grabbableHolder = _holders[i];
			if (grabbableHolder.serverHeldEntity != Entity.invalid)
			{
				Grabbable grabbable = grabbableHolder.serverHeldEntity.GetObject<Grabbable>();
				grabbable.ServerRemoveFromHolder();
				grabbable.ServerBreakEntireStack();
				grabbableHolder.ServerRemoveItem();
				_entities.Clear();
				grabbable.GetStack(_entities);
				for (int j = 0; j < _entities.Count; j++)
				{
					_entities[j].rigidbody.AddExplosionForce(bonkForce, position, bonkRadius, bonkUpwardsModifierDegrees, ForceMode.Impulse);
				}
			}
		}
		RpcShelfKnocked();
	}

	[ClientRpc]
	private void RpcShelfKnocked()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Bonkable::RpcShelfKnocked()", 1771211449, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	static Bonkable()
	{
		_holders = new List<GrabbableHolder>();
		_entities = new List<Entity>();
		RemoteProcedureCalls.RegisterCommand(typeof(Bonkable), "System.Void Bonkable::CmdBonk()", InvokeUserCode_CmdBonk, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Bonkable), "System.Void Bonkable::RpcShelfKnocked()", InvokeUserCode_RpcShelfKnocked);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdBonk()
	{
		ServerBonk();
	}

	protected static void InvokeUserCode_CmdBonk(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdBonk called on client.");
		}
		else
		{
			((Bonkable)obj).UserCode_CmdBonk();
		}
	}

	protected void UserCode_RpcShelfKnocked()
	{
		if (base.entity.TryGetObject<Animator>(out var obj))
		{
			obj.SetTrigger("bonk");
		}
	}

	protected static void InvokeUserCode_RpcShelfKnocked(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShelfKnocked called on server.");
		}
		else
		{
			((Bonkable)obj).UserCode_RpcShelfKnocked();
		}
	}
}
