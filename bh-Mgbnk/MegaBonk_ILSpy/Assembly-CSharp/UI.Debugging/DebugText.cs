using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Debugging;

public class DebugText : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<string, int> _003C_003E9__5_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CSortKeysByPriority_003Eb__5_0(string key)
		{
			//IL_0060: Expected I4, but got O
			if (debugPriority != null)
			{
				if (!debugPriority.ContainsKey(key))
				{
					return 2147483647;
				}
				if (debugPriority != null)
				{
					return debugPriority.get_Item(key);
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public static Dictionary<string, string> debugEntries;

	public static Dictionary<string, int> debugPriority;

	private static List<string> sortedKeys;

	private void OnGUI()
	{
	}

	public static void DebugValue(string key, string value, int priority = 0)
	{
		if (debugEntries.ContainsKey(key))
		{
			((Dictionary<object, object>)(object)debugEntries).set_Item((object)key, (object)value);
			((Dictionary<object, int>)(object)debugPriority).set_Item((object)key, priority);
		}
		else
		{
			((Dictionary<object, object>)(object)debugEntries).Add((object)key, (object)value);
			((Dictionary<object, int>)(object)debugPriority).Add((object)key, priority);
		}
		Dictionary<string, string>.KeyCollection keys = debugEntries.Keys;
		Func<string, int> keySelector = _003C_003Ec._003C_003E9__5_0;
		if (_003C_003Ec._003C_003E9__5_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__5_0 = delegate(string key2)
			{
				//IL_0060: Expected I4, but got O
				if (debugPriority != null)
				{
					if (!debugPriority.ContainsKey(key2))
					{
						return 2147483647;
					}
					if (debugPriority != null)
					{
						return debugPriority.get_Item(key2);
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			});
		}
		IOrderedEnumerable<string> source = Enumerable.OrderBy(keys, keySelector);
		List<object> list = Enumerable.ToList((IEnumerable<object>)source);
		sortedKeys = (List<string>)(object)list;
	}

	private static void SortKeysByPriority()
	{
		Dictionary<string, string>.KeyCollection keys = debugEntries.Keys;
		Func<string, int> keySelector = _003C_003Ec._003C_003E9__5_0;
		if (_003C_003Ec._003C_003E9__5_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__5_0 = delegate(string key)
			{
				//IL_0060: Expected I4, but got O
				if (debugPriority != null)
				{
					if (!debugPriority.ContainsKey(key))
					{
						return 2147483647;
					}
					if (debugPriority != null)
					{
						return debugPriority.get_Item(key);
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			});
		}
		IOrderedEnumerable<string> source = Enumerable.OrderBy(keys, keySelector);
		List<object> list = Enumerable.ToList((IEnumerable<object>)source);
		sortedKeys = (List<string>)(object)list;
	}

	static DebugText()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		debugEntries = dictionary;
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		debugPriority = dictionary2;
		List<string> list = new List<string>();
		sortedKeys = list;
	}
}
