using DV.Simulation.Controllers;
using UnityEngine;

namespace DV.Util
{
	public class PositionSyncConsumerController : ARefreshableChildrenController<PositionSyncConsumer>
	{
		private void Awake()
		{
			TrainCar trainCar = TrainCar.Resolve(base.transform);
			if (trainCar == null)
			{
				Debug.LogError("Unexpected state: car not found on PositionSyncConsumerController");
				return;
			}
			PositionSyncProviderController component = trainCar.GetComponent<PositionSyncProviderController>();
			if (component == null || component.entries.Length == 0)
			{
				Debug.LogError("Unexpected state: PositionSyncProviderController doesn't have providers set!");
				return;
			}
			PositionSyncConsumer[] array = entries;
			foreach (PositionSyncConsumer positionSyncConsumer in array)
			{
				PositionSyncProvider[] array2 = component.entries;
				foreach (PositionSyncProvider positionSyncProvider in array2)
				{
					if (positionSyncConsumer.syncTag == positionSyncProvider.syncTag)
					{
						positionSyncConsumer.SetProviderTransform(positionSyncProvider);
						break;
					}
				}
			}
		}

		private void LateUpdate()
		{
			PositionSyncConsumer[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Sync();
			}
		}
	}
}
