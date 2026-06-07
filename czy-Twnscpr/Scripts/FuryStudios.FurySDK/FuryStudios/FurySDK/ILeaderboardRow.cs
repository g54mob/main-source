using System.Collections.Generic;

namespace FuryStudios.FurySDK
{
	public interface ILeaderboardRow
	{
		string DisplayName { get; }

		uint Rank { get; }

		IReadOnlyList<string> Columns { get; }
	}
}
