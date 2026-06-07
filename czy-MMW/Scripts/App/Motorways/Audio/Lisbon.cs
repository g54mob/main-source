using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Audio
{
	public class Lisbon : MusicData
	{
		private List<Rhythm> ClavesLong = Rhythm.Claves.Scale(1.5f);

		public override void Injections()
		{
			Quality quality = Quality.Clone(QualityDatabase.MAJOR);
			quality.Scales.RemoveAt(6);
			quality.Chromatic();
			SetQualities(Liszt.From<Quality>(quality));
			SetKeyDeltas(Liszt.From<int>(-1), Rando.Range(4, 7));
			SetRhythms(Rando.Pick<List<Rhythm>>(Rhythm.Claves, ClavesLong), RhythmUpdateType.RandomSingle);
			SetTremolo(new Param.LFO(new Param.Data(5f, 5f), new Param.Data(0f, 0f)), new Param.LFO(new Param.Data(0.18f, 0.22f), new Param.Data(0.33f, 0.45f)));
			SetVibrato(new Param.Vibrato(new Param.Data(0.72f, 0.88f), 25), new Param.Vibrato(new Param.Data(5f, 5f), 0));
			SetVoiceLimits(0.1, 5, 0.0, 2);
		}

		public override int ChordSize()
		{
			if (Get.Clock.Hour >= 6)
			{
				return Mathf.Min(Get.Week + 1, base.NoteWindow.Count);
			}
			return base.ChordSize();
		}

		public override float ChordSpread()
		{
			return Mathf.Lerp(0.5f, 0.05f, ChordSize() / base.NoteWindow.Count);
		}

		public override void OnHour()
		{
			if (Get.Clock.Hour >= 6 && Get.Hour % 18 == 0 && Rando.FlipCoin())
			{
				UpdateNoteWindow();
			}
		}

		public override void OnHouseConnected(int groupIndex)
		{
			UpdateNoteWindow();
		}
	}
}
