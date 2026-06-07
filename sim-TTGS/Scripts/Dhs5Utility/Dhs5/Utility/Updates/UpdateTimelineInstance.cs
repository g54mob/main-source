using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Updates
{
	public class UpdateTimelineInstance
	{
		public readonly int timelineUID;

		public readonly EUpdateChannel updateChannel;

		public readonly float duration;

		private readonly List<IUpdateTimeline.Event> customEvents;

		private Queue<IUpdateTimeline.Event> eventQueue;

		public bool IsActive { get; private set; }

		public float Time { get; private set; }

		public float NormalizedTime
		{
			get
			{
				return Time / duration;
			}
			set
			{
				Time = value * duration;
			}
		}

		public bool Loop { get; set; }

		public float Timescale { get; set; }

		public event UpdateCallback Updated;

		public event UpdateTimelineEvent EventTriggered;

		public UpdateTimelineInstance(IUpdateTimeline updateTimeline)
		{
			IsActive = false;
			Time = 0f;
			timelineUID = updateTimeline.UID;
			updateChannel = updateTimeline.UpdateChannel;
			duration = updateTimeline.Duration;
			Loop = updateTimeline.Loop;
			Timescale = updateTimeline.Timescale;
			eventQueue = new Queue<IUpdateTimeline.Event>();
			customEvents = new List<IUpdateTimeline.Event>();
			IEnumerable<IUpdateTimeline.Event> sortedEvents = updateTimeline.GetSortedEvents();
			if (sortedEvents == null)
			{
				return;
			}
			foreach (IUpdateTimeline.Event item in sortedEvents)
			{
				customEvents.Add(item);
			}
		}

		private void SetActive(bool active, bool force, bool triggerPauseEvents)
		{
			if (IsActive != active || force)
			{
				IsActive = active;
				if (IsActive)
				{
					OnSetActive(triggerPauseEvents);
				}
				else
				{
					OnSetInactive(triggerPauseEvents);
				}
			}
		}

		public void Play()
		{
			SetActive(active: true, force: false, triggerPauseEvents: true);
		}

		public void Pause()
		{
			SetActive(active: true, force: false, triggerPauseEvents: true);
		}

		public void SetTime(float time, bool triggerCustomEvents)
		{
			Time = Mathf.Clamp(time, 0f, duration);
			if (triggerCustomEvents)
			{
				CheckCustomEvents();
			}
			else
			{
				FillCustomEventsQueue(NormalizedTime);
			}
		}

		public void SetNormalizedTime(float normalizedTime, bool triggerCustomEvents)
		{
			NormalizedTime = Mathf.Clamp01(normalizedTime);
			if (triggerCustomEvents)
			{
				CheckCustomEvents();
			}
			else
			{
				FillCustomEventsQueue(NormalizedTime);
			}
		}

		public void Complete(bool triggerCustomEvents)
		{
			if (Time != duration)
			{
				Time = duration;
				if (triggerCustomEvents)
				{
					CheckCustomEvents();
				}
				SetActive(active: false, force: true, triggerPauseEvents: false);
			}
		}

		public void Restart(bool complete)
		{
			if (complete && Time > 0f)
			{
				Complete(triggerCustomEvents: true);
			}
			Time = 0f;
			SetActive(active: true, force: true, triggerPauseEvents: false);
		}

		public void Reset()
		{
			Time = 0f;
			SetActive(active: false, force: false, triggerPauseEvents: false);
		}

		public void OnUpdate(float deltaTime)
		{
			if (!IsActive)
			{
				return;
			}
			deltaTime *= Timescale;
			Time += deltaTime;
			if (Time >= duration)
			{
				float num = Time - duration;
				if (Loop)
				{
					Time = duration;
					TriggerUpdate(deltaTime - num);
					OnEnd();
					Time = 0f;
					OnStart();
					if (num > 0f)
					{
						Time = num;
						TriggerUpdate(num);
					}
				}
				else
				{
					Time = duration;
					TriggerUpdate(deltaTime - num);
					SetActive(active: false, force: false, triggerPauseEvents: false);
				}
			}
			else
			{
				TriggerUpdate(deltaTime);
			}
		}

		private void CheckCustomEvents()
		{
			IUpdateTimeline.Event result;
			while (eventQueue.TryPeek(out result) && result.normalizedTime <= NormalizedTime)
			{
				TriggerCustomEvent(eventQueue.Dequeue().id);
			}
		}

		private void FillCustomEventsQueue(float normalizedTime)
		{
			eventQueue.Clear();
			if (!customEvents.IsValid())
			{
				return;
			}
			foreach (IUpdateTimeline.Event customEvent in customEvents)
			{
				if (customEvent.normalizedTime >= normalizedTime)
				{
					eventQueue.Enqueue(customEvent);
				}
			}
		}

		private void OnStart()
		{
			FillCustomEventsQueue(0f);
			this.EventTriggered?.Invoke(EUpdateTimelineEventType.START, 0);
		}

		private void OnEnd()
		{
			this.EventTriggered?.Invoke(EUpdateTimelineEventType.END, 0);
		}

		private void OnSetActive(bool triggerPauseEvents)
		{
			if (Mathf.Approximately(Time, duration))
			{
				Time = 0f;
			}
			if (Time == 0f)
			{
				OnStart();
			}
			else if (triggerPauseEvents)
			{
				this.EventTriggered?.Invoke(EUpdateTimelineEventType.UNPAUSE, 0);
			}
		}

		private void OnSetInactive(bool triggerPauseEvents)
		{
			if (Mathf.Approximately(Time, duration))
			{
				OnEnd();
			}
			else if (triggerPauseEvents)
			{
				this.EventTriggered?.Invoke(EUpdateTimelineEventType.PAUSE, 0);
			}
		}

		private void TriggerUpdate(float deltaTime)
		{
			this.Updated?.Invoke(deltaTime);
			CheckCustomEvents();
		}

		private void TriggerCustomEvent(ushort id)
		{
			this.EventTriggered?.Invoke(EUpdateTimelineEventType.CUSTOM, id);
		}
	}
}
