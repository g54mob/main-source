using Unity.Entities;

public struct FireSpreaderCD : IComponentData, IQueryTypeParameter
{
	public TickTimer spreadTimer;
}
