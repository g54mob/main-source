using Unity.Entities;

public struct AddSkillValueCD : IComponentData, IQueryTypeParameter
{
	public Entity entity;

	public SkillID skillID;

	public int amount;
}
