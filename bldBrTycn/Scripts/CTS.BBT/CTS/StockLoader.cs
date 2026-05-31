using System.Collections.Generic;
using CTS.BBT;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS
{
	public class StockLoader
	{
		private static Dictionary<string, StockItemSO> _stockList;

		public static IEnumerable<StockItemSO> GetLoadedStockables => _stockList.Values;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialize()
		{
			_stockList = new Dictionary<string, StockItemSO>();
			foreach (StockItemSO item in Addressables.LoadAssetsAsync<StockItemSO>("Stockables").WaitForCompletion())
			{
				_stockList.TryAdd(item.name, item);
			}
		}

		public static bool TryGet(string id, out StockItemSO furnitureData)
		{
			return _stockList.TryGetValue(id, out furnitureData);
		}
	}
}
