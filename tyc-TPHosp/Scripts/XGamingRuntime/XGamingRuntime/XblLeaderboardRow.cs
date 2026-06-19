using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblLeaderboardRow
	{
		public string Gamertag { get; }

		public string ModernGamertag { get; }

		public string ModernGamertagSuffix { get; }

		public string UniqueModernGamertag { get; }

		public ulong XboxUserId { get; }

		public double Percentile { get; }

		public uint Rank { get; }

		public string[] ColumnValues { get; }

		internal XblLeaderboardRow(XGamingRuntime.Interop.XblLeaderboardRow interopRow)
		{
			Gamertag = Converters.ByteArrayToString(interopRow.gamertag);
			ModernGamertag = Converters.ByteArrayToString(interopRow.modernGamertag);
			ModernGamertagSuffix = Converters.ByteArrayToString(interopRow.modernGamertagSuffix);
			UniqueModernGamertag = Converters.ByteArrayToString(interopRow.uniqueModernGamertag);
			XboxUserId = interopRow.xboxUserId;
			Percentile = interopRow.percentile;
			Rank = interopRow.rank;
			ColumnValues = interopRow.GetColumnValues();
		}
	}
}
