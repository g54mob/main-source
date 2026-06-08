using System.Collections.Generic;
using Unity.Entities;

namespace Kitchen
{
	public class PerformDirectProviderInsertion : ItemInteractionSystem
	{
		private CItemProvider Provider;

		private Entity TargetItem;

		private Entity FutureHolder;

		private Entity NewEntity;

		private HashSet<Entity> ActedEntities = new HashSet<Entity>();

		protected override bool BeforeRun()
		{
			ActedEntities.Clear();
			return true;
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			if (ActedEntities.Contains(data.Attempt.Target))
			{
				return false;
			}
			if (!Require<CItemProvider>(data.Target, out Provider))
			{
				return false;
			}
			if (!Provider.DirectInsertionOnly)
			{
				return false;
			}
			if (Provider.Available == 0 && Provider.Maximum != 0)
			{
				return false;
			}
			if (Require<CItemHolder>(data.Target, out CItemHolder comp) && comp.HeldItem != default(Entity))
			{
				FutureHolder = data.Target;
				TargetItem = comp;
				if (TargetItem == default(Entity))
				{
					return false;
				}
				if (Has<CHeldAppliance>(TargetItem))
				{
					return false;
				}
				if (!Has<CItem>(TargetItem))
				{
					return false;
				}
				return data.Context.AttemptItemMerge(out NewEntity, TargetItem, Provider.ProvidedItem, Provider.ProvidedComponents, !data.ShouldAct);
			}
			return false;
		}

		protected override void Perform(ref InteractionData data)
		{
			ActedEntities.Add(data.Attempt.Target);
			data.Context.Destroy(TargetItem);
			data.Context.UpdateHolder(NewEntity, FutureHolder);
			if (Provider.Maximum > 0)
			{
				Provider.Available--;
				Set(data.Target, Provider);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
