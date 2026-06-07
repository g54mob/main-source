namespace Motorways.Audio
{
	public class Tokyo : MusicData
	{
		public override void Injections()
		{
			SetRhythms(Rhythm.AllPulses().Phase(0.1f), RhythmUpdateType.LinearParallel);
			SetNoteSequenceStyles(Liszt.Make(6, () => NoteSequenceType.Forward));
			SetQualities(QualityDatabase.Gather("Penta", "Penta Chromodal", "Maj7", "7", "11", "13"), QualityDatabase.Gather("Insen", "Insen Chromodal", "Ritsu", "Quartal"));
		}
	}
}
