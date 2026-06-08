using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(CustomerSchedulingGroup))]
	[UpdateAfter(typeof(SplitCustomerGroups))]
	[UpdateAfter(typeof(CreateCustomerSchedule))]
	public class CustomerGroupsMaxSize : RestaurantSystem
	{
		private EntityQuery ScheduledCustomers;

		protected override void Initialise()
		{
			base.Initialise();
			ScheduledCustomers = GetEntityQuery(typeof(CScheduledCustomer));
		}

		protected override void OnUpdate()
		{
			if (!Has<SRequireSchedulingUpdate>() || !HasStatus(RestaurantStatus.HalloweenTrickMaxDiningGroups) || !Require<SLargestTableSize>(out var comp))
			{
				return;
			}
			using NativeArray<Entity> nativeArray = ScheduledCustomers.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (Require<CScheduledCustomer>(item, out CScheduledCustomer comp2) && comp2.GroupSize != comp.LargestTableSize)
				{
					comp2.GroupSize = comp.LargestTableSize;
					Set(item, comp2);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
