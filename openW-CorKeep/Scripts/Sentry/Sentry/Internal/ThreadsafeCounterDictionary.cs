using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace Sentry.Internal
{
	internal class ThreadsafeCounterDictionary<TKey> : IReadOnlyDictionary<TKey, int>, IEnumerable<KeyValuePair<TKey, int>>, IEnumerable, IReadOnlyCollection<KeyValuePair<TKey, int>> where TKey : notnull
	{
		private class CounterItem
		{
			private int _value;

			public int Value => _value;

			public void Add(int quantity)
			{
				Interlocked.Add(ref _value, quantity);
			}

			public void Increment()
			{
				Interlocked.Increment(ref _value);
			}

			public int ReadAndReset()
			{
				return Interlocked.Exchange(ref _value, 0);
			}
		}

		private readonly ConcurrentDictionary<TKey, CounterItem> _items = new ConcurrentDictionary<TKey, CounterItem>();

		public int Count => _items.Count;

		public int this[TKey key]
		{
			get
			{
				if (!_items.TryGetValue(key, out CounterItem value))
				{
					return 0;
				}
				return value.Value;
			}
		}

		public IEnumerable<TKey> Keys => _items.Keys;

		public IEnumerable<int> Values => _items.Values.Select((CounterItem x) => x.Value);

		public void Add(TKey key, int quantity)
		{
			_items.GetOrAdd(key, new CounterItem()).Add(quantity);
		}

		public void Increment(TKey key)
		{
			_items.GetOrAdd(key, new CounterItem()).Increment();
		}

		public int ReadAndReset(TKey key)
		{
			if (!_items.TryGetValue(key, out CounterItem value))
			{
				return 0;
			}
			return value.ReadAndReset();
		}

		public IReadOnlyDictionary<TKey, int> ReadAllAndReset()
		{
			return new ReadOnlyDictionary<TKey, int>(_items.ToDictionary<KeyValuePair<TKey, CounterItem>, TKey, int>((KeyValuePair<TKey, CounterItem> x) => x.Key, (KeyValuePair<TKey, CounterItem> x) => x.Value.ReadAndReset()));
		}

		public IEnumerator<KeyValuePair<TKey, int>> GetEnumerator()
		{
			return _items.Select<KeyValuePair<TKey, CounterItem>, KeyValuePair<TKey, int>>((KeyValuePair<TKey, CounterItem> x) => new KeyValuePair<TKey, int>(x.Key, x.Value.Value)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public bool ContainsKey(TKey key)
		{
			return _items.ContainsKey(key);
		}

		public bool TryGetValue(TKey key, out int value)
		{
			value = this[key];
			return true;
		}
	}
}
