using System;
using System.Collections.Generic;
using Restory.Gameplay.Common;
using Restory.Infrastructure.StateMachine;
using Restory.TimeSystems;
using Zenject;

namespace Restory.Gameplay.TimeSystems
{
	public class TimeSystem : ITickable, IInitializable, IDisposable
	{
		private bool isActive = true;

		private readonly GlobalStateObserver globalStateObserver;

		private readonly TickSystem tickSystem;

		private readonly GameCalendar gameCalendar;

		private readonly TimeSettingsProvidingService timeSettings;

		private readonly ActiveStateSwitcher activeStateSwitcher;

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			private set
			{
				if (isActive != value)
				{
					isActive = value;
					this.OnActiveStatusChanged?.Invoke();
				}
			}
		}

		public TimeOfDay TimeStep => timeSettings.TimeStep;

		public float TimeStepSeconds => TimeStep.TotalSeconds;

		public event Action OnActiveStatusChanged;

		private TimeSystem(GlobalStateObserver globalStateObserver, TickSystem tickSystem, GameCalendar gameCalendar, TimeSettingsProvidingService timeSettings)
		{
			this.timeSettings = timeSettings;
			this.gameCalendar = gameCalendar;
			this.globalStateObserver = globalStateObserver;
			this.tickSystem = tickSystem;
			activeStateSwitcher = new ActiveStateSwitcher(ActiveStateSwitcher.WorkMode.ActiveByDefaultAndRequestersMakeItInactive);
		}

		public void Initialize()
		{
			tickSystem.AddSubscriber(this);
			isActive = activeStateSwitcher.ShouldSystemBeActive;
			activeStateSwitcher.OnActiveStatusSwitchRequested += ResolveActiveStatusSwitchRequested;
		}

		public void Dispose()
		{
			if ((bool)tickSystem)
			{
				tickSystem.RemoveSubscriber(this);
			}
			if (activeStateSwitcher != null)
			{
				activeStateSwitcher.OnActiveStatusSwitchRequested -= ResolveActiveStatusSwitchRequested;
				activeStateSwitcher.Clear();
			}
			this.OnActiveStatusChanged = null;
		}

		public void Tick(float deltaTime)
		{
			if (IsActive && globalStateObserver.IsInGameLoop)
			{
				TimeSpan value = TimeSpan.FromSeconds(TimeStep.InTimeSpan().TotalSeconds * (double)deltaTime);
				gameCalendar.CurrentDateTime = gameCalendar.CurrentDateTime.Add(value);
			}
		}

		public void BlockTimeSystem(IActiveStateSwitchRequester blocker)
		{
			activeStateSwitcher.AddRequester(blocker);
		}

		public void StopBlockingTimeSystem(IActiveStateSwitchRequester blocker)
		{
			activeStateSwitcher.RemoveRequester(blocker);
		}

		public void Debug_GetAllTimeBlockers(List<IActiveStateSwitchRequester> blockersList)
		{
			blockersList.Clear();
			blockersList.AddRange(activeStateSwitcher.Requesters);
		}

		public void SkipTime(TimeOfDay targetTimeOfDay)
		{
			DateTime dateTime = new DateTime(gameCalendar.CurrentDateTime.Year, gameCalendar.CurrentDateTime.Month, gameCalendar.CurrentDateTime.Day, targetTimeOfDay.Hours, targetTimeOfDay.Minutes, targetTimeOfDay.Seconds);
			TimeSpan value = dateTime - gameCalendar.CurrentDateTime;
			if (value.TotalSeconds < 0.0)
			{
				dateTime = dateTime.AddDays(1.0);
				value = dateTime - gameCalendar.CurrentDateTime;
			}
			gameCalendar.CurrentDateTime = gameCalendar.CurrentDateTime.Add(value);
		}

		private void ResolveActiveStatusSwitchRequested()
		{
			IsActive = activeStateSwitcher.ShouldSystemBeActive;
		}
	}
}
