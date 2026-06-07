using System.Collections.Generic;

namespace Motorways.Audio
{
	public class Copenhagen : MusicData
	{
		private List<Rhythm> rhythms;

		private Rhythm quarterNote = new Rhythm(0f, 0.25f);

		public override void Injections()
		{
			rhythms = Liszt.From<Rhythm>(new Rhythm(0f, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f), new Rhythm(0f, 0.5f, 0.25f), new Rhythm(0f, 0.5f, 0.25f, 0.25f), new Rhythm(0f, 0.75f, 0.25f, 0.5f, 0.5f), new Rhythm(0f, 0.5f, 0.5f, 1f), new Rhythm(0f, 0.75f, 0.75f, 0.5f), new Rhythm(0f, 0.5f, 0.25f, 0.25f, 0.5f, 0.5f));
			for (int i = 0; i < 7; i++)
			{
				rhythms.Add(rhythms[i].Scale(2f, scaleOffset: true));
				rhythms.Add(rhythms[i].Scale(3f, scaleOffset: true));
			}
			SetRhythms(rhythms);
			List<int> baseStack = Liszt.From<int>(12, 19, 24);
			List<Quality> dayQualities = Liszt.From<Quality>(new Quality("Ionian", Liszt.From<int>(2, 2, 1, 2, 2, 2, 1), baseStack), new Quality("Mixolydian b7", Liszt.From<int>(2, 2, 2, 1, 2, 1, 2), baseStack), new Quality("Dorian", Liszt.From<int>(2, 1, 2, 2, 2, 1, 2), baseStack), new Quality("Aeolian", Liszt.From<int>(2, 1, 2, 2, 1, 2, 2), baseStack), new Quality("Mixolydian", Liszt.From<int>(2, 2, 1, 2, 2, 1, 2), baseStack), new Quality("Traditional Minor", Liszt.From<int>(2, 1, 2, 2, 2, 2, 1), baseStack));
			SetQualities(dayQualities);
			SetDrumSequencer(quarterNote, boom: false, bap: false, hat: false, useEuclideanGates: true, 0f, 0f);
		}

		public override void PostLoad()
		{
			base.PostLoad();
			UpdateTrain(Rando.Pick<int>(3, 4), 0.5f, 0, "STAR", "CROSS", "TRIANGLE");
		}

		public override void OnHour()
		{
			DrumVolume = 1f - Maf.Map(Get.Loadout.Train.SpeedAlpha, 0.1f, 1f, 0f, 1f) * Maf.Map(Get.Loadout.Train.Attenuation, 0f, 0.25f, 0f, 1f);
		}

		public override void OnTrainArrived()
		{
			UpdateTrain(Rando.Pick<int>(3, 4), -1f, -1);
		}

		public override void OnNewWeek()
		{
			UpdateTrain(-1, -1f, -1);
			if (Get.Week > 0)
			{
				UpdateDrumSequencer(quarterNote, Rando.FlipCoin(), Rando.FlipCoin(), Rando.FlipCoin());
			}
		}
	}
}
