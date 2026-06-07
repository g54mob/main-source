using System;

namespace XGamingRuntime.Interop
{
	internal struct XblLeaderboardRow
	{
		internal readonly byte[] gamertag;

		internal readonly byte[] modernGamertag;

		internal readonly byte[] modernGamertagSuffix;

		internal readonly byte[] uniqueModernGamertag;

		internal readonly ulong xboxUserId;

		internal readonly double percentile;

		internal readonly uint rank;

		internal readonly uint globalRank;

		private readonly IntPtr columnValues;

		private readonly SizeT columnValuesCount;

		public string[] GetColumnValues()
		{
			return null;
		}

		internal XblLeaderboardRow(XGamingRuntime.XblLeaderboardRow row, DisposableCollection disposableCollection)
		{
			gamertag = null;
			modernGamertag = null;
			modernGamertagSuffix = null;
			uniqueModernGamertag = null;
			xboxUserId = 0uL;
			percentile = 0.0;
			rank = 0u;
			globalRank = 0u;
			columnValues = (IntPtr)0;
			columnValuesCount = default(SizeT);
		}
	}
}
