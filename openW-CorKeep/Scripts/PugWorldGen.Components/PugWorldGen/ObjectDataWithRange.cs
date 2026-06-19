using Pug.UnityExtensions;
using Unity.Entities;

namespace PugWorldGen
{
	public struct ObjectDataWithRange
	{
		public ObjectID objectID;

		public RangeInt amount;

		public BlobArray<int> variations;

		public BlobArray<float> accumulatedVariationProbability;
	}
}
