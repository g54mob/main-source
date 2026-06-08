using Unity.Entities;

namespace Kitchen
{
	public class ManageDecorationIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.DecorationIndicator;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CGivesDecoration), typeof(CPosition));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (Has<CHeldBy>(candidate))
			{
				return false;
			}
			return true;
		}

		protected override Entity CreateIndicator(Entity source)
		{
			if (!Require<CGivesDecoration>(source, out CGivesDecoration comp))
			{
				return default(Entity);
			}
			if (!Require<CPosition>(source, out CPosition comp2))
			{
				return default(Entity);
			}
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CDecorationIndicator
			{
				DecorationValues = comp.DecorationValues
			});
			base.EntityManager.AddComponentData(entity, new CPosition(comp2));
			return entity;
		}

		protected override void UpdateIndicator(Entity indicator, Entity source)
		{
			base.UpdateIndicator(indicator, source);
			if (Require<CGivesDecoration>(source, out CGivesDecoration comp))
			{
				base.EntityManager.SetComponentData(indicator, new CDecorationIndicator
				{
					DecorationValues = comp.DecorationValues
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
