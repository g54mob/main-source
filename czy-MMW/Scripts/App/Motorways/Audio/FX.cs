using System;
using System.Linq;
using GAudio;
using UnityEngine;

namespace Motorways.Audio
{
	public static class FX
	{
		public class Modulator : GATDynamicMixInfo
		{
			public class Portamento
			{
				public double StartPitch;

				public double EndPitch;

				public double Duration;

				public Portamento(double startPitch, double endPitch, double duration)
				{
					StartPitch = startPitch;
					EndPitch = endPitch;
					Duration = duration;
				}

				public double Value(double timeThrough)
				{
					double num = ((Duration < 0.001) ? 1.0 : Maf.Clamp(timeThrough / Duration, 0.0, 1.0));
					return StartPitch * (1.0 - num) + EndPitch * num;
				}
			}

			public class LFO
			{
				public double Frequency;

				public double Amplitude;

				public double FrequencyAtStart;

				public double AmplitudeAtStart;

				public double Phase;

				public LFO(double freq, double amp, double phaseAlpha = 0.0)
				{
					Frequency = (FrequencyAtStart = freq);
					Amplitude = (AmplitudeAtStart = amp);
					Phase = Maf.Lerp(0.0, Math.PI * 2.0, phaseAlpha);
				}

				public void Update(double timeThrough)
				{
					double num = (timeThrough * Frequency + Phase) % (Math.PI * 2.0);
					double num2 = timeThrough * Frequency % (Math.PI * 2.0);
					Phase = num - num2;
				}
			}

			public class Vibrato : LFO
			{
				public double PitchPole;

				public Vibrato(double freq, double amp, double pitchPole, double phaseAlpha)
					: base(freq, amp, phaseAlpha)
				{
					PitchPole = pitchPole;
				}

				public double Alpha(double timeThrough)
				{
					return Math.Sin(timeThrough * Frequency + Phase) * 0.5 + 0.5;
				}

				public double Value(double timeThrough)
				{
					return (PitchPole + PitchPole * (0.0 - Amplitude)) * (1.0 - Alpha(timeThrough)) + (PitchPole + PitchPole * Amplitude) * Alpha(timeThrough);
				}
			}

			public class Tremolo : LFO
			{
				public Tremolo(double freq, float amp, double phaseAlpha = 0.0)
					: base(freq, amp, phaseAlpha)
				{
				}

				public float Value(double timeThrough)
				{
					float num = (float)(Math.Sin(timeThrough * (Math.PI * 2.0 * Frequency) + Phase) * 0.5) + 0.5f;
					return 1f - (float)Amplitude * num;
				}
			}

			private double _timeThrough;

			public Portamento Port;

			public Vibrato Vibr;

			public Tremolo Trem;

			public override float Gain => Trem?.Value(_timeThrough) ?? 1f;

			public override double Pitch
			{
				get
				{
					if (Port == null && Vibr == null)
					{
						return base.Pitch;
					}
					double num = Port?.Value(_timeThrough) ?? Vibr.PitchPole;
					Vibrato vibr = Vibr;
					return Maf.Lerp(num + num * ((vibr != null) ? (0.0 - vibr.Amplitude) : 0.0), num + num * (Vibr?.Amplitude ?? 0.0), Vibr?.Alpha(_timeThrough) ?? 1.0);
				}
			}

			public Modulator(Portamento portamento = null, Vibrato vibrato = null, Tremolo tremolo = null)
			{
				Port = portamento;
				Vibr = vibrato;
				Trem = tremolo;
			}

			public override void Update(double deltaDspTime)
			{
				Vibr?.Update(_timeThrough);
				Trem?.Update(_timeThrough);
				_timeThrough += deltaDspTime;
			}
		}

		public static bool IsEchoing;

		public static void UpdateEcho()
		{
			Get.Mixbus.EchoDecay = Settings.ECHO_DECAY_RANGE.Random() * ((Get.Pulse.Scale == TimeScale.DoubleSlow) ? 0.5f : 1f);
			Get.Mixbus.EchoDelay = 1000f * Get.Loadout.MusicData.EchoDuration();
		}

		public static void ToggleEcho(bool on)
		{
			if (IsEchoing != on)
			{
				if (on)
				{
					Get.Mixbus.EchoWet = Settings.ECHO_WET_RANGE.Random() * ((Get.Pulse.Scale == TimeScale.DoubleSlow) ? 0.5f : 1f);
					UpdateEcho();
					IsEchoing = true;
				}
				else
				{
					Get.Mixbus.EchoWet = 0f;
					Get.Mixbus.EchoDecay = 0.75f;
					IsEchoing = false;
				}
			}
		}

		public static void ToggleNightMode(bool on, bool init = false)
		{
			if (Get.Loadout != null)
			{
				ToggleEcho(on);
				if (Get.Loadout?.MusicData?.NightQualities != null)
				{
					Get.Loadout.MusicData.CurrentQualities = (on ? Get.Loadout.MusicData.NightQualities.ToList() : Get.Loadout.MusicData.DayQualities.ToList());
				}
				if (init && on)
				{
					Get.Mixbus.Pitch = Settings.PITCH_NIGHT;
					Settings.PITCH_ANCHOR = Settings.PITCH_NIGHT;
					return;
				}
				Get.Loadout?.MusicData?.Bass?.FadeOutAndStop(0.5);
				float duration = AudioEnvironment.Game.Theme.TransitionDuration * 2f;
				float targetPitch = (Settings.PITCH_ANCHOR = ((!Get.State.HasFlag(StateType.GamePaused)) ? (on ? Settings.PITCH_NIGHT : 1f) : (on ? (Settings.PITCH_NIGHT * Settings.PITCH_PAUSE) : Settings.PITCH_PAUSE)));
				Get.Mixbus.InterpolatePitch(targetPitch, duration, 1, Twerp.CurveType.Boing);
			}
		}

		public static void TogglePauseModePitch(bool on)
		{
			float targetPitch = (Settings.PITCH_ANCHOR = ((!Get.State.HasFlag(StateType.ModeNight)) ? (on ? Settings.PITCH_PAUSE : 1f) : (on ? (Settings.PITCH_NIGHT * Settings.PITCH_PAUSE) : Settings.PITCH_NIGHT)));
			Get.Mixbus.InterpolatePitch(targetPitch, 2f, 1, Twerp.CurveType.Boing);
		}

		public static float SineLFO(float freq)
		{
			return Mathf.Sin(Time.time * freq) * 0.5f + 0.5f;
		}
	}
}
