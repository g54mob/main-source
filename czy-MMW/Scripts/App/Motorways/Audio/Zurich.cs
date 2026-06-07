namespace Motorways.Audio
{
	public class Zurich : MusicData
	{
		public override void Injections()
		{
			SetQualities(QualityDatabase.Gather("Dorian", "Aeolian", "Penta", "Dominant Penta", "Lydian Dominant").Keyless());
			SetRhythms(Liszt.Flatten<Rhythm>(Rhythm.Triplet.Pulses(), Rhythm.Quintuplet.Pulses()));
			SetKeyDeltas(Liszt.From<int>(-4, -2, 1, 3), D20.Range(0, 6));
			SetWeekendChances(1f, 0f);
			SetNoteSequenceStyles(Liszt.Make(5, (int i) => i switch
			{
				1 => NoteSequenceType.Backward, 
				2 => NoteSequenceType.PingPong, 
				3 => NoteSequenceType.Seeded, 
				4 => NoteSequenceType.AutoReroll, 
				_ => NoteSequenceType.Forward, 
			}));
			SetVoiceLimits(0.1, 3);
			SetPortamento(new Param.Portamento(-150, 150, 0.0, 0.2), new Param.Portamento());
			SetEchoDuratios(Liszt.From<float>(Rhythms[RhythmPointer].Duration));
			SetDrumSequencer(Rhythms.Shortest(), boom: true);
		}

		public override void OnNewWeek()
		{
			base.OnNewWeek();
			bool bap = false;
			bool hat = false;
			bool boom;
			switch (Get.Clock.Week)
			{
			case 0:
				boom = true;
				break;
			case 1:
				hat = true;
				goto case 0;
			case 2:
				bap = true;
				goto case 1;
			default:
				boom = Rando.FlipCoin();
				hat = Rando.FlipCoin();
				bap = Rando.FlipCoin();
				break;
			}
			UpdateDrumSequencer(Get.Loadout.DestinationGroupRhythms.Shortest(), boom, bap, hat);
			WeekendKeyChangeChance = ((Get.Clock.Week % 3 == 0) ? 1f : 0f);
		}
	}
}
