using Pug.Conversion;
using Unity.Collections;
using Unity.Entities;

public class SpawnGroupTableConverter : SingleAuthoringComponentConverter<SpawnGroupTable>
{
	protected override void Convert(SpawnGroupTable authoring)
	{
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		ref SpawnGroupsTable reference = ref blobBuilder.ConstructRoot<SpawnGroupsTable>();
		int length = 30;
		BlobBuilderArray<FactionSpawnGroup> blobBuilderArray = blobBuilder.Allocate(ref reference.factionSpawnGroups, length);
		foreach (SpawnGroupTable.FactionSpawnGroups factionSpawnGroup in authoring.factionSpawnGroups)
		{
			int faction = (int)factionSpawnGroup.faction;
			BlobBuilderArray<SpawnGroup> blobBuilderArray2 = blobBuilder.Allocate(ref blobBuilderArray[faction].spawnGroups, factionSpawnGroup.spawnGroups.Count);
			int num = 0;
			for (int i = 0; i < blobBuilderArray2.Length; i++)
			{
				blobBuilderArray2[i].killRequirement = factionSpawnGroup.spawnGroups[i].killRequirement;
				blobBuilderArray2[i].weight = num + factionSpawnGroup.spawnGroups[i].weight;
				num += factionSpawnGroup.spawnGroups[i].weight;
				BlobBuilderArray<SpawnObject> blobBuilderArray3 = blobBuilder.Allocate(ref blobBuilderArray2[i].spawnObjects, factionSpawnGroup.spawnGroups[i].objects.Count);
				for (int j = 0; j < blobBuilderArray3.Length; j++)
				{
					SpawnGroupTable.SpawnObject spawnObject = factionSpawnGroup.spawnGroups[i].objects[j];
					blobBuilderArray3[j] = new SpawnObject
					{
						objectData = spawnObject.objectData,
						amountToSpawn = spawnObject.amountToSpawn
					};
				}
			}
		}
		BlobAssetReference<SpawnGroupsTable> blobAsset = blobBuilder.CreateBlobAssetReference<SpawnGroupsTable>(Allocator.Persistent);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		AddComponentData(new SpawnGroupsTableCD
		{
			Value = blobAsset
		});
	}
}
