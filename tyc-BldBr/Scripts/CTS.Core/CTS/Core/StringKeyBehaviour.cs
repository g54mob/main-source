using System.Collections.Generic;

namespace CTS.Core
{
	internal static class StringKeyBehaviour
	{
		private static readonly Dictionary<string, uint> _ids = new Dictionary<string, uint>();

		private static uint _currentId = 1u;

		public static uint GetID(ref string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return 0u;
			}
			if (!_ids.TryGetValue(name, out var value))
			{
				value = _currentId;
				_currentId++;
				if (_currentId == 0)
				{
					_currentId++;
				}
				_ids[name] = value;
			}
			return value;
		}

		public static bool TryGetID(ref string name, out uint outId)
		{
			if (string.IsNullOrEmpty(name))
			{
				outId = 0u;
				return false;
			}
			return _ids.TryGetValue(name, out outId);
		}

		public static string ToString(ref bool useScriptable, ScriptableStringKey scriptable, ref string stringKey)
		{
			if (useScriptable)
			{
				if ((bool)scriptable)
				{
					return scriptable.Key;
				}
				return "Null";
			}
			return stringKey;
		}
	}
}
