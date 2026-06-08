namespace Platforms
{
	public struct LeaderboardKey
	{
		public int Year;

		public int Week;

		public string Name => $"{Year:0000}_{Week:00}";

		public int IntID => Week;

		public LeaderboardKey(int year, int week)
		{
			Year = year;
			Week = week;
		}
	}
}
