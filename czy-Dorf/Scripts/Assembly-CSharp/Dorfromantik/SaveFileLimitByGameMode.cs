using System;

namespace Dorfromantik
{
	[Serializable]
	public class SaveFileLimitByGameMode
	{
		public GameModeId gameMode;

		public int limit = -1;
	}
}
