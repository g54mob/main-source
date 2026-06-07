using System.Collections.Generic;
using Motorways.Models;
using Motorways.Views.Trains;
using UnityEngine;

namespace Motorways.Audio
{
	public class Train : Playback
	{
		public List<string> TrainEngines = new List<string> { "CIRCLE", "CROSS", "DIAMOND", "EGG", "PENTAGON", "SQUARE", "STAR", "TRIANGLE" };

		private int seed = -1;

		private int patternLength;

		private int enginePulse = 8;

		private int counter;

		private bool trainArrived;

		private int _subDiv = -1;

		public bool VariablePulseMode = true;

		public int PatternLengthOverride = -1;

		public float KickDoublingProbability = 0.25f;

		public float SpeedAlpha;

		public float Attenuation;

		private TimeScale prevScale;

		public Train(TrainView view)
		{
			Reseed();
		}

		public void Reseed()
		{
			seed = Rando.Range(1, 9999);
			patternLength = ((PatternLengthOverride > 0) ? PatternLengthOverride : Rando.Range(4, 13, seed));
			enginePulse = Rando.Range(6, 9);
		}

		protected override void OnPulse()
		{
			if (Get.State.HasAny(StateType.GameOver) || Get.Game.Simulation.IsPaused)
			{
				return;
			}
			foreach (TrainView train in Get.Environment.Trains)
			{
				Attenuation = Mathf.Pow(train.Attenuation, 1.5f);
				if (train._state != TrainModel.BehaviorState.Stopped)
				{
					counter++;
					if (counter > patternLength - 1)
					{
						counter = 0;
					}
					SpeedAlpha = train._speed / 3f;
					if (VariablePulseMode)
					{
						int num = (int)(Mathf.Lerp(4f, enginePulse, SpeedAlpha) / Get.Pulse.Scale.Scale);
						if (num != _subDiv)
						{
							Module.ChangePulse(num);
							_subDiv = num;
						}
					}
					else
					{
						if (prevScale != Get.Pulse.Scale)
						{
							Module.ChangePulse((int)(4f / Get.Pulse.Scale.Scale));
						}
						prevScale = Get.Pulse.Scale;
						if (Rando.m(seed++) > SpeedAlpha)
						{
							break;
						}
					}
					if (Attenuation > 0f)
					{
						AudioPlayer.Default.PlaySample("PeepAppears_" + TrainEngines[Rando.Range(0, TrainEngines.Count - 1, seed * counter)], train.Pan.x, Mathf.Lerp(0.5f, 1f, Maf.VolCurve(SpeedAlpha)) * 0.5f * Attenuation, Rando.Range(0.5f, 2f, seed + counter) * Mathf.Lerp(0.5f, 1f, SpeedAlpha), 0.0, time);
						if (Rando.m(seed + counter) < KickDoublingProbability)
						{
							AudioPlayer.Default.PlaySample("perc_kick", train.Pan.x, Mathf.Lerp(0.5f, 1f, Maf.VolCurve(SpeedAlpha)) * 0.75f * Attenuation, Rando.Range(0.75f, 1.25f, seed + counter) * Mathf.Lerp(0.5f, 1f, SpeedAlpha), 0.0, time);
						}
					}
				}
				else if (trainArrived)
				{
					if (Attenuation > 0f)
					{
						AudioPlayer.Default.PlaySample("TrainArrives_" + Rando.Pick<string>("0", "1"), train.Pan.x, 0.075f * Attenuation, Rando.Range(0.6f, 0.8f), 0.0, time);
					}
					trainArrived = false;
				}
			}
		}

		public override void AddEventListeners()
		{
			EventListener.Add(OnTrainArrives, new AudioEventFilter(AudioEventType.TrainArrives));
		}

		private void OnTrainArrives(AudioEvent e)
		{
			trainArrived = true;
			Get.Loadout.MusicData.OnTrainArrived();
		}

		private void OnTrainDeparts(AudioEvent e)
		{
		}
	}
}
