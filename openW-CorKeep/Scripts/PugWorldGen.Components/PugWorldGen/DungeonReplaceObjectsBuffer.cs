using Pug.UnityExtensions;
using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonReplaceObjectsBuffer : IBufferElementData
	{
		public ObjectID replaceID;

		public OptionalValue<int> replaceVariation;

		public ObjectID replaceWithID;

		public BlobAssetReference<BlobArray<int>> replaceWithVariations;

		public BlobAssetReference<BlobArray<float>> accumulatedVariationProbability;
	}
}
