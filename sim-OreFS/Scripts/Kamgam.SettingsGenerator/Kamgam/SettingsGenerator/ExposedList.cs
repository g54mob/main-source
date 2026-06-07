using System;
using System.Collections.Generic;

namespace Kamgam.SettingsGenerator
{
	public class ExposedList<T> where T : class
	{
		public const int k_DefaultCapacity = 10;

		private const int k_MaxAutoIncrease = 1000;

		private int _capacity;

		public T[] Values;

		public int Capacity
		{
			get
			{
				return _capacity;
			}
			set
			{
				resizeTo(value);
			}
		}

		public ExposedList()
		{
			Values = new T[10];
			Clear();
		}

		public ExposedList(int capacity)
		{
			Values = new T[capacity];
			Clear();
		}

		public ExposedList(IList<T> list)
		{
			if (list == null)
			{
				Values = new T[10];
				Clear();
				return;
			}
			Values = new T[list.Count];
			for (int i = 0; i < Values.Length; i++)
			{
				Values[i] = list[i];
			}
		}

		protected void resizeTo(int newCapacity)
		{
			_capacity = newCapacity;
			if (Values.Length != _capacity)
			{
				T[] values = Values;
				Values = new T[newCapacity];
				Clear();
				int num = Math.Min(newCapacity, values.Length);
				for (int i = 0; i < num; i++)
				{
					Values[i] = values[i];
				}
			}
		}

		protected void autoIncreaseCapacity()
		{
			int newCapacity = Values.Length + Math.Min(1000, Values.Length / 2);
			resizeTo(newCapacity);
		}

		public void Clear()
		{
			for (int i = 0; i < Values.Length; i++)
			{
				Values[i] = null;
			}
		}

		public void Add(T value)
		{
			if (value == null)
			{
				return;
			}
			for (int i = 0; i < Values.Length; i++)
			{
				if (Values[i] == null)
				{
					Values[i] = value;
					return;
				}
			}
			int num = Values.Length;
			autoIncreaseCapacity();
			Values[num] = value;
		}

		public void Add(IList<T> values)
		{
			if (values == null)
			{
				return;
			}
			foreach (T value in values)
			{
				Add(value);
			}
		}

		public void Remove(T value)
		{
			if (value == null)
			{
				return;
			}
			for (int i = 0; i < Values.Length; i++)
			{
				if (Values[i] == value)
				{
					Values[i] = null;
				}
			}
		}

		protected bool Contains(T value)
		{
			if (value == null)
			{
				return false;
			}
			for (int i = 0; i < Values.Length; i++)
			{
				if (Values[i] == value)
				{
					return true;
				}
			}
			return false;
		}
	}
}
