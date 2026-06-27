using System;
using System.Collections.Generic;
using Restory.Data.Visits;
using Restory.Gameplay.Common;
using Restory.Gameplay.EmailSystems;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.Shops.Devices;
using Restory.Gameplay.Statistics;
using Restory.Gameplay.Visits;
using Restory.Infrastructure.StateMachine;
using Restory.TimeSystems;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.TimeSystems
{
	public class MainDayTimesSwitchingProcessingService : IInitializable, IDisposable, IActiveStateSwitchRequester
	{
		private readonly MainDayTimeSwitchingService mainDayTimeSwitchingService;

		private readonly CurrentDayVisitsQueueService currentDayVisitsQueueService;

		private readonly VisitsScheduleService visitsScheduleService;

		private readonly TransitionToEndOfDayService transitionToEndOfDayService;

		private readonly GlobalStateObserver globalStateObserver;

		private readonly GameStatisticsService gameStatistics;

		private readonly EmailService emailService;

		private readonly DeviceShopSupplier deviceShopSupplier;

		private readonly DeviceShopTimedLotsRemovingService deviceShopTimedLotsRemovingService;

		private readonly RegularPaymentsService regularPaymentsService;

		private readonly TimeSystem timeSystem;

		public MainDayTimesSwitchingProcessingService(CurrentDayVisitsQueueService currentDayVisitsQueueService, VisitsScheduleService visitsScheduleService, MainDayTimeSwitchingService mainDayTimeSwitchingService, EmailService emailService, DeviceShopSupplier deviceShopSupplier, DeviceShopTimedLotsRemovingService deviceShopTimedLotsRemovingService, RegularPaymentsService regularPaymentsService, TransitionToEndOfDayService transitionToEndOfDayService, GlobalStateObserver globalStateObserver, GameStatisticsService gameStatistics, TimeSystem timeSystem)
		{
			this.globalStateObserver = globalStateObserver;
			this.visitsScheduleService = visitsScheduleService;
			this.mainDayTimeSwitchingService = mainDayTimeSwitchingService;
			this.currentDayVisitsQueueService = currentDayVisitsQueueService;
			this.emailService = emailService;
			this.deviceShopSupplier = deviceShopSupplier;
			this.deviceShopTimedLotsRemovingService = deviceShopTimedLotsRemovingService;
			this.regularPaymentsService = regularPaymentsService;
			this.transitionToEndOfDayService = transitionToEndOfDayService;
			this.timeSystem = timeSystem;
			this.gameStatistics = gameStatistics;
		}

		public void Initialize()
		{
			if (globalStateObserver.IsInGameLoop)
			{
				ResolveTimeChanged();
				mainDayTimeSwitchingService.OnDayTimeChanged += ResolveTimeChanged;
			}
			else
			{
				currentDayVisitsQueueService.BlockVisits(this);
				globalStateObserver.AddSubscriber(this, ResolveGlobalStateChanged);
			}
		}

		public void Dispose()
		{
			if (mainDayTimeSwitchingService != null)
			{
				mainDayTimeSwitchingService.OnDayTimeChanged -= ResolveTimeChanged;
			}
			globalStateObserver?.RemoveSubscriber(this);
			timeSystem?.StopBlockingTimeSystem(this);
		}

		private void ResolveGlobalStateChanged()
		{
			if (globalStateObserver.IsInGameLoop)
			{
				globalStateObserver.RemoveSubscriber(this);
				ResolveTimeChanged();
				mainDayTimeSwitchingService.OnDayTimeChanged += ResolveTimeChanged;
			}
		}

		private void ResolveTimeChanged()
		{
			switch (mainDayTimeSwitchingService.CurrentDayTime)
			{
			case MainDayTimes.Morning:
				gameStatistics.ProcessMorningStarted(mainDayTimeSwitchingService.PreviousDayTime);
				deviceShopTimedLotsRemovingService.RemoveTimedOutLotsIfPossible();
				deviceShopSupplier.SupplyNextBatchIfNecessary();
				emailService.SetCurrentTime(MainDayTimes.Morning);
				if (mainDayTimeSwitchingService.PreviousDayTime == MainDayTimes.AfterWork)
				{
					SwitchVisitsServicesToNextDay();
				}
				currentDayVisitsQueueService.SetUpVisitsForTheDay(visitsScheduleService.VisitsForCurrentDay);
				currentDayVisitsQueueService.SetFirstVisitTriggerTimeForTheDay();
				currentDayVisitsQueueService.UnblockVisits(this);
				currentDayVisitsQueueService.SetCurrentTime(MainDayTimes.Morning);
				regularPaymentsService.SendBillsIfTimeIsDue();
				break;
			case MainDayTimes.Afternoon:
				currentDayVisitsQueueService.UnblockVisits(this);
				emailService.SetCurrentTime(MainDayTimes.Afternoon);
				break;
			case MainDayTimes.Evening:
				currentDayVisitsQueueService.SetUpVisitsForEvening(visitsScheduleService.VisitsForCurrentDay);
				currentDayVisitsQueueService.SetCurrentTime(MainDayTimes.Evening);
				currentDayVisitsQueueService.UnblockVisits(this);
				emailService.SetCurrentTime(MainDayTimes.Evening);
				break;
			case MainDayTimes.AfterWork:
				currentDayVisitsQueueService.BlockVisits(this);
				currentDayVisitsQueueService.ForceStopCurrentVisit();
				currentDayVisitsQueueService.SetCurrentTime(MainDayTimes.AfterWork);
				emailService.SetCurrentTime(MainDayTimes.AfterWork);
				break;
			case MainDayTimes.StoreClosedTime:
				timeSystem.BlockTimeSystem(this);
				currentDayVisitsQueueService.BlockVisits(this);
				currentDayVisitsQueueService.ForceStopCurrentVisit();
				SwitchVisitsServicesToNextDay();
				currentDayVisitsQueueService.SetCurrentTime(MainDayTimes.StoreClosedTime);
				emailService.SetCurrentTime(MainDayTimes.StoreClosedTime);
				gameStatistics.ProcessStoreClosed();
				gameStatistics.ProcessDayEnded();
				transitionToEndOfDayService.PerformDaySwitchingOperation();
				break;
			default:
				throw new NotImplementedException();
			case MainDayTimes.None:
				break;
			}
		}

		private void SwitchVisitsServicesToNextDay()
		{
			visitsScheduleService.SwitchToNextDay();
			TransferLeftoverVisitsToNextDays();
		}

		private void TransferLeftoverVisitsToNextDays()
		{
			List<StoryNpcVisit> list = CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Get();
			currentDayVisitsQueueService.ClearQueueAtTheEndOfDay(list, out var firstNextMorningUrgentVisit);
			foreach (StoryNpcVisit item in list)
			{
				visitsScheduleService.AddStoryVisit(item.Npc, npcTextureID: item.NpcTextureID, visitType: item.VisitType, suggestedDayIndex: 0, timeInterval: item.IntendedTimeInterval, resultDayIndex: out var _);
			}
			if (firstNextMorningUrgentVisit != null)
			{
				visitsScheduleService.AddFirstUrgentMorningVisit(firstNextMorningUrgentVisit.Npc, firstNextMorningUrgentVisit.VisitType, 0, firstNextMorningUrgentVisit.NpcTextureID);
			}
			CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Release(list);
		}
	}
}
