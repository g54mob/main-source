using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class HandleDumbWaiters : ItemInteractionSystem
	{
		private EntityQuery DumbWaiters;

		private NativeArray<Entity> WaiterEntities;

		protected override void Initialise()
		{
			base.Initialise();
			DumbWaiters = GetEntityQuery(typeof(CApplianceDumbWaiter), typeof(CItemHolder));
			RequireForUpdate(DumbWaiters);
		}

		protected override bool BeforeRun()
		{
			base.BeforeRun();
			WaiterEntities = DumbWaiters.ToEntityArray(Allocator.TempJob);
			return true;
		}

		protected override void AfterRun()
		{
			base.AfterRun();
			WaiterEntities.Dispose();
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Has<CApplianceDumbWaiter>(data.Target))
			{
				return false;
			}
			if (!Has<CItemHolder>(data.Target))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			if (HasComponent<CIsInactive>(data.Target))
			{
				data.Context.Remove<CIsInactive>(data.Target);
				int length = WaiterEntities.Length;
				for (int i = 0; i < length; i++)
				{
					Entity entity = WaiterEntities[i];
					if (!HasComponent<CIsInactive>(entity) && entity != data.Target)
					{
						data.Context.Add<CIsInactive>(entity);
					}
					Entity heldItem = GetComponent<CItemHolder>(entity).HeldItem;
					if (heldItem != default(Entity))
					{
						data.Context.UpdateHolder(heldItem, data.Target);
					}
				}
			}
			else
			{
				data.Context.Add<CIsInactive>(data.Target);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
