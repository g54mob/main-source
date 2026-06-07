using System.Collections.Generic;

namespace Motorways.Audio
{
	public class HarmonyDefinition
	{
		private AudioLoadout _parentLoadout;

		private List<Attribute> _sequenceAttribute;

		private Attribute _bassAttribute;

		public int WeekIndex { get; private set; }

		public MusicData CreateHarmony(AudioLoadout loadout)
		{
			return new MusicData();
		}
	}
}
