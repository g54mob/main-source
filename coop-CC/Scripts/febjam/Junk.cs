using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class Junk : EntityBehaviourBase
{
	public bool registerWithServerSpawner = true;

	public GameObject cycledVfx;

	private LinkedListNode<Entity> _node;

	protected override void OnEntityCreated()
	{
		if (registerWithServerSpawner && base.isServer)
		{
			_node = AggroManagerBase<BoxManager>.instance.ServerAddSpawnedJunk(base.entity);
		}
	}

	protected override void OnEntityDestroyed()
	{
		if (_node != null && base.isServer)
		{
			AggroManagerBase<BoxManager>.instance.ServerRemoveSpawnedJunk(_node);
			_node = null;
		}
	}

	[Server]
	public void ServerJunkBeingCycled()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Junk::ServerJunkBeingCycled()' called when server was not active");
			return;
		}
		NetworkAggroManagerBase<VFXManager>.instance.Play(cycledVfx, base.entity.transform.position);
		_node = null;
	}
}
