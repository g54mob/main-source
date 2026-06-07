namespace Motorways.Audio
{
	public class Munich : MusicData
	{
		public override void Injections()
		{
			SetRhythms(Rhythm.Triplet.Pulses().And(Rhythm.Duplet.Patterns()), RhythmUpdateType.RandomSingle);
			SetQualities(QualityDatabase.Gather("Maj7"));
		}
	}
}
