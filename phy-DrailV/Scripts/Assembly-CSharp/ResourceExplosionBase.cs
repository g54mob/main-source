using System.Collections;
using DV;
using DV.Damage;
using DV.Hazmat;
using DV.Simulation.Cars;
using DV.ThingTypes;
using DV.Utils;
using LocoSim.Implementations;
using LocoSim.Resources;
using UnityEngine;

public class ResourceExplosionBase : MonoBehaviour
{
	private const float EXPLOSION_RADIUS = 15f;

	private const float EXPLOSION_EFFECTS_DURATION = 5f;

	private const float MINIMUM_FUEL_PERCENTAGE_FOR_EXPLOSION = 0.3f;

	[SerializeField]
	private CargoType explosionLiquid = CargoType.Diesel;

	[SerializeField]
	private GameObject explosionPrefab;

	[SerializeField]
	private Transform explosionAnchor;

	private TrainCar trainCar;

	private TrainCarTileInteraction tileInteraction;

	private ResourceContainerController resourceContainerController;

	private ResourceContainer fuelContainer;

	private DamageController carDamageController;

	private Coroutine delayedExplosionBehaviourCoro;

	private bool hasExplosiveResource;

	private bool initialized;

	[InspectorButton("ExplodeDebug", true, true)]
	public bool explodeDebug;

	private const float ignitionSphereRadius = 25f;

	private void ExplodeDebug()
	{
		ExplodeResource();
	}

	private void Start()
	{
		Initialize();
	}

	private void Initialize()
	{
		if (!initialized)
		{
			trainCar = GetComponentInParent<TrainCar>();
			carDamageController = trainCar.GetComponent<DamageController>();
			tileInteraction = trainCar.GetComponent<TrainCarTileInteraction>();
			resourceContainerController = trainCar.SimController.resourceContainerController;
			fuelContainer = resourceContainerController.GetResourceContainer(ResourceContainerType.FUEL);
			OnFuelUpdated(fuelContainer.amountReadOut.Value);
			SetupListeners(on: true);
			initialized = true;
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			if (trainCar != null)
			{
				trainCar.CarDamage.CarEffectiveHealthStateUpdate += OnHealthUpdated;
			}
			if (tileInteraction != null)
			{
				tileInteraction.CarBurning += OnCarBurning;
			}
			if (fuelContainer != null)
			{
				fuelContainer.amountReadOut.ValueUpdatedInternally += OnFuelUpdated;
			}
		}
		else
		{
			if (trainCar != null)
			{
				trainCar.CarDamage.CarEffectiveHealthStateUpdate -= OnHealthUpdated;
			}
			if (tileInteraction != null)
			{
				tileInteraction.CarBurning -= OnCarBurning;
			}
			if (fuelContainer != null)
			{
				fuelContainer.amountReadOut.ValueUpdatedInternally -= OnFuelUpdated;
			}
		}
	}

	private void OnFuelUpdated(float value)
	{
		hasExplosiveResource = value / fuelContainer.capacity > 0.3f;
		if (tileInteraction != null)
		{
			tileInteraction.hasExplosiveResource = hasExplosiveResource;
		}
	}

	private void OnCarBurning(float _)
	{
		if (hasExplosiveResource && !(carDamageController.bodyDamage.HealthPercentage > float.Epsilon) && Globals.G.GameParams.DrivetrainFailuresAllowed)
		{
			ExplodeResource();
		}
	}

	private void OnHealthUpdated(float health)
	{
		if (trainCar.isExploded && health >= 95f)
		{
			ResetToUnexplodedState();
		}
	}

	private void OnDestroy()
	{
		if (delayedExplosionBehaviourCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(delayedExplosionBehaviourCoro);
		}
	}

	protected void PostExplosionBehavior()
	{
		if (!SingletonBehaviour<HazmatTileManager>.Instance || !SingletonBehaviour<HazmatTileManager>.Instance.enabled || explosionLiquid == CargoType.None)
		{
			return;
		}
		foreach (HazmatGridTile item in SingletonBehaviour<HazmatTileManager>.Instance.GetTilesInDiamondAreaAroundWorldPosition(base.transform.position, 15f))
		{
			if (item != null)
			{
				item.AddLiquidAmount(explosionLiquid, 1000f);
				item.UpdateCurrentWeight();
			}
		}
	}

	public void ExplodeResource()
	{
		TrainCarExplosion.CreateExplosion(10000000f, base.transform.position, 15f, -1f, 100f);
		if (explosionPrefab != null)
		{
			Transform parent = ((explosionAnchor != null) ? explosionAnchor : base.transform);
			Object.Destroy(Object.Instantiate(explosionPrefab, parent, worldPositionStays: false), 5f);
		}
		else
		{
			Debug.LogError("Missing explosion effects prefab for " + trainCar.gameObject.name + ".", this);
		}
		UpdateToExplodedState();
		carDamageController.DamageFullyAll();
		resourceContainerController.DepleteAllResourceContainers();
		float delay = Random.Range(0.25f, 2f);
		if (delayedExplosionBehaviourCoro != null)
		{
			Debug.LogError("delayedExplosionBehaviourCoro is already running!");
		}
		else
		{
			delayedExplosionBehaviourCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedExplosionBehavior(delay));
		}
	}

	private void TryIgniteOrExplodeSurroundings()
	{
		Igniter.IgniteTerrainDiamond(base.transform.position, 1f, 15f, 15f, 0.5f);
		Igniter.Ignite(base.transform.position, 1f, 25f, null, 0f, 0.8f);
	}

	private IEnumerator DelayedExplosionBehavior(float delay)
	{
		yield return WaitFor.Seconds(delay);
		PostExplosionBehavior();
		TryIgniteOrExplodeSurroundings();
		delayedExplosionBehaviourCoro = null;
	}

	public void UpdateToExplodedStateExternal()
	{
		Initialize();
		UpdateToExplodedState();
	}

	private void UpdateToExplodedState()
	{
		if (!trainCar.isExploded)
		{
			TrainCarExplosion.UpdateModelToExploded(trainCar);
		}
	}

	private void ResetToUnexplodedState()
	{
		if (trainCar.isExploded)
		{
			if (delayedExplosionBehaviourCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(delayedExplosionBehaviourCoro);
				delayedExplosionBehaviourCoro = null;
			}
			TrainCarExplosion.RevertModelToUnexploded(trainCar);
		}
	}
}
