using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	public class SafeEnumerable<TKey, TValue>
	{
		private readonly Dictionary<TKey, TValue> _dataDict = new Dictionary<TKey, TValue>();

		private readonly Dictionary<TKey, TValue> _enumerator = new Dictionary<TKey, TValue>();

		private bool _isEnumerating;

		public TValue this[TKey key]
		{
			get
			{
				return _dataDict[key];
			}
			set
			{
				_dataDict[key] = value;
			}
		}

		public bool ContainsKey(TKey key)
		{
			return _dataDict.ContainsKey(key);
		}

		public bool ContainsValue(TValue value)
		{
			return _dataDict.ContainsValue(value);
		}

		public void Clear()
		{
			_dataDict.Clear();
		}

		public void Add(TKey key, TValue value)
		{
			_dataDict.Add(key, value);
		}

		public void Remove(TKey key)
		{
			_dataDict.Remove(key);
		}

		public Dictionary<TKey, TValue> ToDictionary()
		{
			return new Dictionary<TKey, TValue>(_dataDict);
		}

		public void ToDictionary(Dictionary<TKey, TValue> dict)
		{
			dict.Clear();
			foreach (KeyValuePair<TKey, TValue> item in _dataDict)
			{
				dict[item.Key] = item.Value;
			}
		}

		private void PrepareLoop()
		{
			if (_isEnumerating)
			{
				throw new Exception("Safe Enumerable is already enumerating.");
			}
			_enumerator.Clear();
			foreach (KeyValuePair<TKey, TValue> item in _dataDict)
			{
				_enumerator.Add(item.Key, item.Value);
			}
		}

		public void Enumerate(Action<TKey, TValue> function)
		{
			if (_dataDict.Count <= 0)
			{
				return;
			}
			PrepareLoop();
			_isEnumerating = true;
			foreach (KeyValuePair<TKey, TValue> item in _enumerator)
			{
				item.Deconstruct(out var key, out var value);
				TKey val = key;
				TValue val2 = value;
				if (!_dataDict.ContainsKey(val))
				{
					continue;
				}
				value = _dataDict[val];
				if (value.Equals(val2))
				{
					try
					{
						function(val, val2);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			_isEnumerating = false;
		}

		public void Enumerate<TArg>(Action<TKey, TValue, TArg> function, TArg arg)
		{
			if (_dataDict.Count <= 0)
			{
				return;
			}
			PrepareLoop();
			_isEnumerating = true;
			foreach (KeyValuePair<TKey, TValue> item in _enumerator)
			{
				item.Deconstruct(out var key, out var value);
				TKey val = key;
				TValue val2 = value;
				if (!_dataDict.ContainsKey(val))
				{
					continue;
				}
				value = _dataDict[val];
				if (value.Equals(val2))
				{
					try
					{
						function(val, val2, arg);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			_isEnumerating = false;
		}

		public void Enumerate<TArg1, TArg2>(Action<TKey, TValue, TArg1, TArg2> function, TArg1 arg1, TArg2 arg2)
		{
			if (_dataDict.Count <= 0)
			{
				return;
			}
			PrepareLoop();
			_isEnumerating = true;
			foreach (KeyValuePair<TKey, TValue> item in _enumerator)
			{
				item.Deconstruct(out var key, out var value);
				TKey val = key;
				TValue val2 = value;
				if (!_dataDict.ContainsKey(val))
				{
					continue;
				}
				value = _dataDict[val];
				if (value.Equals(val2))
				{
					try
					{
						function(val, val2, arg1, arg2);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			_isEnumerating = false;
		}

		public void Enumerate<TArg1, TArg2, TArg3>(Action<TKey, TValue, TArg1, TArg2, TArg3> function, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			if (_dataDict.Count <= 0)
			{
				return;
			}
			PrepareLoop();
			_isEnumerating = true;
			foreach (KeyValuePair<TKey, TValue> item in _enumerator)
			{
				item.Deconstruct(out var key, out var value);
				TKey val = key;
				TValue val2 = value;
				if (!_dataDict.ContainsKey(val))
				{
					continue;
				}
				value = _dataDict[val];
				if (value.Equals(val2))
				{
					try
					{
						function(val, val2, arg1, arg2, arg3);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			_isEnumerating = false;
		}
	}
	public class SafeEnumerable<T>
	{
		private readonly List<T> _dataList = new List<T>();

		private readonly List<T> _enumerateList = new List<T>();

		private bool _isEnumerating;

		public int Count => _dataList.Count;

		public T this[int index] => _dataList[index];

		public T this[Index index]
		{
			get
			{
				List<T> dataList = _dataList;
				return dataList[index.GetOffset(dataList.Count)];
			}
		}

		public bool Contains(T obj)
		{
			return _dataList.Contains(obj);
		}

		public void Clear()
		{
			_dataList.Clear();
		}

		public void Add(T data)
		{
			_dataList.Add(data);
		}

		public void Remove(T data)
		{
			_dataList.Remove(data);
		}

		private void PrepareLoop()
		{
			if (_isEnumerating)
			{
				throw new Exception("Safe Enumerator is already enumerating");
			}
			_enumerateList.Clear();
			_enumerateList.AddRange(_dataList);
		}

		public void Enumerate(Action<T> function)
		{
			if (_dataList.Count <= 0)
			{
				return;
			}
			PrepareLoop();
			_isEnumerating = true;
			foreach (T enumerate in _enumerateList)
			{
				if (_dataList.Contains(enumerate))
				{
					try
					{
						function(enumerate);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			_isEnumerating = false;
		}

		public void Enumerate<TArg>(Action<T, TArg> function, TArg arg)
		{
			if (_dataList.Count <= 0)
			{
				return;
			}
			PrepareLoop();
			_isEnumerating = true;
			foreach (T enumerate in _enumerateList)
			{
				if (_dataList.Contains(enumerate))
				{
					try
					{
						function(enumerate, arg);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			_isEnumerating = false;
		}

		public void Enumerate<TArg1, TArg2>(Action<T, TArg1, TArg2> function, TArg1 arg1, TArg2 arg2)
		{
			if (_dataList.Count <= 0)
			{
				return;
			}
			PrepareLoop();
			_isEnumerating = true;
			foreach (T enumerate in _enumerateList)
			{
				if (_dataList.Contains(enumerate))
				{
					try
					{
						function(enumerate, arg1, arg2);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			_isEnumerating = false;
		}

		public void Enumerate<TArg1, TArg2, TArg3>(Action<T, TArg1, TArg2, TArg3> function, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			if (_dataList.Count <= 0)
			{
				return;
			}
			PrepareLoop();
			_isEnumerating = true;
			foreach (T enumerate in _enumerateList)
			{
				if (_dataList.Contains(enumerate))
				{
					try
					{
						function(enumerate, arg1, arg2, arg3);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			_isEnumerating = false;
		}
	}
}
