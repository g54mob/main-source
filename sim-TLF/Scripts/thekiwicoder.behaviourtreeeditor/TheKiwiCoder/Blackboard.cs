using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder
{
	[Serializable]
	public class Blackboard
	{
		[SerializeReference]
		public List<BlackboardKey> keys = new List<BlackboardKey>();

		public BlackboardKey Find(string keyName)
		{
			return keys.Find((BlackboardKey key) => key.name == keyName);
		}

		public BlackboardKey<T> Find<T>(string keyName)
		{
			BlackboardKey blackboardKey = Find(keyName);
			if (blackboardKey == null)
			{
				Debug.LogWarning("Failed to find blackboard key, invalid keyname:" + keyName);
				return null;
			}
			if (blackboardKey.underlyingType != typeof(T))
			{
				Debug.LogWarning($"Failed to find blackboard key, invalid keytype:{typeof(T)}, Expected:{blackboardKey.underlyingType}");
				return null;
			}
			if (!(blackboardKey is BlackboardKey<T> result))
			{
				Debug.LogWarning($"Failed to find blackboard key, casting failed:{typeof(T)}, Expected:{blackboardKey.underlyingType}");
				return null;
			}
			return result;
		}

		public void SetValue<T>(string keyName, T value)
		{
			BlackboardKey<T> blackboardKey = Find<T>(keyName);
			if (blackboardKey != null)
			{
				blackboardKey.value = value;
			}
		}

		public T GetValue<T>(string keyName)
		{
			BlackboardKey<T> blackboardKey = Find<T>(keyName);
			if (blackboardKey != null)
			{
				return blackboardKey.value;
			}
			return default(T);
		}
	}
}
