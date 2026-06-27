using System;
using System.Collections;
using System.Collections.Generic;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.TimeSystems;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.TimeSystems
{
	public class GameCalendar : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private TimeSettingsProvidingService timeSettings;

		private UDateTime currentDateTime = new UDateTime(DateTime.MinValue);

		private DayOfWeekInfo currentDayOfWeek;

		private DayOfWeek previousDayOfWeek;

		private readonly List<ITimeChangeReceiver> timeChangeSubscribers = new List<ITimeChangeReceiver>();

		private readonly List<ITimeChangeReceiver> subscribersToAdd = new List<ITimeChangeReceiver>();

		private readonly List<ITimeChangeReceiver> subscribersToRemove = new List<ITimeChangeReceiver>();

		private Coroutine doCallbackAfterEndOfFrameCoroutine;

		public DateTime CurrentDateTime
		{
			get
			{
				return currentDateTime.DateTime;
			}
			set
			{
				currentDateTime.Set(value);
				UpdateCurrentDayOfWeek();
				UpdateSubscribers();
			}
		}

		public DayOfWeekInfo CurrentDayOfWeek => currentDayOfWeek;

		public int CurrentDayNumber => TimeSinceStartingTime.Days + 1;

		public DateTime StartingTime => timeSettings.StartingTime;

		public TimeSpan TimeSinceStartingTime => CurrentDateTime - timeSettings.StartingTime;

		public DateTime CurrentDayStartTime => CurrentDateTime - CurrentDateTime.TimeOfDay + timeSettings.StartingTime.DateTime.TimeOfDay;

		public event Action OnDayOfWeekChanged;

		[Inject]
		private void Construct(TimeSettingsProvidingService timeSettings)
		{
			this.timeSettings = timeSettings;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if (timeSettings != null && base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void Init()
		{
			currentDateTime = StartingTime;
			SetCurrentDayOfWeek();
		}

		private void OnDisable()
		{
			timeChangeSubscribers.Clear();
			subscribersToAdd.Clear();
			subscribersToRemove.Clear();
			if (doCallbackAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(doCallbackAfterEndOfFrameCoroutine);
				doCallbackAfterEndOfFrameCoroutine = null;
			}
			this.OnDayOfWeekChanged = null;
		}

		public void AddSubscriber(ITimeChangeReceiver subscriber)
		{
			if (subscriber != null && !timeChangeSubscribers.Contains(subscriber) && !subscribersToAdd.Contains(subscriber))
			{
				if (subscribersToRemove.Contains(subscriber))
				{
					subscribersToRemove.Remove(subscriber);
					return;
				}
				subscribersToAdd.Add(subscriber);
				RequestSubscribersRefreshCoroutine();
			}
		}

		public void RemoveSubscriber(ITimeChangeReceiver subscriber)
		{
			if (subscriber != null)
			{
				if (subscribersToAdd.Contains(subscriber))
				{
					subscribersToAdd.Remove(subscriber);
				}
				else if (base.isActiveAndEnabled)
				{
					subscribersToRemove.Add(subscriber);
					RequestSubscribersRefreshCoroutine();
				}
				else
				{
					timeChangeSubscribers.Remove(subscriber);
				}
			}
		}

		public DayOfWeekInfo GetDayOfWeek(DateTime targetDateTime)
		{
			return timeSettings.DaysOfWeek.DaysOfWeek.Find((DayOfWeekInfo d) => d.DayOfWeek == GetDayOfWeekByDateTime(targetDateTime));
		}

		public int GetDayNumberByDateTime(DateTime targetDateTime)
		{
			return (targetDateTime - CurrentDateTime).Days + CurrentDayNumber;
		}

		public int GetDaysAfterDateTime(DateTime dateTime)
		{
			int days = (dateTime - timeSettings.StartingTime).Days;
			return TimeSinceStartingTime.Days - days;
		}

		private void RequestSubscribersRefreshCoroutine()
		{
			if (doCallbackAfterEndOfFrameCoroutine == null)
			{
				doCallbackAfterEndOfFrameCoroutine = StartCoroutine(DoCallbackAfterEndOfFrameCoroutine(RefreshSubscribers));
			}
		}

		private IEnumerator DoCallbackAfterEndOfFrameCoroutine(Action callback)
		{
			yield return new WaitForEndOfFrame();
			doCallbackAfterEndOfFrameCoroutine = null;
			callback?.Invoke();
		}

		private void RefreshSubscribers()
		{
			RemoveSubscribers();
			AddSubscribers();
		}

		private void AddSubscribers()
		{
			timeChangeSubscribers.AddRange(subscribersToAdd);
			subscribersToAdd.Clear();
		}

		private void RemoveSubscribers()
		{
			foreach (ITimeChangeReceiver item in subscribersToRemove)
			{
				for (int num = timeChangeSubscribers.Count - 1; num >= 0; num--)
				{
					if (timeChangeSubscribers[num] == item)
					{
						timeChangeSubscribers.RemoveAt(num);
						break;
					}
				}
			}
			subscribersToRemove.Clear();
		}

		private void UpdateSubscribers()
		{
			foreach (ITimeChangeReceiver timeChangeSubscriber in timeChangeSubscribers)
			{
				timeChangeSubscriber.ProcessTimeChanged();
			}
		}

		private void UpdateCurrentDayOfWeek()
		{
			DayOfWeek dayOfWeek = GetCurrentDayOfWeek();
			if (previousDayOfWeek != dayOfWeek)
			{
				previousDayOfWeek = dayOfWeek;
				SetCurrentDayOfWeek();
			}
		}

		private void SetCurrentDayOfWeek()
		{
			currentDayOfWeek = timeSettings.DaysOfWeek.DaysOfWeek.Find((DayOfWeekInfo d) => d.DayOfWeek == GetCurrentDayOfWeek());
			this.OnDayOfWeekChanged?.Invoke();
		}

		private DayOfWeek GetCurrentDayOfWeek()
		{
			return GetDayOfWeekByDateTime(CurrentDateTime);
		}

		private DayOfWeek GetDayOfWeekByDateTime(DateTime dateTime)
		{
			int hour = timeSettings.StartingTime.DateTime.Hour;
			return dateTime.AddHours(-hour).DayOfWeek;
		}

		public object CaptureState()
		{
			try
			{
				return new GameCalendarSaveData
				{
					DateTime = CurrentDateTime
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				GameCalendarSaveData gameCalendarSaveData = DataMigrationWizard.Migrate<GameCalendarSaveData>(state, base.gameObject);
				CurrentDateTime = gameCalendarSaveData.DateTime;
				SetCurrentDayOfWeek();
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
