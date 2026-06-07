using DV.Hazmat;
using DV.Utils;
using UnityEngine;

public class CargoReactionLiquid : CargoReactionBase
{
	protected override void ManageReaction()
	{
		if ((!isFlammable && !canExtinguish) || reactionCurveAsset == null)
		{
			return;
		}
		if (cargoLeak.IsLeaking() || cargoLeak.CargoVolumeLeaked() > float.Epsilon)
		{
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
				cargoLeak.ReduceLeakedMass(500f * Time.deltaTime);
				cargoEffects.UpdateEffectsFlowIn(1f);
				IgniteTerrainTile(1f);
				ProcessBurning();
			}
		}
		else
		{
			isIgnited = false;
			cargoEffects.UpdateEffectsFlowIn(0f);
		}
	}

	private void CheckEnergyBuildupForIgnition()
	{
		if (currentReactivity > cargoReactionProperties.ignitionReactivityMin)
		{
			currentEnergy = Mathf.InverseLerp(cargoReactionProperties.ignitionReactivityMin, cargoReactionProperties.ignitionReactivityMax, currentReactivity);
			int num = Random.Range(0, 100);
			float num2 = currentEnergy * 10f;
			isIgnited = (float)num < num2;
		}
		else
		{
			currentEnergy = 0f;
		}
	}

	private void ProcessBurning()
	{
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
		else if (isExplosive && elapsedBurnTime > explosionThresholdTime)
		{
			aboutToExplode = true;
			Debug.Log($"Explosion imminent in car {trainCar.transform.name} with cargo {cargoContent.GetCargoType()}. Fire reached interior.");
		}
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
		foreach (HazmatGridTile item in SingletonBehaviour<HazmatTileManager>.Instance.GetTilesInLine(base.transform.position, base.transform.position + base.transform.forward * 8f, existingOnly: true))
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
				item.AddLiquidAmount(cargoContent.GetCargoType(), 1000f);
				item.UpdateCurrentWeight();
			}
		}
	}
}
