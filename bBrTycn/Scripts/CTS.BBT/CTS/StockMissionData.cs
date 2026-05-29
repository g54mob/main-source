using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Stocks/Mission Data")]
	public class StockMissionData : ScriptableObject
	{
		[field: SerializeField]
		public StockDeliveryData StockData { get; private set; }

		[field: SerializeField]
		public bool AllowLockedItems { get; private set; }
	}
}
