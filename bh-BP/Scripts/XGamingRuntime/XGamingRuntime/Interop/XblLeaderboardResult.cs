using System;

namespace XGamingRuntime.Interop
{
	internal struct XblLeaderboardResult
	{
		internal readonly uint totalRowCount;

		private readonly IntPtr columns;

		private readonly SizeT columnsCount;

		private readonly IntPtr rows;

		private readonly SizeT rowsCount;

		internal readonly NativeBool hasNext;

		internal readonly XblLeaderboardQuery nextQuery;

		internal T[] GetColumns<T>(Func<XblLeaderboardColumn, T> ctor)
		{
			return null;
		}

		internal T[] GetRows<T>(Func<XblLeaderboardRow, T> ctor)
		{
			return null;
		}

		internal XblLeaderboardResult(XGamingRuntime.XblLeaderboardResult result, DisposableCollection disposableCollection)
		{
			totalRowCount = 0u;
			columns = (IntPtr)0;
			columnsCount = default(SizeT);
			rows = (IntPtr)0;
			rowsCount = default(SizeT);
			hasNext = default(NativeBool);
			nextQuery = default(XblLeaderboardQuery);
		}
	}
}
