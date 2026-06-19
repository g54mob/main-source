using System.Collections.Generic;
using Pug.Conversion;
using Unity.Collections;
using Unity.Entities;

public class UpgradeCostsTableConverter : SingleAuthoringComponentConverter<UpgradeCostsTableAuthoring>
{
	protected override void Convert(UpgradeCostsTableAuthoring authoring)
	{
		BlobAssetReference<UpgradeCostsTableBlob> blobAsset = CreateBlob(authoring.upgradeCostsTable);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		AddComponentData(new UpgradeCostsTableCD
		{
			Value = blobAsset
		});
	}

	private BlobAssetReference<UpgradeCostsTableBlob> CreateBlob(UpgradeCostsTable upgradeCostsTable)
	{
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		BlobBuilderArray<UpgradeCostPerLevelBlob> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<UpgradeCostsTableBlob>().upgradeCostsByLevel, upgradeCostsTable.upgradeCosts.Count);
		for (int i = 0; i < blobBuilderArray.Length; i++)
		{
			List<UpgradeCost> upgradeCost = upgradeCostsTable.upgradeCosts[i].upgradeCost;
			BlobBuilderArray<UpgradeCostBlob> blobBuilderArray2 = blobBuilder.Allocate(ref blobBuilderArray[i].upgradeCosts, upgradeCost.Count);
			for (int j = 0; j < blobBuilderArray2.Length; j++)
			{
				blobBuilderArray2[j] = new UpgradeCostBlob
				{
					item = upgradeCost[j].item,
					amount = upgradeCost[j].amount
				};
			}
		}
		return blobBuilder.CreateBlobAssetReference<UpgradeCostsTableBlob>(Allocator.Persistent);
	}
}
