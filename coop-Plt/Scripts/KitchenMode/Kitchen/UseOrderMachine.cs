using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class UseOrderMachine : ItemInteractionSystem
	{
		private EntityQuery ReadyToOrder;

		private EntityQuery Reorderable;

		private NativeArray<Entity> OrderTargets;

		private NativeArray<Entity> ReOrderTargets;

		private int OrderOffset;

		private int ReOrderOffset;

		protected override void Initialise()
		{
			base.Initialise();
			ReadyToOrder = GetEntityQuery(typeof(CGroupReadyToOrder));
			Reorderable = GetEntityQuery(new QueryHelper().All(typeof(CGroupAwaitingOrder), typeof(CWaitingForItem)).None(typeof(CGroupHasChangedMind)));
		}

		protected override bool BeforeRun()
		{
			base.BeforeRun();
			OrderTargets = ReadyToOrder.ToEntityArray(Allocator.TempJob);
			ReOrderTargets = Reorderable.ToEntityArray(Allocator.TempJob);
			OrderOffset = 0;
			ReOrderOffset = 0;
			return true;
		}

		protected override void AfterRun()
		{
			base.AfterRun();
			OrderTargets.Dispose();
			ReOrderTargets.Dispose();
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Has<CApplianceOrderMachine>(data.Target))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			if (GetComponent<CApplianceOrderMachine>(data.Target).IsReorderMachine)
			{
				Entity nextReorderGroup = GetNextReorderGroup();
				if (nextReorderGroup != default(Entity))
				{
					data.Context.Add<CGroupForceChangedMind>(nextReorderGroup);
				}
			}
			else if (OrderTargets.Length > OrderOffset)
			{
				data.Context.Add<CGroupPromptedForOrder>(OrderTargets[OrderOffset++]);
			}
		}

		private Entity GetNextReorderGroup()
		{
			for (int i = ReOrderOffset; i < ReOrderTargets.Length; i++)
			{
				Entity entity = ReOrderTargets[i];
				DynamicBuffer<CWaitingForItem> buffer = GetBuffer<CWaitingForItem>(entity);
				bool flag = true;
				foreach (CWaitingForItem item in buffer)
				{
					if (item.Satisfied)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return entity;
				}
			}
			return default(Entity);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
