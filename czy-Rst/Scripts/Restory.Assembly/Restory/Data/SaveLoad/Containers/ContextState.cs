using System.Collections.Generic;
using FullSerializer;
using Restory.Data.Locations;

namespace Restory.Data.SaveLoad.Containers
{
	[fsObject(VersionString = "GameProgressSaveContextDataV01")]
	public class ContextState
	{
		public GameScenesPreset Preset;

		public Dictionary<string, object> States = new Dictionary<string, object>();
	}
}
