using UnityEngine;

namespace Motorways.Audio
{
	public class Vancouver : MusicData
	{
		private int commonTones = 5;

		private Rhythm firstRhythm;

		private Persistent.Chord chord;

		public override void Injections()
		{
			SetQualities(Liszt.From<Quality>(new Quality("Maj9", Liszt.From<int>(2, 2, 3, 4, 1), Liszt.From<int>(0, 12, 24)).Chromatic(), new Quality("Minor Hex", Liszt.From<int>(2, 1, 2, 2, 3, 2), Liszt.From<int>(0, 12, 24)).Chromatic()), null, defaultNoteWindowBehavior: false);
			SetVibrato(new Param.Vibrato(new Param.Data(10f, 20f), 12), new Param.Vibrato(new Param.Data(10f, 20f), 12));
			SetTremolo(new Param.LFO(new Param.Data(10f, 20f), new Param.Data(0f, 0.5f)), new Param.LFO(new Param.Data(10f, 20f), new Param.Data(0f, 0.5f)));
			firstRhythm = Rhythm.Frag(0.5f);
			firstRhythm.Offset = Rando.m();
			SetDrumSequencer(firstRhythm, boom: false, bap: false, hat: false, useEuclideanGates: true, 0f, 10f);
			SetRhythms(Liszt.From<Rhythm>(firstRhythm));
			SetVoiceLimits(0.25, 6, 0.25, 2);
			chord = new Persistent.Chord();
			commonTones = Get.MaxGroups - 1;
		}

		public override void OnNewWeek()
		{
			if (Get.Week > 3)
			{
				commonTones = Get.MaxGroups - Rando.Range(1, 5);
			}
			else if (Get.Week > 0)
			{
				commonTones = Get.MaxGroups - (Get.Week + 1);
			}
			if (Get.Week == 1)
			{
				Boom = true;
				Bap = true;
				Hat = true;
			}
			UpdateNoteWindow(commonTones, 1f, 0, 1f, forceChange: true);
		}

		private void UpdateDrums(bool boom, bool bap, bool hat)
		{
			if (Get.Week > 0 && Get.Day % 2 == 0)
			{
				UpdateDrumSequencer(firstRhythm, boom, bap, hat);
			}
		}

		public override void OnHour()
		{
			if (Get.Hour == 23)
			{
				UpdateNoteWindow(commonTones, 1f, 0, 0.5f, forceChange: true);
				chord.Play(dspStartTime: Clock.NextPulseTime, polyphony: Mathf.Max(1, Get.AudibleGroups), spread: firstRhythm.Steps[0] * 0.5f, isImportant: false, transpose: 0, gainAdjust: 0.5f);
			}
			if (Get.Hour == 5)
			{
				if (Get.Week % 4 == 1 || Get.Week % 4 == 3)
				{
					UpdateDrums(Boom, Bap, !Hat);
				}
				if (Get.Week > 2 && Rando.FlipCoin())
				{
					chord.PlaySingleRandom(0, 0.5f, 0.33f);
				}
			}
			if (Get.Hour != 17)
			{
				return;
			}
			if (Get.Week > 3)
			{
				chord.PlaySingleRandom(12, 0f, 0.33f);
			}
			if (Get.Week == 2 || Get.Week == 3)
			{
				UpdateDrums(Boom, !Bap, Hat);
			}
			else
			{
				if (Get.Week <= 1 || Get.Day % 2 != 0)
				{
					return;
				}
				firstRhythm = firstRhythm.InjectNoise(0.05f);
				firstRhythm = new Rhythm(firstRhythm.Offset, firstRhythm.Steps);
				UpdateDrums(Rando.FlipCoin(), Rando.FlipCoin(), Rando.FlipCoin());
				foreach (DestinationGroup destinationGroup in Get.Loadout.DestinationGroups)
				{
					destinationGroup.Module.ChangePulse(firstRhythm);
				}
			}
		}

		public override void OnRhythmUpdate(int groupIndex)
		{
		}

		public override void OnDay()
		{
			if (Get.Week % 4 == 0 || Get.Week % 4 == 3)
			{
				UpdateDrums(!Boom, Bap, Hat);
			}
			if (Get.Week > 2)
			{
				string text = Note.SCALE[CurrentScale.Key];
				Bass?.FadeOutAndStop(0.5);
				Bass = AudioPlayer.Default.PlaySample("bass_" + text, 0.5f, 0.2f, dspTime: Clock.NextPulseTime, pitch: Get.State.HasFlag(StateType.ModeNight) ? Rando.Pick<float>(-0.5f, -1f) : 1f, fadeTime: 0.5);
			}
		}
	}
}
