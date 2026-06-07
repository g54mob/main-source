using System.Collections.Generic;

namespace Motorways.Audio
{
	public class Reykjavik : MusicData
	{
		public static List<Rhythm> Patterns = Liszt.From<Rhythm>(new Rhythm(0f, 0.75f, 0.25f), new Rhythm(0f, 0.5f, 0.25f, 0.25f), new Rhythm(0f, 0.375f, 0.375f, 0.25f), new Rhythm(0f, 0.75f, 0.75f, 0.5f));

		public override void Injections()
		{
			List<Quality> list = new List<Quality>
			{
				new Quality("Aeolian", new List<int> { 2, 1, 2, 2, 1, 2, 2 }, new List<int> { 0, 12, 24 }),
				new Quality("Ionian", new List<int> { 2, 2, 1, 2, 2, 2, 1 }, new List<int> { 0, 12, 24 })
			};
			list = list.Chromatic(" (Chromatic)");
			SetQualities(list);
			SetRhythms(Patterns);
			SetDrumSequencer(Rhythms.Pick(), boom: true);
			SetKeyDeltas(Liszt.From<int>(-2, 2), Rando.Pick<int>(0, 2, 3, 5, 7, 9, 11));
		}

		public override void OnNewWeek()
		{
			base.OnNewWeek();
			UpdateDrumSequencer(Rhythms.Pick(), boom: true);
		}
	}
}
