using System.Collections.Generic;
using Restory.Data.Locations;

namespace Restory.Data.SaveLoad.Containers
{
	public class GameplayProgressSaveData
	{
		public GameScenesPreset ActivePreset;

		public Dictionary<string, object> CommonContainer = new Dictionary<string, object>();

		public Dictionary<string, ContextState> ConcreteContainers = new Dictionary<string, ContextState>();
	}
}
