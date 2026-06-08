using KitchenData;
using Sirenix.Utilities;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ToggleFranchiseSelector : ItemInteractionSystem
	{
		private EntityQuery CardViewers;

		private EntityQuery SpeedrunDishes;

		private SFranchiseSelector Selector;

		private DynamicBuffer<CAvailableFranchises> Available;

		private NativeArray<Entity> ViewerEntities;

		private NativeArray<Entity> SpeedrunDishEntities;

		protected override bool AllowActOrGrab => true;

		protected override void Initialise()
		{
			base.Initialise();
			CardViewers = GetEntityQuery(typeof(CFranchiseCardViewer));
			SpeedrunDishes = GetEntityQuery(typeof(CSpeedrun));
		}

		protected override bool BeforeRun()
		{
			base.BeforeRun();
			ViewerEntities = CardViewers.ToEntityArray(Allocator.TempJob);
			SpeedrunDishEntities = SpeedrunDishes.ToEntityArray(Allocator.TempJob);
			return true;
		}

		protected override void AfterRun()
		{
			base.AfterRun();
			ViewerEntities.Dispose();
			SpeedrunDishEntities.Dispose();
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<SFranchiseSelector>(data.Target, out Selector))
			{
				return false;
			}
			if (!RequireBuffer(data.Target, out Available))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			foreach (Entity speedrunDishEntity in SpeedrunDishEntities)
			{
				HolderHelpers.GoHome(base.EntityManager, speedrunDishEntity);
			}
			int num = ((data.Attempt.Type == InteractionType.Grab) ? 1 : (-1));
			Selector.SelectedIndex = (Selector.SelectedIndex + num + Available.Length) % Available.Length;
			Selector.SelectedFranchise = Available[Selector.SelectedIndex].Franchise;
			if (Selector.SelectedFranchise == default(Entity))
			{
				Selector.RequiresAdditionalBase = true;
			}
			else
			{
				CFranchiseItem component = GetComponent<CFranchiseItem>(Selector.SelectedFranchise);
				int num2 = 1;
				foreach (int card in component.Cards)
				{
					if (base.Data.TryGet<Dish>(card, out var output) && output.Type == DishType.Base)
					{
						num2--;
					}
					if (!base.Data.TryGet<UnlockCard>(card, out var output2) || output2.Effects.IsNullOrEmpty())
					{
						continue;
					}
					foreach (UnlockEffect effect in output2.Effects)
					{
						if (effect is FranchiseEffect franchiseEffect)
						{
							num2 += franchiseEffect.IncreasedBaseDishCount;
						}
					}
				}
				Selector.RequiresAdditionalBase = num2 > 0;
			}
			SetComponent(data.Target, Selector);
			foreach (Entity viewerEntity in ViewerEntities)
			{
				data.Context.Set(viewerEntity, default(CFranchiseCardViewer));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
