using Unity.Entities;
using Unity.Mathematics;

public struct WeaponDamageCD : IComponentData, IQueryTypeParameter
{
	public int damage;

	public int GetDamage(bool isReinforced)
	{
		if (isReinforced)
		{
			return (int)math.round((float)damage * 1.15f);
		}
		return damage;
	}
}
