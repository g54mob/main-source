using System.Collections.Generic;

namespace FuryStudios.FurySDK
{
	public interface ILeaderboard
	{
		StatID id { get; }

		IReadOnlyList<ILeaderboardColumn> Columns { get; }

		IReadOnlyList<ILeaderboardRow> Rows { get; }
	}
}
