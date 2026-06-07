namespace XGamingRuntime.Interop
{
	internal struct XblTournamentGameResultWithRank
	{
		internal readonly XblTournamentGameResult Result;

		internal readonly ulong Ranking;

		internal XblTournamentGameResultWithRank(XGamingRuntime.XblTournamentGameResultWithRank publicObject)
		{
			Result = default(XblTournamentGameResult);
			Ranking = 0uL;
		}
	}
}
