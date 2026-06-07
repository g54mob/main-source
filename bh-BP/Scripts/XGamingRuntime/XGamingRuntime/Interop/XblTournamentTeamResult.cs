namespace XGamingRuntime.Interop
{
	internal struct XblTournamentTeamResult
	{
		internal readonly UTF8StringPtr Team;

		internal readonly XblTournamentGameResultWithRank GameResult;

		internal XblTournamentTeamResult(XGamingRuntime.XblTournamentTeamResult publicObject, DisposableCollection disposableCollection)
		{
			Team = default(UTF8StringPtr);
			GameResult = default(XblTournamentGameResultWithRank);
		}
	}
}
