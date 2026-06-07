using System.Collections.Generic;

namespace Motorways.Audio
{
	public class ChiangMai : MusicData
	{
		private int _rhythmUpdates;

		private const int MaxRhythmUpdates = 40;

		public override void Injections()
		{
			SetRhythms(Rhythm.AllPatterns().Phase());
			SetNoteSequenceStyles(Liszt.Make(6, () => NoteSequenceType.AutoReroll));
			SetQualities(new List<Quality> { QualityDatabase.NINE.Chromatic() }, new List<Quality>
			{
				QualityDatabase.INSEN,
				QualityDatabase.PENTA_DOM
			}.Chromodal());
			SetVibrato(new Param.Vibrato(new Param.Data(2f, 6f), 12));
			SetKeyDeltas(Liszt.From<int>(default(int)), Rando.Range(6, 8));
		}

		public override void OnRhythmUpdate(int groupIndex)
		{
			float num = (float)_rhythmUpdates / 40f;
			if (_rhythmUpdates % 2 == 0)
			{
				UpdateDrumSequencer(Rando.Pick(Rhythm.Duplet.Patterns()), Rando.FlipCoin(num), Rando.FlipCoin(0.75f * num), Rando.FlipCoin(0.5f * num), Rando.FlipCoin());
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
