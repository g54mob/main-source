using System.Collections.Generic;

namespace Motorways.Audio
{
	public class London : MusicData
	{
		public override void Injections()
		{
			SetKeyDeltas(Liszt.From<int>(-1, 1), Rando.Pick<int>(0, 1, 2, 10, 11));
			Quality quality = Quality.Clone(QualityDatabase.MAJOR);
			quality.Scales.RemoveAt(6);
			quality.Scales.RemoveAt(2);
			quality.Chromatic();
			SetQualities(new List<Quality> { quality });
			SetRhythms(Rhythm.AllPulses());
		}

		public override void PostLoad()
		{
			base.PostLoad();
			Get.Loadout.Train.PatternLengthOverride = Rando.Pick<int>(4, 6, 8, 10, 12);
		}

		public override void OnTrainArrived()
		{
			Get.Loadout.Train.PatternLengthOverride = Rando.Pick<int>(4, 6, 8, 10, 12);
		}
	}
}
