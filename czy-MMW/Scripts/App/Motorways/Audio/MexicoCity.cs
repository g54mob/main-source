using System.Collections.Generic;

namespace Motorways.Audio
{
	public class MexicoCity : MusicData
	{
		private List<Rhythm> GenRhythms()
		{
			return Rhythm.Frag(0.25f).Uniform().Scatter();
		}

		public override void Injections()
		{
			SetEasterEggHorn("Special");
			SetWeekendChances(0f);
			SetRhythms(GenRhythms(), RhythmUpdateType.RandomAll);
			SetQualities(Liszt.From<Quality>(QualityDatabase.MAJOR.GetMode(0, "Ionian"), QualityDatabase.MAJOR.GetMode(5, "Aeolian"), QualityDatabase.Find("7"), QualityDatabase.Find("7b9")));
			SetVoiceLimits(0.05, 2);
			SetDrumSequencer(Rhythms.Shortest());
		}

		public override void OnRhythmUpdate(int groupIndex)
		{
			Rhythms = GenRhythms();
			UpdateDrumSequencer(Rhythms.Shortest(), Boom, Bap, Hat);
			foreach (DestinationGroup destinationGroup in Get.Loadout.DestinationGroups)
			{
				destinationGroup.Module.ChangePulse(Rando.Pick(Rhythms));
			}
		}

		public override void OnConnection()
		{
			Boom = Rando.FlipCoin();
			Bap = Rando.FlipCoin();
			Hat = Rando.FlipCoin();
			UseEuclideanDrumGates = Rando.FlipCoin();
			Get.Loadout.DrumSequencer.Hat.PseudoUpbeatChance = Rando.m();
			if (!Boom && !Bap && !Hat)
			{
				Rando.Pick<bool>(Boom, Bap, Hat).Flip();
			}
		}

		public override float SamplePitchSign()
		{
			return Get.Day switch
			{
				0 => 1f, 
				1 => Rando.FlipCoin(5f / 6f) ? 1f : (-1f), 
				2 => Rando.FlipCoin(2f / 3f) ? 1f : (-1f), 
				3 => Rando.FlipCoin() ? 1f : (-1f), 
				4 => Rando.FlipCoin(1f / 3f) ? 1f : (-1f), 
				5 => Rando.FlipCoin(1f / 6f) ? 1f : (-1f), 
				6 => -1f, 
				_ => 1f, 
			};
		}
	}
}
