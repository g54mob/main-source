using System;
using System.Collections.Generic;
using Restory.Data.PC;
using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking
{
	public class GUI_DeviceHackingTimeline : MonoBehaviour
	{
		private readonly List<DeviceHackingEvent> timeline = new List<DeviceHackingEvent>();

		private readonly HackingEventType[] eventTypes = (HackingEventType[])Enum.GetValues(typeof(HackingEventType));

		private HackingTimelineSettings settings;

		public void Init(HackingTimelineSettings settings)
		{
			this.settings = settings;
			GenerateTimeline();
		}

		public bool CheckEvent(float hackingProgress, out DeviceHackingEvent reachedEvent)
		{
			reachedEvent = null;
			foreach (DeviceHackingEvent item in timeline)
			{
				if (item.EventTime > hackingProgress)
				{
					if (item.Passed && item.EventTime - hackingProgress > (float)settings.EventComebackThresholdPercentage / 100f)
					{
						item.Passed = false;
					}
				}
				else if (!item.Passed)
				{
					reachedEvent = item;
					reachedEvent.Passed = true;
				}
			}
			return reachedEvent != null;
		}

		private void GenerateTimeline()
		{
			float minInclusive = (float)settings.EmptyStartZonePercentage / 100f;
			float num = (float)(100 - settings.EmptyEndZonePercentage) / 100f;
			float num2 = (float)settings.MinEventGapPercentage / 100f;
			timeline.Clear();
			int num3 = UnityEngine.Random.Range(settings.MinEventCount, settings.MaxEventCount + 1);
			for (int i = 0; i < num3; i++)
			{
				float eventTime = UnityEngine.Random.Range(minInclusive, num);
				DeviceHackingEvent item = CreateEvent(eventTime);
				timeline.Add(item);
			}
			timeline.Sort((DeviceHackingEvent a, DeviceHackingEvent b) => a.EventTime.CompareTo(b.EventTime));
			DeviceHackingEvent deviceHackingEvent = null;
			for (int num4 = 0; num4 < timeline.Count; num4++)
			{
				if (deviceHackingEvent == null)
				{
					deviceHackingEvent = timeline[num4];
					continue;
				}
				if (Mathf.Abs(timeline[num4].EventTime - deviceHackingEvent.EventTime) < num2)
				{
					timeline[num4].SetEventTime(deviceHackingEvent.EventTime + num2);
				}
				if (timeline[num4].EventTime <= num)
				{
					deviceHackingEvent = timeline[num4];
					continue;
				}
				timeline.RemoveAt(num4);
				num4--;
			}
		}

		private DeviceHackingEvent CreateEvent(float eventTime)
		{
			return eventTypes[UnityEngine.Random.Range(0, eventTypes.Length)] switch
			{
				HackingEventType.Break => new HackingDelayEvent(HackingEventType.Break, eventTime, (float)settings.BreakBonusPercentage / 100f, (float)settings.BreakPenaltyPercentage / 100f, UnityEngine.Random.Range(settings.MinHackingDelayInSeconds, settings.MaxHackingDelayInSeconds)), 
				HackingEventType.Alert => new HackingDelayEvent(HackingEventType.Alert, eventTime, (float)settings.AlertBonusPercentage / 100f, (float)settings.AlertPenaltyPercentage / 100f, UnityEngine.Random.Range(settings.MinHackingDelayInSeconds, settings.MaxHackingDelayInSeconds)), 
				HackingEventType.Decision => new HackingDecisionEvent(eventTime, (float)settings.DecisionBonusPercentage / 100f, (float)settings.DecisionPenaltyPercentage / 100f, UnityEngine.Random.value), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
