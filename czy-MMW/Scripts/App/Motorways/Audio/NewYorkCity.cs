using System.Collections.Generic;

namespace Motorways.Audio
{
	public class NewYorkCity : MusicData
	{
		public override void Injections()
		{
			SetKeyDeltas(Liszt.From<int>(-1, 1), Rando.Pick<int>(0, 1, 2, 3));
			List<Quality> list = QualityDatabase.Gather("Blues", "7#9", "11", "13");
			list.Add(new Quality("Mixolydian", Liszt.From<int>(2, 2, 1, 2, 2, 1, 2)).Chromatic());
			SetQualities(list);
			List<Rhythm> rhythms = Liszt.From<Rhythm>(new Rhythm(0f, 0.333f, 0.333f, 0.334f), new Rhythm(0f, 0.666f, 0.334f), new Rhythm(0f, 1f), new Rhythm(0f, 1.666f, 0.334f), new Rhythm(0f, 2f));
			SetRhythms(rhythms);
		}

		public override void PostLoad()
		{
			base.PostLoad();
			Get.Loadout.Train.PatternLengthOverride = 4;
		}

		public override void OnTrainArrived()
		{
			Get.Loadout.Train.PatternLengthOverride = 4;
		}
	}
}
