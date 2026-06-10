using System;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Resources
{
	public class FloraController : MapResourceController<FloraController, PlantMapResourceInstance>
	{
		public delegate void PlantHandler(string modelId, Vector3 position, string prefabId, int phase, bool domestic = false, bool randomPhaseHours = false);

		public event ResourceHandler ChangeLifePhaseEvent;

		public event ResourceHandler HarvestFinishedEvent;

		public event Action<PlantMapResourceInstance> SpawnCropEvent;

		public event Action<PlantMapResourceInstance> CuttingFinishedEvent;

		public event Action<PlantMapResourceInstance> OnSpawnPlantMapResourceInstanceEvent;

		public void ChangeLifePhase(PlantMapResourceInstance instance)
		{
			this.ChangeLifePhaseEvent?.Invoke(instance);
		}

		public void HarvestFinished(PlantMapResourceInstance instance)
		{
			this.HarvestFinishedEvent?.Invoke(instance);
		}

		public void CuttingFinished(PlantMapResourceInstance instance)
		{
			this.CuttingFinishedEvent?.Invoke(instance);
		}

		public void SpawnCrop(PlantMapResourceInstance instance)
		{
			this.SpawnCropEvent?.Invoke(instance);
		}

		public void SpawnPlantMapResourceInstance(PlantMapResourceInstance resourceInstance)
		{
			this.OnSpawnPlantMapResourceInstanceEvent?.Invoke(resourceInstance);
		}
	}
}
