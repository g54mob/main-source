using System;
using System.Collections.Generic;
using Motorways.Models;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Audio
{
	public class Vehicle : Playback
	{
		public class AudioMotor : FX.Modulator
		{
			private struct Interpolator
			{
				public float Value;

				public float Target;

				public float Min;

				public float Max;

				public float Duration;

				public Interpolator(float min, float max, float duration)
				{
					Min = min;
					Max = max;
					Duration = duration;
					Value = (Target = 1f);
				}

				public void Interp(double deltaTime)
				{
					Value = Mathf.MoveTowards(Value, Target, (Max - Min) / (Duration / (float)deltaTime));
				}
			}

			private MusicData.EngineData _engineData;

			public double PitchAtFullSpeed;

			private Interpolator _gainPause = new Interpolator(0f, 1f, 2f);

			private Interpolator _gainDeleteMode = new Interpolator(0.25f, 1f, 1f);

			private Interpolator _gainInTunnel = new Interpolator(0.1f, 1f, 0.33f);

			public VehicleView Vehicle { get; set; }

			public HouseView House { get; private set; }

			public DestinationView Destination { get; private set; }

			public AudioSample Sample { get; private set; }

			public override double Pitch => Maf.Lerp(PitchAtFullSpeed * 0.1, PitchAtFullSpeed, NormSpeed());

			public override float Gain => base.Gain * _engineData.Gain * _gainPause.Value * _gainDeleteMode.Value * _gainInTunnel.Value * Vehicle.Attenuation * Twerp.Ease.In(Mathf.Clamp((float)NormSpeed(), 0f, 2f / 3f), 2);

			public override float Pan => Vehicle.Pan[0];

			public AudioMotor(VehicleView v)
			{
				Vehicle = v;
				House = v.House;
				Destination = v.Destination;
				List<MusicData.EngineData> groupEngines = Get.Loadout.MusicData.GroupEngines;
				_engineData = groupEngines[Mathf.Clamp(Vehicle.groupIndex, 0, groupEngines.Count - 1)];
				PitchAtFullSpeed = (float)Rando.Pick<int>(-1, 1) * UnityEngine.Random.Range(_engineData.PitchRange.x, _engineData.PitchRange.y);
				Trem = new Tremolo(Rando.Range(1.0, 20.0), UnityEngine.Random.Range(0f, 0.2f));
				PlayEngineLoop();
			}

			public override void OnGameTick()
			{
				if (Sample?.DynamicMix != null)
				{
					Trem.Frequency = Maf.Lerp(Trem.FrequencyAtStart, 20.0, NormSpeed(2.0));
					Trem.Amplitude = Maf.Lerp(Trem.AmplitudeAtStart, 1.0, (1.0 - NormSpeed()) * 0.5);
				}
				_gainPause.Target = (Get.Game.Simulation.IsPaused ? _gainPause.Min : _gainPause.Max);
				_gainDeleteMode.Target = (Get.State.Contains(StateType.ModeDelete) ? _gainDeleteMode.Min : _gainDeleteMode.Max);
				_gainInTunnel.Target = (Vehicle.IsInTunnel ? _gainInTunnel.Min : _gainInTunnel.Max);
			}

			public override void Update(double deltaDspTime)
			{
				_gainPause.Interp(deltaDspTime);
				_gainDeleteMode.Interp(deltaDspTime);
				_gainInTunnel.Interp(deltaDspTime);
			}

			public void FadeOutAndStop(double duration = 1.0)
			{
				if (Sample != null)
				{
					Sample.FadeOutAndStop(duration);
					Sample.DynamicMix = null;
					Sample = null;
				}
			}

			public double NormSpeed(double maxSpeed = 3.0)
			{
				return Math.Min((double)Vehicle.Speed / maxSpeed, 1.0);
			}

			public void PlayEngineLoop()
			{
				Sample = AudioPlayer.UI.PlaySample(_engineData.Sample, Vehicle.Pan.x, 0.2f, (float)PitchAtFullSpeed, 1.5, -1.0, loop: true, this, stereo: false, randomStart: true);
			}
		}

		public VehicleView View;

		public AudioMotor Motor;

		public LocationType Location;

		public float LegDistance;

		private double _lastHonkTime;

		private double timeAtRedLight;

		public AudioEventType EventTypes = AudioEventType.VehicleArrivedAtDestination | AudioEventType.VehicleArrivedAtHouse | AudioEventType.VehicleDepartedDestination | AudioEventType.VehicleDepartedHouse | AudioEventType.VehicleEnteredMotorway | AudioEventType.VehicleLeftMotorway | AudioEventType.VehicleEnteredCarpark | AudioEventType.VehicleReceivesPin | AudioEventType.VehicleSpawned;

		public Vehicle(VehicleView view)
		{
			View = view;
			View.AudioVehicle = this;
		}

		public override void OnDeactivate()
		{
			View.AudioVehicle = null;
		}

		public override void Update()
		{
			View.AudioVehicle?.Motor?.OnGameTick();
		}

		protected override void OnPulse()
		{
			PrepHorn();
		}

		public float DistanceAlpha()
		{
			return 1f - Mathf.Clamp(View.DistanceToGoal / LegDistance, 0f, 1f);
		}

		public void PrepHorn()
		{
			float num = 0.01f;
			float num2 = 0.02f;
			float num3 = 0.95f;
			int num4 = 8;
			float chance = 0.8f;
			bool num5 = Location == LocationType.Home || Location == LocationType.Carpark;
			bool flag = View.Speed > num;
			float num6 = DistanceAlpha();
			bool flag2 = num6 > num3 || num6 < num2;
			bool isPaused = Get.Game.Simulation.IsPaused;
			bool isInTunnel = View.IsInTunnel;
			VehicleModel.Frame frame = null;
			if (View != null && View.Model != null)
			{
				frame = View.Model.CurrentFrame;
			}
			bool flag3 = frame?.leadingVehicle == null;
			bool flag4 = !flag3 && (float)frame.distanceToLeadingVehicle < 0.6f;
			bool flag5 = frame?.blockingLane?.roadChunk?.TrafficLight != null;
			timeAtRedLight = (flag5 ? (timeAtRedLight + Module.Pulse.PulseInfo.PulseDuration) : 0.0);
			bool flag6 = timeAtRedLight < (double)num4 && !flag4 && Rando.FlipCoin(chance);
			if (!(num5 || flag || flag2 || flag3 || flag6 || isPaused || isInTunnel) && time > _lastHonkTime + (double)num4)
			{
				Honk();
			}
		}

		public void Honk()
		{
			if (View != null && View.groupIndex >= 0 && View.groupIndex < Get.Loadout.DestinationGroups.Count)
			{
				List<string> notes = Get.Loadout.DestinationGroups[View.groupIndex].Notes;
				if (Diagnostics.Verify(notes.Count > 0, $"No notes available for honk on Group {View.groupIndex}. Destination Groups: {Get.Loadout.DestinationGroups.Count}"))
				{
					string text = notes[UnityEngine.Random.Range(0, notes.Count - 1)];
					text = text.Substring(0, text.Length - 1);
					AudioPlayer.Default.PlaySample("Horn-" + text + "-" + (Rando.FlipCoin(0.995f) ? Rando.Pick<string>("01", "02", "03", "04", "05") : Get.Loadout.MusicData.EasterEggHorn), pitch: Tune.centsToFreqRatio(UnityEngine.Random.Range(-50, 50)), pan: View.Pan.x, gain: 0.11f * View.Attenuation, fadeTime: 0.0, dspTime: time);
					_lastHonkTime = time;
				}
			}
		}

		public override void AddEventListeners()
		{
			AudioEventFilter audioEventFilter = new AudioEventFilter(EventTypes);
			audioEventFilter.Vehicle = View;
			EventListener.Add(OnVehicleEvents, audioEventFilter);
			EventListener.Add(OnGameOver, AudioEventType.GameOver);
			EventListener.Add(OnAudioMinimized, AudioEventType.AudioMinimized);
		}

		private void OnGameOver(AudioEvent e)
		{
			foreach (List<VehicleView> vehicle in Environment.Vehicles)
			{
				foreach (VehicleView item in vehicle)
				{
					item?.AudioVehicle?.Motor?.FadeOutAndStop(2.0);
				}
			}
		}

		private void OnAudioMinimized(AudioEvent e)
		{
			foreach (List<VehicleView> vehicle in Environment.Vehicles)
			{
				foreach (VehicleView item in vehicle)
				{
					item?.AudioVehicle?.Motor?.FadeOutAndStop(2.0);
				}
			}
		}

		private void OnVehicleEvents(AudioEvent e)
		{
			switch (e.Type)
			{
			case AudioEventType.VehicleArrivedAtHouse:
				Location = LocationType.Home;
				Motor?.FadeOutAndStop();
				break;
			case AudioEventType.VehicleDepartedHouse:
				Location = LocationType.Road;
				LegDistance = Mathf.Max(0f, (float)View.Model.pathLength);
				Motor?.FadeOutAndStop();
				if (Motor == null)
				{
					Motor = new AudioMotor(e.Vehicle);
				}
				else
				{
					Motor.PlayEngineLoop();
				}
				break;
			case AudioEventType.VehicleEnteredMotorway:
				Location = LocationType.Motorway;
				break;
			case AudioEventType.VehicleLeftMotorway:
				Location = LocationType.Road;
				break;
			case AudioEventType.VehicleEnteredCarpark:
				Location = LocationType.Carpark;
				break;
			case AudioEventType.VehicleArrivedAtDestination:
				Motor?.FadeOutAndStop();
				break;
			case AudioEventType.VehicleDepartedDestination:
				Location = LocationType.Road;
				Motor?.FadeOutAndStop();
				if (Motor == null)
				{
					Motor = new AudioMotor(e.Vehicle);
				}
				else
				{
					Motor.PlayEngineLoop();
				}
				break;
			case AudioEventType.VehicleReceivesPin:
			{
				if (e.GroupIndex > Get.Loadout.DestinationGroups.Count - 1)
				{
					Dbug.Log.Warn("VehicleReceivesPin: event group index is greater than our DestGroup count. Skipping ...");
					break;
				}
				DestinationGroup destinationGroup = Get.Loadout.GetDestinationGroup(e.GroupIndex);
				if (destinationGroup.Notes.Count < 1)
				{
					Dbug.Log.Warn("VehicleReceivesPin: Notes have not yet been generated for this DestinationGroup.");
					break;
				}
				string text = destinationGroup.Notes.SafeGet(destinationGroup.Note_i);
				AudioPlayer.Default.PlaySample("PeepEmbarks_" + text, e.Vehicle.Pan.x, dspTime: Get.Pulse.HybridTime(destinationGroup.Module), gain: Note.GainFactor(text) * 0.18f * e.Vehicle.Attenuation, pitch: 4f);
				AudioPlayer.Default.PlaySample("PeepEmbarks_" + text, e.Vehicle.Pan.x, Note.GainFactor(text) * 0.01f * e.Vehicle.Attenuation, -4f, 0.1, -1.0, loop: false, null, stereo: false, randomStart: false, 0.94f);
				break;
			}
			}
		}
	}
}
