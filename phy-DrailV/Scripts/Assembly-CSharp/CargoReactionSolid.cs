using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class CargoReactionSolid : CargoReactionBase
{
	private bool wasIgnited;

	private const float MAX_HEALTH_REMAINING_FOR_EXPLOSION = 0.9f;

	private const float MIN_HEALTH_REMAINING_FOR_EXPLOSION = 0.5f;

	private const float SPILL_AMOUNT_MODIFIER = 0.5f;

	public override void SetupForContent(ICargoContent cargoContent)
	{
		base.SetupForContent(cargoContent);
		if (isExplosive)
		{
			ignitionStrength = 1000f;
			cargoDamageModel.CargoDamaged += OnCargoDamaged;
		}
		else
		{
			ignitionStrength = 100f;
		}
	}

	protected override void OnAboutToReturnToPool()
	{
		cargoDamageModel.CargoDamaged -= OnCargoDamaged;
		wasIgnited = false;
	}

	private void OnCargoDamaged(float remainingHealth)
	{
		if (!isExploded && !(remainingHealth > 0.9f))
		{
			float num = Mathf.InverseLerp(0.9f, 0.5f, remainingHealth) * 100f;
			if ((float)Random.Range(0, 99) <= num)
			{
				((ICargoReaction)this).TryExplodeExternally();
			}
		}
	}

	protected override void OnCargoSeverelyDamaged()
	{
		((ICargoReaction)this).TryExplodeExternally();
	}

	protected override void ManageReaction()
	{
		if (!isFlammable)
		{
			return;
		}
		CheckTerrainForIgnition();
		if (isIgnited)
		{
			cargoContent.ReduceCargo(200f * Time.deltaTime);
			cargoEffects.UpdateEffectsFlowIn(1f);
			IgniteTerrainTile(ignitionStrength);
			if (cargoContent.GetCurrentCargo() <= float.Epsilon)
			{
				isIgnited = false;
				cargoEffects.UpdateEffectsFlowIn(0f);
			}
			if (isIgnited && !wasIgnited)
			{
				cargoEffects.ActivateEffectsExternally();
			}
			wasIgnited = isIgnited;
		}
	}

	protected override void CheckTerrainForIgnition()
	{
		if (!SingletonBehaviour<HazmatTileManager>.Instance || isIgnited || SingletonBehaviour<HazmatTileManager>.Instance.IgnitedTileCoords.Count <= 0)
		{
			return;
		}
		if (elapsedTerrainCheckTime < 1f)
		{
			elapsedTerrainCheckTime += Time.deltaTime;
			return;
		}
		foreach (HazmatGridTile item in trainCar.TileInteraction.RequestPositionTiles())
		{
			if (item.IsIgnited)
			{
				isIgnited = true;
				break;
			}
		}
	}

	private void IgniteTerrainTile(float ignitionStrength)
	{
		if (!SingletonBehaviour<HazmatTileManager>.Instance || !SingletonBehaviour<HazmatTileManager>.Instance.enabled)
		{
			return;
		}
		if (elapsedTileIgnitionTime < 1f)
		{
			elapsedTileIgnitionTime += Time.deltaTime;
			return;
		}
		elapsedTileIgnitionTime = 0f;
		foreach (HazmatGridTile item in trainCar.TileInteraction.RequestPositionTiles())
		{
			if (!item.IsIgnited)
			{
				SingletonBehaviour<HazmatTileManager>.Instance.IgniteTile(item, ignitionStrength);
			}
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
