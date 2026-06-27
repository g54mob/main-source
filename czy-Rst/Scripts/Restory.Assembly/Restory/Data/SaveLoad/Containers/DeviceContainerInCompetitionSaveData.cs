using System;
using Restory.Gameplay.Elements;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class DeviceContainerInCompetitionSaveData
	{
		public string DeviceContainerUniqueID;

		public float CurrentTime;

		public bool WasCompleted;

		public bool WasPreviousTimeBested;

		public PlacedElementsData ElementsInitialPlacement;
	}
}
