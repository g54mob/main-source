using Unity.Entities;

namespace PugWorldGen
{
	public struct SpawnTemplateBlob
	{
		public float shapeAmp;

		public float shapeFreq;

		public BlobArray<SpawnEntryCD> entries;
	}
}
