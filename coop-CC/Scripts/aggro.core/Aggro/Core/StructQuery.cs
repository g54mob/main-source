using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Aggro.Core
{
	public class StructQuery<T> : IEnumerable<T>, IEnumerable where T : struct, IEntityStruct
	{
		private class Iter : IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _iterIndex = -1;

			private StructQuery<T> _collection;

			public T Current => _collection[_iterIndex];

			object IEnumerator.Current => Current;

			public Iter(StructQuery<T> collection)
			{
				_collection = collection;
			}

			public bool MoveNext()
			{
				_iterIndex++;
				return _iterIndex < _collection.count;
			}

			public void Reset()
			{
				_iterIndex = -1;
			}

			public void Dispose()
			{
			}
		}

		public readonly EntityManager entityManager;

		public readonly int typeIndex = EntityTypeManager.GetIndex<T>();

		public readonly EntityQueryFlags flags;

		internal readonly List<EntityKey> keys = new List<EntityKey>();

		private readonly Iter _iter;

		public int count => keys.Count;

		public T this[int index]
		{
			get
			{
				ComponentQueryResult<T> componentQueryResult = new ComponentQueryResult<T>
				{
					key = keys[index]
				};
				if (!entityManager.Exists(componentQueryResult.key) || !entityManager.HasComponentData(componentQueryResult.key, typeIndex))
				{
					return default(T);
				}
				componentQueryResult.component = entityManager.GetComponentData<T>(componentQueryResult.key, typeIndex);
				return componentQueryResult.component;
			}
		}

		public void Run()
		{
			entityManager.RunQuery(this);
		}

		public void Run(EntityContext context)
		{
			entityManager.RunQuery(this, context);
		}

		public void Run(List<EntityContext> contexts)
		{
			entityManager.RunQuery(this, contexts);
		}

		internal StructQuery(EntityManager manager, EntityQueryFlags flags)
		{
			entityManager = manager;
			this.flags = flags;
			_iter = new Iter(this);
		}

		public IEnumerator<T> GetEnumerator()
		{
			_iter.Reset();
			return _iter;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public EntityKey GetEntityKey(int index)
		{
			EntityKey entityKey = keys[index];
			if (!entityManager.Exists(entityKey) || !entityManager.HasComponentData(entityKey, typeIndex))
			{
				return EntityKey.invalid;
			}
			return entityKey;
		}

		public Entity GetEntity(int index)
		{
			EntityKey key = keys[index];
			if (entityManager.Exists(key))
			{
				return new Entity(key, entityManager.world);
			}
			return Entity.invalid;
		}

		public T GetComponentData(int index)
		{
			EntityKey key = keys[index];
			if (!entityManager.Exists(key) || !entityManager.HasComponentData(key, typeIndex))
			{
				return default(T);
			}
			return entityManager.GetComponentData<T>(key, typeIndex);
		}

		public void SetComponentData(int index, T comp)
		{
			EntityKey key = keys[index];
			if (entityManager.Exists(key) && entityManager.HasComponentData(key, typeIndex))
			{
				entityManager.SetComponentData(key, comp, typeIndex);
			}
		}

		public void Get(int index, out EntityKey key, out T comp)
		{
			key = keys[index];
			if (!entityManager.Exists(key) || !entityManager.HasComponentData(key, typeIndex))
			{
				comp = default(T);
				key = EntityKey.invalid;
			}
			else
			{
				comp = entityManager.GetComponentData<T>(key, typeIndex);
			}
		}

		public void Get(int index, out Entity entity, out T comp)
		{
			EntityKey key = keys[index];
			if (!entityManager.Exists(key) || !entityManager.HasComponentData(key, typeIndex))
			{
				comp = default(T);
				entity = Entity.invalid;
			}
			else
			{
				comp = entityManager.GetComponentData<T>(key, typeIndex);
				entity = new Entity(key, entityManager.world);
			}
		}

		public void Randomize(int seed)
		{
			keys.Randomize(seed);
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyHasBeenRun()
		{
		}
	}
}
