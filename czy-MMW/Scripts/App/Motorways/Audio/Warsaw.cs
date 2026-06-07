using System.Collections.Generic;

namespace Motorways.Audio
{
	public class Warsaw : MusicData
	{
		private int _rhythmUpdates = 10;

		private const int MaxRhythmUpdates = 40;

		public override void Injections()
		{
			Quality quality = Quality.Clone(QualityDatabase.MAJOR);
			quality.Scales.RemoveAt(6);
			quality.Scales.RemoveAt(5);
			quality.Scales.RemoveAt(2);
			quality.Chromatic();
			SetQualities(new List<Quality> { quality }, QualityDatabase.Gather("Wholetone", "Maj7"));
			SetRhythms(Rhythm.Triplet.Patterns().And(Rhythm.Duplet.Patterns()));
			SetNoteSequenceStyles(Liszt.Make(5, () => Rando.EnumValue<NoteSequenceType>()));
			SetTremolo(new Param.LFO(new Param.Data(0.2f, 0.3f), new Param.Data(0.1f, 0.2f)), new Param.LFO(new Param.Data(2f, 3f), new Param.Data(0.4f, 0.5f)));
		}

		public override void OnRhythmUpdate(int groupIndex)
		{
			float num = (float)_rhythmUpdates / 40f;
			if (_rhythmUpdates % 2 == 0)
			{
				UpdateDrumSequencer(Rhythm.Duplet.Patterns().Pick(), Rando.FlipCoin(0.25f * num), Rando.FlipCoin(0.75f * num), Rando.FlipCoin(num), Rando.FlipCoin());
			}
			if (_rhythmUpdates < 40)
			{
				_rhythmUpdates++;
			}
		}

		public override void OnHouseConnected(int groupIndex)
		{
			UpdateNoteWindow();
		}
	}
}
