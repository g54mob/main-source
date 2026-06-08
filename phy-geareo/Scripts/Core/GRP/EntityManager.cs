using System;
using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public abstract class EntityManager : Thing<EntityManagerConfig>
	{
		public IdGenerator idGenerator;

		public Entity Create(EntityConfig entityConfig)
		{
			return null;
		}

		public EntityConfig GetConfig(string key)
		{
			return null;
		}

		public abstract Entity Create(EntityConfig entityConfig, Id id);

		public abstract void Destroy(Entity entity);

		public abstract int GetIndex(Entity entity);

		public abstract void SetIndex(Entity entity, int index);

		public abstract bool TryGet(Id id, out Entity entity);

		public abstract IEnumerable<Entity> GetEntities();

		public abstract EntityManagerData Serialize();

		public abstract void Deserialize(EntityManagerData data);
	}
	public abstract class EntityManager<T> : EntityManager where T : Entity
	{
		public Dictionary<Id, T> entitiesDic;

		public List<T> entities;

		public Action<T> onDestroyed;

		public StateSelector<List<T>> entitiesList;

		public override void OnContext()
		{
		}

		public override void OnContextDispose()
		{
		}

		public void Clear()
		{
		}

		public void Destroy(T entity)
		{
		}

		public override void Destroy(Entity entity)
		{
		}

		public override int GetIndex(Entity entity)
		{
			return 0;
		}

		public override void SetIndex(Entity entity, int index)
		{
		}

		public override bool TryGet(Id id, out Entity entity)
		{
			entity = null;
			return false;
		}

		public T Get(Id id)
		{
			return null;
		}

		public bool TryGet(Id id, out T entity)
		{
			entity = null;
			return false;
		}

		public T TryGet(Id id)
		{
			return null;
		}

		public G Get<G>() where G : T
		{
			return null;
		}

		public override IEnumerable<Entity> GetEntities()
		{
			return null;
		}

		public override EntityManagerData Serialize()
		{
			return null;
		}

		public override void Deserialize(EntityManagerData data)
		{
		}
	}
	public class EntityManager<T, TConfig> : EntityManager<T> where T : Entity where TConfig : EntityConfig
	{
		public T Create(TConfig entityConfig)
		{
			return null;
		}

		public override Entity Create(EntityConfig entityConfig, Id id)
		{
			return null;
		}

		public T Create(TConfig entityConfig, Id id)
		{
			return null;
		}
	}
}
