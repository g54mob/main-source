using System.Collections;
using DV.Damage;
using DV.Hazmat;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class ExplosionActivationOnSignal : ASimInitializedController
	{
		private const float EXPLOSION_RADIUS = 15f;

		private const float EXPLOSION_EFFECTS_DURATION = 5f;

		private const float EXPLOSION_IGNITION_RADIUS = 6f;

		public float bodyDamagePercentage;

		public float wheelsDamagePercentage;

		public float mechanicalPTDamagePercentage;

		public float electricalPTDamagePercentage;

		public GameObject explosionPrefab;

		public float explosionParticlesDuration = 4f;

		public float windowsBreakingDelay = 0.5f;

		public Transform explosionAnchor;

		[PortId(null, null, true)]
		public string explosionSignalPortId;

		public bool explodeTrainCar;

		private TrainCar trainCar;

		private Port explosionSignalPort;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			if (explosionPrefab != null)
			{
				if (explosionAnchor == null)
				{
					Debug.LogError("explosionAnchor is null. Please set the anchor!", base.gameObject);
				}
				if (!simFlow.TryGetPort(explosionSignalPortId, out explosionSignalPort))
				{
					Debug.LogError("[" + base.gameObject.GetPath() + "]: ExplosionActivationOnSignal isn't properly initialized! Destroying self", base.gameObject);
					Object.Destroy(this);
					return;
				}
				trainCar = car;
				explosionSignalPort.ValueUpdatedInternally += OnExplosionSignalChanged;
				if (explodeTrainCar)
				{
					trainCar.CarDamage.CarEffectiveHealthStateUpdate += OnHealthUpdated;
				}
			}
			else
			{
				Debug.LogError("explosionPrefab is null, explosion particles and audio won't be played, destroying self", base.gameObject);
				Object.Destroy(this);
			}
		}

		private void OnDestroy()
		{
			if (explosionSignalPort != null)
			{
				explosionSignalPort.ValueUpdatedInternally -= OnExplosionSignalChanged;
			}
			if (explodeTrainCar)
			{
				trainCar.CarDamage.CarEffectiveHealthStateUpdate -= OnHealthUpdated;
			}
			StopAllCoroutines();
		}

		private void OnExplosionSignalChanged(float explosionSignal)
		{
			if (!AStartGameData.carsAndJobsLoadingFinished || explosionSignal != 1f)
			{
				return;
			}
			GameObject obj = Object.Instantiate(explosionPrefab, explosionAnchor.position, explosionAnchor.rotation, base.transform);
			Object.Destroy(obj, explosionParticlesDuration);
			Igniter.Ignite(obj.transform.position, 1f, 6f, null, 6f);
			TrainCar trainCar = TrainCar.Resolve(base.transform);
			if (!(trainCar == null))
			{
				DamageController component = trainCar.GetComponent<DamageController>();
				if (component != null)
				{
					component.bodyDamage.DamageCar(component.bodyDamage.maxHealth * bodyDamagePercentage, useSensitivityModifier: false);
					component.wheels?.ApplyDamage(component.wheels.fullHitPoints * wheelsDamagePercentage);
					component.mechanicalPT?.ApplyDamage(component.mechanicalPT.fullHitPoints * mechanicalPTDamagePercentage);
					component.electricalPT?.ApplyDamage(component.electricalPT.fullHitPoints * electricalPTDamagePercentage);
				}
				WindowsBreakingController component2 = trainCar.GetComponent<WindowsBreakingController>();
				if (component2 != null)
				{
					StartCoroutine(DelayedWindowsBrakingCoro(component2));
				}
				if (explodeTrainCar)
				{
					ExplodeTrainCar();
				}
			}
		}

		private IEnumerator DelayedWindowsBrakingCoro(WindowsBreakingController windowsController)
		{
			yield return WaitFor.Seconds(windowsBreakingDelay);
			windowsController.BreakWindowsFromCollision(-base.transform.forward);
		}

		private void ExplodeTrainCar()
		{
			if (!trainCar.isExploded)
			{
				TrainCarExplosion.CreateExplosion(10000000f, base.transform.position, 15f, -1f, 100f);
				TrainCarExplosion.UpdateModelToExploded(trainCar);
				trainCar.SimController?.resourceContainerController?.DepleteAllResourceContainers();
			}
		}

		private void OnHealthUpdated(float health)
		{
			if (trainCar.isExploded && health >= 95f)
			{
				TrainCarExplosion.RevertModelToUnexploded(trainCar);
			}
		}
	}
}
