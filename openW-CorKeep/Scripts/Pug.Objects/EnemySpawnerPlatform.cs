using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class EnemySpawnerPlatform : Chest
{
	public enum PlatformState
	{
		Undefined = 0,
		Inactive = 1,
		Spawning = 2,
		HasActiveSpawnedEnemy = 3
	}

	public List<SpriteObject> SOs;

	private PlatformState platformState;

	public ParticleSystem spawnEffect;

	public ParticleSystem prespawnEffect;

	public override void OnOccupied()
	{
		base.OnOccupied();
		platformState = PlatformState.Undefined;
		PlatformState newPlatformState = GetPlatformState();
		UpdatePlatformVisuals(newPlatformState, playEffects: false);
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		PlatformState newPlatformState = GetPlatformState();
		UpdatePlatformVisuals(newPlatformState);
	}

	private PlatformState GetPlatformState()
	{
		if (!EntityUtility.HasComponentData<EnemySpawnerPlatformCD>(base.entity, base.world))
		{
			return PlatformState.Inactive;
		}
		EnemySpawnerPlatformCD componentData = EntityUtility.GetComponentData<EnemySpawnerPlatformCD>(base.entity, base.world);
		if (EntityUtility.EntityExists(componentData.spawnedEntity, base.world) && !EntityUtility.IsComponentEnabled<EntityDestroyedCD>(componentData.spawnedEntity, base.world))
		{
			return PlatformState.HasActiveSpawnedEnemy;
		}
		if (componentData.isSpawning)
		{
			return PlatformState.Spawning;
		}
		return PlatformState.Inactive;
	}

	private void UpdatePlatformVisuals(PlatformState newPlatformState, bool playEffects = true)
	{
		if (newPlatformState == platformState)
		{
			return;
		}
		Color emissiveColor = Color.black;
		switch (newPlatformState)
		{
		case PlatformState.Inactive:
			emissiveColor = Color.black;
			break;
		case PlatformState.Spawning:
			emissiveColor = Color.cyan;
			if (playEffects)
			{
				prespawnEffect.Play();
				AudioManager.Sfx(SfxTableID.spawnCreatureAnticipation, base.RenderPosition);
			}
			break;
		case PlatformState.HasActiveSpawnedEnemy:
			emissiveColor = Color.blue;
			if (playEffects)
			{
				spawnEffect.Play();
				AudioManager.Sfx(SfxTableID.spawnCreature, base.RenderPosition);
			}
			break;
		}
		foreach (SpriteObject sO in SOs)
		{
			sO.emissiveColor = emissiveColor;
		}
		platformState = newPlatformState;
	}
}
