using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Audio
{
	public class Cairns : MusicData
	{
		private List<Rhythm> rhythms;

		private Persistent.Chord chord;

		private Rhythm eighthNote = new Rhythm(0f, 0.5f);

		public override void Injections()
		{
			SetEchoDuratios(Liszt.From<float>(0.75f));
			SetKeyDeltas(Liszt.From<int>(5, 7));
			SetPortamento(new Param.Portamento(-75, 75, 0.0, 0.5));
			SetFadeInProgression(1.0, 0.0, asMultiplier: false);
			SetVoiceLimits(0.05, 3);
			SetVibrato(Vibrato, new Param.Vibrato(new Param.Data(10f, 20f), 20));
			SetWeekendChances(0f, 0f);
			rhythms = Liszt.From<Rhythm>(new Rhythm(0f, 0.75f, 0.75f, 0.5f), new Rhythm(0f, 0.5f, 1f, 0.5f, 1f, 0.5f, 0.5f), new Rhythm(0f, 1f, 1f, 1.5f, 0.5f));
			for (int i = 0; i < 3; i++)
			{
				rhythms.Add(rhythms[i].Scale(2f, scaleOffset: true));
				rhythms.Add(rhythms[i].Scale(3f, scaleOffset: true));
			}
			SetRhythms(rhythms);
			SetNoteSequenceStyles(Liszt.Make(6, () => NoteSequenceType.Seeded));
			SetQualities(Liszt.From<Quality>(new Quality("Mixolydian", Liszt.From<int>(2, 2, 1, 2, 2, 1, 2), Liszt.From<int>(0, 12, 17)).Chromatic()));
			SetDrumSequencer(eighthNote, boom: false, bap: false, hat: false, useEuclideanGates: true, 0f, 0f);
			chord = new Persistent.Chord();
		}

		public override void OnNewWeek()
		{
			if (Get.Week == 1)
			{
				UpdateDrumSequencer(eighthNote, boom: true, bap: false, hat: true);
			}
		}

		public override void OnDay()
		{
			if (Get.Day == 5)
			{
				UpdateNoteWindow(Get.MaxGroups - 1, 1f, 0, 0.5f, forceChange: true);
				chord.Play(dspStartTime: Clock.NextPulseTime, polyphony: Mathf.Max(1, Get.AudibleGroups), spread: eighthNote.Steps[0] * 0.5f, isImportant: false, transpose: 0, gainAdjust: 0.5f);
			}
		}
	}
}
