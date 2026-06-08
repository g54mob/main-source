using Unity.Entities;

namespace Kitchen
{
	public class ManageSeededRunInfoIndicators : IndicatorManager
	{
		public struct CSeedInfoBubble : IComponentData
		{
			public Seed Seed;
		}

		protected override ViewType ViewType => ViewType.SeededRunBubbleIndicator;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CSeededRunInfo));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (!Has<CBeingLookedAt>(candidate) && !Has<CBeingActedOn>(candidate) && !Has<CBeingGrabbed>(candidate))
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
			if (!Require<CPosition>(source, out CPosition comp))
			{
				return default(Entity);
			}
			if (!Require<CSeededRunInfo>(source, out CSeededRunInfo comp2))
			{
				return default(Entity);
			}
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CSeedInfoBubble
			{
				Seed = comp2.FixedSeed
			});
			base.EntityManager.AddComponentData(entity, new CPosition(comp));
			return entity;
		}

		protected override void UpdateIndicator(Entity indicator, Entity source)
		{
			if (Require<CSeededRunInfo>(source, out CSeededRunInfo comp))
			{
				base.EntityManager.SetComponentData(indicator, new CSeedInfoBubble
				{
					Seed = comp.FixedSeed
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
