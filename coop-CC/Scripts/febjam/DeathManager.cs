using System.Collections.Generic;
using Aggro.Core;
using Mirror;
using Unity.Collections;
using UnityEngine;

public class DeathManager : AggroManagerBase<DeathManager>
{
	private struct Entry
	{
		public Entity entity;

		public DeathContext context;

		public bool forceDestroy;
	}

	private struct DyingEntry
	{
		public DyingBehaviour behaviour;

		public DeathContext context;

		public PoolableReference poolable;
	}

	private List<Entry> _queue = new List<Entry>();

	private List<DyingEntry> _queueDying = new List<DyingEntry>();

	private List<DyingEntry> _dyings = new List<DyingEntry>();

	protected override void OnEntityDestroyed()
	{
		ClearDyings();
	}

	public void ClearDyings()
	{
		for (int i = 0; i < _dyings.Count; i++)
		{
			DyingEntry dyingEntry = _dyings[i];
			if (dyingEntry.poolable.isValid)
			{
				dyingEntry.poolable.Release();
			}
			else
			{
				Object.Destroy(dyingEntry.behaviour.gameObject);
			}
		}
	}

	public void QueueDeath(Entity entity, DeathContext context = default(DeathContext))
	{
		Entry item = new Entry
		{
			entity = entity,
			context = context
		};
		_queue.Add(item);
	}

	public void QueueDeathForce(Entity entity)
	{
		Entry item = new Entry
		{
			entity = entity,
			forceDestroy = true
		};
		_queue.Add(item);
	}

	public void QueueDying(GameObject gobj, DeathContext context = default(DeathContext))
	{
		QueueDying(gobj.GetComponent<DyingBehaviour>(), context);
	}

	public void QueueDying(DyingBehaviour behaviour, DeathContext context = default(DeathContext))
	{
		DyingEntry item = new DyingEntry
		{
			behaviour = behaviour,
			context = context
		};
		_queueDying.Add(item);
	}

	public void QueueDying(PoolableReference poolable, DeathContext context = default(DeathContext))
	{
		DyingEntry item = new DyingEntry
		{
			behaviour = poolable.gameObject.GetComponent<DyingBehaviour>(),
			context = context,
			poolable = poolable
		};
		_queueDying.Add(item);
	}

	[UpdateInGroup(typeof(DeathSystemGroup), 10)]
	protected override void OnUpdateSimulation()
	{
		for (int i = 0; i < _queue.Count; i++)
		{
			Entry entry = _queue[i];
			if (!entry.entity.Exists(allowIsDying: true))
			{
				continue;
			}
			PoolableEntityReference comp2;
			if (!entry.forceDestroy && entry.entity.TryGetObject<DyingBehaviour>(out var obj))
			{
				if (entry.entity.TryGetStruct<PoolableEntityReference>(out var comp))
				{
					QueueDying(comp.generic, entry.context);
				}
				else
				{
					QueueDying(obj, entry.context);
				}
				base.entityManager.DestroyEntity(entry.entity.key);
			}
			else if (entry.entity.HasObject<NetworkIdentity>())
			{
				NetworkServer.Destroy(entry.entity.gameObject);
				base.entityManager.DestroyEntity(entry.entity.key);
			}
			else if (entry.entity.TryGetStruct<PoolableEntityReference>(out comp2))
			{
				comp2.Release();
			}
			else
			{
				Object.Destroy(entry.entity.gameObject);
				base.entityManager.DestroyEntity(entry.entity.key);
			}
		}
		_queue.Clear();
		for (int j = 0; j < _queueDying.Count; j++)
		{
			DyingEntry item = _queueDying[j];
			item.behaviour.StartDying(item.context);
			_dyings.Add(item);
		}
		_queueDying.Clear();
		for (int k = 0; k < _dyings.Count; k++)
		{
			_dyings[k].behaviour.UpdateDying();
		}
		for (int l = 0; l < _dyings.Count; l++)
		{
			DyingEntry dyingEntry = _dyings[l];
			if (dyingEntry.behaviour.IsDoneDying())
			{
				if (dyingEntry.poolable.isValid)
				{
					dyingEntry.poolable.Release();
				}
				else
				{
					Object.Destroy(dyingEntry.behaviour.gameObject);
				}
				_dyings.RemoveAtSwapBack(l);
				l--;
			}
		}
	}
}
