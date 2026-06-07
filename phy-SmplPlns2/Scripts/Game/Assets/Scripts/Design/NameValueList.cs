using System;
using System.Collections.Generic;

namespace Assets.Scripts.Design
{
	public class NameValueList<T> where T : IComparable
	{
		private List<KeyValuePair<string, T>> _list;

		public NameValueList()
		{
			_list = new List<KeyValuePair<string, T>>();
		}

		public void Add(string name, T value)
		{
			foreach (KeyValuePair<string, T> item in _list)
			{
				if (item.Key == name)
				{
					throw new Exception("List already contains name: " + name);
				}
			}
			_list.Add(new KeyValuePair<string, T>(name, value));
		}

		public string GetNameFromValue(T value)
		{
			foreach (KeyValuePair<string, T> item in _list)
			{
				if (item.Value.CompareTo(value) >= 0)
				{
					return item.Key;
				}
			}
			return _list[0].Key;
		}

		public T GetValueFromName(string name)
		{
			foreach (KeyValuePair<string, T> item in _list)
			{
				if (item.Key == name)
				{
					return item.Value;
				}
			}
			return _list[0].Value;
		}

		public string NextName(string currentName)
		{
			int num = 0;
			for (int i = 0; i < _list.Count; i++)
			{
				if (_list[i].Key == currentName)
				{
					num = i + 1;
					break;
				}
			}
			if (num >= _list.Count)
			{
				num = 0;
			}
			return _list[num].Key;
		}

		public string PreviousValue(string currentName)
		{
			int num = 0;
			for (int i = 0; i < _list.Count; i++)
			{
				if (_list[i].Key == currentName)
				{
					num = i - 1;
					break;
				}
			}
			if (num < 0)
			{
				num = _list.Count - 1;
			}
			return _list[num].Key;
		}
	}
}
