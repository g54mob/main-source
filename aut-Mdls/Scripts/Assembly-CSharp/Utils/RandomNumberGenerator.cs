using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
	public class RandomNumberGenerator<T>
	{
		private class RandomItem<T>
		{
			public T Item;

			public double Possibility;

			public RandomItem(T item, double possibility)
			{
				Item = item;
				Possibility = possibility;
			}
		}

		private List<RandomItem<T>> _items = new List<RandomItem<T>>();

		private Random _random = new Random();

		public void Add(double possibility, T item)
		{
			_items.Add(new RandomItem<T>(item, possibility));
		}

		public T NextItem()
		{
			double num = _random.NextDouble() * _items.Sum((RandomItem<T> x) => x.Possibility);
			double num2 = 0.0;
			foreach (RandomItem<T> item in _items)
			{
				num2 += item.Possibility;
				if (num <= num2)
				{
					return item.Item;
				}
			}
			return _items.Last().Item;
		}
	}
}
