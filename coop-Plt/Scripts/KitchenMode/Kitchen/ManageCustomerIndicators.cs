using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class ManageCustomerIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.CustomerIndicator;

		protected override ViewMode ViewMode => ViewMode.World;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CCustomerGroup));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (!Has<CAtTable>(candidate) && !Has<CAssignedStand>(candidate))
			{
				return false;
			}
			if (!Has<CPosition>(candidate))
			{
				return false;
			}
			if (!Has<CPatience>(candidate))
			{
				return false;
			}
			if (Has<CGroupLeaving>(candidate))
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
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CPosition(comp));
			base.EntityManager.AddComponent<CCustomerIndicator>(entity);
			return entity;
		}

		protected override void UpdateIndicator(Entity indicator, Entity source)
		{
			if (Require<CPatience>(source, out CPatience comp) && Require<CPosition>(source, out CPosition comp2))
			{
				base.UpdateIndicator(indicator, source);
				base.EntityManager.SetComponentData(indicator, new CCustomerIndicator
				{
					HasPatience = comp.Active,
					Patience = comp.RemainingTime,
					PatienceReason = comp.Reason,
					PatienceFactors = comp.Factors
				});
				CPosition componentData = new CPosition(comp2.Position);
				componentData.Position += new Vector3(0f, 0.1f, 0f);
				base.EntityManager.SetComponentData(indicator, componentData);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
