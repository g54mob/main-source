using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class StockDeliveryEvent : GameEvent
	{
		public static string BoxDeliveryIcon;

		public static string GroundDeliveryIcon;

		public static string AirDeliveryIcon;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		internal List<GameItemTemplate> _stockToDeliver;

		[PersistenceOptIn]
		internal bool _isFastDelivery;

		[PersistenceOptIn]
		protected string _sourceDisplayNameKey;

		private StockDeliveryEvent()
		{
		}

		public StockDeliveryEvent(string sourceDisplayNameKey, float daysFTillDelivery, List<GameItemTemplate> stockToDeliver, Route route, bool isFastDelivery)
		{
		}

		public override void Trigger()
		{
		}

		private void SpawnUrgentPackage()
		{
		}

		private Vector3 GetSpawnPosition(Vector3[] positionsToAvoid)
		{
			return default(Vector3);
		}

		private static float GetMinSquaredDistance(Vector3 position, Vector3[] positionsToAvoid)
		{
			return 0f;
		}

		private void SpawnDeliveryGuy(bool isKraken)
		{
		}

		private void AddItems(DeliveryGuy deliveryGuy)
		{
		}
	}
}
