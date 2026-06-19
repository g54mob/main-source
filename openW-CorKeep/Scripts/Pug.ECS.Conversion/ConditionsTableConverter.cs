using Pug.Conversion;
using Unity.Collections;
using Unity.Entities;

public class ConditionsTableConverter : SingleAuthoringComponentConverter<ConditionsTableAuthoring>
{
	protected override void Convert(ConditionsTableAuthoring authoring)
	{
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		BlobBuilderArray<ConditionInfoBlob> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<ConditionsTableBlob>().infos, 357);
		foreach (ConditionsTable.ConditionCategory conditionCategory in authoring.conditionsTable.conditionCategories)
		{
			foreach (ConditionInfo condition in conditionCategory.conditions)
			{
				blobBuilderArray[(int)condition.Id] = new ConditionInfoBlob
				{
					effect = condition.effect,
					isAdditiveWithSelf = condition.isAdditiveWithSelf,
					isPermanent = condition.isPermanent,
					isNegative = condition.isNegative,
					isUnique = condition.isUnique,
					isInheritedByProjectiles = condition.isInheritedByProjectiles,
					overrideIfRemainingValueIsHigher = condition.overrideIfRemainingValueIsHigher
				};
			}
		}
		BlobAssetReference<ConditionsTableBlob> blobAsset = blobBuilder.CreateBlobAssetReference<ConditionsTableBlob>(Allocator.Persistent);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		AddComponentData(new ConditionsTableCD
		{
			Value = blobAsset
		});
	}
}
