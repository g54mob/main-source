using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalMethodVehicleDefinition : ArrivalMethodDefinition
	{
		public GameObject VehiclePrefab;

		public GameObject[] RandomVehiclePrefabs;

		public int MaxCapacity;

		public RuntimeAnimatorController VehicleAnimGraph;

		public RuntimeAnimatorController[] CharacterAnimGraph = new RuntimeAnimatorController[2];

		public override ArrivalMethod Create(Level level, IArrivedCallback callback)
		{
			return new ArrivalMethodVehicle(this, Reserve(), level, callback);
		}

		private GameObject ChoosePrefab()
		{
			if (RandomVehiclePrefabs == null || RandomVehiclePrefabs.Length == 0)
			{
				return VehiclePrefab;
			}
			return RandomVehiclePrefabs.RandomItem();
		}

		public override bool IsSpawnPointFree()
		{
			return false;
		}

		public virtual int Reserve()
		{
			return -1;
		}

		public virtual void Free(int id)
		{
		}

		public virtual ArrivalBaseComponent GetArrivalComponent(int id)
		{
			return null;
		}

		public virtual bool ValidArrivalComponent(int id)
		{
			return true;
		}

		public virtual void RestoreFromSave(int id)
		{
		}

		public virtual int TotalSpawnPoints()
		{
			return 0;
		}

		public virtual int TotalFreeSpawnPoints()
		{
			return 0;
		}

		public virtual GameObject SetupVehicle(ArrivalBaseComponent arrivalComponent)
		{
			Transform transform = arrivalComponent.GetTransform();
			return Object.Instantiate(ChoosePrefab(), transform);
		}

		public virtual void DestroyVehicle(ref GameObject vehicle)
		{
			GameObjectUtils.SafeDestroy(ref vehicle);
		}
	}
}
