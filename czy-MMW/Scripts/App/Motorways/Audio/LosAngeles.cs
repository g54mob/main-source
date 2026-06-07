namespace Motorways.Audio
{
	public class LosAngeles : MusicData
	{
		public override void Injections()
		{
			SetEasterEggHorn("Special");
			SetRhythms(Rhythm.Frag().Uniform());
			SetKeyDeltas(Rando.Numbers(3, -1));
			SetNoteSequenceStyles(Liszt.Make(6, () => NoteSequenceType.Backward));
			SetVoiceLimits(0.1, 5);
			Quality quality = Quality.Clone(QualityDatabase.MAJOR);
			quality.Scales.RemoveAt(6);
			SetQualities(Liszt.From<Quality>(quality));
			SetPortamento(new Param.Portamento(), new Param.Portamento(-100, 100, 0.0, 0.5));
			SetVibrato(Vibrato, new Param.Vibrato(new Param.Data(10f, 20f), 20));
		}

		public override void OnRhythmUpdate(int groupIndex)
		{
			float duration = Rhythms[0].Duration;
			int nbSteps = Rhythms[0].Steps.Length;
			Rhythm newRhythm = new Rhythm(0f, new D20().Frag(nbSteps, duration));
			foreach (DestinationGroup destinationGroup in Get.Loadout.DestinationGroups)
			{
				destinationGroup.Module.ChangePulse(newRhythm);
			}
		}
	}
}
