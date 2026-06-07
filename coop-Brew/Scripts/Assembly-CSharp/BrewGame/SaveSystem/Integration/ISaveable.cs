using System.Collections.Generic;

namespace BrewGame.SaveSystem.Integration
{
	public interface ISaveable
	{
		string SaveableId { get; }

		int SavePriority => 0;

		Dictionary<string, object> CaptureState();

		void RestoreState(Dictionary<string, object> state);
	}
}
