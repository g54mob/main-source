using Unity.Entities;

public struct MoveFreelyWeaponCD : IComponentData, IQueryTypeParameter
{
	public float moveSpeedMultiplier;
}
