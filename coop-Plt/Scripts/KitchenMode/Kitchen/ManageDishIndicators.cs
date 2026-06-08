using Unity.Entities;

namespace Kitchen
{
	public class ManageDishIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.DishInfo;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CDishChoice));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (!Require<CHeldBy>(candidate, out CHeldBy comp))
			{
				return false;
			}
			if (!Has<CDishChoice>(candidate))
			{
				return false;
			}
			if (!Has<CBeingLookedAt>(comp))
			{
				return false;
			}
			if (!Has<CPosition>(comp))
			{
				return false;
			}
			if (Has<CStoredBy>(comp))
			{
				return false;
			}
			return true;
		}

		protected override Entity CreateIndicator(Entity source)
		{
			if (!Require<CDishChoice>(source, out CDishChoice comp))
			{
				return default(Entity);
			}
			if (!Require<CHeldBy>(source, out CHeldBy comp2))
			{
				return default(Entity);
			}
			if (!Require<CPosition>((Entity)comp2, out CPosition comp3))
			{
				return default(Entity);
			}
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CDishInfo
			{
				Dish = comp.Dish
			});
			base.EntityManager.AddComponentData(entity, new CPosition(comp3));
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
