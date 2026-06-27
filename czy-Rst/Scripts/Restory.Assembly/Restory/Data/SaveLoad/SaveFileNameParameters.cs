using Restory.Data.Locations;

namespace Restory.Data.SaveLoad
{
	public class SaveFileNameParameters
	{
		public readonly GameMode GameplayMode;

		public readonly int Profile;

		public SaveFileNameParameters(GameMode gameplayMode, int profile)
		{
			GameplayMode = gameplayMode;
			Profile = profile;
		}
	}
}
