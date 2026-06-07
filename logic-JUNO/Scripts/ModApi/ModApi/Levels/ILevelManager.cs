using System.Collections.Generic;

namespace ModApi.Levels
{
	public interface ILevelManager
	{
		ILevel CurrentLevel { get; }

		IReadOnlyList<ILevelData> Levels { get; }

		void EndLevel();

		bool StartLevel(ILevelData level);
	}
}
