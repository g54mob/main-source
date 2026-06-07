using System.Collections.Generic;

namespace Utils
{
	public static class IntIdGenerator
	{
		private static int _lastIdKnown = 0;

		private static readonly Dictionary<string, int> _idDictionary = new Dictionary<string, int>();

		public static int GetNewId => _lastIdKnown++;

		public static void Reset()
		{
			_lastIdKnown = 0;
			_idDictionary.Clear();
		}

		public static int GetNewIdOfKey(string key)
		{
			_idDictionary.TryAdd(key, 0);
			return _idDictionary[key]++;
		}
	}
}
