using Unity.Entities;
using Unity.NetCode;

public struct SequenceExplosiveCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool hasSpawnedCharges;

	[GhostField]
	public TickTimer internalTimer;

	public BlobAssetReference<SequenceExplosiveBlobData> sequenceExplosiveData;

	public BlobAssetReference<BlobArray<SequenceChargeBlobData>> sequenceChargesData;
}
