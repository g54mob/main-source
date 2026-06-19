using System.Collections.Generic;
using Aggro.Core;
using Mirror;
using UnityEngine;
using UnityEngine.Pool;

public class BoxManager : AggroManagerBase<BoxManager>
{
	[Min(1f)]
	public int maxJunkCount = 20;

	private LinkedList<Entity> _serverList = new LinkedList<Entity>();

	private ObjectPool<LinkedListNode<Entity>> _pool = new ObjectPool<LinkedListNode<Entity>>(() => new LinkedListNode<Entity>(Entity.invalid));

	[Server]
	public LinkedListNode<Entity> ServerAddSpawnedJunk(Entity junk)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Collections.Generic.LinkedListNode`1<Aggro.Core.Entity> BoxManager::ServerAddSpawnedJunk(Aggro.Core.Entity)' called when server was not active");
			return null;
		}
		LinkedListNode<Entity> linkedListNode = _pool.Get();
		linkedListNode.Value = junk;
		_serverList.AddLast(linkedListNode);
		while (_serverList.Count > maxJunkCount)
		{
			LinkedListNode<Entity> first = _serverList.First;
			_serverList.RemoveFirst();
			if (first.Value.Exists())
			{
				first.Value.GetObject<Junk>().ServerJunkBeingCycled();
				EntityUtil.Destroy(first.Value);
			}
			_pool.Release(first);
		}
		return linkedListNode;
	}

	[Server]
	public void ServerRemoveSpawnedJunk(LinkedListNode<Entity> node)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BoxManager::ServerRemoveSpawnedJunk(System.Collections.Generic.LinkedListNode`1<Aggro.Core.Entity>)' called when server was not active");
			return;
		}
		_serverList.Remove(node);
		_pool.Release(node);
	}
}
