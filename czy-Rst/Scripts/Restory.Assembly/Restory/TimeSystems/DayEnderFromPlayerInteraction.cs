using System;
using Restory.Data.GameWarnings;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.GameDialogues;
using Restory.Utils;
using Zenject;

namespace Restory.TimeSystems
{
	public class DayEnderFromPlayerInteraction : IInitializable, IDisposable
	{
		private readonly BicycleInteractiveStoreItem bicycle;

		private readonly MainDayTimeSwitchingService mainDayTimeSwitchingService;

		private readonly WindowShuttersStoreInteractiveItem windowShuttersStoreInteractiveItem;

		private readonly GameWarningService gameWarningService;

		private readonly GameWarningDatabase gameWarningDatabase;

		public DayEnderFromPlayerInteraction(BicycleInteractiveStoreItem bicycle, MainDayTimeSwitchingService mainDayTimeSwitchingService, WindowShuttersStoreInteractiveItem windowShuttersStoreInteractiveItem, GameWarningService gameWarningService, GameWarningDatabase gameWarningDatabase)
		{
			this.bicycle = bicycle;
			this.windowShuttersStoreInteractiveItem = windowShuttersStoreInteractiveItem;
			this.mainDayTimeSwitchingService = mainDayTimeSwitchingService;
			this.gameWarningDatabase = gameWarningDatabase;
			this.gameWarningService = gameWarningService;
		}

		public void Initialize()
		{
			bicycle.Trigger.OnClick += ResolveBicycleClicked;
		}

		public void Dispose()
		{
			if (bicycle != null && bicycle.Trigger.MonoShellExists())
			{
				bicycle.Trigger.OnClick -= ResolveBicycleClicked;
			}
		}

		private void ResolveBicycleClicked()
		{
			if (!windowShuttersStoreInteractiveItem.WasWindowOpenAtLeastOnce)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.UnableToEndDayWhenItHasNotStartedWarning);
			}
			else if (mainDayTimeSwitchingService.CurrentDayTime != MainDayTimes.StoreClosedTime)
			{
				mainDayTimeSwitchingService.ForceEndDay();
			}
		}
	}
}
