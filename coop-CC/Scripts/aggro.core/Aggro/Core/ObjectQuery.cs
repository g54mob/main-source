using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Aggro.Core
{
	public class ObjectQuery : IEnumerable<object>, IEnumerable
	{
		private struct ResultComparer<TComparer> : IComparer<QueryResult> where TComparer : struct, IComparer<object>
		{
			public TComparer comparer;

			public int Compare(QueryResult x, QueryResult y)
			{
				return comparer.Compare(x.obj, y.obj);
			}
		}

		private class Iter : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _iterIndex = -1;

			private ObjectQuery _collection;

			public object Current => _collection[_iterIndex];

			object IEnumerator.Current => Current;

			public Iter(ObjectQuery collection)
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

		public readonly EntityQueryFlags flags;

		public readonly EntityTypeManager.TypeInfo typeInfo;

		internal readonly List<QueryResult> results = new List<QueryResult>();

		private readonly Iter _iter;

		public bool isValid
		{
			get
			{
				if (entityManager != null)
				{
					return entityManager.isValid;
				}
				return false;
			}
		}

		public int count => results.Count;

		public object this[int index]
		{
			get
			{
				QueryResult queryResult = results[index];
				if (!entityManager.Exists(queryResult.key))
				{
					return null;
				}
				return queryResult.obj;
			}
		}

		public void Run()
		{
			entityManager.RunQuery(this);
		}

		public void Sort<TComparer>(TComparer comparer) where TComparer : struct, IComparer<object>
		{
			ResultComparer<TComparer> resultComparer = new ResultComparer<TComparer>
			{
				comparer = comparer
			};
			results.Sort(resultComparer);
		}

		public void Run(EntityContext context)
		{
			entityManager.RunQuery(this, context);
		}

		public void Run(List<EntityContext> contexts)
		{
			entityManager.RunQuery(this, contexts);
		}

		internal ObjectQuery(EntityManager manager, Type type, EntityQueryFlags flags)
		{
			entityManager = manager;
			this.flags = flags;
			typeInfo = EntityTypeManager.GetInfo(type);
			_iter = new Iter(this);
		}

		public IEnumerator<object> GetEnumerator()
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
			EntityKey key = results[index].key;
			if (!entityManager.Exists(key))
			{
				return EntityKey.invalid;
			}
			return key;
		}

		public Entity GetEntity(int index)
		{
			EntityKey key = results[index].key;
			if (entityManager.Exists(key))
			{
				return new Entity(key, entityManager.world);
			}
			return Entity.invalid;
		}

		public object GetObject(int index)
		{
			QueryResult queryResult = results[index];
			EntityKey key = queryResult.key;
			if (!entityManager.Exists(key))
			{
				return null;
			}
			return queryResult.obj;
		}

		public T GetObject<T>(int index) where T : class
		{
			return GetObject(index) as T;
		}

		public void Get(int index, out EntityKey key, out object obj)
		{
			QueryResult queryResult = results[index];
			key = queryResult.key;
			if (!entityManager.Exists(key))
			{
				obj = null;
				key = EntityKey.invalid;
			}
			else
			{
				obj = queryResult.obj;
			}
		}

		public void Get<T>(int index, out EntityKey key, out T obj) where T : class
		{
			Get(index, out key, out object obj2);
			obj = obj2 as T;
		}

		public void Get(int index, out Entity entity, out object obj)
		{
			QueryResult queryResult = results[index];
			entity = new Entity(queryResult.key, entityManager.world);
			if (!entityManager.Exists(entity.key))
			{
				obj = null;
				entity = Entity.invalid;
			}
			else
			{
				obj = queryResult.obj;
			}
		}

		public void Get<T>(int index, out Entity entity, out T obj) where T : class
		{
			Get(index, out entity, out object obj2);
			obj = obj2 as T;
		}

		public void Randomize(int seed)
		{
			results.Randomize(seed);
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyHasBeenRun()
		{
		}
	}
	public class ObjectQuery<T> : IEnumerable<T>, IEnumerable where T : class
	{
		private struct ResultComparer<TComparer> : IComparer<QueryResult<T>> where TComparer : struct, IComparer<T>
		{
			public TComparer comparer;

			public int Compare(QueryResult<T> x, QueryResult<T> y)
			{
				return comparer.Compare(x.obj, y.obj);
			}
		}

		private class Iter : IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _iterIndex = -1;

			private ObjectQuery<T> _collection;

			public T Current => _collection[_iterIndex];

			object IEnumerator.Current => Current;

			public Iter(ObjectQuery<T> collection)
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

		public readonly EntityQueryFlags flags;

		public readonly EntityTypeManager.TypeInfo typeInfo;

		internal readonly List<QueryResult<T>> results = new List<QueryResult<T>>();

		private readonly Iter _iter;

		public bool isValid
		{
			get
			{
				if (entityManager != null)
				{
					return entityManager.isValid;
				}
				return false;
			}
		}

		public int count => results.Count;

		public T this[int index]
		{
			get
			{
				QueryResult<T> queryResult = results[index];
				if (!entityManager.Exists(queryResult.key))
				{
					return null;
				}
				return queryResult.obj;
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

		public void Sort<TComparer>(TComparer comparer) where TComparer : struct, IComparer<T>
		{
			ResultComparer<TComparer> resultComparer = new ResultComparer<TComparer>
			{
				comparer = comparer
			};
			results.Sort(resultComparer);
		}

		public void Sort(Comparison<T> comparison)
		{
			results.Sort((QueryResult<T> x, QueryResult<T> y) => comparison(x.obj, y.obj));
		}

		public void SortEntities()
		{
			results.Sort((QueryResult<T> x, QueryResult<T> y) => x.key.CompareTo(y.key));
		}

		public void SortEntities(Comparison<Entity> comparison)
		{
			results.Sort((QueryResult<T> x, QueryResult<T> y) => comparison(new Entity(x.key, entityManager.world), new Entity(y.key, entityManager.world)));
		}

		public void Run(List<EntityContext> contexts)
		{
			entityManager.RunQuery(this, contexts);
		}

		internal ObjectQuery(EntityManager manager, EntityQueryFlags flags)
		{
			entityManager = manager;
			this.flags = flags;
			typeInfo = EntityTypeManager.GetInfo<T>();
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
			EntityKey key = results[index].key;
			if (!entityManager.Exists(key))
			{
				return EntityKey.invalid;
			}
			return key;
		}

		public Entity GetEntity(int index)
		{
			EntityKey key = results[index].key;
			if (entityManager.Exists(key))
			{
				return new Entity(key, entityManager.world);
			}
			return Entity.invalid;
		}

		public T GetObject(int index)
		{
			QueryResult<T> queryResult = results[index];
			EntityKey key = queryResult.key;
			if (!entityManager.Exists(key))
			{
				return null;
			}
			return queryResult.obj;
		}

		public void Get(int index, out EntityKey key, out T obj)
		{
			QueryResult<T> queryResult = results[index];
			key = queryResult.key;
			if (!entityManager.Exists(key))
			{
				obj = null;
				key = EntityKey.invalid;
			}
			else
			{
				obj = queryResult.obj;
			}
		}

		public void Get(int index, out Entity entity, out T obj)
		{
			QueryResult<T> queryResult = results[index];
			EntityKey key = queryResult.key;
			if (!entityManager.Exists(key))
			{
				obj = null;
				entity = Entity.invalid;
			}
			else if (!entityManager.HasObject(key, queryResult.typeIndex))
			{
				obj = null;
				entity = Entity.invalid;
			}
			else
			{
				obj = queryResult.obj;
				entity = new Entity(key, entityManager.world);
			}
		}

		public void Randomize(int seed)
		{
			results.Randomize(seed);
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void VerifyHasBeenRun()
		{
		}
	}
}
