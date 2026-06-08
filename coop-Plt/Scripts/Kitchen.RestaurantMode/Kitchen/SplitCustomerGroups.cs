using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateCustomerSchedule))]
	[UpdateInGroup(typeof(CustomerSchedulingGroup))]
	public class SplitCustomerGroups : RestaurantSystem
	{
		private EntityQuery ScheduledCustomers;

		protected override void Initialise()
		{
			base.Initialise();
			ScheduledCustomers = GetEntityQuery(typeof(CScheduledCustomer));
		}

		protected override void OnUpdate()
		{
			if (!Has<SRequireSchedulingUpdate>() || !HasStatus(RestaurantStatus.HalloweenTrickSoloDining))
			{
				return;
			}
			using NativeArray<Entity> nativeArray = ScheduledCustomers.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (!Require<CScheduledCustomer>(item, out CScheduledCustomer comp) || comp.GroupSize == 1)
				{
					continue;
				}
				int groupSize = comp.GroupSize;
				comp.GroupSize = 1;
				for (int i = 0; i < groupSize; i++)
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(CScheduledCustomer));
					base.EntityManager.AddComponentData(entity, comp);
					if (Require<CCustomerType>(item, out CCustomerType comp2))
					{
						base.EntityManager.AddComponentData(entity, comp2);
					}
					if (Require<CExtraScheduledCustomer>(item, out CExtraScheduledCustomer comp3))
					{
						base.EntityManager.AddComponentData(entity, comp3);
					}
				}
				base.EntityManager.DestroyEntity(item);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
