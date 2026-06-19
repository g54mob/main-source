using System.Collections.Generic;
using Pug.Conversion;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class SkillTalentsTableConverter : SingleAuthoringComponentConverter<SkillTalentsTableAuthoring>
{
	protected override void Convert(SkillTalentsTableAuthoring authoring)
	{
		if (Application.isPlaying)
		{
			SkillTalentsTable skillTalentsTable = Manager.mod.SkillTalentsTable;
			BlobAssetReference<SkillTalentsTableBlob> blobAsset = CreateBlob(skillTalentsTable);
			base.BlobAssetStore.TryAdd(ref blobAsset);
			AddComponentData(new SkillTalentsTableCD
			{
				Value = blobAsset
			});
		}
	}

	private BlobAssetReference<SkillTalentsTableBlob> CreateBlob(SkillTalentsTable skillTalentsTable)
	{
		Dictionary<SkillID, SkillTalentsTable.SkillTalentTree> dictionary = new Dictionary<SkillID, SkillTalentsTable.SkillTalentTree>();
		foreach (SkillTalentsTable.SkillTalentTree skillTalentTree in skillTalentsTable.skillTalentTrees)
		{
			dictionary.Add(skillTalentTree.skillID, skillTalentTree);
		}
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		BlobBuilderArray<SkillTalentTreeBlob> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<SkillTalentsTableBlob>().skillTalentTrees, 12);
		for (int i = 0; i < 12; i++)
		{
			SkillID key = (SkillID)i;
			SkillTalentsTable.SkillTalentTree value;
			List<SkillTalentsTable.SkillTalentInfo> list = (dictionary.TryGetValue(key, out value) ? value.skillTalents : new List<SkillTalentsTable.SkillTalentInfo>());
			BlobBuilderArray<SkillTalentInfoBlob> blobBuilderArray2 = blobBuilder.Allocate(ref blobBuilderArray[i].skillTalents, list.Count);
			for (int j = 0; j < blobBuilderArray2.Length; j++)
			{
				blobBuilderArray2[j] = new SkillTalentInfoBlob
				{
					givesCondition = list[j].givesCondition,
					conditionValuePerPoint = list[j].conditionValuePerPoint
				};
			}
		}
		return blobBuilder.CreateBlobAssetReference<SkillTalentsTableBlob>(Allocator.Persistent);
	}
}
