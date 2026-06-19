using System.Collections.Generic;
using Loxodon.Log;

namespace Loxodon.Framework.Binding.Registry
{
	public class KeyValueRegistry<K, V> : IKeyValueRegistry<K, V>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(KeyValueRegistry<K, V>));

		protected readonly Dictionary<K, V> lookups = new Dictionary<K, V>();

		public virtual V Find(K key)
		{
			lookups.TryGetValue(key, out var value);
			return value;
		}

		public virtual V Find(K key, V defaultValue)
		{
			if (lookups.TryGetValue(key, out var value))
			{
				return value;
			}
			return defaultValue;
		}

		public virtual void Register(K key, V value)
		{
			if (lookups.ContainsKey(key) && log.IsWarnEnabled)
			{
				log.WarnFormat("The Key({0}) already exists", key);
			}
			lookups[key] = value;
		}

		public virtual void Unregister(K key)
		{
			lookups.Remove(key);
		}
	}
}
