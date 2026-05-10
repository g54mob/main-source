using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS.Core
{
	[DefaultExecutionOrder(20000)]
	public class UpdateSpreader : MonoPersistentSingleton<UpdateSpreader>
	{
		public class SafeOrderedList<T>
		{
			private struct OrderedData : IEquatable<OrderedData>, IEquatable<T>, IComparable<OrderedData>
			{
				public int Order;

				public T Data;

				public OrderedData(T data, int order)
				{
					Data = data;
					Order = order;
				}

				public bool Equals(OrderedData other)
				{
					return Equals(other.Data);
				}

				public bool Equals(T other)
				{
					return EqualityComparer<T>.Default.Equals(Data, other);
				}

				public int CompareTo(OrderedData other)
				{
					if (other.Order < Order)
					{
						return 1;
					}
					if (other.Order == Order)
					{
						return 0;
					}
					return -1;
				}

				public override bool Equals(object obj)
				{
					if (obj is OrderedData orderedData)
					{
						return Equals(orderedData.Data);
					}
					if (obj is T other)
					{
						return Equals(other);
					}
					return false;
				}

				public override int GetHashCode()
				{
					return Data.GetHashCode();
				}
			}

			public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
			{
				private readonly SafeOrderedList<T> _list;

				private readonly Guid _userGuid;

				private int _currentIndex;

				public T Current => _list._dataList[_currentIndex].Data;

				object IEnumerator.Current => Current;

				public Enumerator(SafeOrderedList<T> list)
				{
					_list = list;
					_currentIndex = -1;
					_userGuid = Guid.NewGuid();
				}

				public bool MoveNext()
				{
					_currentIndex++;
					if (_currentIndex == 0)
					{
						_list.AddEnumerator(_userGuid);
					}
					return _currentIndex < _list._dataList.Count;
				}

				public void Reset()
				{
				}

				public void Dispose()
				{
					_list.RemoveEnumerator(_userGuid);
				}
			}

			private readonly List<OrderedData> _dataList = new List<OrderedData>();

			private readonly List<(T, int, bool)> _operationCache = new List<(T, int, bool)>();

			private readonly HashSet<Guid> _enumerators = new HashSet<Guid>();

			private bool _isEnumerating => _enumerators.Count > 0;

			public void Clear()
			{
				_dataList.Clear();
				_operationCache.Clear();
			}

			public void Add(T data, int order = 0)
			{
				if (_isEnumerating)
				{
					_operationCache.Add((data, order, true));
					return;
				}
				DoAdd(data, order);
				_dataList.Sort();
			}

			private void DoAdd(T data, int order)
			{
				DoRemove(data);
				_dataList.Add(new OrderedData(data, order));
			}

			public void Remove(T data)
			{
				if (_isEnumerating)
				{
					_operationCache.Add((data, 0, false));
				}
				else
				{
					DoRemove(data);
				}
			}

			private void DoRemove(T data)
			{
				_dataList.Remove(new OrderedData(data, 0));
			}

			private void ProcessOperationCache()
			{
				if (_operationCache.Count <= 0)
				{
					return;
				}
				foreach (var item in _operationCache)
				{
					var (data, order, _) = item;
					if (item.Item3)
					{
						DoAdd(data, order);
					}
					else
					{
						DoRemove(data);
					}
				}
				_dataList.Sort();
				_operationCache.Clear();
			}

			private void AddEnumerator(Guid guid)
			{
				_enumerators.Contains(guid);
				_enumerators.Add(guid);
			}

			private void RemoveEnumerator(Guid guid)
			{
				_enumerators.Contains(guid);
				_enumerators.Remove(guid);
				if (_enumerators.Count <= 0)
				{
					ProcessOperationCache();
				}
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(this);
			}
		}

		private class SpreadPool
		{
			private readonly List<ISpreadUpdatable> _updates = new List<ISpreadUpdatable>();

			private float _ratio;

			private float _time;

			private int _currentIndex;

			public float Distribution { get; set; } = 0.5f;

			public void AddUpdater(ISpreadUpdatable updatable)
			{
				RemoveUpdater(updatable);
				_updates.Add(updatable);
				_ratio = Distribution / (float)_updates.Count;
			}

			public void RemoveUpdater(ISpreadUpdatable updatable)
			{
				_updates.Remove(updatable);
				if (_updates.Count > 0)
				{
					_ratio = Distribution / (float)_updates.Count;
				}
			}

			public void Tick(float deltaTime)
			{
				if (_updates.Count <= 0)
				{
					return;
				}
				_time += deltaTime;
				while (_time > _ratio)
				{
					if (_currentIndex >= _updates.Count)
					{
						_currentIndex = 0;
					}
					try
					{
						_updates[_currentIndex].SpreadUpdate();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					_currentIndex++;
					_time -= _ratio;
				}
			}

			internal void CleanUpdaters()
			{
				for (int num = _updates.Count - 1; num >= 0; num--)
				{
					ISpreadUpdatable spreadUpdatable = _updates[num];
					if (spreadUpdatable is MonoBehaviour monoBehaviour && monoBehaviour == null)
					{
						_updates.Remove(spreadUpdatable);
					}
				}
			}
		}

		private static readonly Dictionary<int, SpreadPool> SpreadPools = new Dictionary<int, SpreadPool>();

		private static bool _spreadPoolsTicking = false;

		private static readonly List<(ISpreadUpdatable, bool)> _operationCache = new List<(ISpreadUpdatable, bool)>();

		private static readonly SafeOrderedList<IUpdatable> Updates = new SafeOrderedList<IUpdatable>();

		private static readonly SafeOrderedList<ILateUpdatable> LateUpdates = new SafeOrderedList<ILateUpdatable>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		private static void Init()
		{
			SpreadPools.Clear();
			Updates.Clear();
			LateUpdates.Clear();
			SceneManager.sceneUnloaded += OnSceneUnloaded;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void SpawnSpreader()
		{
			MonoSingleton<UpdateSpreader>.GetOrCreateInstance();
		}

		protected override void SingletonAwake()
		{
		}

		private static void OnSceneUnloaded(Scene scene)
		{
			foreach (SpreadPool value in SpreadPools.Values)
			{
				value.CleanUpdaters();
			}
		}

		public static void Add(ISpreadUpdatable updatable)
		{
			if (_spreadPoolsTicking)
			{
				_operationCache.Add((updatable, true));
				return;
			}
			int hashCode = updatable.TickKey.GetHashCode();
			SpreadPools.EnsureKeyExists(hashCode);
			SpreadPools[hashCode].AddUpdater(updatable);
		}

		public static void Remove(ISpreadUpdatable updatable)
		{
			if (_spreadPoolsTicking)
			{
				_operationCache.Add((updatable, false));
				return;
			}
			int hashCode = updatable.TickKey.GetHashCode();
			if (SpreadPools.ContainsKey(hashCode))
			{
				SpreadPools[hashCode].RemoveUpdater(updatable);
			}
		}

		public static void AddUpdate(IUpdatable updatable, int order = 0)
		{
			RemoveUpdate(updatable);
			Updates.Add(updatable, order);
		}

		public static void RemoveUpdate(IUpdatable updatable)
		{
			Updates.Remove(updatable);
		}

		public static void AddLateUpdate(ILateUpdatable updatable, int order = 0)
		{
			RemoveLateUpdate(updatable);
			LateUpdates.Add(updatable, order);
		}

		public static void RemoveLateUpdate(ILateUpdatable updatable)
		{
			LateUpdates.Remove(updatable);
		}

		private void Update()
		{
			_spreadPoolsTicking = true;
			float deltaTime = Time.deltaTime;
			foreach (KeyValuePair<int, SpreadPool> spreadPool in SpreadPools)
			{
				spreadPool.Deconstruct(out var _, out var value);
				value.Tick(deltaTime);
			}
			_spreadPoolsTicking = false;
			foreach (var item in _operationCache)
			{
				var (updatable, _) = item;
				if (item.Item2)
				{
					Add(updatable);
				}
				else
				{
					Remove(updatable);
				}
			}
			_operationCache.Clear();
			foreach (IUpdatable update in Updates)
			{
				try
				{
					update.OnUpdate();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private void LateUpdate()
		{
			foreach (ILateUpdatable lateUpdate in LateUpdates)
			{
				try
				{
					lateUpdate.OnLateUpdate();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		protected override void OnSingletonDestroy()
		{
			SpreadPools.Clear();
		}
	}
}
