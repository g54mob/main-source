using System.Collections.Generic;
using Pug.Conversion;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class DropLootConverter : SingleAuthoringComponentConverter<DropLootAuthoring>
{
	protected override void Convert(DropLootAuthoring authoring)
	{
		if (authoring.hasCustomLoot)
		{
			EnsureHasBuffer<DropsLootBuffer>();
			foreach (LootDrop value in authoring.customLoot.Values)
			{
				AddToBuffer(new DropsLootBuffer
				{
					lootDropID = value.lootDropID,
					amount = value.amount,
					multiplayerAmountAdditionScaling = value.multiplayerAmountAdditionScaling,
					skipIfScanned = (value.skipDropIfScanned ? new OptionalValue<ObjectID>(value.scanObjectID) : default(OptionalValue<ObjectID>)),
					requiredContentBundle = (value.requiredContentBundle.TryGetValue(out var output) ? new OptionalValue<DataBlockAddress>(output.address) : default(OptionalValue<DataBlockAddress>))
				});
			}
			AddComponentData(new ChanceToDropLootCD
			{
				chance = authoring.customLoot.chance
			});
		}
		if (authoring.hasLootTable)
		{
			AddComponentData(new DropsLootFromLootTableCD
			{
				lootTableID = authoring.lootTableID
			});
		}
		if (authoring.hasSeasonalLoot)
		{
			Season season = Season.None;
			if (Application.isPlaying)
			{
				season = Manager.prefs.season;
			}
			List<SeasonalLootInfo> list = new List<SeasonalLootInfo>();
			foreach (SeasonAndLoot lootDrop in authoring.seasonalLootDrops.lootDrops)
			{
				if (lootDrop.season != season && lootDrop.season != Season.None)
				{
					continue;
				}
				foreach (SeasonalLootDrop lootDrop2 in lootDrop.lootDrops)
				{
					list.Add(new SeasonalLootInfo
					{
						lootDropID = lootDrop2.lootDropID,
						amount = lootDrop2.amount,
						chance = lootDrop2.chance,
						multiplayerAmountAdditionScaling = lootDrop2.multiplayerAmountAdditionScaling
					});
				}
			}
			if (list.Count > 0)
			{
				using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
				BlobBuilderArray<SeasonalLootInfo> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<BlobArray<SeasonalLootInfo>>(), list.Count);
				for (int i = 0; i < list.Count; i++)
				{
					blobBuilderArray[i] = list[i];
				}
				BlobAssetReference<BlobArray<SeasonalLootInfo>> blobAsset = blobBuilder.CreateBlobAssetReference<BlobArray<SeasonalLootInfo>>(Allocator.Persistent);
				base.BlobAssetStore.TryAdd(ref blobAsset);
				AddComponentData(new SeasonalLootCD
				{
					requirementToDropFulfilled = true,
					lootBlob = blobAsset
				});
			}
		}
		if (authoring.hasLootDropsOnUse)
		{
			EnsureHasBuffer<OnUseLootBuffer>();
			foreach (OnUseLootDrop lootDrop3 in authoring.onUseLootDrops.lootDrops)
			{
				AddToBuffer(new OnUseLootBuffer
				{
					lootDropID = lootDrop3.lootDropID,
					amount = lootDrop3.amount,
					chance = lootDrop3.chance
				});
			}
			AddComponentData(new SpawnsItemsOnUseCD
			{
				lootTable = authoring.onUseLootDrops.lootTableID,
				spawnEffects = authoring.onUseLootDrops.spawnEffects
			});
		}
		if (authoring.hasLootDropsOnTakingDamage)
		{
			if (!TryGetActiveComponent<HealthAuthoring>(authoring, out var component))
			{
				Debug.LogError($"DropsLootWhenDamagedAuthoring requires HealthAuthoring on {authoring}");
				return;
			}
			int maxHealth = component.ComputeMaxHealth(base.UseHardModeSettings, base.UseCasualModeSettings);
			AddComponentData(new DropsLootWhenDamagedCD
			{
				dropsLoot = authoring.lootDropsWhenDamaged.dropsLoot,
				damageToDealToDropLoot = authoring.CalculateDamageToDealToDropLoot(maxHealth),
				minHealthToDropLoot = authoring.CalculateMinHealthToDropLoot(maxHealth),
				instantiateEntity = authoring.lootDropsWhenDamaged.instantiateEntity,
				minSpawnOffset = authoring.lootDropsWhenDamaged.minSpawnOffset,
				maxSpawnOffset = authoring.lootDropsWhenDamaged.maxSpawnOffset,
				maxLimitToDropInNearbyArea = authoring.lootDropsWhenDamaged.maxLimitToDropInNearbyArea
			});
		}
	}
}
