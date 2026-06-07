using System.Collections.Generic;

namespace Motorways.Audio
{
	public class Manila : MusicData
	{
		private List<float> duratios = Liszt.From<float>(1f, 1.25f, 1.3333334f, 1.5f, 1.6666666f, 1.75f, 2f);

		private bool flipFlop;

		public override void Injections()
		{
			SetQualities(Liszt.From<Quality>(QualityDatabase.Find("Penta Chromodal")));
			SetDrumSequencer(Rando.Pick(Rhythm.Claves), boom: false, bap: true, hat: true);
			SetKeyDeltas(Rando.Numbers(7, 3), Rando.Range(3, 7));
		}

		public override Rhythm PickInitRhythm(int groupIndex)
		{
			return NewRhythm();
		}

		public override void OnRhythmUpdate(int groupIndex)
		{
			foreach (DestinationGroup destinationGroup in Get.Loadout.DestinationGroups)
			{
				destinationGroup.Module.ChangePulse(NewRhythm());
			}
			flipFlop = !flipFlop;
			UpdateDrumSequencer(Rando.Pick(Rhythm.Claves), Rando.FlipCoin(Get.ZoomOutProgress), Rando.FlipCoin(Get.WeekProgress), Rando.FlipCoin(flipFlop ? 1f : 0f));
		}

		private Rhythm NewRhythm()
		{
			return Rhythm.Sine(Rando.Range(4, 8), Rando.Pick(duratios), Rando.Pick(duratios));
		}
	}
}
