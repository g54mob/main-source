using System;

namespace Data.FactoryFloor.Drones.Freighter.SaveStateDtos
{
	[Serializable]
	public class FreighterStopConfigurationSaveStateDto
	{
		public int FreightHubReferenceID;

		public int[] FreighterSlotActionDatabaseIDs;
	}
}
