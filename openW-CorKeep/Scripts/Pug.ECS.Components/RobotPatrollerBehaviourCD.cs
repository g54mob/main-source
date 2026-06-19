using Unity.Entities;

public struct RobotPatrollerBehaviourCD : IComponentData, IQueryTypeParameter
{
	public bool wasInShootMortarState;

	public int mortarStateCounter;

	public int oilMortarDamage;

	public int oilMortarTileDamage;

	public int fireMortarDamage;

	public int fireMortarTileDamage;
}
