using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblTournamentGameResultWithRank
	{
		public XblTournamentGameResult Result { get; }

		public ulong Ranking { get; }

		internal XblTournamentGameResultWithRank(XGamingRuntime.Interop.XblTournamentGameResultWithRank interopStruct)
		{
			Result = interopStruct.Result;
			Ranking = interopStruct.Ranking;
		}
	}
}
