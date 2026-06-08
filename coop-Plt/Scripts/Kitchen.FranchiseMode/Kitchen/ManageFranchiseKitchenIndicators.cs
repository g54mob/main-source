using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateBefore(typeof(RebuildKitchen))]
	public class ManageFranchiseKitchenIndicators : IndicatorManager
	{
		private EntityQuery RebuildRequests;

		protected override ViewType ViewType => ViewType.KitchenTutorialInfo;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CFranchiseKitchenTutorialPrompt));
		}

		protected override void Initialise()
		{
			base.Initialise();
			RebuildRequests = GetEntityQuery(typeof(RebuildKitchen.CRebuildKitchen));
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
			if (!RebuildRequests.IsEmpty)
			{
				return false;
			}
			return true;
		}

		protected override Entity CreateIndicator(Entity source)
		{
			int dish = AssetReference.DishSteak;
			if (TryGetSingleton<RebuildKitchen.SCurrentKitchen>(out var value))
			{
				dish = value.Dish;
			}
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CPosition(new Vector3(2f, 0f, 2f)));
			base.EntityManager.AddComponentData(entity, new CFranchiseKitchenIndicator
			{
				Dish = dish
			});
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
