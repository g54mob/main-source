namespace Tabletop.GameWorld
{
	public static class SeasonsExtensions
	{
		public static bool Contains(this ESeasonFlags flag, ESeasonFlags other)
		{
			return (flag & other) != 0;
		}
	}
}
