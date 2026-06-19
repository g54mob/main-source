using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblTournamentTeamResult
	{
		public string Team { get; }

		public XblTournamentGameResultWithRank GameResult { get; }

		internal XblTournamentTeamResult(XGamingRuntime.Interop.XblTournamentTeamResult interopStruct)
		{
			Team = interopStruct.Team.GetString();
			GameResult = new XblTournamentGameResultWithRank(interopStruct.GameResult);
		}
	}
}
