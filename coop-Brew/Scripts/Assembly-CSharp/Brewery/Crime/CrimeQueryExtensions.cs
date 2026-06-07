namespace Brewery.Crime
{
	public static class CrimeQueryExtensions
	{
		public static bool ShouldChasePlayer(this ICrimeQuery query, ulong playerId)
		{
			return false;
		}

		public static bool CanArrestPlayer(this ICrimeQuery query, ulong playerId)
		{
			return false;
		}
	}
}
