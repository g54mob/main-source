using System.Collections.Generic;

namespace Motorways.Audio
{
	public class Mumbai : MusicData
	{
		public override void Injections()
		{
			SetKeyDeltas(Liszt.From<int>(-1, 1), Rando.Pick<int>(11, 0, 7));
			SetFadeInTimes(2.549999952316284, 2.200000047683716);
			GlobalFadeOut = (LocalFadeOut = 1.0);
			Quality quality = new Quality("Lydian b7", Liszt.From<int>(2, 2, 2, 1, 2, 1, 2));
			Quality quality2 = new Quality("Mixolydian", Liszt.From<int>(2, 2, 1, 2, 2, 1, 2));
			Quality quality3 = new Quality("Lydian", Liszt.From<int>(2, 2, 2, 1, 2, 2, 1));
			SetQualities(Liszt.From<Quality>(quality.Chromatic(), quality2.Chromatic(), quality3.Chromatic()));
			List<Rhythm> rhythms = Liszt.From<Rhythm>(new Rhythm(0f, 0.75f), new Rhythm(0f, 1f), new Rhythm(0f, 1.5f), new Rhythm(0f, 2f));
			SetRhythms(rhythms);
		}

		public override void PostLoad()
		{
			base.PostLoad();
			Get.Loadout.Train.PatternLengthOverride = Rando.Pick<int>(5, 7, 9, 11, 13);
		}

		public override void OnTrainArrived()
		{
			Get.Loadout.Train.PatternLengthOverride = Rando.Pick<int>(5, 7, 9, 11, 13);
		}
	}
}
