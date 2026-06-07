using System.Linq;

namespace Motorways.Audio
{
	public class Tutorial : MusicData
	{
		public override void Injections()
		{
			SetEchoDuratios(Liszt.From<float>(0.75f));
			SetRhythms(Rhythm.Duplet.Pattern().Uniform().Phase(), RhythmUpdateType.LinearParallel);
			SetDrumSequencer(new Rhythm(0f, Rhythms[0].Steps.Min()), boom: true, bap: true, hat: true);
			SetNoteSequenceStyles(Liszt.Make(6, () => NoteSequenceType.Seeded));
			SetQualities(QualityDatabase.Gather("Major Triad", "Sus", "Maj7", "Sus2Maj7"));
			SetKeyDeltas(Liszt.From<int>(default(int)));
		}
	}
}
