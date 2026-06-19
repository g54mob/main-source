using UnityEngine;

namespace TH20
{
	public class ArrivalMethodItemDefinition : ArrivalMethodVehicleDefinition
	{
		public override bool IsAvailable()
		{
			return ArrivalItemComponent.IsAvailable();
		}

		public override bool IsSpawnPointFree()
		{
			return ArrivalItemComponent.IsSpawnPointFree(this);
		}

		public override int Reserve()
		{
			return ArrivalItemComponent.Reserve(this);
		}

		public override void Free(int spawnIndex)
		{
			ArrivalItemComponent.Free(spawnIndex, this);
		}

		public override bool ValidArrivalComponent(int index)
		{
			return ArrivalItemComponent.ValidArrivalComponent(index);
		}

		public override ArrivalBaseComponent GetArrivalComponent(int index)
		{
			return ArrivalItemComponent.GetArrivalComponent(index);
		}

		public override void RestoreFromSave(int index)
		{
			ArrivalItemComponent.RestoreFromSave(index);
		}

		public override int TotalSpawnPoints()
		{
			return ArrivalItemComponent.TotalSpawnPoints();
		}

		public override int TotalFreeSpawnPoints()
		{
			return ArrivalItemComponent.TotalFreeSpawnPoints();
		}

		public override GameObject SetupVehicle(ArrivalBaseComponent arrivalComponent)
		{
			return arrivalComponent.gameObject;
		}

		public override void DestroyVehicle(ref GameObject vehicle)
		{
			Animator component = vehicle.GetComponent<Animator>();
			if (component != null)
			{
				component.runtimeAnimatorController = null;
			}
			vehicle = null;
		}
	}
}
