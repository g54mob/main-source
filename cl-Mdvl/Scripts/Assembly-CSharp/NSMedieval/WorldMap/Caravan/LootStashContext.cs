using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.Village.Map;

namespace NSMedieval.WorldMap.Caravan
{
	[FVSerializableKey("LootStashContext", "")]
	public class LootStashContext : ICaravanEvent, IFVSerializable
	{
		private int caravanId;

		private CaravanInstance caravan;

		public LootStashContext(CaravanInstance caravanInstance)
		{
			caravanId = caravanInstance.UniqueId;
			caravan = caravanInstance;
		}

		public static LootStashContext StartNew(CaravanInstance caravanInstance)
		{
			return new LootStashContext(caravanInstance);
		}

		public void OnLeftMap()
		{
			caravan.ClearEventContext();
			WorldMapMarkerPlace worldMapMarkerPlace = (WorldMapMarkerPlace)caravan.DestinationPlace;
			switch (MonoSingleton<TravelManager>.Instance.SecondMapLeaveOutcome)
			{
			case SecondMapLeaveOutcome.LeftWithoutEngagingEnemy:
				if (MonoSingleton<TravelManager>.Instance.TookItemsFromMap)
				{
					worldMapMarkerPlace.MarkLootableOrDestroy();
				}
				break;
			case SecondMapLeaveOutcome.BattleVictory:
				worldMapMarkerPlace.MarkLootableOrDestroy();
				break;
			case SecondMapLeaveOutcome.FullDefeat:
				if (worldMapMarkerPlace.CachedMapInfo.HasHostiles)
				{
					MonoSingleton<WorldMap>.Instance.MarkerManager.DestroyMarker(worldMapMarkerPlace);
				}
				else
				{
					worldMapMarkerPlace.MarkLootableOrDestroy();
				}
				break;
			case SecondMapLeaveOutcome.BattleInProgress:
			case SecondMapLeaveOutcome.BattleDefeat:
			case SecondMapLeaveOutcome.BattleTie:
				break;
			}
		}

		public void OnLoaded()
		{
			caravan = CaravanManager.GetCaravan(caravanId);
		}

		public void Tick()
		{
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("caravanId", caravanId);
		}

		public LootStashContext(FVDeserializer deserializer)
		{
			caravanId = deserializer.ReadInt("caravanId");
		}
	}
}
