using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;

namespace Aggro.Core
{
	public class EntityCoroutineManager
	{
		private class CoroutineEntry
		{
			public CoroutineType type;

			public EntityKey key;

			public Behaviour behaviour;

			public int behaviourTypeIndex;

			public Stack<IEnumerator> enumerators = new Stack<IEnumerator>();

			public EntityCoroutineId id;
		}

		private enum CoroutineType
		{
			EntityKey = 0,
			Behaviour = 1
		}

		private EntityManager _entityManager;

		private Stack<CoroutineEntry> _pool = new Stack<CoroutineEntry>();

		private List<CoroutineEntry> _coroutines = new List<CoroutineEntry>();

		private Dictionary<EntityCoroutineId, int> _idToIndex = new Dictionary<EntityCoroutineId, int>();

		private List<CoroutineEntry> _newCoroutines = new List<CoroutineEntry>();

		private List<EntityCoroutineId> _removeCoroutines = new List<EntityCoroutineId>();

		private ProfilerMarker _updateMarker;

		private int _managerId;

		private int _nextCoroutineId;

		private static int _nextManagerId = 1;

		public int runningCoroutinesCount => _coroutines.Count + _newCoroutines.Count;

		internal int managerId => _managerId;

		internal EntityCoroutineManager(EntityManager entityManager)
		{
			_managerId = _nextManagerId++;
			_entityManager = entityManager;
			_updateMarker = new ProfilerMarker("Entity Coroutines");
		}

		public void Update()
		{
			int count = _newCoroutines.Count;
			for (int i = 0; i < count; i++)
			{
				CoroutineEntry coroutineEntry = _newCoroutines[i];
				_idToIndex[coroutineEntry.id] = _coroutines.Count;
				_coroutines.Add(coroutineEntry);
			}
			_newCoroutines.Clear();
			count = _removeCoroutines.Count;
			for (int j = 0; j < count; j++)
			{
				RemoveCoroutineSwapBack(_removeCoroutines[j]);
			}
			_removeCoroutines.Clear();
			for (int k = 0; k < _coroutines.Count; k++)
			{
				CoroutineEntry coroutineEntry2 = _coroutines[k];
				if (!_entityManager.Exists(coroutineEntry2.key) || _entityManager.IsDying(coroutineEntry2.key))
				{
					if (RemoveCoroutineSwapBack(coroutineEntry2.id))
					{
						k--;
					}
				}
				else
				{
					if (!_entityManager.IsEnabled(coroutineEntry2.key))
					{
						continue;
					}
					if (coroutineEntry2.type == CoroutineType.Behaviour)
					{
						if (!_entityManager.HasObject(coroutineEntry2.key, coroutineEntry2.behaviourTypeIndex))
						{
							if (RemoveCoroutineSwapBack(coroutineEntry2.id))
							{
								k--;
							}
							continue;
						}
						if (!coroutineEntry2.behaviour.isActiveAndEnabled)
						{
							continue;
						}
					}
					StepEntryForward(coroutineEntry2);
					if (coroutineEntry2.enumerators.Count == 0 && RemoveCoroutineSwapBack(coroutineEntry2.id))
					{
						k--;
					}
				}
			}
		}

		private bool RemoveCoroutineSwapBack(EntityCoroutineId removingId)
		{
			if (_idToIndex.TryGetValue(removingId, out var value))
			{
				_idToIndex.Remove(removingId);
				CoroutineEntry entry = _coroutines[value];
				_coroutines.RemoveAtSwapBack(value);
				if (value < _coroutines.Count)
				{
					_idToIndex[_coroutines[value].id] = value;
				}
				ReleaseToPool(entry);
				return true;
			}
			return false;
		}

		public EntityCoroutineId StartCoroutine(EntityKey key, IEnumerator coroutine)
		{
			CoroutineEntry fromPool = GetFromPool();
			fromPool.type = CoroutineType.EntityKey;
			fromPool.key = key;
			fromPool.enumerators.Push(coroutine);
			fromPool.id = new EntityCoroutineId(_managerId, _nextCoroutineId++);
			_newCoroutines.Add(fromPool);
			StepEntryForward(fromPool);
			return fromPool.id;
		}

		public EntityCoroutineId StartCoroutine(Behaviour behaviour, EntityKey key, int typeIndex, IEnumerator coroutine)
		{
			CoroutineEntry fromPool = GetFromPool();
			fromPool.type = CoroutineType.Behaviour;
			fromPool.key = key;
			fromPool.behaviour = behaviour;
			fromPool.behaviourTypeIndex = typeIndex;
			fromPool.enumerators.Push(coroutine);
			fromPool.id = new EntityCoroutineId(_managerId, _nextCoroutineId++);
			_newCoroutines.Add(fromPool);
			StepEntryForward(fromPool);
			return fromPool.id;
		}

		public void StopCoroutine(EntityCoroutineId id)
		{
			_removeCoroutines.Add(id);
		}

		public bool IsRunningCoroutine(EntityCoroutineId id)
		{
			if (_idToIndex.ContainsKey(id))
			{
				return true;
			}
			int count = _newCoroutines.Count;
			for (int i = 0; i < count; i++)
			{
				if (_newCoroutines[i].id.Equals(id))
				{
					return true;
				}
			}
			return false;
		}

		private void StepEntryForward(CoroutineEntry entry)
		{
			try
			{
				IEnumerator result;
				while (entry.enumerators.TryPeek(out result))
				{
					if (result.Current is IEntityCoroutineYield entityCoroutineYield)
					{
						if (entityCoroutineYield.keepWaiting)
						{
							break;
						}
						entityCoroutineYield.ReleaseSelf();
					}
					if (result.MoveNext())
					{
						if (result.Current == null || result.Current is IEntityCoroutineYield)
						{
							break;
						}
						if (result.Current is IEnumerator item)
						{
							entry.enumerators.Push(item);
						}
					}
					else
					{
						entry.enumerators.Pop();
					}
				}
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				entry.enumerators.Clear();
			}
		}

		private CoroutineEntry GetFromPool()
		{
			if (!_pool.TryPop(out var result))
			{
				return new CoroutineEntry();
			}
			return result;
		}

		private void ReleaseToPool(CoroutineEntry entry)
		{
			entry.enumerators.Clear();
			_pool.Push(entry);
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNotNull(Behaviour behaviour)
		{
			if ((object)behaviour == null)
			{
				throw new NullReferenceException("Entity Behaviour is null!");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNotNull(IEnumerator coroutine)
		{
			if (coroutine == null)
			{
				throw new NullReferenceException("Coroutine is null!");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckValidEntity(EntityKey key)
		{
			if (!_entityManager.Exists(key))
			{
				throw new InvalidOperationException($"Invalid entity! ({key})");
			}
			if (_entityManager.IsDying(key))
			{
				if (_entityManager.TryGetObject<EntityBehaviour>(key, out var obj))
				{
					UnityEngine.Debug.LogError("Can't run a coroutine on a dying entity!", obj);
				}
				throw new InvalidOperationException($"Can't run a coroutine on a dying entity! ({key})!");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckValidYield(object current, CoroutineEntry entry)
		{
			if (current == null)
			{
				return;
			}
			string text = null;
			if (!(current is IEntityCoroutineYield) && !(current is IEnumerator))
			{
				text = ((!(current is YieldInstruction) && !(current is CustomYieldInstruction)) ? ("Unknown yield type! (" + TypeUtil.GetFriendlyName(current.GetType()) + ")") : "Unity's YieldInstructions (WaitFor*) not supported, use the Yield class instead!");
			}
			if (text != null)
			{
				EntityBehaviour obj;
				if (entry.behaviour != null)
				{
					UnityEngine.Debug.LogError(text, entry.behaviour);
				}
				else if (_entityManager.TryGetObject<EntityBehaviour>(entry.key, out obj))
				{
					UnityEngine.Debug.LogError(text, obj);
				}
				throw new InvalidOperationException(text);
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckValidId(EntityCoroutineId id)
		{
			if (!id.isValid)
			{
				throw new InvalidOperationException($"Invalid coroutine id! ({id})");
			}
			if (id.managerId != _managerId)
			{
				throw new InvalidOperationException($"Invalid coroutine manager id, trying to stop a coroutine with the wrong manager? ({id})");
			}
		}
	}
}
