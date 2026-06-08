using Unity.Entities;

namespace Kitchen
{
	public class ManageFranchiseCardSetIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.FranchiseCardSetInfo;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CFranchiseItem));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (!Require<CHeldBy>(candidate, out CHeldBy comp))
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
			if (!Require<CHeldBy>(source, out CHeldBy comp))
			{
				return default(Entity);
			}
			if (!Require<CPosition>((Entity)comp, out CPosition comp2))
			{
				return default(Entity);
			}
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CCardSetBubble
			{
				CardSet = source
			});
			base.EntityManager.AddComponentData(entity, new CPosition(comp2));
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
