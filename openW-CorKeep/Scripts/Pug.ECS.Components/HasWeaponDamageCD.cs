using Unity.Entities;

public struct HasWeaponDamageCD : IComponentData, IQueryTypeParameter
{
	public bool isRange;

	public bool isMagic;
}
