using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Audio
{
	public class DrumSequencer : Playback
	{
		public struct Part
		{
			public int Steps;

			public int Hits;

			public bool StartOnTrue;

			public bool Reverse;

			public List<bool> Sequence;

			public float PanOffset;

			public string SampleName;

			public float PseudoUpbeatChance;

			public Param.Group Parameters;

			public bool Do;

			public List<List<float>> Randoms;

			public bool On;

			public Part(int steps, int hits, Param.Group group, string sampleName = "perc_kick", float pseudoUpbeatChance = 0f)
			{
				SampleName = sampleName;
				PseudoUpbeatChance = pseudoUpbeatChance;
				Parameters = group;
				Steps = steps;
				Hits = hits;
				StartOnTrue = Rando.FlipCoin();
				Reverse = Rando.FlipCoin();
				Sequence = Maf.Bjorklund(Hits, Steps, StartOnTrue, Reverse);
				PanOffset = Rando.m();
				Do = (On = false);
				Randoms = new List<List<float>>();
				for (int i = 0; i < 3; i++)
				{
					Randoms.Add(Liszt.Make(Sequence.Count, () => Rando.m()));
				}
			}

			public void Reroll()
			{
				Sequence = Maf.Bjorklund(Hits, Steps, StartOnTrue, Reverse);
			}

			public void Toggle(float chance = 1f)
			{
				On = (Rando.FlipCoin(chance) ? (!On) : On);
			}

			public void Play(bool on)
			{
				On = on;
				MusicData musicData = Get.Loadout.MusicData;
				DrumSequencer drumSequencer = Get.Loadout.DrumSequencer;
				if (musicData.UseEuclideanDrumGates)
				{
					Do = On && Sequence.SafeGet(drumSequencer.sequence_i);
				}
				else
				{
					Do = On;
				}
				if (Do)
				{
					double num = drumSequencer.time;
					if (Randoms[2].SafeGet(drumSequencer.sequence_i) < PseudoUpbeatChance)
					{
						num += (drumSequencer.Module.NextPulseTime - drumSequencer.time) / 2.0;
					}
					AudioPlayer.Default.PlaySample(SampleName, GetPanLFO(PanOffset), drumSequencer.VolumeActual * Mathf.Lerp(Parameters.Gain.Range.x, Parameters.Gain.Range.y, Randoms[0].SafeGet(drumSequencer.sequence_i)), Mathf.Lerp(Parameters.Pitch.Range.x, Parameters.Pitch.Range.y, Randoms[1].SafeGet(drumSequencer.sequence_i)), 0.0, num);
				}
			}
		}

		private int sequence_i;

		private bool pauseMode;

		private bool play;

		private int _pulseCount;

		private float VolumeActual;

		public Part Boom;

		public Part Bap;

		public Part Hat;

		public List<Part> Parts;

		private TimeScale prevScale;

		public bool PauseMode
		{
			get
			{
				return pauseMode;
			}
			set
			{
				if (value != pauseMode)
				{
					pauseMode = value;
				}
			}
		}

		public bool Play
		{
			get
			{
				return play;
			}
			set
			{
				if (value != play)
				{
					play = value;
					_pulseCount = 0;
					if (play)
					{
						Init();
					}
				}
			}
		}

		public override void OnDeactivate()
		{
			Play = false;
		}

		public override void OnBeginPulse()
		{
			ChangePulse(Get.Loadout.MusicData.DrumSequencerRhythm);
		}

		public void ChangePulse(Rhythm newRhythm)
		{
			Module.ChangePulse(newRhythm);
			Init();
		}

		public static float GetPanLFO(double offset = 0.0)
		{
			offset *= 48.0;
			double num = (offset + AudioSystem.Instance.DspTime) % (double)Get.Pulse.Duratio(48f) / (double)Get.Pulse.Duratio(24f);
			return (float)((num > 1.0) ? (2.0 - num) : num);
		}

		protected override void OnPulse()
		{
			if ((!Play && !PauseMode) || Get.State.HasAny(StateType.GameOver) || (Get.Loadout.Id != "menu" && Get.AudibleGroups < 1))
			{
				return;
			}
			MusicData musicData = Get.Loadout.MusicData;
			if (prevScale != Get.Pulse.Scale && Get.Pulse.Scale != TimeScale.DoubleSlow && Get.Pulse.Scale != TimeScale.SingleSlow)
			{
				Module.ChangePulse(musicData.DrumSequencerRhythm.Scale(Get.Pulse.Scale.Scale));
			}
			prevScale = Get.Pulse.Scale;
			_pulseCount++;
			VolumeActual = musicData.DrumVolume;
			float num = (float)(_pulseCount / Module.Rhythm.Steps.Length) * Module.Rhythm.Duration;
			if (!(((musicData.DrumDelayDuration == 0f) ? 1f : (num / musicData.DrumDelayDuration)) < 1f))
			{
				float num2 = ((musicData.DrumAttackDuration == 0f) ? 1f : ((num - musicData.DrumDelayDuration) / musicData.DrumAttackDuration));
				if (num2 < 1f)
				{
					VolumeActual = Mathf.Lerp(0f, musicData.DrumVolume, Maf.VolCurve(num2));
				}
				Boom.Play(musicData.Boom);
				Bap.Play(musicData.Bap);
				Hat.Play(musicData.Hat);
				if (_pulseCount % Module.Rhythm.Steps.Length == 0)
				{
					musicData?.OnDrumRhythmComplete();
				}
				musicData?.OnDrumPulse();
				sequence_i++;
			}
		}

		private void Init()
		{
			Play = true;
			List<int> list = Liszt.From<int>(8, 12, 16, 24, 32, 40);
			int num = Rando.Pick(list);
			list.Remove(num);
			int num2 = Rando.Pick(list);
			int num3 = Rando.Pick(list);
			Boom = new Part(num, UnityEngine.Random.Range(2, num - 1), Param.Group.Make(0.2f, 1f, 0.75f, 1.25f));
			Bap = new Part(Rando.Pick(list), UnityEngine.Random.Range(1, num2 / 2), Param.Group.Make(0.2f, 0.5f, 2f, 6f));
			Hat = new Part(Rando.Pick(list), UnityEngine.Random.Range(num3 / 2, num3), Param.Group.Make(0f, 0.4f, 1f, 4f), "PeepAppears_TRIANGLE");
			Parts = Liszt.From<Part>(Boom, Bap, Hat);
		}
	}
}
