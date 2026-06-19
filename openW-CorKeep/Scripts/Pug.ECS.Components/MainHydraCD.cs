using Unity.Entities;

public struct MainHydraCD : IComponentData, IQueryTypeParameter
{
	public int currentMinHealth;

	public float healTimer;
}
