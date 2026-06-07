using DV.Damage;
using DV.Utils;
using UnityEngine;

namespace DV.ServicePenalty
{
	public class CarDebtController : MonoBehaviour
	{
		private TrainCar trainCar;

		private bool ignoreCarDamageDebt;

		public DebtTrackerCar CarDebtTracker { get; private set; }

		public bool IsDummy => CarDebtTracker == null;

		public void OnCreated(TrainCar trainCar, bool ignoreCarDamageDebt)
		{
			this.trainCar = trainCar;
			this.ignoreCarDamageDebt = ignoreCarDamageDebt;
		}

		public void SetDebtTracker(CarDamageModel carDmg, CargoDamageModel cargoDmg)
		{
			if (ignoreCarDamageDebt)
			{
				carDmg = null;
			}
			if (carDmg != null || cargoDmg != null)
			{
				CarDebtTracker = new DebtTrackerCar(carDmg, cargoDmg, trainCar.ID, trainCar.carType);
				return;
			}
			Debug.LogError("Car is missing both damage components: CarDamageModel or CargoDamageModel. CarDebtTracker will be set to null!", this);
			CarDebtTracker = null;
		}

		public void SetDummyDebtTracker()
		{
			CarDebtTracker = null;
		}

		public void SetupOnDestroyJoblessCarListener()
		{
			if (IsDummy)
			{
				Debug.LogError("SetupOnDestroyJoblessCarListener called for dummy debt! Ignoring request.");
			}
			else
			{
				trainCar.OnDestroyCar += OnJoblessCarDestroy;
			}
		}

		private void OnJoblessCarDestroy(TrainCar destroyedCar)
		{
			if (IsDummy)
			{
				Debug.LogError("SetupOnDestroyJoblessCarListener called for dummy debt! Ignoring request.");
				return;
			}
			trainCar.OnDestroyCar -= OnJoblessCarDestroy;
			SingletonBehaviour<JobDebtController>.Instance.StageJoblessCarDebtOnCarDestroy(CarDebtTracker);
		}
	}
}
