using System.Collections.Generic;
using Pug.Conversion;
using Unity.Collections;
using Unity.Entities;

namespace PugWorldGen
{
	public class DungeonReplaceObjectsConverter : SingleAuthoringComponentConverter<DungeonReplaceObjectsAuthoring>
	{
		protected override void Convert(DungeonReplaceObjectsAuthoring authoring)
		{
			EnsureHasBuffer<DungeonReplaceObjectsBuffer>();
			List<ValueWithWeight<int>> list = new List<ValueWithWeight<int>>();
			foreach (Replacement replacement in authoring.replacements)
			{
				list.Clear();
				if (replacement.advancedVariationControl)
				{
					list.AddRange(replacement.weightedVariations.value);
				}
				else
				{
					for (int i = replacement.variation.min; i <= replacement.variation.max; i++)
					{
						list.Add(new ValueWithWeight<int>(i, 1f));
					}
				}
				DungeonReplaceObjectsBuffer elementData = new DungeonReplaceObjectsBuffer
				{
					replaceID = replacement.replaceID,
					replaceVariation = replacement.replaceVariation,
					replaceWithID = replacement.replaceWithID,
					replaceWithVariations = CreateVariationBlob(list),
					accumulatedVariationProbability = CreateNormalizedWeightsBlob(list)
				};
				AddToBuffer(elementData);
			}
		}

		private BlobAssetReference<BlobArray<int>> CreateVariationBlob(List<ValueWithWeight<int>> variations)
		{
			using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp, 1024);
			BlobBuilderArray<int> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<BlobArray<int>>(), variations.Count);
			for (int i = 0; i < variations.Count; i++)
			{
				blobBuilderArray[i] = variations[i].value;
			}
			BlobAssetReference<BlobArray<int>> blobAsset = blobBuilder.CreateBlobAssetReference<BlobArray<int>>(Allocator.Persistent);
			base.BlobAssetStore.TryAdd(ref blobAsset);
			return blobAsset;
		}

		private BlobAssetReference<BlobArray<float>> CreateNormalizedWeightsBlob(List<ValueWithWeight<int>> variations)
		{
			float num = 0f;
			foreach (ValueWithWeight<int> variation in variations)
			{
				num += variation.weight;
			}
			using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp, 1024);
			BlobBuilderArray<float> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<BlobArray<float>>(), variations.Count);
			float num2 = 0f;
			for (int i = 0; i < variations.Count; i++)
			{
				num2 += variations[i].weight / num;
				blobBuilderArray[i] = num2;
			}
			BlobAssetReference<BlobArray<float>> blobAsset = blobBuilder.CreateBlobAssetReference<BlobArray<float>>(Allocator.Persistent);
			base.BlobAssetStore.TryAdd(ref blobAsset);
			return blobAsset;
		}
	}
}
