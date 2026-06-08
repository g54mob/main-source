using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class ManageQueueIndicator : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.QueueIndicator;

		protected override ViewMode ViewMode => ViewMode.World;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(SQueueMarker));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (Require<CHasIndicator>(candidate, out CHasIndicator comp) && Require<CRequiresView>(comp.Indicator, out CRequiresView comp2) && comp2.ViewMode != ViewMode)
			{
				return false;
			}
			return true;
		}

		protected override Entity CreateIndicator(Entity source)
		{
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CPosition(GetFrontDoor() + new Vector3(0f, 0.5f, 0f)));
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
