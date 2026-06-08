using Unity.Entities;

namespace Kitchen
{
	public class ManageApplianceIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.ApplianceInfo;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CShowApplianceInfo));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (Has<CHeldAppliance>(candidate))
			{
				return false;
			}
			Entity e = candidate;
			if (Require<CHeldBy>(candidate, out CHeldBy comp))
			{
				e = comp.Holder;
			}
			if (!Require<CBeingLookedAt>(e, out CBeingLookedAt comp2))
			{
				return false;
			}
			if (Require<CItemHolder>(comp2.Interactor, out CItemHolder comp3) && comp3.HeldItem != default(Entity))
			{
				return false;
			}
			if (!Has<CPosition>(e))
			{
				return false;
			}
			return true;
		}

		protected override void UpdateIndicator(Entity indicator, Entity source)
		{
			if (Require<CApplianceInfo>(indicator, out CApplianceInfo comp) && Require<CShowApplianceInfo>(source, out CShowApplianceInfo comp2) && comp.ID != comp2.Appliance)
			{
				comp.ID = comp2.Appliance;
				Set(indicator, comp);
			}
		}

		protected override Entity CreateIndicator(Entity source)
		{
			Entity e = source;
			if (Require<CHeldBy>(source, out CHeldBy comp))
			{
				e = comp.Holder;
			}
			if (!Require<CPosition>(e, out CPosition comp2))
			{
				return default(Entity);
			}
			if (!Require<CShowApplianceInfo>(source, out CShowApplianceInfo comp3))
			{
				return default(Entity);
			}
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CPosition(comp2));
			base.EntityManager.AddComponentData(entity, new CApplianceInfo
			{
				ID = comp3.Appliance,
				Mode = ((!comp3.ShowPrice) ? CApplianceInfo.ApplianceInfoMode.Garage : CApplianceInfo.ApplianceInfoMode.Shop),
				Price = comp3.Price
			});
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
