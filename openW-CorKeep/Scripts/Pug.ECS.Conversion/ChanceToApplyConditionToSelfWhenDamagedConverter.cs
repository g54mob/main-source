using Pug.Conversion;
using Unity.Entities;

public class ChanceToApplyConditionToSelfWhenDamagedConverter : SingleAuthoringComponentConverter<ChanceToApplyConditionToSelfWhenDamagedAuthoring>
{
	protected override void Convert(ChanceToApplyConditionToSelfWhenDamagedAuthoring authoring)
	{
		EnsureHasBuffer<ChanceToApplyConditionToSelfWhenDamagedBufferElement>();
		for (int i = 0; i < authoring.conditionsByChance.Count; i++)
		{
			BlobAssetReference<BlobCurve> blobAsset = BlobCurve.Create(authoring.conditionsByChance[i].chanceForEachPercentDamageTakenByCurrentHealthPercentage);
			base.BlobAssetStore.TryAdd(ref blobAsset);
			AddToBuffer(new ChanceToApplyConditionToSelfWhenDamagedBufferElement
			{
				chanceForEachPercentDamageTakenByCurrentHealthPercentage = blobAsset,
				conditionData = authoring.conditionsByChance[i].conditionData
			});
		}
	}
}
