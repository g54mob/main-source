namespace Motorways.Audio
{
	public class Moscow : MusicData
	{
		public override void Injections()
		{
			SetRhythms(Liszt.Make(12, () => Rando.Pick<Rhythm>(Rhythm.Frag(), Rhythm.Sine(Rando.Range(3, 8), Rando.Pick(Rhythm.FragRatios(0)), Rando.Range(0.25f, 2f), Rando.Range(0.25f, 0.75f)), Rando.Pick(Rhythm.AllPlets()))), Rando.EnumValue<RhythmUpdateType>());
			SetFadeInProgression(ZeroOrRandom(), ZeroOrRandom(), Rando.FlipCoin());
			SetFadeInTimes(ZeroOrRandom(), ZeroOrRandom());
			SetNoteSequenceStyles(Liszt.Make(6, () => Rando.EnumValue<NoteSequenceType>()));
		}

		private double ZeroOrRandom()
		{
			return Rando.Pick<double>(0.0, 0.0, 0.0, Rando.Range(0.0, 0.25));
		}
	}
}
