using System.Collections.Generic;
using FullInspector;

namespace TH20
{
	public class MetagameCutsceneHospitalUnlockedDefinition : MetagameCutsceneDefinition
	{
		public List<SharedInstance<LevelConfig>> LevelConfigList;

		public SharedInstance<DLCItemDefinition> DLCPackRequired;

		public override MetagameCutsceneInstance CreateCutsceneInstance(MetagameMap map)
		{
			return new MetagameCutsceneHospitalUnlocked(map, this);
		}
	}
}
