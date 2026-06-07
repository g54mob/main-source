using UnityEngine;

namespace Motorways.Audio
{
	public class Clock : Playback
	{
		private string scenario;

		private int playCountLimit = 9;

		private int playCount = 9;

		private int _hour;

		private int _day;

		public static float GainFactor;

		public static double NextPulseTime;

		public Clock(AudioEventFilter filter, string scenario = "")
			: base(filter)
		{
			this.scenario = scenario;
		}

		protected override void OnPulse()
		{
			NextPulseTime = Module.NextPulseTime;
			if (Get.Game.Simulation.IsPaused)
			{
				playCount = 0;
				return;
			}
			if (GetEvents())
			{
				playCount = 0;
				audioEvents.Clear();
			}
			_hour = Get.Clock.Hour % 24;
			_day = Get.Clock.Day % 7;
			if (Get.City.Rules.ScoringMode == ScoringMode.Trips && _day == 6 && _hour == 23)
			{
				Persistent.UpgradeChord(Module.NextPulseTime);
				playCountLimit = 8;
				playCount = 8;
			}
			Play();
		}

		private void Play()
		{
			GainFactor = 1f;
			if (scenario == "Clock")
			{
				if (Get.City.Rules.ScoringMode == ScoringMode.Trips && _day == 6 && _hour > 14 && _hour < 24)
				{
					GainFactor = 0.5f * Mathf.Pow(((float)_hour - 14f) / 9f, 1.5f);
				}
				else
				{
					if (playCount == playCountLimit)
					{
						GainFactor = 0f;
						return;
					}
					playCount++;
					GainFactor = Mathf.Pow(GainFactor / (float)playCount, 1.5f);
				}
			}
			if (scenario == "Click")
			{
				GainFactor = 0f;
				AudioPlayer.UI.PlaySample("metronome_0", 0.5f, 0.5f, 1f, 0.0, time);
			}
			else
			{
				AudioPlayer.UI.PlaySample("metronome_0", 0.75f, GainFactor * 0.5f, 1f, 0.0, time);
			}
		}

		public override void AddEventListeners()
		{
			EventListener.Add(OnPressPlay, UIEventType.Click, UIAudioProfile.Play);
			EventListener.Add(OnPressFF, UIEventType.Click, UIAudioProfile.FastForward);
			EventListener.Add(OnClockToggle, UIEventType.Click, UIAudioProfile.Clock);
			EventListener.Add(OnClockStart, AudioEventType.ClockStart);
		}

		private void OnClockStart(AudioEvent e)
		{
			playCount = 0;
		}

		private void OnClockToggle(AudioEvent e)
		{
			string sampleName = (e.Condition ? "clock-show-controls" : "clock-hide-controls");
			double num = (e.Condition ? 0.1 : 0.0);
			playCount = ((!e.Condition) ? playCountLimit : 0);
			AudioPlayer.UI.PlaySample(sampleName, 0.75f, 0.5f, 1f, 0.0, AudioSystem.Instance.DspTime + num);
		}

		private void OnPressPlay(AudioEvent e)
		{
			playCount = 0;
		}

		private void OnPressFF(AudioEvent e)
		{
			playCount = 0;
		}
	}
}
