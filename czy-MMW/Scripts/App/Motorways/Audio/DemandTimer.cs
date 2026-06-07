using System.Collections.Generic;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Audio
{
	public class DemandTimer : Playback
	{
		private struct Ping
		{
			public float Pan;

			public int GroupIndex;

			public float Danger;

			public Ping(float pan, int groupIndex, float danger)
			{
				this = default(Ping);
				Pan = pan;
				GroupIndex = groupIndex;
				Danger = danger;
			}
		}

		private int timerCount;

		private int pulseCount;

		private List<Ping> pings = new List<Ping>();

		private float maxOvercrowdingTime;

		private float longestOvercrowdingTime;

		private readonly float[] TICK_GAINS = new float[2] { 0.5f, 0.083f };

		private readonly float DANGER_START = 0.5f;

		private readonly float[] PITCHES = new float[2] { 2f, 4f };

		public DemandTimer(AudioEventFilter filter)
			: base(filter)
		{
		}

		protected override void OnPulse()
		{
			pulseCount++;
			if (GetEvents())
			{
				foreach (AudioEvent audioEvent in audioEvents)
				{
					timerCount += (audioEvent.Condition ? 1 : (-1));
				}
				audioEvents.Clear();
			}
			if (timerCount < 1 || Get.State.HasAny(StateType.GameOver, StateType.GamePaused, StateType.MenuPause, StateType.MenuUpgrades, StateType.MenuPhoto))
			{
				pulseCount = 0;
				return;
			}
			maxOvercrowdingTime = (float)Get.GameConstants.MaxOvercrowdTime;
			longestOvercrowdingTime = 0f;
			pings.Clear();
			foreach (List<DestinationView> destination in Environment.Destinations)
			{
				foreach (DestinationView item in destination)
				{
					float num = (float)item.Model.CurrentFrame.OvercrowdingTime;
					if (num > 0f)
					{
						pings.Add(new Ping(item.Pan.x, item.groupIndex, Maf.Map(num / maxOvercrowdingTime, DANGER_START, 1f, 0f, 1f)));
						if (num > longestOvercrowdingTime)
						{
							longestOvercrowdingTime = Mathf.Max(longestOvercrowdingTime, num);
						}
					}
					maxOvercrowdingTime = Mathf.Max(maxOvercrowdingTime, item.MaxOvercrowdingTime);
				}
			}
			if (pings.Count != 0)
			{
				int num2 = pulseCount % pings.Count;
				float num3 = pings[num2].Pan;
				float num4 = Maf.Map(longestOvercrowdingTime / maxOvercrowdingTime, DANGER_START, 1f, 0f, 1f);
				float num5 = Maf.VolCurve(Mathf.Lerp(0f, 1f, num4));
				float a = ((pings.Count < 2) ? 0.75f : Maf.Map(pulseCount % pings.Count, 0f, pings.Count - 1, 0.75f, 1.5f));
				a = Mathf.Lerp(a, 3f, num4);
				AudioPlayer.UI.PlaySample("DangerTick", num3, num5 * TICK_GAINS[pulse.StepIndex % 2], a, 0.0, time);
				a = PITCHES[(int)Mathf.Lerp(0f, 1.999f, num4)] + Mathf.Lerp(0f, 0.225f, num4 * num4);
				AudioPlayer.Default.PlaySample("LineCreated_" + Get.Loadout.MusicData.NoteWindow.SafeGet(num2), num3, Mathf.Lerp(0f, 0.3f, pings.SafeGet(pulseCount).Danger) * TICK_GAINS[pulse.StepIndex % 2], a, 0.0, time);
			}
		}

		public override void AddEventListeners()
		{
			EventListener.Add(OnRippleAlert, AudioEventType.RippleAlert);
			EventListener.Add(OnDestinationOvercrowding, AudioEventType.DestinationOvercrowding);
		}

		private void OnDestinationOvercrowding(AudioEvent e)
		{
			if (Get.Loadout.Id != "menu")
			{
				if (e.Condition)
				{
					AudioPlayer.UI.PlaySample("PopUp-" + Rando.Pick<string>("01", "02", "03"), e.Pan, 0.8f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				}
				else
				{
					AudioPlayer.UI.PlaySample("PinFulfilled-01", e.Pan, 1f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
				}
			}
		}

		private void OnRippleAlert(AudioEvent e)
		{
			float num = (float)e.Destination.Model.CurrentFrame.OvercrowdingTime / maxOvercrowdingTime;
			AudioPlayer.UI.PlaySample("ui_stationWarning", e.Pan, num * 0.35f, Rando.Range(0.9f, 1.1f), 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
		}
	}
}
