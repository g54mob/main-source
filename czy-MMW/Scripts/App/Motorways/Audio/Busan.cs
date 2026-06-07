using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Audio
{
	public class Busan : MusicData
	{
		private List<Rhythm> ClavesLong = Rhythm.Claves.Scale(1.5f);

		public override void Injections()
		{
			List<Quality> list = new List<Quality>
			{
				new Quality("Dorian Pentatonic", new List<int> { 3, 2, 2, 2 }),
				new Quality("Minor Penta 5", new List<int> { 2, 3, 2, 2 }),
				new Quality("Minor Penta 1", new List<int> { 3, 2, 2, 3 }),
				new Quality("Aeolian no6no7", new List<int> { 2, 1, 2, 2 }),
				new Quality("Dorian no3", new List<int> { 2, 3, 2, 2, 1 })
			};
			list = list.Chromatic(" (Chromatic)");
			SetQualities(list);
			SetKeyDeltas(Liszt.From<int>(-1), Rando.Range(4, 7));
			SetRhythms(Rando.Pick<List<Rhythm>>(Rhythm.Claves, ClavesLong));
			SetDrumSequencer(Rhythms.Pick(), boom: false, bap: true, hat: true);
			SetTremolo(new Param.LFO(new Param.Data(0.18f, 0.22f), new Param.Data(0.33f, 0.45f)), new Param.LFO(new Param.Data(5f, 5f), new Param.Data(0f, 0f)));
			SetVibrato(new Param.Vibrato(new Param.Data(0.72f, 0.88f), 25), new Param.Vibrato(new Param.Data(5f, 5f), 0));
			SetVoiceLimits(0.1, 4, 0.0, 2);
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
			if (Get.Clock.Hour < 6)
			{
				return;
			}
			if (Get.Hour % 18 == 0 && Rando.FlipCoin())
			{
				UpdateNoteWindow();
			}
			float chance = Mathf.Max(Get.WeekProgress, Get.ZoomOutProgress);
			if (Get.Hour % 12 == 0 && Rando.FlipCoin(chance))
			{
				UpdateDrumSequencer(Rhythms.Pick(), Boom, Bap, Hat);
			}
			if (Get.Hour % Rando.Pick<int>(6, 9) == 0)
			{
				Get.Loadout.DrumSequencer.Parts.ForEach(delegate(DrumSequencer.Part x)
				{
					x.Toggle(0.25f);
				});
			}
		}
	}
}
