using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(PickUpAndDropAppliance))]
	public class PickUpAppliance : PickUpAndDropAppliance
	{
		protected CPosition TargetPosition;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CPosition>(data.Interactor, out Position))
			{
				return false;
			}
			if (!Require<CPosition>(data.Target, out TargetPosition))
			{
				return false;
			}
			if (!Require<CItemHolder>(data.Interactor, out Holder))
			{
				return false;
			}
			if (Holder.HeldItem != default(Entity))
			{
				return false;
			}
			return Perform(ref data, should_act: false);
		}

		protected override void Perform(ref InteractionData data)
		{
			Perform(ref data, data.ShouldAct);
		}

		protected override bool Perform(ref InteractionData data, bool should_act)
		{
			CAttemptingInteraction interact = data.Attempt;
			bool flag = false;
			flag |= PerformPickUp(data.Context, data.Interactor, ref interact, in Position, data.ShouldAct && should_act, OccupancyLayer.Default);
			if (should_act)
			{
				MadeChanges |= flag;
			}
			return flag;
		}

		protected new bool PerformPickUp(EntityContext ctx, Entity player, ref CAttemptingInteraction interact, in CPosition pos, bool should_act, OccupancyLayer layer)
		{
			Entity target = interact.Target;
			if (!base.TileManager.CanReach(pos, TargetPosition))
			{
				return false;
			}
			if (!Require<CAppliance>(target, out CAppliance comp))
			{
				return false;
			}
			if (Has<CHeldAppliance>(target))
			{
				return false;
			}
			if (Has<CImmovable>(target))
			{
				return false;
			}
			if (should_act)
			{
				ctx.Add<CHeldAppliance>(target);
				ctx.Add<CHeldBy>(target);
				ctx.Add<CRemoveView>(target);
				ctx.Set(target, new CRequiresView
				{
					Type = ViewType.HeldAppliance
				});
				ctx.Set(target, new CHeldBy
				{
					Holder = player
				});
				ctx.Set(target, CPosition.Hidden);
				ctx.Set(player, new CItemHolder
				{
					HeldItem = target
				});
				base.TileManager.SetOccupant(interact.Location, default(Entity), comp.Layer);
			}
			interact.Result = ((!should_act) ? InteractionResult.Possible : InteractionResult.Performed);
			return true;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
