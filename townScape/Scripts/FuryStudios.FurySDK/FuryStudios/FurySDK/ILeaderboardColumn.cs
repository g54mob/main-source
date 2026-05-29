using System;

namespace FuryStudios.FurySDK
{
	public interface ILeaderboardColumn
	{
		string Name { get; }

		Type Type { get; }
	}
}
