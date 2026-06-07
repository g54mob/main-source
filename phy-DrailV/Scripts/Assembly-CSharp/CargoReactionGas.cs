using System.Collections.Generic;
using DV.Hazmat;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class CargoReactionGas : CargoReactionBase
{
	private const float REACTION_BOOST_FROM_OTHER_BURNING = 0.1f;

	private const float TILE_EXTINGUISHING_SPEED = 0.3f;

	private const float TILE_OXIDATION_SPEED = 0.01f;

	private const float EXPLOSION_MIN_VOLUME_THRESHOLD = 100f;

	private const float SPILL_AMOUNT_MODIFIER = 0.5f;

	private Collider[] overlaps = new Collider[32];

	private List<HazmatGridTile> tileCache = new List<HazmatGridTile>();

	protected override void ManageReaction()
	{
		if (!isFlammable && !canExtinguish && !isOxidizer)
		{
			return;
		}
		if (cargoLeak.IsLeaking() || cargoLeak.CargoVolumeLeaked() > float.Epsilon)
		{
			cargoEffects.AllowSpecialEffects(cargoLeak.HasGasBuildup);
			CheckGasCloudOverlapReaction();
			if (reactionCurveAsset == null)
			{
				return;
			}
			currentReactivity = cargoReactionProperties.reactivity;
			CheckTerrainForIgnition();
			if (!isIgnited)
			{
				CheckEnergyBuildupForIgnition();
				if (isIgnited)
				{
					PlayIgnitionSound(cargoLeak.Position());
				}
			}
			else if (!aboutToExplode)
			{
				ProcessBurning();
			}
		}
		else
		{
			isIgnited = false;
			cargoEffects.UpdateEffectsFlowIn(0f);
		}
	}

	private void CheckGasCloudOverlapReaction()
	{
		int num = Physics.OverlapSphereNonAlloc(base.transform.position, cargoLeak.VaporRadius(), overlaps, hazmask, QueryTriggerInteraction.Collide);
		for (int i = 0; i < num; i++)
		{
			Collider collider = overlaps[i];
			if (collider.transform.root == trainCar.transform)
			{
				continue;
			}
			ICargoReaction componentInParent = collider.transform.GetComponentInParent<ICargoReaction>();
			if (componentInParent == null)
			{
				continue;
			}
			if (isFlammable && (componentInParent.CanExtinguish() || componentInParent.IsOxidizer()))
			{
				currentReactivity += componentInParent.ReactivityModifier();
			}
			if (componentInParent.IsIgnited())
			{
				if (isFlammable)
				{
					currentReactivity += 0.1f;
				}
				else if (isOxidizer)
				{
					cargoLeak.ReduceLeakedMass(500f * Time.deltaTime);
				}
				else if (canExtinguish)
				{
					componentInParent.TryExtinguishExternally();
				}
			}
		}
		if (!canExtinguish && !isOxidizer)
		{
			return;
		}
		SingletonBehaviour<HazmatTileManager>.Instance.GetTilesInDiamondAreaAroundWorldPosition(base.transform.position, cargoLeak.VaporRadius(), existingOnly: true, tileCache);
		float num2 = 0f;
		if (canExtinguish)
		{
			num2 -= 0.3f;
		}
		if (isOxidizer)
		{
			num2 += 0.01f;
		}
		num2 *= Time.deltaTime;
		foreach (HazmatGridTile item in tileCache)
		{
			item.AddExternalReactivityModifier(num2);
		}
	}

	private void ProcessBurning()
	{
		cargoLeak.ReduceLeakedMass(500f * Time.deltaTime);
		cargoEffects.UpdateEffectsFlowIn(1f);
		IgniteTerrainTile(1f);
		if (extinguished)
		{
			isIgnited = (extinguished = false);
			elapsedTerrainCheckTime = (elapsedTileIgnitionTime = 0f);
			cargoEffects.UpdateEffectsFlowIn(0f);
			PlayExtinguishSound();
			Debug.Log($"Fire extinguished externally, no explosion in car {trainCar.transform.name} with cargo {cargoContent.GetType()}");
		}
		else
		{
			if (aboutToExplode)
			{
				return;
			}
			cargoLeak.ReduceLeakedMass(500f * Time.deltaTime);
			cargoEffects.UpdateEffectsFlowIn(1f);
			IgniteTerrainTile(1f);
			if (extinguished)
			{
				isIgnited = (extinguished = false);
				elapsedTerrainCheckTime = (elapsedTileIgnitionTime = 0f);
				cargoEffects.UpdateEffectsFlowIn(0f);
				elapsedBurnTime = 0f;
				PlayExtinguishSound();
				Debug.Log($"Fire extinguished externally, no explosion in car {trainCar.transform.name} with cargo {cargoContent.GetType()}");
				return;
			}
			elapsedBurnTime += Time.deltaTime;
			if (cargoContent.GetCurrentCargo() <= cargoContent.GetMinCargo() + 100f)
			{
				isIgnited = false;
				cargoEffects.UpdateEffectsFlowIn(0f);
				elapsedBurnTime = 0f;
				Debug.Log($"Fire gone, no explosion in car {trainCar.transform.name} with cargo {cargoContent.GetCargoType()}");
			}
			else if (isExplosive && elapsedBurnTime > explosionThresholdTime && cargoLeak.CargoVolumeLeaked() < 100f)
			{
				aboutToExplode = true;
				Debug.Log($"Explosion imminent in car {trainCar.transform.name} with cargo {cargoContent.GetCargoType()}. Fire reached interior.");
			}
		}
	}

	private void CheckEnergyBuildupForIgnition()
	{
		float time = Mathf.Min(cargoLeak.CargoVolumeLeaked() / cargoReactionProperties.criticalVolumeIgnitionMax, 1f);
		currentReactivity *= reactionCurveAsset.curve.Evaluate(time);
		if (currentReactivity > cargoReactionProperties.ignitionReactivityMin)
		{
			currentEnergy = Mathf.InverseLerp(cargoReactionProperties.ignitionReactivityMin, cargoReactionProperties.ignitionReactivityMax, currentReactivity);
		}
		else
		{
			currentEnergy = 0f;
		}
		int num = Random.Range(0, 100);
		float num2 = currentEnergy * 10f;
		isIgnited = (float)num < num2;
	}

	protected override void CheckTerrainForIgnition()
	{
		if (!SingletonBehaviour<HazmatTileManager>.Instance || !isFlammable || isIgnited || SingletonBehaviour<HazmatTileManager>.Instance.IgnitedTileCoords.Count <= 0)
		{
			return;
		}
		if (elapsedTerrainCheckTime < 1f)
		{
			elapsedTerrainCheckTime += Time.deltaTime;
			return;
		}
		elapsedTerrainCheckTime = 0f;
		foreach (HazmatGridTile item in SingletonBehaviour<HazmatTileManager>.Instance.GetTilesInDiamondAreaAroundWorldPosition(base.transform.position, cargoLeak.VaporRadius(), existingOnly: true))
		{
			if (item != null && item.IsIgnited)
			{
				isIgnited = true;
				break;
			}
		}
	}

	private void IgniteTerrainTile(float ignitionStrength)
	{
		if ((bool)SingletonBehaviour<HazmatTileManager>.Instance && SingletonBehaviour<HazmatTileManager>.Instance.enabled)
		{
			if (elapsedTileIgnitionTime < 1f)
			{
				elapsedTileIgnitionTime += Time.deltaTime;
				return;
			}
			elapsedTileIgnitionTime = 0f;
			Igniter.IgniteTerrainLine(base.transform.position, base.transform.position + base.transform.forward * 22.4f, ignitionStrength, float.PositiveInfinity);
		}
	}

	protected override void PostExplosionBehavior()
	{
		if (!SingletonBehaviour<HazmatTileManager>.Instance || !SingletonBehaviour<HazmatTileManager>.Instance.enabled)
		{
			return;
		}
		foreach (HazmatGridTile item in SingletonBehaviour<HazmatTileManager>.Instance.GetTilesInDiamondAreaAroundWorldPosition(base.transform.position, 25f))
		{
			if (item != null)
			{
				item.AddLiquidAmount(CargoType.Gasoline, 500f);
				item.UpdateCurrentWeight();
			}
		}
	}
}
