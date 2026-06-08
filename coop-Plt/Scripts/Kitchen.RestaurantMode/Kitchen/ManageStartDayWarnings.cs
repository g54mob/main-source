using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(TableUpdatesGroup))]
	public class ManageStartDayWarnings : RestaurantSystem
	{
		private EntityQuery PreventStartDay;

		private EntityQuery RequireRecalculation;

		private EntityQuery TableSets;

		private EntityQuery Popups;

		private EntityQuery CranePlayers;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SLargestTableSize_13;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SStartDayWarnings_14;

		private EntityQuery _SingletonEntityQuery_SStartDayWarnings_15;

		protected override void Initialise()
		{
			base.Initialise();
			PreventStartDay = GetEntityQuery(new QueryHelper().Any(typeof(CPreventStartDayPost), typeof(CUnlockSelectPopupResult), typeof(CUnlockSelectPopup)));
			RequireRecalculation = GetEntityQuery(typeof(CRequireStartDayWarningRecalculation));
			TableSets = GetEntityQuery(typeof(CTableSet));
			Popups = GetEntityQuery(typeof(CPopup));
			CranePlayers = GetEntityQuery(typeof(CIsCraneMode));
			RequireSingletonForUpdate<SLargestTableSize>();
			RequireSingletonForUpdate<SStartDayWarnings>();
		}

		protected override void OnUpdate()
		{
			bool flag = HasStatus(RestaurantStatus.OneTableMax);
			SLargestTableSize singleton = _SingletonEntityQuery_SLargestTableSize_13.GetSingleton<SLargestTableSize>();
			SStartDayWarnings singleton2 = _SingletonEntityQuery_SStartDayWarnings_14.GetSingleton<SStartDayWarnings>();
			base.EntityManager.DestroyEntity(RequireRecalculation);
			CreateCustomerSchedule.SAnalysis orDefault = GetOrDefault<CreateCustomerSchedule.SAnalysis>();
			singleton2.PopupsOpen = WarningLevel.Error.If(!Popups.IsEmpty);
			singleton2.SellingRequiredAppliance = WarningLevel.Error.If(Has<CheckSellingRequiredAppliance.SWarning>() || Has<CheckSellingRequiredIngredient.SWarning>());
			singleton2.TableSize = WarningLevel.Error.If(singleton.LargestTableSize < orDefault.LargestGroupPossibility);
			singleton2.PlayersNotReady = WarningLevel.Error.If(!GetComponent<CPlayersReadyToStart>(_SingletonEntityQuery_SStartDayWarnings_14.GetSingletonEntity()).Ready);
			singleton2.PostUnopened = WarningLevel.Error.If(!PreventStartDay.IsEmpty);
			int num = 0;
			using NativeArray<CTableSet> nativeArray = TableSets.ToComponentDataArray<CTableSet>(Allocator.Temp);
			if (flag)
			{
				foreach (CTableSet item in nativeArray)
				{
					if (!item.IsWaitingTable && item.ChairCount > 0)
					{
						num++;
					}
				}
			}
			singleton2.MoreThanOneTable = WarningLevel.Error.If(flag && num > 1);
			singleton2.PlayersInCraneMode = WarningLevel.Warning.If(!CranePlayers.IsEmpty);
			_SingletonEntityQuery_SStartDayWarnings_15.SetSingleton(singleton2);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SLargestTableSize_13 = GetEntityQuery(ComponentType.ReadOnly<SLargestTableSize>());
			_SingletonEntityQuery_SStartDayWarnings_14 = GetEntityQuery(ComponentType.ReadOnly<SStartDayWarnings>());
			_SingletonEntityQuery_SStartDayWarnings_15 = GetEntityQuery(ComponentType.ReadWrite<SStartDayWarnings>());
		}
	}
}
