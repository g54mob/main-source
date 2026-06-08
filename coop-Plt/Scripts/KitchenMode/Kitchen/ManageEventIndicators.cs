using Unity.Entities;

namespace Kitchen
{
	public class ManageEventIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.EventIndicator;

		protected override ViewMode ViewMode => ViewMode.World;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CEventIndicatorRequest));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (!Has<CEventIndicatorRequest>(candidate))
			{
				return false;
			}
			if (!Has<CPosition>(candidate))
			{
				return false;
			}
			return true;
		}

		protected override Entity CreateIndicator(Entity source)
		{
			if (!Require<CEventIndicatorRequest>(source, out CEventIndicatorRequest comp))
			{
				return default(Entity);
			}
			if (!Require<CPosition>(source, out CPosition comp2))
			{
				return default(Entity);
			}
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CPosition(comp2));
			base.EntityManager.AddComponentData(entity, new CEventIndicator
			{
				Event = comp.Event
			});
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
