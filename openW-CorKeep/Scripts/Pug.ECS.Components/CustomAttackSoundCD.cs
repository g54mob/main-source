using Unity.Entities;

public struct CustomAttackSoundCD : IComponentData, IQueryTypeParameter
{
	public int attackSoundId;

	public int impactSoundId;

	public int windupSoundId;

	public int windupCancelSoundId;

	public int strongAttackSoundId;
}
