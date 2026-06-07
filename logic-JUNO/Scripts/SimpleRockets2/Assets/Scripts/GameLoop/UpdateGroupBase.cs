using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameLoop
{
	[Serializable]
	internal abstract class UpdateGroupBase<T> : IUpdateGroup where T : class, IGameLoopItem
	{
		[Serializable]
		protected class Subset
		{
			public readonly int ExecutionOrder;

			[SerializeField]
			public int Count;

			public T[] Items;

			private Dictionary<int, int> _indexLookup;

			private HashSet<T> _pendingRegistrations;

			private HashSet<T> _pendingUnregistrations;

			private UpdateGroupBase<T> _updateGroup;

			public Subset(UpdateGroupBase<T> updateGroup, int executionOrder)
			{
				_updateGroup = updateGroup;
				ExecutionOrder = executionOrder;
				Items = new T[10];
				_indexLookup = new Dictionary<int, int>(10);
				_pendingRegistrations = new HashSet<T>();
				_pendingUnregistrations = new HashSet<T>();
				Count = 0;
			}

			public void ClearRegisteredItems()
			{
				for (int i = 0; i < Count; i++)
				{
					Items[i] = null;
				}
				_indexLookup.Clear();
				_pendingUnregistrations.Clear();
				Count = 0;
			}

			public IEnumerable<T> GetRegisteredItems()
			{
				return Items.Take(Count);
			}

			public void ProcessPendingRegistrations()
			{
				foreach (T pendingRegistration in _pendingRegistrations)
				{
					try
					{
						RegisterImmediate(pendingRegistration);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				_pendingRegistrations.Clear();
			}

			public void ProcessPendingUnregistrations()
			{
				foreach (T pendingUnregistration in _pendingUnregistrations)
				{
					try
					{
						UnregisterImmediate(pendingUnregistration);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				_pendingUnregistrations.Clear();
			}

			public void Register(T item)
			{
				if (_updateGroup._executing)
				{
					if (!_pendingUnregistrations.Remove(item))
					{
						_pendingRegistrations.Add(item);
					}
				}
				else
				{
					RegisterImmediate(item);
				}
			}

			public void Unregister(T item)
			{
				if (_updateGroup._executing)
				{
					if (!_pendingRegistrations.Remove(item))
					{
						_pendingUnregistrations.Add(item);
					}
				}
				else
				{
					UnregisterImmediate(item);
				}
			}

			private void RegisterImmediate(T item)
			{
				if (Count == Items.Length)
				{
					Array.Resize(ref Items, Items.Length * 2);
				}
				int instanceID = item.GetInstanceID();
				_indexLookup.Add(instanceID, Count);
				Items[Count] = item;
				Count++;
			}

			private void UnregisterImmediate(T item)
			{
				int instanceID = item.GetInstanceID();
				if (_indexLookup.TryGetValue(instanceID, out var value))
				{
					Count--;
					if (value != Count)
					{
						T val = Items[Count];
						int instanceID2 = val.GetInstanceID();
						_indexLookup[instanceID2] = value;
						Items[value] = val;
					}
					Items[Count] = null;
					_indexLookup.Remove(instanceID);
				}
				else
				{
					Debug.LogError($"Failed to unregister game object {instanceID} - {(item as MonoBehaviour).name}");
				}
			}
		}

		protected UpdateGroupDebugCallback _debugCallback;

		protected bool _executing;

		protected IGameLoop _gameLoop;

		protected Subset _subset;

		protected SortedList<int, Subset> _subsets;

		public bool Executing
		{
			get
			{
				return _executing;
			}
			set
			{
				_executing = value;
			}
		}

		public UpdateGroupBase(IGameLoop gameLoop)
		{
			_gameLoop = gameLoop;
			_subsets = new SortedList<int, Subset>(1);
		}

		public void BeginUpdate(UpdateGroupDebugCallback debugCallback)
		{
			_executing = true;
			_debugCallback = debugCallback;
		}

		public abstract void EndUpdate();

		public void Register(T item, int executionOrder)
		{
			GetSubset(executionOrder).Register(item);
		}

		public void Unregister(T item, int executionOrder)
		{
			GetSubset(executionOrder).Unregister(item);
		}

		private Subset GetSubset(int executionOrder)
		{
			if (!_subsets.TryGetValue(executionOrder, out var value))
			{
				value = new Subset(this, executionOrder);
				_subsets.Add(executionOrder, value);
			}
			return value;
		}
	}
}
