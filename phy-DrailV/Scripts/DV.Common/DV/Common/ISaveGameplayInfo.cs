using System;

namespace DV.Common
{
	public interface ISaveGameplayInfo
	{
		int DataVersion { get; }

		DateTime InGameDate { get; }

		TimeSpan InGameTimePassed { get; }

		float PlayerMoney { get; }

		float FeeDebt { get; }

		int LicensesUnlocked { get; }

		int OrdersActive { get; }

		bool IsCorrupt { get; }
	}
}
