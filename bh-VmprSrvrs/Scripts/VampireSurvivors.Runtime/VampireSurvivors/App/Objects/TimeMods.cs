using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.App.Objects
{
	[Title("Time Mods")]
	public class TimeMods
	{
		[Title("Start")]
		public float? Start;

		[Title("HP Per Minute")]
		public float? HpPerMinute;

		[Title("Speed Per Minute")]
		public float? SpeedPerMinute;
	}
}
