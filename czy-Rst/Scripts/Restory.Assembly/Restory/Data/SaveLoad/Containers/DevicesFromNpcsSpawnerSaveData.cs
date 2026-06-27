using System;
using Restory.Gameplay.InteractiveObjects;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class DevicesFromNpcsSpawnerSaveData
	{
		public string[] InteractiveObjectsAtSpawnPointsIds;

		public InteractiveObjectData DevicesBoxData;

		public ContainedInteractiveObject[] ItemsInBox;
	}
}
