using Unity.Entities;
using Unity.Physics;

public struct ClosestHitCollectorWithComponent<T, D> : ICollector<T> where T : struct, IQueryResult where D : unmanaged, IComponentData
{
	public enum ComponentMode
	{
		Required = 0,
		Forbidden = 1
	}

	public ComponentLookup<D> ComponentLookup;

	public ComponentMode Mode;

	private T m_ClosestHit;

	public bool EarlyOutOnFirstHit => false;

	public float MaxFraction { get; private set; }

	public int NumHits { get; private set; }

	public T ClosestHit => m_ClosestHit;

	public ClosestHitCollectorWithComponent(float maxFraction, ComponentLookup<D> componentLookup, ComponentMode componentMode)
	{
		MaxFraction = maxFraction;
		m_ClosestHit = default(T);
		NumHits = 0;
		ComponentLookup = componentLookup;
		Mode = componentMode;
	}

	public bool AddHit(T hit)
	{
		bool num = ComponentLookup.HasComponent(hit.Entity);
		bool flag = Mode == ComponentMode.Required;
		if (num != flag)
		{
			return false;
		}
		MaxFraction = hit.Fraction;
		m_ClosestHit = hit;
		NumHits = 1;
		return true;
	}
}
