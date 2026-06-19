using Unity.Entities;

public struct ChanceToApplyConditionToSelfWhenDamagedBufferElement : IBufferElementData
{
	public BlobAssetReference<BlobCurve> chanceForEachPercentDamageTakenByCurrentHealthPercentage;

	public ConditionData conditionData;
}
