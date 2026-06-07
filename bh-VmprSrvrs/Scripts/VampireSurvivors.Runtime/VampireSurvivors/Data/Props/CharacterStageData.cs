using System;

namespace VampireSurvivors.Data.Props
{
	[Serializable]
	public class CharacterStageData
	{
		public int complete { get; set; }

		public bool hyper { get; set; }

		public bool hurry { get; set; }

		public bool inverse { get; set; }

		public int survivedMinutes { get; set; }

		public int startedRun { get; set; }

		public StageType type { get; set; }
	}
}
