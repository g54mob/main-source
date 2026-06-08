using System.Collections.Generic;
using UnityEngine;

namespace Themee
{
	public class BakedStyle
	{
		private Dictionary<string, object> fields;

		private List<string> clears;

		public void Write(BakedStyle other)
		{
		}

		public void Bake(Transform transform)
		{
		}

		public object GetValue(string key)
		{
			return null;
		}

		public bool TryGet<T>(string key, out T value)
		{
			value = default(T);
			return false;
		}

		public T Get<T>(string key, T defaultValue = default(T))
		{
			return default(T);
		}
	}
}
