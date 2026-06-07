using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Motorways.Audio
{
	public class Menu : MusicData
	{
		private int nbSteps;

		private float dur;

		public override void Injections()
		{
			SetEchoDuratios(Liszt.From<float>(1f));
			int num = Rando.Range(3, 6);
			SetRhythms(Rando.Pick<List<Rhythm>>(Rhythm.Sine(num, Rando.Pick<float>(1f, 1.25f, 1.3333334f, 1.5f, 1.6666666f, 1.75f, 2f), Rando.Pick<float>(1f, 2f)).Uniform().Scatter(), Rhythm.Frag().Uniform(num).Spread(1f / (float)num)));
			SetQualities(QualityDatabase.Gather("Quartal", "Maj7", "Maj6", "7", "5sus2", "Sus", "Major Lower Tetra", "Sus2Maj7", "Major Pentatonic"), QualityDatabase.Gather("Quartal", "Min7", "MinMaj6", "7", "5sus2", "Sus", "Minor Lower Tetra", "Sus2Min7", "Minor Pentatonic", "Dominant Penta 4"));
			dur = Rhythms[0].Duration / (float)Rando.Pick<int>(2, 3);
			nbSteps = ((dur < 0.5f) ? Rando.Pick<int>(2, 3) : Rando.Pick<int>(3, 4));
			SetDrumSequencer(GenDrumRhythm(), boom: true, bap: true, hat: true, useEuclideanGates: true, 3f);
			DrumVolume = 0.5f;
			SetPortamento(new Param.Portamento(-75, 75, 0.0, 0.5));
			MusicData.MenuKey = StartingKey;
		}

		private Rhythm GenDrumRhythm()
		{
			return new Rhythm(0f, new D20().Frag(nbSteps, dur, 0.15f));
		}

		public override void OnHour()
		{
			DrumSequencer drumSequencer = Get.Loadout.DrumSequencer;
			if (Get.Hour % 6 == 0)
			{
				DrumSequencer.Part part = Rando.Pick(drumSequencer.Parts);
				part.Hits = Rando.Range(0, part.Steps);
				part.Reroll();
			}
			if ((float)drumSequencer.Parts.Sum((DrumSequencer.Part x) => x.Hits) / (float)drumSequencer.Parts.Sum((DrumSequencer.Part x) => x.Steps) > 0.8f)
			{
				drumSequencer.Parts.ForEach(delegate(DrumSequencer.Part x)
				{
					x.Hits = Mathf.Max(0, x.Hits - 1);
				});
			}
		}
	}
}
