using Unity.Entities;

namespace Kitchen
{
	public class ManageLayoutIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.LayoutInfo;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CItemLayoutMap), typeof(CSetting));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (!Require<CHeldBy>(candidate, out CHeldBy comp))
			{
				return false;
			}
			if (!Has<CSetting>(candidate))
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
			if (!Require<CItemLayoutMap>(source, out CItemLayoutMap comp))
			{
				return default(Entity);
			}
			if (!Require<CSetting>(source, out CSetting comp2))
			{
				return default(Entity);
			}
			if (!Require<CHeldBy>(source, out CHeldBy comp3))
			{
				return default(Entity);
			}
			if (!Require<CPosition>((Entity)comp3, out CPosition comp4))
			{
				return default(Entity);
			}
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CLayoutInfo
			{
				Layout = comp.Layout,
				Setting = comp2.RestaurantSetting,
				Seed = comp2.FixedSeed
			});
			if (Has<CShowSeed>(source))
			{
				base.EntityManager.AddComponent<CShowSeed>(entity);
			}
			base.EntityManager.AddComponentData(entity, new CPosition(comp4));
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
