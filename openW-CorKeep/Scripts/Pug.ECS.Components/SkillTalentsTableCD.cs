using Unity.Entities;

public struct SkillTalentsTableCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<SkillTalentsTableBlob> Value;

	public readonly ref SkillTalentTreeBlob GetSkillTalentTree(SkillID skillID)
	{
		return ref Value.Value.skillTalentTrees[(int)skillID];
	}
}
