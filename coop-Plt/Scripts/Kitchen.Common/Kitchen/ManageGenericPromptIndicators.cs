using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class ManageGenericPromptIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.GenericIndicator;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CRequiresGenericInputIndicator));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (Has<CHideView>(candidate))
			{
				return false;
			}
			if (Has<CRemoveGenericInputIndicator>(candidate))
			{
				return false;
			}
			if (!Require<CBeingLookedAt>(candidate, out CBeingLookedAt comp))
			{
				return false;
			}
			if (!Require<CPlayer>(comp.Interactor, out CPlayer _))
			{
				return false;
			}
			if (Has<CUserGeneratedContentInput>(candidate) && !GameData.Main.IsUserGeneratedContentAllowed)
			{
				return false;
			}
			return true;
		}

		protected override void DestroyIndicator(Entity indicator, Entity source)
		{
			base.DestroyIndicator(indicator, source);
			if (Has<CRemoveGenericInputIndicator>(source))
			{
				base.EntityManager.RemoveComponent<CRequiresGenericInputIndicator>(source);
				base.EntityManager.RemoveComponent<CRemoveGenericInputIndicator>(source);
			}
		}

		protected override Entity CreateIndicator(Entity source)
		{
			if (!Require<CPosition>(source, out CPosition comp))
			{
				return default(Entity);
			}
			Require<CGenericInputIndicatorOffset>(source, out CGenericInputIndicatorOffset comp2);
			if (!Require<CBeingLookedAt>(source, out CBeingLookedAt comp3))
			{
				return default(Entity);
			}
			if (!Require<CPlayer>(comp3.Interactor, out CPlayer comp4))
			{
				return default(Entity);
			}
			if (!Require<CRequiresGenericInputIndicator>(source, out CRequiresGenericInputIndicator comp5))
			{
				return default(Entity);
			}
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CPosition(comp + comp2.Offset));
			base.EntityManager.AddComponentData(entity, new CGenericInputIndicator
			{
				CreateForPlayer = comp4.ID,
				Message = comp5.Message
			});
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
