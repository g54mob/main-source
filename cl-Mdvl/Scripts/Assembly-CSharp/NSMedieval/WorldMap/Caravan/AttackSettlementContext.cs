using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.Village.Map;

namespace NSMedieval.WorldMap.Caravan
{
	[FVSerializableKey("AttackSettlementContext", "")]
	public class AttackSettlementContext : ICaravanEvent, IFVSerializable
	{
		private int caravanId;

		private CaravanInstance caravan;

		public AttackSettlementContext(CaravanInstance caravanInstance)
		{
			caravanId = caravanInstance.UniqueId;
			caravan = caravanInstance;
		}

		public static AttackSettlementContext StartNew(CaravanInstance caravanInstance)
		{
			return new AttackSettlementContext(caravanInstance);
		}

		public void OnLeftMap()
		{
			caravan.ClearEventContext();
			WorldMapPlace place = caravan.DestinationPlace;
			place.ClearScheduledStateChanges();
			place.ShouldShowDisabledTimer = false;
			switch (MonoSingleton<TravelManager>.Instance.SecondMapLeaveOutcome)
			{
			case SecondMapLeaveOutcome.BattleInProgress:
				place.MarkerState = MapMarkerState.Disabled;
				place.ShouldShowDisabledTimer = true;
				place.ScheduleStateChangeHours(12, MapMarkerState.Enterable);
				break;
			case SecondMapLeaveOutcome.BattleVictory:
				place.MarkerState = MapMarkerState.Lootable;
				place.ScheduleStateChangeDays(10, MapMarkerState.Disabled);
				place.ScheduleStateChangeDays(40, MapMarkerState.Enterable);
				MonoSingleton<TaskController>.Instance.WaitUntil((float time) => MonoSingleton<UIController>.Instance.GameStarted).Then(delegate
				{
					FactionInstance factionInstance = place.FactionInstance;
					if (factionInstance != null)
					{
						foreach (FactionInstance enemyFactionInstance in factionInstance.GetEnemyFactionInstances())
						{
							float friendlinessGainAfterBanditCampVictory = SingletonModel<LeaveMapOutcomeSettings, LeaveMapOutcomeSettingsData>.I.FriendlinessGainAfterBanditCampVictory;
							enemyFactionInstance.AddFriendliness(friendlinessGainAfterBanditCampVictory);
						}
					}
				});
				break;
			case SecondMapLeaveOutcome.BattleDefeat:
			case SecondMapLeaveOutcome.BattleTie:
			case SecondMapLeaveOutcome.FullDefeat:
				place.MarkerState = MapMarkerState.Disabled;
				place.ShouldShowDisabledTimer = true;
				place.ScheduleStateChangeDays(10, MapMarkerState.Enterable);
				break;
			case SecondMapLeaveOutcome.LeftWithoutEngagingEnemy:
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

		public AttackSettlementContext(FVDeserializer deserializer)
		{
			caravanId = deserializer.ReadInt("caravanId");
		}
	}
}
