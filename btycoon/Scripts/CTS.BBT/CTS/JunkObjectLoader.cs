using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS
{
	public static class JunkObjectLoader
	{
		private static Dictionary<string, JunkObjectParameters> _junkList;

		public static IEnumerable<JunkObjectParameters> GetLoadedJunk => _junkList.Values;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			_junkList = new Dictionary<string, JunkObjectParameters>();
			foreach (JunkObjectParameters item in Addressables.LoadAssetsAsync<JunkObjectParameters>("Junks").WaitForCompletion())
			{
				_junkList.TryAdd(item.name, item);
			}
		}

		public static bool TryGet(string id, out JunkObjectParameters furnitureData)
		{
			return _junkList.TryGetValue(id, out furnitureData);
		}
	}
}
