using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblTournamentTeamResult
	{
		public string Team { get; private set; }

		public XblTournamentGameResultWithRank GameResult { get; private set; }

		internal XblTournamentTeamResult(XGamingRuntime.Interop.XblTournamentTeamResult interopStruct)
		{
		}
	}
}
