using System.Collections;
using UnityEngine;

namespace DV.Cargo
{
	public class CargoWaterDamage : MonoBehaviour
	{
		private const float WATER_DAMAGE_CHECK_PERIOD = 5f;

		private TrainCar car;

		private TrainBuoyancyController buoyancyController;

		private Coroutine waterDamageCoroutine;

		private void Start()
		{
			car = TrainCar.Resolve(base.transform);
			if (car == null || car.CargoDamage == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: Car not found on CargoWaterDamage.");
				Object.Destroy(this);
				return;
			}
			buoyancyController = car.GetComponent<TrainBuoyancyController>();
			if (buoyancyController == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: TrainBuoyancyController not found on CargoWaterDamage.");
				Object.Destroy(this);
			}
			else
			{
				SetupListeners(on: true);
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				StopWaterDamage();
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				if (buoyancyController != null)
				{
					buoyancyController.OnEnterWater += OnEnterWater;
					buoyancyController.OnExitWater += OnExitWater;
				}
			}
			else if (buoyancyController != null)
			{
				buoyancyController.OnEnterWater -= OnEnterWater;
				buoyancyController.OnExitWater -= OnExitWater;
			}
		}

		private void OnEnterWater()
		{
			StopWaterDamage();
			waterDamageCoroutine = StartCoroutine(WaterDamage());
		}

		private void OnExitWater()
		{
			StopWaterDamage();
		}

		private IEnumerator WaterDamage()
		{
			do
			{
				yield return WaitFor.Seconds(5f);
			}
			while (car.transform.TransformPoint(car.Bounds.center).y - LevelInfo.WaterLevel > 0f);
			car.CargoDamage.DestroyCargo();
			StopWaterDamage();
		}

		private void StopWaterDamage()
		{
			if (waterDamageCoroutine != null)
			{
				StopCoroutine(waterDamageCoroutine);
				waterDamageCoroutine = null;
			}
		}
	}
}
