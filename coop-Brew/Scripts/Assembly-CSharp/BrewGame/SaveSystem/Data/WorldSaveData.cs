using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class WorldSaveData
	{
		public List<PlacedObjectSaveData> placedObjects;

		public List<VehicleSaveData> vehicles;

		public List<StationSaveData> stations;

		public List<BarSaveData> bars;

		public List<ShelfSaveData> shelves;

		public List<EnvironmentObjectSaveData> environmentObjects;
	}
}
