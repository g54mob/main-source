using System;
using System.Collections.Generic;

namespace GPUInstancerPro
{
	public abstract class GPUIDataProvider<K, T> : IGPUIDisposable, IDisposable
	{
		protected Dictionary<K, T> _dataDict;

		public bool IsInitialized { get; protected set; }

		public int Count
		{
			get
			{
				if (_dataDict == null)
				{
					return 0;
				}
				return _dataDict.Count;
			}
		}

		public Dictionary<K, T>.ValueCollection Values
		{
			get
			{
				if (_dataDict == null)
				{
					return null;
				}
				return _dataDict.Values;
			}
		}

		public virtual void Initialize()
		{
			IsInitialized = true;
			if (_dataDict == null)
			{
				_dataDict = new Dictionary<K, T>();
			}
		}

		public virtual void ReleaseBuffers()
		{
			IsInitialized = false;
		}

		public virtual void Dispose()
		{
			ReleaseBuffers();
			_dataDict = null;
		}

		public virtual void Reset()
		{
			Dispose();
			Initialize();
		}

		public virtual bool TryGetData(K key, out T result)
		{
			if (!IsInitialized)
			{
				result = default(T);
				return false;
			}
			return _dataDict.TryGetValue(key, out result);
		}

		public virtual bool Remove(K key)
		{
			if (IsInitialized)
			{
				return _dataDict.Remove(key);
			}
			return false;
		}

		public virtual bool AddOrSet(K key, T value)
		{
			if (!IsInitialized)
			{
				return false;
			}
			_dataDict[key] = value;
			return true;
		}

		public virtual T GetFirstValue()
		{
			if (!IsInitialized)
			{
				return default(T);
			}
			Dictionary<K, T>.Enumerator enumerator = _dataDict.GetEnumerator();
			enumerator.MoveNext();
			return enumerator.Current.Value;
		}

		public virtual T GetValueAtIndex(int index)
		{
			if (!IsInitialized || _dataDict.Count <= index)
			{
				return default(T);
			}
			Dictionary<K, T>.Enumerator enumerator = _dataDict.GetEnumerator();
			for (int i = 0; i <= index; i++)
			{
				enumerator.MoveNext();
			}
			return enumerator.Current.Value;
		}

		public virtual KeyValuePair<K, T> GetKVPairAtIndex(int index)
		{
			if (!IsInitialized || _dataDict.Count <= index)
			{
				return default(KeyValuePair<K, T>);
			}
			Dictionary<K, T>.Enumerator enumerator = _dataDict.GetEnumerator();
			for (int i = 0; i <= index; i++)
			{
				enumerator.MoveNext();
			}
			return enumerator.Current;
		}

		public Dictionary<K, T>.Enumerator GetEnumerator()
		{
			if (!IsInitialized)
			{
				return default(Dictionary<K, T>.Enumerator);
			}
			return _dataDict.GetEnumerator();
		}

		public bool ContainsKey(K key)
		{
			if (!IsInitialized)
			{
				return false;
			}
			return _dataDict.ContainsKey(key);
		}

		public virtual bool ContainsValue(T value)
		{
			if (!IsInitialized)
			{
				return false;
			}
			return _dataDict.ContainsValue(value);
		}
	}
}
