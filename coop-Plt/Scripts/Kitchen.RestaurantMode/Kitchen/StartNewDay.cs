using System.Runtime.InteropServices;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(AdvanceTime))]
	[UpdateInGroup(typeof(TimeManagementGroup))]
	public class StartNewDay : NightSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct STriggerStartDay : IComponentData
		{
		}

		private EntityQuery CarriedAppliances;

		private EntityQuery PreventStartDay;

		private EntityQuery RequireRecalculation;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SStartDayWarnings_18;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_19;

		private EntityQuery _SingletonEntityQuery_SDay_20;

		protected override void Initialise()
		{
			base.Initialise();
			CarriedAppliances = GetEntityQuery(typeof(CHeldAppliance));
			PreventStartDay = GetEntityQuery(typeof(CPreventStartDayPost));
			RequireRecalculation = GetEntityQuery(typeof(CRequireStartDayWarningRecalculation));
		}

		protected override void OnUpdate()
		{
			if (HasSingleton<SGameOver>() || base.Time.IsPaused || !RequireRecalculation.IsEmpty || !CarriedAppliances.IsEmpty || !PreventStartDay.IsEmpty || !HasSingleton<SStartDayWarnings>())
			{
				return;
			}
			SStartDayWarnings singleton = _SingletonEntityQuery_SStartDayWarnings_18.GetSingleton<SStartDayWarnings>();
			if ((Has<STriggerStartDay>() || (!singleton.TableSize.IsBlocking() && !singleton.PlayersNotReady.IsBlocking() && !singleton.MoreThanOneTable.IsBlocking())) && !singleton.PostUnopened.IsBlocking())
			{
				if (ModPreload.IsModded && !HasSingleton<SModdedRun>())
				{
					Set<SModdedRun>();
				}
				Clear<STriggerStartDay>();
				Clear<SStartDayWarnings>();
				if (!Has<SPracticeMode>())
				{
					EntityContext entityContext = new EntityContext(base.World.EntityManager);
					Persistence.FullWorld.Save(base.World.EntityManager, entityContext.Get<SSelectedLocation>().Selected.Slot);
				}
				BecomeDay();
			}
		}

		protected void BecomeDay()
		{
			int day = _SingletonEntityQuery_SDay_19.GetSingleton<SDay>().Day;
			_SingletonEntityQuery_SDay_20.SetSingleton(new SDay
			{
				Day = day + 1
			});
			Set<SIsDayFirstUpdate>();
			Set<SIsDayTime>();
			Clear<SIsNightTime>();
			if (!HasSingleton<SPerformTableUpdate>())
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(SPerformTableUpdate));
				base.EntityManager.SetComponentData(entity, new SPerformTableUpdate
				{
					EnforcePaths = true,
					PathingSource = SPerformTableUpdate.DefaultPathingSource
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SStartDayWarnings_18 = GetEntityQuery(ComponentType.ReadOnly<SStartDayWarnings>());
			_SingletonEntityQuery_SDay_19 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
			_SingletonEntityQuery_SDay_20 = GetEntityQuery(ComponentType.ReadWrite<SDay>());
		}
	}
}
