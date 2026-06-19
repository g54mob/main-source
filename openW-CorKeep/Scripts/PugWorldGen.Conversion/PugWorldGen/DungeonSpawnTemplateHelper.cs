using System;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace PugWorldGen
{
	public static class DungeonSpawnTemplateHelper
	{
		internal static BlobAssetReference<SpawnTemplateBlob> GetBlob(SpawnTemplate spawnTemplate, BlobAssetComputationContext<int, SpawnTemplateBlob> context, UnityEngine.Object owner)
		{
			Unity.Entities.Hash128 guid = spawnTemplate.guid;
			if (!guid.IsValid)
			{
				throw new InvalidOperationException("Spawn template " + spawnTemplate.name + " missing guid");
			}
			if (context.NeedToComputeBlobAsset(guid))
			{
				BlobBuilder builder = new BlobBuilder(Allocator.Temp);
				ref SpawnTemplateBlob reference = ref builder.ConstructRoot<SpawnTemplateBlob>();
				reference.shapeAmp = spawnTemplate.shapeAmplitude;
				reference.shapeFreq = spawnTemplate.shapeFrequency;
				BlobBuilderArray<SpawnEntryCD> blobBuilderArray = builder.Allocate(ref reference.entries, spawnTemplate.spawnEntries.Count);
				for (int i = 0; i < blobBuilderArray.Length; i++)
				{
					BuildSpawnEntryComponent(ref blobBuilderArray[i], spawnTemplate.spawnEntries[i], ref builder);
				}
				context.AddComputedBlobAsset(guid, builder.CreateBlobAssetReference<SpawnTemplateBlob>(Allocator.Persistent));
				builder.Dispose();
			}
			if (!context.GetBlobAsset(guid, out var blob))
			{
				throw new Exception("failed to register blob asset for spawn template " + spawnTemplate.name);
			}
			return blob;
		}

		private static void BuildSpawnEntryComponent(ref SpawnEntryCD entryComp, SpawnTemplate.SpawnEntry e, ref BlobBuilder builder)
		{
			foreach (ObjectID item5 in e.canSpawnOn)
			{
				ObjectID item = item5;
				if (item == ObjectID.None)
				{
					entryComp.canSpawnOn.Add(in item);
					break;
				}
			}
			foreach (ObjectID item6 in e.canSpawnOn)
			{
				ObjectID item2 = item6;
				if (item2 != ObjectID.None)
				{
					entryComp.canSpawnOn.Add(in item2);
				}
			}
			foreach (ObjectID item7 in e.canSpawnNextTo)
			{
				ObjectID item3 = item7;
				entryComp.canSpawnNextTo.Add(in item3);
			}
			foreach (ObjectID item8 in e.canNotSpawnOn)
			{
				ObjectID item4 = item8;
				entryComp.canNotSpawnOn.Add(in item4);
			}
			entryComp.objectToSpawn.objectID = e.objectID;
			entryComp.objectToSpawn.amount = e.objectAmount;
			if (e.advancedVariationControl)
			{
				float num = 0f;
				for (int i = 0; i < e.weightedVariations.Count; i++)
				{
					num += e.weightedVariations[i].weight;
				}
				BlobBuilderArray<int> blobBuilderArray = builder.Allocate(ref entryComp.objectToSpawn.variations, e.weightedVariations.Count);
				BlobBuilderArray<float> blobBuilderArray2 = builder.Allocate(ref entryComp.objectToSpawn.accumulatedVariationProbability, e.weightedVariations.Count);
				float num2 = 0f;
				for (int j = 0; j < e.weightedVariations.Count; j++)
				{
					blobBuilderArray[j] = e.weightedVariations[j].value;
					num2 += e.weightedVariations[j].weight / num;
					blobBuilderArray2[j] = num2;
				}
			}
			else
			{
				int num3 = e.variation.max - e.variation.min + 1;
				float num4 = 1f / (float)num3;
				BlobBuilderArray<int> blobBuilderArray3 = builder.Allocate(ref entryComp.objectToSpawn.variations, num3);
				BlobBuilderArray<float> blobBuilderArray4 = builder.Allocate(ref entryComp.objectToSpawn.accumulatedVariationProbability, num3);
				for (int k = 0; k < num3; k++)
				{
					int num5 = e.variation.min + k;
					blobBuilderArray3[k] = num5;
					blobBuilderArray4[k] = (float)(k + 1) * num4;
				}
			}
			entryComp.disabled = e.disable;
			entryComp.cannotSpawnOnAnyPreviousObject = e.cannotSpawnOnAnyPreviousObject;
			entryComp.chanceToAppearAtAll = e.chanceToAppearAtAll;
			entryComp.containLoot = e.containLoot;
			entryComp.algorithm = e.algorithm;
			entryComp.placementAlignment = e.placementAlignement;
			entryComp.shapeSize = e.shapeSize;
			entryComp.amount = e.amount;
			entryComp.randomChance = e.randomChance;
			entryComp.oblongness = e.oblongness;
			entryComp.rotateTowardsCenter = e.rotateTowardsCenter;
			if (!e.rotateTowardsCenter)
			{
				entryComp.tilt = new Pug.UnityExtensions.Range
				{
					min = math.radians(e.tilt.min),
					max = math.radians(e.tilt.max)
				};
			}
			if (e.randomPlacement)
			{
				entryComp.placement = e.placementRadius;
			}
		}
	}
}
