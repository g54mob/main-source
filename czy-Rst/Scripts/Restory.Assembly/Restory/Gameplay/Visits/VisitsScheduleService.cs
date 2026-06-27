using System;
using System.Collections.Generic;
using Restory.Data.NPCs;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Visits;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Visits
{
	public class VisitsScheduleService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private VisitsScheduleSettings visitsScheduleSettings;

		private List<VisitsInOneDayList> futureDaysSchedule = new List<VisitsInOneDayList>();

		public IReadOnlyList<StoryNpcVisit> VisitsForCurrentDay
		{
			get
			{
				if (futureDaysSchedule.Count != 0 && futureDaysSchedule[0] != null)
				{
					return futureDaysSchedule[0].VisitsForTheDay;
				}
				return Array.Empty<StoryNpcVisit>();
			}
		}

		[Inject]
		private void Construct()
		{
			futureDaysSchedule.Clear();
		}

		public bool IsTimeVacantForNewVisit(int dayIndex, VisitTimeInterval timeInterval)
		{
			if (dayIndex < 0)
			{
				return false;
			}
			if (dayIndex >= futureDaysSchedule.Count)
			{
				return true;
			}
			VisitsInOneDayList visitsInOneDayList = futureDaysSchedule[dayIndex];
			if (visitsInOneDayList == null)
			{
				return true;
			}
			int num = 0;
			foreach (StoryNpcVisit item in visitsInOneDayList.VisitsForTheDay)
			{
				if (item.IntendedTimeInterval == timeInterval)
				{
					num++;
				}
			}
			bool flag = true;
			switch (timeInterval)
			{
			case VisitTimeInterval.Morning:
				flag = num < visitsScheduleSettings.MaxMorningVisitsPerDay;
				break;
			case VisitTimeInterval.Evening:
				flag = num < visitsScheduleSettings.MaxEveningVisitsPerDay;
				break;
			default:
				throw new NotImplementedException();
			case VisitTimeInterval.AnyTime:
				break;
			}
			if (flag)
			{
				return visitsInOneDayList.VisitsForTheDay.Count < visitsScheduleSettings.MaxTotalVisitsPerDay;
			}
			return false;
		}

		public void AddStoryVisit(INpcInfo visitor, StoryVisitType visitType, int suggestedDayIndex, VisitTimeInterval timeInterval, out int resultDayIndex, string npcTextureID = "")
		{
			if (visitor == null)
			{
				resultDayIndex = 0;
				return;
			}
			for (resultDayIndex = suggestedDayIndex; resultDayIndex < int.MaxValue; resultDayIndex++)
			{
				if (IsTimeVacantForNewVisit(resultDayIndex, timeInterval))
				{
					AddStoryVisit(visitor, visitType, resultDayIndex, timeInterval, npcTextureID);
					break;
				}
			}
		}

		public void SwitchToNextDay()
		{
			if (futureDaysSchedule.Count != 0)
			{
				futureDaysSchedule.RemoveAt(0);
			}
		}

		private void AddStoryVisit(INpcInfo visitor, StoryVisitType visitType, int suggestedDayIndex, VisitTimeInterval timeInterval, string npcTextureID = "")
		{
			StoryNpcVisit item = new StoryNpcVisit
			{
				IntendedTimeInterval = timeInterval,
				Npc = visitor,
				NpcTextureID = npcTextureID,
				VisitType = visitType
			};
			while (futureDaysSchedule.Count <= suggestedDayIndex)
			{
				futureDaysSchedule.Add(null);
			}
			if (futureDaysSchedule[suggestedDayIndex] == null)
			{
				futureDaysSchedule[suggestedDayIndex] = new VisitsInOneDayList
				{
					VisitsForTheDay = { item }
				};
			}
			else
			{
				futureDaysSchedule[suggestedDayIndex].VisitsForTheDay.Add(item);
			}
		}

		public void AddFirstUrgentMorningVisit(INpcInfo visitor, StoryVisitType visitType, int suggestedDayIndex, string npcTextureID = "")
		{
			StoryNpcVisit item = new StoryNpcVisit
			{
				IntendedTimeInterval = VisitTimeInterval.Morning,
				Npc = visitor,
				NpcTextureID = npcTextureID,
				VisitType = visitType
			};
			while (futureDaysSchedule.Count <= suggestedDayIndex)
			{
				futureDaysSchedule.Add(null);
			}
			if (futureDaysSchedule[suggestedDayIndex] == null)
			{
				futureDaysSchedule[suggestedDayIndex] = new VisitsInOneDayList
				{
					VisitsForTheDay = { item }
				};
			}
			else
			{
				futureDaysSchedule[suggestedDayIndex].VisitsForTheDay.Insert(0, item);
			}
		}

		public object CaptureState()
		{
			try
			{
				return new VisitsScheduleServiceSaveData
				{
					Schedule = futureDaysSchedule.ToArray()
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
				futureDaysSchedule.Clear();
				VisitsScheduleServiceSaveData visitsScheduleServiceSaveData = DataMigrationWizard.Migrate<VisitsScheduleServiceSaveData>(state, base.gameObject);
				futureDaysSchedule.AddRange(visitsScheduleServiceSaveData.Schedule);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
