using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.Village.Map;
using Utils;

namespace NSMedieval.WorldMap.Caravan
{
	[FVSerializableKey("AttackBanditCampContext", "")]
	public class AttackBanditCampContext : ICaravanEvent, IFVSerializable
	{
		private int caravanId;

		private CaravanInstance caravan;

		public AttackBanditCampContext(CaravanInstance caravanInstance)
		{
			caravanId = caravanInstance.UniqueId;
			caravan = caravanInstance;
		}

		public static AttackBanditCampContext StartNew(CaravanInstance caravanInstance)
		{
			return new AttackBanditCampContext(caravanInstance);
		}

		public void OnLeftMap()
		{
			caravan.ClearEventContext();
			WorldMapMarkerPlace place = (WorldMapMarkerPlace)caravan.DestinationPlace;
			WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			place.ClearScheduledStateChanges();
			place.ShouldShowDisabledTimer = false;
			switch (MonoSingleton<TravelManager>.Instance.SecondMapLeaveOutcome)
			{
			case SecondMapLeaveOutcome.BattleInProgress:
				place.MarkerState = MapMarkerState.Disabled;
				place.ScheduleStateChangeHours(12, MapMarkerState.Enterable);
				place.ShouldShowDisabledTimer = true;
				break;
			case SecondMapLeaveOutcome.BattleVictory:
				place.MarkLootableOrDestroy();
				MonoSingleton<TaskController>.Instance.WaitUntil((float time) => MonoSingleton<UIController>.Instance.GameStarted).Then(delegate
				{
					FactionInstance closestVillageFaction = FactionUtil.GetClosestVillageFaction(place.Position);
					if (closestVillageFaction != null)
					{
						float friendlinessGainAfterBanditCampVictory = SingletonModel<LeaveMapOutcomeSettings, LeaveMapOutcomeSettingsData>.I.FriendlinessGainAfterBanditCampVictory;
						closestVillageFaction.AddFriendliness(friendlinessGainAfterBanditCampVictory);
					}
				});
				break;
			case SecondMapLeaveOutcome.BattleDefeat:
			case SecondMapLeaveOutcome.BattleTie:
				place.MarkerState = MapMarkerState.Disabled;
				place.SetExpireMinutesFromNow(dateAndTime.MinutesInHour * 5);
				break;
			case SecondMapLeaveOutcome.FullDefeat:
				MonoSingleton<WorldMap>.Instance.MarkerManager.DestroyMarker(place);
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

		public AttackBanditCampContext(FVDeserializer deserializer)
		{
			caravanId = deserializer.ReadInt("caravanId");
		}
	}
}
