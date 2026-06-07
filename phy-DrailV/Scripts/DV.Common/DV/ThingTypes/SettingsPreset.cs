using System.Collections.Generic;
using DV.Common;
using UnityEngine;

namespace DV.ThingTypes
{
	public class SettingsPreset : IThing
	{
		private Dictionary<string, object> valueStore;

		public string Name { get; set; }

		public int DataVersion => 1;

		public IReadOnlyDictionary<string, object> Values => valueStore;

		public SettingsPreset(string name, Dictionary<string, object> valueStore)
		{
			Name = name;
			this.valueStore = valueStore;
		}

		public bool TryGetValue<T>(string key, out T result)
		{
			if (valueStore.TryGetValue(key, out var value))
			{
				if (typeof(T).IsAssignableFrom(value.GetType()))
				{
					result = (T)value;
					return true;
				}
				Debug.LogError("Bad type requested for key '" + key + "', Get<" + typeof(T).Name + "> but the value is <" + value.GetType().Name + ">");
				result = default(T);
				return false;
			}
			result = default(T);
			return false;
		}
	}
}
