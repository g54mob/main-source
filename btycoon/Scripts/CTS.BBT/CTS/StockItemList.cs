using CTS.BBT;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Stocks/Stock Populator")]
	public class StockItemList : ScriptableObject
	{
		[field: SerializeField]
		public StockItemSO[] Items { get; private set; }
	}
}
